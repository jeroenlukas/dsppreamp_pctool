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
    public partial class frmPatches : Form
    {
        public Form1 MyParent { get; set; }

        //public bool valueChangedExternally = false;

        public frmPatches()
        {
            InitializeComponent();
        }

        private void knobGain_ValueChanged(object Sender)
        {
            if(Convert.ToInt16(knobGain.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.GAIN, (byte)knobGain.Value);
            knobGain.Tag = 0;
            
        }

        private void knobLow_ValueChanged_1(object Sender)
        {
            if (Convert.ToInt16(knobLow.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.LOW, (byte)knobLow.Value);
            knobLow.Tag = 0;
        }

        private void knobMid_ValueChanged_1(object Sender)
        {
            if(Convert.ToInt16(knobMid.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.MID, (byte)knobMid.Value);
            knobMid.Tag = 0;
        }

        private void knobHigh_ValueChanged(object Sender)
        {
            if (Convert.ToInt16(knobHigh.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.HIGH, (byte)knobHigh.Value);
            knobHigh.Tag = 0;
        }

        private void knobPresence_ValueChanged_1(object Sender)
        {
            if (Convert.ToInt16(knobPresence.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.PRES, (byte)knobPresence.Value);
            knobPresence.Tag = 0;
        }

        private void knobVolume_ValueChanged(object Sender)
        {
            if (Convert.ToInt16(knobVolume.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.VOLUME, (byte)knobVolume.Value);
            knobVolume.Tag = 0;
        }

        public void setKnob(int property, int value)
        {
            
            switch(property)
            {
                case Form1.PatchProperties.GAIN:
                    knobGain.Tag = 1;
                    knobGain.Value = value;
                    break;
                case Form1.PatchProperties.LOW:
                    knobLow.Tag = 1;
                    knobLow.Value = value;
                    break;
                case Form1.PatchProperties.MID:
                    knobMid.Tag = 1;
                    knobMid.Value = value;
                    break;
                case Form1.PatchProperties.HIGH:
                    knobHigh.Tag = 1;
                    knobHigh.Value = value;
                    break;
                case Form1.PatchProperties.PRES:
                    knobPresence.Tag = 1;
                    knobPresence.Value = value;
                    break;
                case Form1.PatchProperties.VOLUME:
                    knobVolume.Tag = 1;
                    knobVolume.Value = value;
                    break;
                default:
                    break;

            }
            
        }

        public void setName(string name)
        {
            
            if (this.tbName.InvokeRequired)
            {
                this.tbName.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbName.Tag = 1;
                    tbName.Text = name;                   
                });
            }
            else
            {
                tbName.Tag = 1;
                tbName.Text = name;
            }
            
        }

        public void selectPatch(int patchNo)
        {
            
            if (this.lbPatches.InvokeRequired)
            {
                this.lbPatches.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbPatches.Tag = 1;
                    lbPatches.SelectedIndex = patchNo;
                    tbPatchNo.Text = (patchNo + 1).ToString().PadLeft(3, '0');
                    
                });
            }
            else
            {
                lbPatches.Tag = 1;
                lbPatches.SelectedIndex = patchNo;
                tbPatchNo.Text = (patchNo + 1).ToString().PadLeft(3, '0');
                
            }
            
        }

        public void setPatchNameInList(int patch_id, string name)
        {
            if (this.lbPatches.InvokeRequired)
            {
                this.lbPatches.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbPatches.Tag = 1;
                    lbPatches.Items[patch_id] = "P" + (patch_id + 1).ToString().PadLeft(3, '0') + ": " + name;
                });
            }
            else
            {
                lbPatches.Tag = 1;
                lbPatches.Items[patch_id] = "P" + (patch_id + 1).ToString().PadLeft(3, '0') + ": " + name;
            }
        }

        public void setModelNameInList(int model_id, string name)
        {
            if (this.cbModel.InvokeRequired)
            {
                this.cbModel.BeginInvoke((MethodInvoker)delegate ()
                {                    
                    cbModel.Items[model_id] = "M" + (model_id + 1).ToString().PadLeft(2, '0') + ": " + name;                 
                });
            }
            else
            {
                cbModel.Items[model_id] = "M" + (model_id + 1).ToString().PadLeft(2, '0') + ": " + name;
            }
        }

        public void setModel(int model_id)
        {
            
            if (model_id < cbModel.Items.Count)
            {
                if (this.cbModel.InvokeRequired)
                {
                    this.cbModel.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cbModel.Tag = 1;
                        cbModel.SelectedIndex = model_id;
                        
                    });
                }
                else
                {
                    cbModel.Tag = 1;
                    cbModel.SelectedIndex = model_id;
                    
                }
            }
            

        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            MyParent.storeCurrentPatch();
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Convert.ToInt16(cbModel.Tag) != 1)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.MODEL, (byte)cbModel.SelectedIndex);
            cbModel.Tag = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                MyParent.setCurrentPatchValueString(Form1.PatchProperties.NAME, tbName.Text);
            }

        }

        private void lbPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(lbPatches.Tag) != 1)
                MyParent.selectPatch(Convert.ToByte(lbPatches.SelectedIndex));
            lbPatches.Tag = 0;
        }

        private void frmPatches_Load(object sender, EventArgs e)
        {            
            lbPatches.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                lbPatches.Items.Add("P" + (i+1).ToString().PadLeft(3, '0'));
            }

            cbModel.Items.Clear();
            for(int i = 0; i < 10; i++)
            {
                cbModel.Items.Add("M" + (i + 1).ToString().PadLeft(2, '0'));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerTagReset_Tick(object sender, EventArgs e)
        {
            lbPatches.Tag = 0;
            cbModel.Tag = 0;
            knobGain.Tag = 0;
            knobLow.Tag = 0;
            knobMid.Tag = 0;
            knobHigh.Tag = 0;
            knobPresence.Tag = 0;
            knobVolume.Tag = 0;
        }
    }
}
