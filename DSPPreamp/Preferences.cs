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
    public partial class frmPreferences : Form
    {
        public frmPreferences()
        {
            InitializeComponent();
        }

        public Form1 MyParent { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MyParent.prefrences.ConnectOnStartup = cbConnectOnStartup.Checked;
            MyParent.prefrences.DefaultComPort = cbDefaultPort.Text;
            MyParent.SavePreferences();
            Close();
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            cbConnectOnStartup.Checked = MyParent.prefrences.ConnectOnStartup;

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cbDefaultPort.Items.Add(port);

                if (port == MyParent.prefrences.DefaultComPort) cbDefaultPort.SelectedIndex = cbDefaultPort.Items.Count - 1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
