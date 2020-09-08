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
    }
}
