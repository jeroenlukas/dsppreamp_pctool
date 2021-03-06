﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

namespace DSPPreamp
{
    public partial class Form1 : Form
    {
        public enum stateMachine { Idle, Header, Command, Length, Payload, Done };

        static System.Threading.Timer timerHeartbeatReset;

        public bool online = false;
        //public System.Threading.Timer tmrHeartbeat

        public class ProgramPreferences
        {
            public ProgramPreferences()
            {
                ConnectOnStartup = false;
            }
            public bool ConnectOnStartup { get; set; }
            public string DefaultComPort { get; set; }
        }


        static class Commands
        {
            public const int GET_MODEL_VALUE = 1;
            public const int GET_PATCH_VALUE = 2;
            public const int SET_MODEL_VALUE = 3;
            public const int SET_PATCH_VALUE = 4;
            public const int GET_SYSTEM_VLAUE = 5;
            public const int STORE_CURRENT_MODEL = 6;
            public const int STORE_CURRENT_PATCH = 7;
            public const int MIDI_RECEIVED = 8;

            public const int LOG_MESSAGE = 9;
            public const int SELECT_PATCH = 10;
            public const int HEARTBEAT = 11;

            public const int INITIALIZE_PATCHES = 124;
            public const int INITIALIZE_MODELS = 125;
        }

        public static class PatchProperties
        {
            public const int NAME = 1;
            public const int MODEL = 2;
            public const int GAIN = 3;
            public const int LOW = 4;
            public const int MID = 5;
            public const int HIGH = 6;
            public const int PRES = 7;
            public const int VOLUME = 8;
            public const int NOISE_GATE = 9;
        }

        public static class ModelProperties
        {
            public const int NAME = 62;
            public const int CHANNEL = 2;
            public const int ZINPUT = 60;
            public const int PREGAIN_LOWCUT = 40;
            public const int PREGAIN_LOWCUT_ORDER = 41;

            public const int POSTGAIN_BYPASS = 19;
            public const int DSPDISTORTION_BYPASS = 20;
            public const int DSPDISTORTION_ALPHA = 21;
            public const int DSPDISTORTION_GAIN_MIN = 22;
            public const int DSPDISTORTION_GAIN_MAX = 25;
            public const int DSPDISTORTION_ASYMMETRY = 23;
            public const int DSPDISTORTION_VOLUME = 24;
            public const int BYPASS = 30;

            public const int POSTGAIN_LOW_GAIN_MIN = 52;
            public const int POSTGAIN_LOW_GAIN_MAX = 53;

            public const int POSTGAIN_MID_Q = 50;
            public const int POSTGAIN_MID_FREQ = 51;
            public const int POSTGAIN_MID_GAIN_MIN = 54;
            public const int POSTGAIN_MID_GAIN_MAX = 55;

            public const int POSTGAIN_HIGH_GAIN_MIN = 56;
            public const int POSTGAIN_HIGH_GAIN_MAX = 57;
            public const int POSTGAIN_PRES_FREQ_MIN = 58;
            public const int POSTGAIN_PRES_FREQ_MAX = 59;
            public const int POSTGAIN_PRES_ORDER = 63;
        }

        //public struct frame { byte command; byte length; byte[] payload; };

        frmLog formLog;
        frmModels formModels;
        frmPatches formPatches;
        frmPreferences formPreferences;
        stateMachine smComm = stateMachine.Idle;

        public ProgramPreferences prefrences = new ProgramPreferences();

        string appDir = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

        //public frame received_frame = new frame();
        byte frame_command = 0;
        byte frame_length = 0;
        byte[] frame_payload = new byte[128];
        byte receive_header_count = 0;
        byte receive_length_left = 0;


        public void LoadPreferences()
        {
            XmlReader xml = XmlReader.Create(appDir + "\\preferences.xml");           

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    switch (xml.Name)
                    {
                        case "connectonstartup":
                            prefrences.ConnectOnStartup = xml.ReadElementContentAsBoolean();
                            break;

                        case "defaultcomport":
                            prefrences.DefaultComPort = xml.ReadElementContentAsString();
                            break;
                        default:
                            break;
                    }
                }
            }

