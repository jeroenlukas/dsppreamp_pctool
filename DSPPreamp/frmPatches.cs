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

        public bool valueChangedExternally = false;

        public frmPatches()
        {
            InitializeComponent();
        }

        private void knobGain_ValueChanged(object Sender)
        {
            if(!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.GAIN, (byte)knobGain.Value);
            
        }

        private void knobLow_ValueChanged_1(object Sender)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.LOW, (byte)knobLow.Value);
        }

        private void knobMid_ValueChanged_1(object Sender)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.MID, (byte)knobMid.Value);
        }

        private void knobHigh_ValueChanged(object Sender)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.HIGH, (byte)knobHigh.Value);
        }

        private void knobPresence_ValueChanged_1(object Sender)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.PRES, (byte)knobPresence.Value);
        }

        private void knobVolume_ValueChanged(object Sender)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.VOLUME, (byte)knobVolume.Value);
        }

        public void setKnob(int property, int value)
        {
            valueChangedExternally = true;
            switch(property)
            {
                case Form1.PatchProperties.GAIN:
                    knobGain.Value = value;
                    break;
                case Form1.PatchProperties.LOW:
                    knobLow.Value = value;
                    break;
                case Form1.PatchProperties.MID:
                    knobMid.Value = value;
                    break;
                case Form1.PatchProperties.HIGH:
                    knobHigh.Value = value;
                    break;
                case Form1.PatchProperties.PRES:
                    knobPresence.Value = value;
                    break;
                case Form1.PatchProperties.VOLUME:
                    knobVolume.Value = value;
                    break;
                default:
                    break;

            }
            valueChangedExternally = false;
        }

        public void setName(string name)
        {
            valueChangedExternally = true;
            if (this.tbName.InvokeRequired)
            {
                this.tbName.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbName.Text = name;                   
                });
            }
            else
            {
                tbName.Text = name;
            }
            valueChangedExternally = false;
        }

        public void selectPatch(int patchNo)
        {
            
            if (this.lbPatches.InvokeRequired)
            {
                this.lbPatches.BeginInvoke((MethodInvoker)delegate ()
                {
                    valueChangedExternally = true;
                    lbPatches.SelectedIndex = patchNo;
                    tbPatchNo.Text = (patchNo + 1).ToString();
                    valueChangedExternally = false;
                });
            }
            else
            {
                valueChangedExternally = true;
                lbPatches.SelectedIndex = patchNo;
                tbPatchNo.Text = (patchNo + 1).ToString();
                valueChangedExternally = false;
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
                        valueChangedExternally = true;
                        cbModel.SelectedIndex = model_id;
                        valueChangedExternally = false;
                    });
                }
                else
                {
                    valueChangedExternally = true;
                    cbModel.SelectedIndex = model_id;
                    valueChangedExternally = false;
                }
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            MyParent.storeCurrentModel();
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!valueChangedExternally)
                MyParent.setCurrentPatchValue(Form1.PatchProperties.MODEL, (byte)cbModel.SelectedIndex);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                MyParent.setCurrentPatchValueString(Form1.PatchProperties.PATCH_NAME, tbName.Text);
            }

        }

        private void lbPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!valueChangedExternally)
                MyParent.selectPatch(Convert.ToByte(lbPatches.SelectedIndex));
        }
    }
}
