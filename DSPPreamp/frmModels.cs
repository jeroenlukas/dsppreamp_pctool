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
    public partial class frmModels : Form
    {
        public Form1 MyParent { get; set; }

        public frmModels()
        {
            InitializeComponent();
        }

        private void cbPostgainBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPostgainBypass.Checked)
            {
                MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_BYPASS, 1);
            }
            else MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_BYPASS, 0);
        }

        private void cbDSPDistortionBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDSPDistortionBypass.Checked)
            {
                MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_BYPASS, 1);
            }
            else MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_BYPASS, 0);
        }

        private void nudDSPDistortionAlpha_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ALPHA, Convert.ToByte((nudDSPDistortionAlpha.Value * 10)));
        }

        private void nudDSPDistortionGain_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_GAIN, Convert.ToByte(nudDSPDistortionGainMin.Value));
        }

        private void nudDSPDistortionVolume_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_VOLUME, Convert.ToByte(nudDSPDistortionVolume.Value * -1));
        }

        private void cbAnalogBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnalogBypass.Checked)
            {
                MyParent.setCurrentModelValue(Form1.ModelProperties.ANALOG_BYPASS, 1);
            }
            else MyParent.setCurrentModelValue(Form1.ModelProperties.ANALOG_BYPASS, 0);
        }

        private void nudPregainLowcut_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValueInt(Form1.ModelProperties.PREGAIN_LOWCUT, Convert.ToInt16(nudPregainLowcut.Value));
        }

        private void nudDSPDistortionAsymmetry_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValue(Form1.ModelProperties.DSPDISTORTION_ASYMMETRY, Convert.ToByte((nudDSPDistortionAsymmetry.Value * 100)));
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudPostgainMidQ_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValue(Form1.ModelProperties.POSTGAIN_MID_Q, Convert.ToByte((nudPostgainMidQ.Value * 10)));
        }

        private void nudPostgainMidFreq_ValueChanged(object sender, EventArgs e)
        {
            MyParent.setCurrentModelValueInt(Form1.ModelProperties.POSTGAIN_MID_FREQ, Convert.ToInt16(nudPostgainMidFreq.Value));
        }

        private void lbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbModelNo.Text = (lbModels.SelectedIndex + 1).ToString();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            MyParent.storeCurrentModel();
        }
    }
}
