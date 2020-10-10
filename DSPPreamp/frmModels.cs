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

        //public bool valueChangedExternally = false;

        public frmModels()
        {
            InitializeComponent();
        }

        private void cbPostgainBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cbPostgainBypass.Tag) != 1)            
                setCurrentModelBypass();
            cbPostgainBypass.Tag = 0;
            
        }

        private void cbDSPDistortionBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cbDSPDistortionBypass.Tag) != 1)            
                setCurrentModelBypass();
            cbDSPDistortionBypass.Tag = 0;
        }

        private void nudDSPDistortionAlpha_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudDSPDistortionAlpha.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ALPHA, Convert.ToSByte((nudDSPDistortionAlpha.Value * 10)));
            nudDSPDistortionAlpha.Tag = 0;
        }    

        private void nudDSPDistortionVolume_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudDSPDistortionVolume.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_VOLUME, Convert.ToSByte(nudDSPDistortionVolume.Value ));
            nudDSPDistortionVolume.Tag = 0;           
        }

        private void cbAnalogBypass_CheckedChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(cbAnalogBypass.Tag) != 1)
                setCurrentModelBypass();
            cbAnalogBypass.Tag = 0;
            
        }

        private void nudPregainLowcut_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudPregainLowcut.Tag) != 1)// && nudPregainLowcut.Focused)
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.PREGAIN_LOWCUT, Convert.ToInt16(nudPregainLowcut.Value));
            nudPregainLowcut.Tag = 0;
        }

        private void nudDSPDistortionAsymmetry_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudDSPDistortionAsymmetry.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ASYMMETRY, Convert.ToSByte((nudDSPDistortionAsymmetry.Value * 100)));
            nudDSPDistortionAsymmetry.Tag = 0;
        }

  

        private void nudPostgainMidQ_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostgainMidQ.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_Q, Convert.ToSByte((nudPostgainMidQ.Value * 10)));
            nudPostgainMidQ.Tag = 0;
        }

        private void nudPostgainMidFreq_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudPostgainMidFreq.Tag) != 1)
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_MID_FREQ, Convert.ToInt16(nudPostgainMidFreq.Value));
            nudPostgainMidFreq.Tag = 0;
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
            //valueChangedExternally = true;
            int data = bypass;
            if((data & 8 ) > 0) // pregain
            {
                if (this.cbPreGainBypass.InvokeRequired)
                {
                    this.cbPreGainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        //valueChangedExternally = true;
                        cbPreGainBypass.Tag = 1;
                        cbPreGainBypass.Checked = true;

                    });
                }
                else
                {
                    cbPreGainBypass.Tag = 1;
                    cbPreGainBypass.Checked = true;
                }

            }
            else
            {
                if (this.cbPreGainBypass.InvokeRequired)
                {
                    this.cbPreGainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbPreGainBypass.Tag = 1;
                        cbPreGainBypass.Checked = false;

                    });
                }
                else
                {
                    cbPreGainBypass.Tag = 1;
                    cbPreGainBypass.Checked = false;
                }
            }

            if ((data & 4) > 0) // distortion
            {
                if (this.cbDSPDistortionBypass.InvokeRequired)
                {
                    this.cbDSPDistortionBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbDSPDistortionBypass.Tag = 1;
                        cbDSPDistortionBypass.Checked = true;
                    });
                }
                else
                {
                    cbDSPDistortionBypass.Tag = 1;
                    cbDSPDistortionBypass.Checked = true;
                }
            }
            else
            {
                if (this.cbDSPDistortionBypass.InvokeRequired)
                {
                    this.cbDSPDistortionBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbDSPDistortionBypass.Tag = 1;
                        cbDSPDistortionBypass.Checked = false;
                    });
                }
                else
                {
                    cbDSPDistortionBypass.Tag = 1;
                    cbDSPDistortionBypass.Checked = false;
                }
            }

            if ((data & 2) > 0) // analog
            {
                if (this.cbAnalogBypass.InvokeRequired)
                {
                    this.cbAnalogBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbAnalogBypass.Tag = 1;
                        cbAnalogBypass.Checked = true;

                    });
                }
                else
                {
                    cbAnalogBypass.Tag = 1;
                    cbAnalogBypass.Checked = true;
                }
            }
            else
            {
                if (this.cbAnalogBypass.InvokeRequired)
                {
                    this.cbAnalogBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbAnalogBypass.Tag = 1;
                        cbAnalogBypass.Checked = false;
                    });
                }
                else
                {
                    cbAnalogBypass.Tag = 1;
                    cbAnalogBypass.Checked = false;
                }
            }

            if ((data & 1) > 0) // postgain
            {
                if (this.cbPostgainBypass.InvokeRequired)
                {
                    this.cbPostgainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbPostgainBypass.Tag = 1;
                        cbPostgainBypass.Checked = true;
                    });
                }
                else
                {
                    cbPostgainBypass.Tag = 1;
                    cbPostgainBypass.Checked = true;
                }
            }
            else
            {
                if (this.cbPostgainBypass.InvokeRequired)
                {
                    this.cbPostgainBypass.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbPostgainBypass.Tag = 1;
                        cbPostgainBypass.Checked = false;
                    });
                }
                else
                {
                    cbPostgainBypass.Tag = 1;
                    cbPostgainBypass.Checked = false;
                }
            }



            
        }

        public void setDSPDistortionGainMin(sbyte gain)
        {
            
            if (this.nudDSPDistortionGainMin.InvokeRequired)
            {
                this.nudDSPDistortionGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudDSPDistortionGainMin.Tag = 1;
                    nudDSPDistortionGainMin.Value = gain;
            
                });
            }
            else
            {
                nudDSPDistortionGainMin.Tag = 1;
                nudDSPDistortionGainMin.Value = gain;
            }
            
        }

        public void setDSPDistortionGainMax(sbyte gain)
        {
            
            if (this.nudDSPDistortionGainMax.InvokeRequired)
            {
                this.nudDSPDistortionGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudDSPDistortionGainMax.Tag = 1;
                    nudDSPDistortionGainMax.Value = gain;
                    
                });
            }
            else
            {
                nudDSPDistortionGainMax.Tag = 1;
                nudDSPDistortionGainMax.Value = gain;
            }
            
        }

        public void setDSPDistortionAlpha(decimal alpha)
        {
         
            if (this.nudDSPDistortionAlpha.InvokeRequired)
            {
                this.nudDSPDistortionAlpha.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudDSPDistortionAlpha.Tag = 1;
                    nudDSPDistortionAlpha.Value = alpha;
                    
                });
            }
            else
            {
                nudDSPDistortionAlpha.Tag = 1;
                nudDSPDistortionAlpha.Value = alpha;
            }            
        }

        public void setDSPDistortionAsymmetry(decimal asymm)
        {
            
            if (this.nudDSPDistortionAsymmetry.InvokeRequired)
            {
                this.nudDSPDistortionAsymmetry.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudDSPDistortionAsymmetry.Tag = 1;
                    nudDSPDistortionAsymmetry.Value = asymm;                    
                });
            }
            else
            {
                nudDSPDistortionAsymmetry.Tag = 1;
                nudDSPDistortionAsymmetry.Value = asymm;
            }
            
        }

        public void setDSPDistortionVolume(sbyte vol)
        {            
            if (this.nudDSPDistortionVolume.InvokeRequired)
            {
                this.nudDSPDistortionVolume.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudDSPDistortionVolume.Tag = 1;
                    nudDSPDistortionVolume.Value = vol;                    
                });
            }
            else
            {
                nudDSPDistortionVolume.Tag = 1;
                nudDSPDistortionVolume.Value = vol;
            }            
        }

        public void setPostLowGainMin(sbyte gain)
        {
            
            if (this.nudPostLowGainMin.InvokeRequired)
            {
                this.nudPostLowGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostLowGainMin.Tag = 1;
                    nudPostLowGainMin.Value = gain;
                    
                });
            }
            else
            {
                nudPostLowGainMin.Tag = 1;
                nudPostLowGainMin.Value = gain;
            }
            
        }

        public void setPostLowGainMax(sbyte gain)
        {
            
            if (this.nudPostLowGainMax.InvokeRequired)
            {
                this.nudPostLowGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostLowGainMax.Tag = 1;
                    nudPostLowGainMax.Value = gain;                    
                });
            }
            else
            {
                nudPostLowGainMax.Tag = 1;
                nudPostLowGainMax.Value = gain;
            }
        }

        public void setPostMidGainMin(sbyte gain)
        {            
            if (this.nudPostMidGainMin.InvokeRequired)
            {
                this.nudPostMidGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostMidGainMin.Tag = 1;
                    nudPostMidGainMin.Value = gain;
         
                });
            }
            else
            {
                nudPostMidGainMin.Tag = 1;
                nudPostMidGainMin.Value = gain;
            }
         
        }

        public void setPostMidGainMax(sbyte gain)
        {
         
            if (this.nudPostMidGainMax.InvokeRequired)
            {
                this.nudPostMidGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostMidGainMax.Tag = 1;
                    nudPostMidGainMax.Value = gain;
                    
                });
            }
            else
            {
                nudPostMidGainMax.Tag = 1;
                nudPostMidGainMax.Value = gain;
            }
            
        }

        public void setPostMidFreq(int freq)
        {            
            if (this.nudPostgainMidFreq.InvokeRequired)
            {
                this.nudPostgainMidFreq.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostgainMidFreq.Tag = 1;
                    nudPostgainMidFreq.Value = freq;                    
                });
            }
            else
            {
                nudPostgainMidFreq.Tag = 1;
                nudPostgainMidFreq.Value = freq;
            }            
        }

        public void setPostMidQ(decimal Q)
        {
          
            if (this.nudPostgainMidQ.InvokeRequired)
            {
                this.nudPostgainMidQ.BeginInvoke((MethodInvoker)delegate ()
                {          
                    nudPostgainMidQ.Tag = 1;
                    nudPostgainMidQ.Value = Q;
          
                });
            }
            else
            {
                nudPostgainMidQ.Tag = 1;
                nudPostgainMidQ.Value = Q;
            }         
        }

        public void setPostHighGainMin(sbyte gain)
        {
            
            if (this.nudPostHighGainMin.InvokeRequired)
            {
                this.nudPostHighGainMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostHighGainMin.Tag = 1;
                    nudPostHighGainMin.Value = gain;                    
                });
            }
            else
            {
                nudPostHighGainMin.Tag = 1;
                nudPostHighGainMin.Value = gain;
            }
        }

        public void setPostHighGainMax(sbyte gain)
        {
            if (this.nudPostHighGainMax.InvokeRequired)
            {
                this.nudPostHighGainMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostHighGainMax.Tag = 1;
                    nudPostHighGainMax.Value = gain;                    
                });
            }
            else
            {
                nudPostHighGainMax.Tag = 1;
                nudPostHighGainMax.Value = gain;
            }
        }

        public void setPreLowCut(int freq)
        {            
            if (this.nudPregainLowcut.InvokeRequired)
            {
                this.nudPregainLowcut.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPregainLowcut.Tag = 1;
                    nudPregainLowcut.Value = freq;
         
                });
            }
            else
            {
                nudPregainLowcut.Tag = 1;
                nudPregainLowcut.Value = freq;                
            }            
        }

        public void setPostPresenceFreqMin(int freq)
        {            
            if (this.nudPostPresenceMin.InvokeRequired)
            {
                this.nudPostPresenceMin.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostPresenceMin.Tag = 1;
                    nudPostPresenceMin.Value = freq;                    
                });
            }
            else
            {
                nudPostPresenceMin.Tag = 1;
                nudPostPresenceMin.Value = freq;
            }
        }

        public void setPostPresenceFreqMax(int freq)
        {

            if (this.nudPostPresenceMax.InvokeRequired)
            {
                this.nudPostPresenceMax.BeginInvoke((MethodInvoker)delegate ()
                {
                    nudPostPresenceMax.Tag = 1;
                    nudPostPresenceMax.Value = freq;

                });
            }
            else
            {
                nudPostPresenceMax.Tag = 1;
                nudPostPresenceMax.Value = freq;
            }            
        }

        public void setPostPresenceOrder(int order)
        {
            if (order == 0) order = 1;
            
            if (this.cbPostPresenceOrder.InvokeRequired)
            {
                this.cbPostPresenceOrder.BeginInvoke((MethodInvoker)delegate ()
                {
                    cbPostPresenceOrder.Tag = 1;
                    cbPostPresenceOrder.SelectedIndex = order - 1;
                    
                });
            }
            else
            {
                cbPostPresenceOrder.Tag = 1;
                cbPostPresenceOrder.SelectedIndex = order - 1;
            }
            

        }

        public void setPreLowcutOrder(int order)
        {
            if (order == 0) order = 1;
           
            if (this.cbPregainLowcutOrder.InvokeRequired)
            {
                this.cbPregainLowcutOrder.BeginInvoke((MethodInvoker)delegate ()
                {            
                    cbPregainLowcutOrder.Tag = 1;
                    cbPregainLowcutOrder.SelectedIndex = order - 1;
                });
            }
            else
            {               
                cbPregainLowcutOrder.Tag = 1;
                cbPregainLowcutOrder.SelectedIndex = order - 1;             
            }
        }

        public void setModelId(int id)
        {
            if (this.tbModelNo.InvokeRequired)
            {
                this.tbModelNo.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbModels.Tag = 1;
                    tbModelNo.Text = "M" + (id+1).ToString().PadLeft(2, '0');
                    lbModels.SelectedIndex = id;                    
                });
            }
            else
            {
                tbModelNo.Text = "M" + (id+1).ToString().PadLeft(2, '0');
                lbModels.Tag = 1;
                lbModels.SelectedIndex = id;
            }
        }

        public void setModelName(string name)
        {
            if (this.tbModelName.InvokeRequired)
            {
                this.tbModelName.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbModelName.Tag = 1;
                    tbModelName.Text = name;
                    
                });
            }
            else
            {
                tbModelName.Tag = 1;
                tbModelName.Text = name;
            }
        }

        public void setModelNameInList(int model_id, string name)
        {
            if (this.lbModels.InvokeRequired)
            {
                this.lbModels.BeginInvoke((MethodInvoker)delegate ()
                {
                 
                    lbModels.Items[model_id] = "M" + (model_id + 1).ToString().PadLeft(2, '0') + ": " + name;
                 
                });
            }
            else
            {
                lbModels.Items[model_id] = "M" + (model_id + 1).ToString().PadLeft(2, '0') + ": " + name; 
            }
        }

        private void nudDSPDistortionGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudDSPDistortionGainMin.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_GAIN_MIN, Convert.ToSByte(nudDSPDistortionGainMin.Value));
            nudDSPDistortionGainMin.Tag = 0;
        }

        private void nudDSPDistortionGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudDSPDistortionGainMax.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_GAIN_MAX, Convert.ToSByte(nudDSPDistortionGainMax.Value));
            nudDSPDistortionGainMax.Tag = 0;
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
            if(Convert.ToInt16(cbPostPresenceOrder.Tag) != 1)            
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_PRES_ORDER, Convert.ToSByte(cbPostPresenceOrder.SelectedIndex + 1));
            cbPostPresenceOrder.Tag = 0;
        }

        private void nudPostPresenceMin_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(nudPostPresenceMin.Tag) != 1)            
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_PRES_FREQ_MIN, Convert.ToInt16(nudPostPresenceMin.Value));
            nudPostPresenceMin.Tag = 0;
        }

        private void nudPostPresenceMax_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostPresenceMax.Tag) != 1)            
                MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_PRES_FREQ_MAX, Convert.ToInt16(nudPostPresenceMax.Value));
            nudPostPresenceMax.Tag = 0;
        }

        private void nudPostLowGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostLowGainMin.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_LOW_GAIN_MIN, Convert.ToSByte(nudPostLowGainMin.Value));
            nudPostLowGainMin.Tag = 0;
        }

        private void nudPostLowGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostLowGainMax.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_LOW_GAIN_MAX, Convert.ToSByte(nudPostLowGainMax.Value));
            nudPostLowGainMax.Tag = 0;
        }

        private void nudPostHighGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostHighGainMin.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_HIGH_GAIN_MIN, Convert.ToSByte(nudPostHighGainMin.Value));
            nudPostHighGainMin.Tag = 0;
        }

        private void nudPostHighGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostHighGainMax.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_HIGH_GAIN_MAX, Convert.ToSByte(nudPostHighGainMax.Value));
            nudPostHighGainMax.Tag = 0;
        }

        private void nudPostMidGainMin_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostMidGainMin.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_GAIN_MIN, Convert.ToSByte(nudPostMidGainMin.Value));
            nudPostMidGainMin.Tag = 0;
        }

        private void nudPostMidGainMax_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(nudPostMidGainMax.Tag) != 1)
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_GAIN_MAX, Convert.ToSByte(nudPostMidGainMax.Value));
            nudPostMidGainMax.Tag = 0;
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
            xml.WriteStartElement("bypass"); xml.WriteString(cbPreGainBypass.Checked.ToString().ToLower()); xml.WriteEndElement();
            xml.WriteStartElement("lowcut"); xml.WriteString(nudPregainLowcut.Value.ToString()); xml.WriteEndElement();
            xml.WriteStartElement("lowcut_order"); xml.WriteString(cbPregainLowcutOrder.SelectedIndex.ToString()); xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("distortion");
            xml.WriteStartElement("bypass"); xml.WriteString(cbDSPDistortionBypass.Checked.ToString().ToLower()); xml.WriteEndElement();
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
            xml.WriteStartElement("bypass"); xml.WriteString(cbPostgainBypass.Checked.ToString().ToLower()); xml.WriteEndElement();
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
                        case "lowcut_order":
                            if (block == "pregain") cbPregainLowcutOrder.SelectedIndex = xml.ReadElementContentAsInt();
                            break;
                        case "bypass":
                            if (block == "analog") cbAnalogBypass.Checked = xml.ReadElementContentAsBoolean();                            
                            else if (block == "distortion") cbDSPDistortionBypass.Checked = xml.ReadElementContentAsBoolean();
                            else if (block == "pregain") cbPreGainBypass.Checked = xml.ReadElementContentAsBoolean(); 
                            else if(block == "postgain") cbPostgainBypass.Checked = xml.ReadElementContentAsBoolean(); 
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
            if (Convert.ToInt16(cbPreGainBypass.Tag) != 1)
            {
                setCurrentModelBypass();
            }
            cbPreGainBypass.Tag = 0;
        }

        private void cbPregainLowcutOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( Convert.ToInt16(cbPregainLowcutOrder.Tag) != 1)            
                MyParent.setCurrentModelValue(Form1.ModelProperties.PREGAIN_LOWCUT_ORDER, Convert.ToSByte(cbPregainLowcutOrder.SelectedIndex + 1));
               
            cbPregainLowcutOrder.Tag = 0;
        }

        private void timerTagReset_Tick(object sender, EventArgs e)
        {
            cbPreGainBypass.Tag = 0;
            cbPregainLowcutOrder.Tag = 0;
            nudPregainLowcut.Tag = 0;

            cbDSPDistortionBypass.Tag = 0;
            nudDSPDistortionGainMin.Tag = 0;
            nudDSPDistortionGainMax.Tag = 0;
            nudDSPDistortionAlpha.Tag = 0;
            nudDSPDistortionAsymmetry.Tag = 0;
            nudDSPDistortionVolume.Tag = 0;

            cbAnalogBypass.Tag = 0;
            cbAnalogChannel.Tag = 0;

            cbPostgainBypass.Tag = 0;
            nudPostLowGainMin.Tag = 0;
            nudPostLowGainMax.Tag = 0;
            nudPostMidGainMin.Tag = 0;
            nudPostMidGainMax.Tag = 0;
            nudPostgainMidFreq.Tag = 0;
            nudPostgainMidQ.Tag = 0;
            nudPostHighGainMin.Tag = 0;
            nudPostHighGainMax.Tag = 0;
            nudPostPresenceMin.Tag = 0;
            nudPostPresenceMax.Tag = 0;
            cbPostPresenceOrder.Tag = 0;

        }
    }
}
