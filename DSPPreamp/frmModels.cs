using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DSPPreamp
{
    public partial class frmModels : Form
    {
        public Form1 MyParent { get; set; }

        public bool valueChangedExternally = false;

        public frmModels()
        {
            InitializeComponent();
        }

        private void cbPostgainBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
            {
                /*    if (cbPostgainBypass.Checked)
                    {
                        MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_BYPASS, 1);
                    }
                    else MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_BYPASS, 0);*/
                setCurrentModelBypass();
            }
        }

        private void cbDSPDistortionBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
            {
                //if (cbDSPDistortionBypass.Checked)
                //{
                    // MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_BYPASS, 1);
                    setCurrentModelBypass();
                //}
                //else //MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_BYPASS, 0);
            }
        }

        private void nudDSPDistortionAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ALPHA, Convert.ToSByte((nudDSPDistortionAlpha.Value * 10)));
        }

        private void nudDSPDistortionGain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudDSPDistortionVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)// && nudDSPDistortionVolume.Focused)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_VOLUME, Convert.ToSByte(nudDSPDistortionVolume.Value ));
        }

        private void cbAnalogBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
            {
                /*    if (cbAnalogBypass.Checked)
                    {
                        MyParent.setCurrentModelValue(Form1.ModelProperties.BYPASS, 1);
                    }
                    else MyParent.setCurrentModelValue(Form1.ModelProperties.BYPASS, 0);*/
                setCurrentModelBypass();
            }
        }

        private void nudPregainLowcut_ValueChanged(object sender, EventArgs e)
        {
            if(!valueChangedExternally)// && nudPregainLowcut.Focused)
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.PREGAIN_LOWCUT, Convert.ToInt16(nudPregainLowcut.Value));
        }

        private void nudDSPDistortionAsymmetry_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ASYMMETRY, Convert.ToSByte((nudDSPDistortionAsymmetry.Value * 100)));
        }

  

        private void nudPostgainMidQ_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_Q, Convert.ToSByte((nudPostgainMidQ.Value * 10)));
        }

        private void nudPostgainMidFreq_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_MID_FREQ, Convert.ToInt16(nudPostgainMidFreq.Value));
        }

        private void lbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tbModelNo.Text = (lbModels.SelectedIndex + 1).ToString().PadLeft(2, '0');
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            MyParent.storeCurrentModel();
        }

        /* Boring modifiers */

        public void setBypassCheckboxes(sbyte bypass)
        {
            valueChangedExternally = true;
            int data = bypass;
            if((data & 8 ) > 0) // pregain
            {
                if (this.cbPreGainBypass.InvokeRequired)
                {
                    this.cbPreGainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbPreGainBypass.Checked = true;
                        valueChangedExternally = false;
                    });
                }
                else cbPreGainBypass.Checked = true;
            }
            else
            {
                if (this.cbPreGainBypass.InvokeRequired)
                {
                    this.cbPreGainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbPreGainBypass.Checked = false;
                        valueChangedExternally = false;
                    });
                }
                else cbPreGainBypass.Checked = false;
            }

            if ((data & 4) > 0) // distortion
            {
                if (this.cbDSPDistortionBypass.InvokeRequired)
                {
                    this.cbDSPDistortionBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbDSPDistortionBypass.Checked = true;
                        valueChangedExternally = false;
                    });
                }
                else cbDSPDistortionBypass.Checked = true;
            }
            else
            {
                if (this.cbDSPDistortionBypass.InvokeRequired)
                {
                    this.cbDSPDistortionBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbDSPDistortionBypass.Checked = false;
                        valueChangedExternally = false;
                    });
                }
                else cbDSPDistortionBypass.Checked = false;
            }

            if ((data & 2) > 0) // analog
            {
                if (this.cbAnalogBypass.InvokeRequired)
                {
                    this.cbAnalogBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbAnalogBypass.Checked = true;
                        valueChangedExternally = false;
                    });
                }
                else cbAnalogBypass.Checked = true;
            }
            else
            {
                if (this.cbAnalogBypass.InvokeRequired)
                {
                    this.cbAnalogBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbAnalogBypass.Checked = false;
                        valueChangedExternally = false;
                    });
                }
                else cbAnalogBypass.Checked = false;
            }

            if ((data & 1) > 0) // postgain
            {
                if (this.cbPostgainBypass.InvokeRequired)
                {
                    this.cbPostgainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbPostgainBypass.Checked = true;
                        valueChangedExternally = false;
                    });
                }
                else cbPostgainBypass.Checked = true;
            }
            else
            {
                if (this.cbPostgainBypass.InvokeRequired)
                {
                    this.cbPostgainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        valueChangedExternally = true;
                        cbPostgainBypass.Checked = false;
                        valueChangedExternally = false;
                    });
                }
                else cbPostgainBypass.Checked = false;
            }



            valueChangedExternally = false;
        }

        public void setDSPDistortionGainMin(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudDSPDistortionGainMin.InvokeRequired)
            {
                this.nudDSPDistortionGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudDSPDistortionGainMin.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudDSPDistortionGainMin.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setDSPDistortionGainMax(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudDSPDistortionGainMax.InvokeRequired)
            {
                this.nudDSPDistortionGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudDSPDistortionGainMax.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudDSPDistortionGainMax.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setDSPDistortionAlpha(decimal alpha)
        {
            valueChangedExternally = true;
            if (this.nudDSPDistortionAlpha.InvokeRequired)
            {
                this.nudDSPDistortionAlpha.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudDSPDistortionAlpha.Value = alpha;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudDSPDistortionAlpha.Value = alpha;
            }
            valueChangedExternally = false;
        }

        public void setDSPDistortionAsymmetry(decimal asymm)
        {
            valueChangedExternally = true;
            if (this.nudDSPDistortionAsymmetry.InvokeRequired)
            {
                this.nudDSPDistortionAsymmetry.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudDSPDistortionAsymmetry.Value = asymm;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudDSPDistortionAsymmetry.Value = asymm;
            }
            valueChangedExternally = false;
        }

        public void setDSPDistortionVolume(sbyte vol)
        {
            valueChangedExternally = true;
            if (this.nudDSPDistortionVolume.InvokeRequired)
            {
                this.nudDSPDistortionVolume.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudDSPDistortionVolume.Value = vol;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudDSPDistortionVolume.Value = vol;
            }
            valueChangedExternally = false;
        }

        public void setPostLowGainMin(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostLowGainMin.InvokeRequired)
            {
                this.nudPostLowGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostLowGainMin.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostLowGainMin.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPostLowGainMax(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostLowGainMax.InvokeRequired)
            {
                this.nudPostLowGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostLowGainMax.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostLowGainMax.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPostMidGainMin(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostMidGainMin.InvokeRequired)
            {
                this.nudPostMidGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostMidGainMin.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostMidGainMin.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPostMidGainMax(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostMidGainMax.InvokeRequired)
            {
                this.nudPostMidGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostMidGainMax.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostMidGainMax.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPostMidFreq(int freq)
        {
            valueChangedExternally = true;
            if (this.nudPostgainMidFreq.InvokeRequired)
            {
                this.nudPostgainMidFreq.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostgainMidFreq.Value = freq;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostgainMidFreq.Value = freq;
            }
            valueChangedExternally = false;
        }

        public void setPostMidQ(decimal Q)
        {
            valueChangedExternally = true;
            if (this.nudPostgainMidQ.InvokeRequired)
            {
                this.nudPostgainMidQ.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostgainMidQ.Value = Q;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostgainMidQ.Value = Q;
            }
            valueChangedExternally = false;
        }

        public void setPostHighGainMin(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostHighGainMin.InvokeRequired)
            {
                this.nudPostHighGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostHighGainMin.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostHighGainMin.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPostHighGainMax(sbyte gain)
        {
            valueChangedExternally = true;
            if (this.nudPostHighGainMax.InvokeRequired)
            {
                this.nudPostHighGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostHighGainMax.Value = gain;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostHighGainMax.Value = gain;
            }
            valueChangedExternally = false;
        }

        public void setPreLowCut(int freq)
        {
            valueChangedExternally = true;
            if (this.nudPregainLowcut.InvokeRequired)
            {
                this.nudPregainLowcut.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPregainLowcut.Value = freq;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPregainLowcut.Value = freq;
            }
            valueChangedExternally = false;
        }

        public void setPostPresenceFreqMin(int freq)
        {
            valueChangedExternally = true;
            if (this.nudPostPresenceMin.InvokeRequired)
            {
                this.nudPostPresenceMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostPresenceMin.Value = freq;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostPresenceMin.Value = freq;
            }
            valueChangedExternally = false;
        }

        public void setPostPresenceFreqMax(int freq)
        {
            valueChangedExternally = true;
            if (this.nudPostPresenceMax.InvokeRequired)
            {
                this.nudPostPresenceMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    nudPostPresenceMax.Value = freq;
                    valueChangedExternally = false;
                });
            }
            else
            {
                nudPostPresenceMax.Value = freq;
            }
            valueChangedExternally = false;
        }

        public void setPostPresenceOrder(int order)
        {
            if (order == 0) order = 1;
            valueChangedExternally = true;
            if (this.cbPostPresenceOrder.InvokeRequired)
            {
                this.cbPostPresenceOrder.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    cbPostPresenceOrder.SelectedIndex = order - 1;
                    valueChangedExternally = false;
                });
            }
            else
            {
                cbPostPresenceOrder.SelectedIndex = order - 1;
            }
            valueChangedExternally = false;

        }

        public void setPreLowcutOrder(int order)
        {
            if (order == 0) order = 1;
            valueChangedExternally = true;
            if (this.cbPregainLowcutOrder.InvokeRequired)
            {
                this.cbPregainLowcutOrder.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    cbPregainLowcutOrder.SelectedIndex = order - 1;
                    valueChangedExternally = false;
                });
            }
            else
            {
                cbPregainLowcutOrder.SelectedIndex = order - 1;
            }
            valueChangedExternally = false;

        }

        public void setModelId(int id)
        {
            if (this.tbModelNo.InvokeRequired)
            {
                this.tbModelNo.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    tbModelNo.Text = "M" + (id+1).ToString().PadLeft(2, '0');
                    lbModels.SelectedIndex = id;
                    valueChangedExternally = false;
                });
            }
            else
            {
                tbModelNo.Text = "M" + (id+1).ToString().PadLeft(2, '0');
                lbModels.SelectedIndex = id;
            }
        }

        public void setModelName(string name)
        {
            if (this.tbModelName.InvokeRequired)
            {
                this.tbModelName.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    tbModelName.Text = name;
                    valueChangedExternally = false;
                });
            }
            else
            {
                tbModelName.Text = name;
            }
        }

        private void nudDSPDistortionGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_GAIN_MIN, Convert.ToSByte(nudDSPDistortionGainMin.Value));
        }

        private void nudDSPDistortionGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_GAIN_MAX, Convert.ToSByte(nudDSPDistortionGainMax.Value));
        }

        private void frmModels_Load(object sender, EventArgs e)
        {
            lbModels.Items.Clear();
            for(int i = 0; i < 10; i++)
            {
                lbModels.Items.Add("M" + (i + 1).ToString().PadLeft(2, '0'));
            }
        }

        private void tbModelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MyParent.setCurrentModelValueString(Form1.ModelProperties.NAME, tbModelName.Text);
            }
        }

        private void cbPostPresenceOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!valueChangedExternally)
            {
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_PRES_ORDER, Convert.ToSByte(cbPostPresenceOrder.SelectedIndex + 1));
            }
        }

        private void nudPostPresenceMin_ValueChanged(object sender, EventArgs e)
        {
            if(!valueChangedExternally)
            {
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_PRES_FREQ_MIN, Convert.ToInt16(nudPostPresenceMin.Value));
            }
        }

        private void nudPostPresenceMax_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
            {
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_PRES_FREQ_MAX, Convert.ToInt16(nudPostPresenceMax.Value));
            }
        }

        private void nudPostLowGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_LOW_GAIN_MIN, Convert.ToSByte(nudPostLowGainMin.Value));
        }

        private void nudPostLowGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_LOW_GAIN_MAX, Convert.ToSByte(nudPostLowGainMax.Value));
        }

        private void nudPostHighGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_HIGH_GAIN_MIN, Convert.ToSByte(nudPostHighGainMin.Value));
        }

        private void nudPostHighGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_HIGH_GAIN_MAX, Convert.ToSByte(nudPostHighGainMax.Value));
        }

        private void nudPostMidGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_GAIN_MIN, Convert.ToSByte(nudPostMidGainMin.Value));
        }

        private void nudPostMidGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_GAIN_MAX, Convert.ToSByte(nudPostMidGainMax.Value));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dlgExport.FileName = tbModelNo.Text + "_" + tbModelName.Text;
            dlgExport.ShowDialog();            
        }

        private void dlgExport_FileOk(object sender, CancelEventArgs e)
        {
            XmlWriterSettings xmlsettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = true
            };

            XmlWriter xml = XmlWriter.Create(dlgExport.FileName, xmlsettings);

            //cbAnalogChannel.SelectedIndex = 0;
            //xml.Settings.NewLineOnAttributes = true;

            xml.WriteStartDocument();
            xml.WriteStartElement("model");

            xml.WriteStartElement("name");
            xml.WriteString(tbModelName.Text);
            xml.WriteEndElement();

            xml.WriteStartElement("input");
            xml.WriteStartElement("impedance");
            xml.WriteString(nudInputZ.Value.ToString());
            xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("pregain");
            xml.WriteStartElement("lowcut"); xml.WriteString(nudPregainLowcut.Value.ToString()); xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("distortion");
            xml.WriteStartElement("gain_min"); xml.WriteString(nudDSPDistortionGainMin.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("gain_max"); xml.WriteString(nudDSPDistortionGainMax.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("alpha"); xml.WriteString(nudDSPDistortionAlpha.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("asymmetry"); xml.WriteString(nudDSPDistortionAsymmetry.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("volume"); xml.WriteString(nudDSPDistortionVolume.Value.ToString()); xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("analog");
            xml.WriteStartElement("bypass"); xml.WriteString(cbAnalogBypass.Checked.ToString().ToLower()); xml.WriteEndElement();
            xml.WriteStartElement("channel"); xml.WriteString(cbAnalogChannel.SelectedIndex.ToString()); xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("postgain");
            xml.WriteStartElement("low_gain_min"); xml.WriteString(nudPostLowGainMin.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("low_gain_max"); xml.WriteString(nudPostLowGainMax.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("mid_frequency"); xml.WriteString(nudPostgainMidFreq.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("mid_q"); xml.WriteString(nudPostgainMidQ.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("mid_gain_min"); xml.WriteString(nudPostMidGainMin.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("mid_gain_max"); xml.WriteString(nudPostMidGainMax.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("high_gain_min"); xml.WriteString(nudPostHighGainMin.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("high_gain_max"); xml.WriteString(nudPostHighGainMax.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("presence_frequency_min"); xml.WriteString(nudPostPresenceMin.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("presence_frequency_max"); xml.WriteString(nudPostPresenceMax.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("presence_order"); xml.WriteString(cbPostPresenceOrder.SelectedIndex.ToString()); xml.WriteEndElement();

            xml.WriteEndElement();



            xml.WriteEndDocument();
            xml.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dlgImport.ShowDialog();
        }

        public void setCurrentModelBypass()
        {
            int data = (Convert.ToInt16(cbPreGainBypass.Checked) << 3) + (Convert.ToInt16(cbDSPDistortionBypass.Checked) << 2) + (Convert.ToInt16(cbAnalogBypass.Checked) << 1) + Convert.ToInt16(cbPostgainBypass.Checked);
            sbyte bypass = (sbyte)(data & 0xFF);
            MyParent.setCurrentModelValue(Form1.ModelProperties.BYPASS, bypass);
        }

        private void dlgImport_FileOk(object sender, CancelEventArgs e)
        {
            XmlReader xml = XmlReader.Create(dlgImport.FileName);
           
            string block = "";

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    switch (xml.Name)
                    {
                        case "input":
                            block = "input";
                            break;
                        case "pregain":
                            block = "pregain";
                            break;
                        case "distortion":
                            block = "distortion";
                            break;
                        case "analog":
                            block = "analog";
                            break;
                        case "postgain":
                            block = "postgain";
                            break;

                        case "name":                            
                            tbModelName.Text = xml.ReadElementContentAsString();
                            break;
                        case "impedance":
                            nudInputZ.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "bypass":
                            if (block == "analog") cbAnalogBypass.Checked = xml.ReadElementContentAsBoolean();                            
                            break;
                        case "lowcut":
                            if (block == "pregain") nudPregainLowcut.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "gain_min":
                            if (block == "distortion") nudDSPDistortionGainMin.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "gain_max":
                            if (block == "distortion") nudDSPDistortionGainMax.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "alpha":
                            nudDSPDistortionAlpha.Value = Convert.ToDecimal(xml.ReadElementContentAsString());
                            break;
                        case "asymmetry":
                            nudDSPDistortionAsymmetry.Value = Convert.ToDecimal(xml.ReadElementContentAsString());
                            break;
                        case "volume":
                            if (block == "distortion") nudDSPDistortionVolume.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "channel":
                            cbAnalogChannel.SelectedIndex = xml.ReadElementContentAsInt();
                            break;
                        case "low_gain_min":
                            nudPostLowGainMin.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "low_gain_max":
                            nudPostLowGainMax.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "mid_frequency":
                            nudPostgainMidFreq.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "mid_q":
                            nudPostgainMidQ.Value = Convert.ToDecimal(xml.ReadElementContentAsString());
                            break;
                        case "mid_gain_min":
                            nudPostMidGainMin.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "mid_gain_max":
                            nudPostMidGainMax.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "high_gain_min":
                            nudPostHighGainMin.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "high_gain_max":
                            nudPostHighGainMax.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "presence_frequency_min":
                            nudPostPresenceMin.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "presence_frequency_max":
                            nudPostPresenceMax.Value = xml.ReadElementContentAsDecimal();
                            break;
                        case "presence_order":
                            cbPostPresenceOrder.SelectedIndex = xml.ReadElementContentAsInt();
                            break;



                        default:
                            break;

                    }
                }
            }
        }

        private void cbPreGainBypass_CheckedChanged(object sender, EventArgs e)
        {
            if(!valueChangedExternally)
                setCurrentModelBypass();
        }

        private void cbPregainLowcutOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
            {
                MyParent.setCurrentModelValue(Form1.ModelProperties.PREGAIN_LOWCUT_ORDER, Convert.ToSByte(cbPregainLowcutOrder.SelectedIndex + 1));
            }            
        }
    }
}
