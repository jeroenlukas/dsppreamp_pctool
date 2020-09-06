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

        public frmPatches()
        {
            InitializeComponent();
        }

             private void knobGain_ValueChanged(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.GAIN, (byte)knobGain.Value);
            
        }

        private void knobLow_ValueChanged_1(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.LOW, (byte)knobLow.Value);
        }

        private void knobMid_ValueChanged_1(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.MID, (byte)knobMid.Value);
        }

        private void knobHigh_ValueChanged(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.HIGH, (byte)knobHigh.Value);
        }

        private void knobPresence_ValueChanged_1(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.PRES, (byte)knobPresence.Value);
        }

        private void knobVolume_ValueChanged(object Sender)
        {
            MyParent.setCurrentPatchValue(Form1.PatchProperties.VOLUME, (byte)knobVolume.Value);
        }
    }
}
