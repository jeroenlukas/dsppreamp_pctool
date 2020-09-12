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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        public void logMessage(string text, Color color)
        {
            if (this.rtbLog.InvokeRequired)
            {
                this.rtbLog.BeginInvoke((MethodInvoker)delegate () {
                    rtbLog.SelectionStart = rtbLog.TextLength;
                    rtbLog.SelectionLength = 0;
                    rtbLog.SelectionColor = color;
                    rtbLog.AppendText("\n[" + DateTime.Now.ToString() + "] " + text );
                    rtbLog.SelectionColor = rtbLog.ForeColor;
                    ; });
            }
            else
            {
                rtbLog.SelectionStart = rtbLog.TextLength;
                rtbLog.SelectionLength = 0;
                rtbLog.SelectionColor = color;
                rtbLog.AppendText("\n[" + DateTime.Now.ToString() + "] " + text );
                rtbLog.SelectionColor = rtbLog.ForeColor; ;
            }
            //rtbLog.AppendText("[" + DateTime.Now.ToString() + "] " + text + "\n");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
    }
}
