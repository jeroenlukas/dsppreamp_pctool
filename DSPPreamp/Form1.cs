using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSPPreamp
{
    public partial class Form1 : Form
    {
        public enum stateMachine { Idle, Header, Command, Length, Payload, Done };

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
        }

        public static class PatchProperties
        {
            public const int PATCH_NAME = 1;
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
            public const int NAME = 1;
            public const int CHANNEL = 2;
            public const int ZINPUT = 3;
            public const int PREGAIN_LOWCUT = 40;

            public const int POSTGAIN_BYPASS = 19;
            public const int DSPDISTORTION_BYPASS = 20;
            public const int DSPDISTORTION_ALPHA = 21;
            public const int DSPDISTORTION_GAIN = 22;
            public const int DSPDISTORTION_ASYMMETRY = 23;
            public const int DSPDISTORTION_VOLUME = 24;
            public const int ANALOG_BYPASS = 30;

            public const int POSTGAIN_MID_Q = 50;
            public const int POSTGAIN_MID_FREQ = 51;
        }

        //public struct frame { byte command; byte length; byte[] payload; };

        frmLog formLog;
        frmModels formModels;
        frmPatches formPatches;
        stateMachine smComm = stateMachine.Idle;

        //public frame received_frame = new frame();
        byte frame_command = 0;
        byte frame_length = 0;
        byte[] frame_payload = new byte[128];
        byte receive_header_count = 0;
        byte receive_length_left = 0;
        

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

            serialPort.Write(data, 0, 5 + length);
        }

        public void setCurrentPatchValue(byte property, byte value)
        {
            byte[] data = new byte[3];
            data[0] = 255;
            data[1] = property;
            data[2] = value;
            sendCommand(Commands.SET_PATCH_VALUE, 3, data);
        }

        public void setCurrentModelValue(byte property, byte value)
        {
            byte[] data = new byte[3];
            data[0] = 255;
            data[1] = property;
            data[2] = value; // should be two bytes
            sendCommand(Commands.SET_MODEL_VALUE, 3, data);
        }

        public void setCurrentModelValueInt(byte property, int value)
        {
            byte[] data = new byte[4];
            data[0] = 255;
            data[1] = property;
            data[2] = Convert.ToByte((value >> 8) & 0xff); // should be two bytes
            data[3] = Convert.ToByte(value & 0xff);
            sendCommand(Commands.SET_MODEL_VALUE, 4, data);
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
        }

        public void storeCurrentModel()
        {
            byte[] data = new byte[1];
            data[0] = 255;
            sendCommand(Commands.STORE_CURRENT_MODEL, 1, data);
        }

        public void selectPatch(byte patch_no)
        {
            byte[] data = new byte[1];
            data[0] = patch_no;
            sendCommand(Commands.SELECT_PATCH, 1, data);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            formLog = new frmLog();
            formLog.MdiParent = this;
            formLog.Show();

            formModels = new frmModels();
            formModels.MdiParent = this;
            formModels.MyParent = this;
            formModels.Show();

            formPatches = new frmPatches();
            formPatches.MdiParent = this;
            formPatches.MyParent = this;
            formPatches.Show();

            
            
            
            formLog.logMessage("dspPreamp", Color.Black);

            serialPort.Open();

            if(serialPort.IsOpen)
            {
                formLog.logMessage("Opened COM port " + serialPort.PortName, Color.Black);
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
            if(frame_command == Commands.SET_PATCH_VALUE)
            {
                if(frame_payload[0] == PatchProperties.PATCH_NAME)
                {
                    string patchName = System.Text.Encoding.UTF8.GetString(frame_payload, 1, 9) + "\0";
                    
                    formPatches.setName(patchName);
                }
                else if(frame_payload[0] == PatchProperties.MODEL)
                {
                    formPatches.setModel(frame_payload[1]);
                }
                else
                {                    
                    formPatches.setKnob(frame_payload[0], frame_payload[1]);
                }
            }
            if(frame_command == Commands.SELECT_PATCH)
            {
                formPatches.selectPatch(frame_payload[0]);
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

        private void loadModelFromEEPROMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