            xml.Close();
        }

        public void SavePreferences()
        {
            XmlWriterSettings xmlsettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = true
            };

            XmlWriter xml = XmlWriter.Create(appDir + "\\preferences.xml", xmlsettings);

            xml.WriteStartDocument();
            xml.WriteStartElement("preferences");

            xml.WriteStartElement("communication");
            xml.WriteStartElement("connectonstartup"); xml.WriteString(prefrences.ConnectOnStartup.ToString().ToLower()); xml.WriteEndElement();
            xml.WriteStartElement("defaultcomport"); xml.WriteString(prefrences.DefaultComPort); xml.WriteEndElement();

            xml.WriteEndElement();
            xml.WriteEndElement();
            xml.WriteEndDocument();

            xml.Close();

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void sendCommand(byte command, byte length, byte[] payload)
        {
            byte[] data = new byte[128];

            data[0] = 0xAA;
            data[1] = 0xAA;
            data[2] = 0xAA;
            data[3] = command;
            data[4] = length;
            for (int a = 0; a < length; a++)
            {
                data[5 + a] = payload[a];
            }

            if (!disableOutgoingCommandsToolStripMenuItem.Checked)
            {
                serialPort.Write(data, 0, 5 + length);
            }
        }

        public void setCurrentPatchValue(byte property, byte value)
        {
            byte[] data = new byte[3];
            data[0] = 255;
            data[1] = property;
            data[2] = value;
            sendCommand(Commands.SET_PATCH_VALUE, 3, data);
            if(logOutgoingCommandsToolStripMenuItem1.Checked)
                formLog.logMessage("Set patch property " + property.ToString() + " to " + value.ToString(), Color.Orange);
        }

        public void setCurrentModelValue(byte property, sbyte value)
        {
            byte[] data = new byte[3];
            data[0] = 255;
            data[1] = property;
            data[2] = (byte)value; // should be two bytes
            sendCommand(Commands.SET_MODEL_VALUE, 3, data);
            if (logOutgoingCommandsToolStripMenuItem1.Checked)
                formLog.logMessage("Set model property " + property.ToString() + " to " + value.ToString(), Color.Orange);
        }

        public void setCurrentModelValueInt(byte property, int value)
        {
            byte[] data = new byte[4];
            data[0] = 255;
            data[1] = property;
            data[2] = Convert.ToByte((value >> 8) & 0xff); // should be two bytes
            data[3] = Convert.ToByte(value & 0xff);
            sendCommand(Commands.SET_MODEL_VALUE, 4, data);
            if (logOutgoingCommandsToolStripMenuItem1.Checked)
                formLog.logMessage("Set model property " + property.ToString() + " to " + value.ToString(), Color.Orange);
        }

        public void setCurrentPatchValueString(byte property, string value)
        {
            byte[] data = new byte[24];
            data[0] = 255;
            data[1] = property;
            int i;
            for (i = 0; i < value.Length; i++)
                data[2 + i] = Convert.ToByte(value[i]);

            data[2+i] = 0;
            //data[2] = Convert.ToByte((value >> 8) & 0xff); // should be two bytes
            //data[3] = Convert.ToByte(value & 0xff);
            sendCommand(Commands.SET_PATCH_VALUE,  Convert.ToByte(value.Length + 2 + 1), data);
            if (logOutgoingCommandsToolStripMenuItem1.Checked)
                formLog.logMessage("Set patch property " + property.ToString() + " to " + value, Color.Orange);
        }

        public void setCurrentModelValueString(byte property, string value)
        {
            byte[] data = new byte[24];
            data[0] = 255;
            data[1] = property;
            int i;
            for (i = 0; i < value.Length; i++)
                data[2 + i] = Convert.ToByte(value[i]);

            data[2 + i] = 0;
            //data[2] = Convert.ToByte((value >> 8) & 0xff); // should be two bytes
            //data[3] = Convert.ToByte(value & 0xff);
            sendCommand(Commands.SET_MODEL_VALUE, Convert.ToByte(value.Length + 2 + 1), data);
            if (logOutgoingCommandsToolStripMenuItem1.Checked)
                formLog.logMessage("Set model property " + property.ToString() +  " to " + value, Color.Orange);
        }

        public void getModelValue(byte model_id, byte property)
        {
            byte[] data = new byte[4];
            data[0] = model_id;
            data[1] = property;            
            sendCommand(Commands.GET_MODEL_VALUE, 2, data);            
        }

        public void getPatchValue(byte patch_id, byte property)
        {
            byte[] data = new byte[4];
            data[0] = patch_id;
            data[1] = property;
            sendCommand(Commands.GET_PATCH_VALUE, 2, data);
        }

        public void storeCurrentModel()
        {
            byte[] data = new byte[1];
            data[0] = 255;
            sendCommand(Commands.STORE_CURRENT_MODEL, 1, data);
        }

        public void storeCurrentPatch()
        {
            byte[] data = new byte[1];
            data[0] = 255;
            sendCommand(Commands.STORE_CURRENT_PATCH, 1, data);
        }

        public void selectPatch(byte patch_no)
        {
            //formLog.logMessage("Changing to patch " + patch_no.ToString(), Color.Aqua);
            byte[] data = new byte[1];
            data[0] = patch_no;
            sendCommand(Commands.SELECT_PATCH, 1, data);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            

            formModels = new frmModels();
            formModels.MdiParent = this;
            formModels.MyParent = this;
            formModels.Show();

            formPatches = new frmPatches();
            formPatches.MdiParent = this;
            formPatches.MyParent = this;
            formPatches.Show();

            formLog = new frmLog();
            formLog.MdiParent = this;
            formLog.Show();


            timerHeartbeatReset = new System.Threading.Timer(
                new TimerCallback(tickHeartbeatReset),
                null,
                1000,
                2000);

            formLog.logMessage("AppDir: " + appDir, Color.Black);

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                ToolStripItem tsi = ddComPorts.DropDownItems.Add(port);
                tsi.Tag = port;
                
                tsi.Click += cOM1ToolStripMenuItem_Click;
            }

            LoadPreferences();

            if(prefrences.ConnectOnStartup)
            {
                if(ports.Contains(prefrences.DefaultComPort))
                {
                    serialPort.PortName = prefrences.DefaultComPort;
                    serialPort.Open();

                    if (serialPort.IsOpen)
                    {
                        formLog.logMessage("Opened COM port " + serialPort.PortName, Color.Black);
                    }
                }
            }               
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort.Close();
        }


        private void parseCommand()
        {
            if(frame_command == Commands.LOG_MESSAGE)
            {
                // Log message
                string result = System.Text.Encoding.UTF8.GetString(frame_payload) + "\0";

                formLog.logMessage("[dsppreamp] " + result + "\r\n", Color.Blue);
            }
            if(frame_command == Commands.MIDI_RECEIVED)
            {
                if(frame_payload[1] == 0x0B)
                {
                    formLog.logMessage("[midi] [channel " + frame_payload[0].ToString() + "] CC #" + frame_payload[2].ToString() + " -> " + frame_payload[3].ToString(), Color.Green);
                }
                else if(frame_payload[1] == 0x0C)
                {
                    formLog.logMessage("[midi] [channel " + frame_payload[0].ToString() + "] PC " + frame_payload[2].ToString(), Color.Green);
                }
            }
            if (frame_command == Commands.SET_PATCH_VALUE)
            {
                if (frame_payload[0] == 0xFF)
                {
                    if (frame_payload[1] == PatchProperties.NAME)
                    {
                        string patchName = System.Text.Encoding.UTF8.GetString(frame_payload, 2, 9) + "\0";

                        formPatches.setName(patchName);
                    }
                    else if (frame_payload[1] == PatchProperties.MODEL)
                    {
                        formPatches.setModel(frame_payload[2]);
                        formModels.setModelId(frame_payload[2]);
                    }
                    else
                    {
                        formPatches.setKnob(frame_payload[1], frame_payload[2]);
                    }
                }
                else
                {
                    switch (frame_payload[1])
                    {
                        case PatchProperties.NAME:
                            string patchName = System.Text.Encoding.UTF8.GetString(frame_payload, 2, 9) + "\0";                            
                            formPatches.setPatchNameInList(frame_payload[0], patchName);
                            break;
                    }
                }
            }
            if(frame_command == Commands.SELECT_PATCH)
            {
                formPatches.selectPatch(frame_payload[0]);
            }
            if(frame_command == Commands.HEARTBEAT)
            {
                // Reset timer
                timerHeartbeatReset.Change(2000, 2000);

                if (!online)
                {
                    online = true;
                    lblConnectionStatus.Text = "CONNECTED";
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblConnectionStatus.ForeColor = Color.Green;
                    });
                    formLog.logMessage("dspPreamp connected", Color.Green);
                    getModelNames();
                    getPatchNames();
                }
            }

            if (frame_command == Commands.SET_MODEL_VALUE)
            {
                if (frame_payload[0] == 0xFF)
                {
                    switch (frame_payload[1])
                    {
                        case ModelProperties.NAME:
                            string modelName = System.Text.Encoding.UTF8.GetString(frame_payload, 2, 9) + "\0";
                            formModels.setModelName(modelName);
                            break;
                        case ModelProperties.PREGAIN_LOWCUT:
                            formModels.setPreLowCut((frame_payload[2] << 8) + frame_payload[3]);
                            break;
                        case ModelProperties.PREGAIN_LOWCUT_ORDER:
                            formModels.setPreLowcutOrder((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.BYPASS:
                            formModels.setBypassCheckboxes((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.DSPDISTORTION_GAIN_MIN:
                            formModels.setDSPDistortionGainMin((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.DSPDISTORTION_GAIN_MAX:
                            formModels.setDSPDistortionGainMax((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.DSPDISTORTION_ALPHA:
                            formModels.setDSPDistortionAlpha((decimal)frame_payload[2] / 10);
                            break;
                        case ModelProperties.DSPDISTORTION_ASYMMETRY:
                            formModels.setDSPDistortionAsymmetry((decimal)frame_payload[2] / 100);
                            break;
                        case ModelProperties.DSPDISTORTION_VOLUME:
                            formModels.setDSPDistortionVolume((sbyte)frame_payload[2]);
                            break;

                        case ModelProperties.POSTGAIN_LOW_GAIN_MIN:
                            formModels.setPostLowGainMin((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.POSTGAIN_LOW_GAIN_MAX:
                            formModels.setPostLowGainMax((sbyte)frame_payload[2]);
                            break;

                        case ModelProperties.POSTGAIN_MID_FREQ:
                            formModels.setPostMidFreq((frame_payload[2] << 8) + frame_payload[3]);
                            break;

                        case ModelProperties.POSTGAIN_MID_Q:
                            formModels.setPostMidQ((decimal)frame_payload[2] / 10);
                            break;
                        case ModelProperties.POSTGAIN_MID_GAIN_MIN:
                            formModels.setPostMidGainMin((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.POSTGAIN_MID_GAIN_MAX:
                            formModels.setPostMidGainMax((sbyte)frame_payload[2]);
                            break;


                        case ModelProperties.POSTGAIN_HIGH_GAIN_MIN:
                            formModels.setPostHighGainMin((sbyte)frame_payload[2]);
                            break;
                        case ModelProperties.POSTGAIN_HIGH_GAIN_MAX:
                            formModels.setPostHighGainMax((sbyte)frame_payload[2]);
                            break;

                        case ModelProperties.POSTGAIN_PRES_FREQ_MIN:
                            formModels.setPostPresenceFreqMin((frame_payload[2] << 8) + frame_payload[3]);
                            break;
                        case ModelProperties.POSTGAIN_PRES_FREQ_MAX:
                            formModels.setPostPresenceFreqMax((frame_payload[2] << 8) + frame_payload[3]);
                            break;
                        case ModelProperties.POSTGAIN_PRES_ORDER:
                            formModels.setPostPresenceOrder((sbyte)frame_payload[2]);
                            break;


                    }

                }
                else
                {
                    switch (frame_payload[1])
                    {
                        case ModelProperties.NAME:
                            string modelName = System.Text.Encoding.UTF8.GetString(frame_payload, 2, 9) + "\0";
                            formModels.setModelNameInList(frame_payload[0], modelName);
                            formPatches.setModelNameInList(frame_payload[0], modelName);
                            break;
                    }
                }
            }

        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte data;
            while (serialPort.BytesToRead > 0)
            {
                data = (byte)serialPort.ReadByte();
                switch (smComm)
                {
                    case stateMachine.Idle:
                        if (data == 0xAA)
                        {
                            receive_header_count++;
                            smComm = stateMachine.Header;
                        }
                        break;

                    case stateMachine.Header:
                        receive_header_count++;
                        if(receive_header_count == 3)
                        {
                            smComm = stateMachine.Command;
                        }
                        break;
                    case stateMachine.Command:
                        frame_command = data;
                        smComm = stateMachine.Length;
                        break;
                    case stateMachine.Length:
                        frame_length = data;
                        smComm = stateMachine.Payload;
                        receive_length_left = frame_length;
                        break;
                    case stateMachine.Payload:
                        frame_payload[frame_length - receive_length_left] = data;

                        receive_length_left--;

                        if(receive_length_left == 0)
                        {
                            parseCommand();

                            receive_header_count = 0;
                            frame_payload[0] = 0;
                            
                            
                            smComm = stateMachine.Idle;
                        }
                        break;




                }
            }
            
        }



        private void patchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Are you sure?
            byte[] data = new byte[1];
            data[0] = 0xAF;

            if (MessageBox.Show("Are you sure?", "Confirm patch initialization", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sendCommand(Commands.INITIALIZE_PATCHES, 1, data);
            }
        }

        private void modelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Are you sure?
            byte[] data = new byte[1];
            data[0] = 0xBB;

            if (MessageBox.Show("Are you sure?", "Confirm model initialization", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sendCommand(Commands.INITIALIZE_MODELS, 1, data);
            }
        }

        public void getModelNames()
        {
            for (byte i = 0; i < 10; i++)
            {
                getModelValue(i, ModelProperties.NAME);
                Thread.Sleep(5);
            }                
        }

        public void getPatchNames()
        {
            for (byte i = 0; i < 100; i++)
            {
                getPatchValue(i, PatchProperties.NAME);
                Thread.Sleep(5);
            }

        }

        private void fetchModelNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getModelNames();
        }

     

        private void tickHeartbeatReset(object state)
        {            
            if(online)
            {
                online = false;
                lblConnectionStatus.Text = "OFFLINE";
                formLog.logMessage("dspPreamp offline", Color.Red);

                this.Invoke((MethodInvoker) delegate
                {
                    lblConnectionStatus.ForeColor = Color.Red;
                });
            }            
        }

        private void fetchPatchNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getPatchNames();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string port = (sender as ToolStripItem).Tag.ToString();

            formLog.logMessage("Connect to " + port, Color.Black);


            if(serialPort.IsOpen)
            {
                serialPort.Close();
            }

            serialPort.PortName = port;
            serialPort.Open();

            if (serialPort.IsOpen)
                (sender as ToolStripItem).Select();


        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPreferences = new frmPreferences();
            
            
            formPreferences.MyParent = this;
            formPreferences.Show();
        }

        private void ddComPorts_DropDownOpened(object sender, EventArgs e)
        {
            foreach(ToolStripMenuItem item in ddComPorts.DropDownItems)
            {
                if ((item.Tag.ToString() == serialPort.PortName) && (serialPort.IsOpen))
                {
                    item.Checked = true;
                }
                else item.Checked = false;
            }
        }
    }
}
