namespace DSPPreamp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadModelFromEEPROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeModelToEEPROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.disableUSBTransmitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutgoingCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 57600;
            this.serialPort.PortName = "COM4";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 753);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1364, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.testToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadModelFromEEPROMToolStripMenuItem,
            this.storeModelToEEPROMToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "&Test";
            // 
            // loadModelFromEEPROMToolStripMenuItem
            // 
            this.loadModelFromEEPROMToolStripMenuItem.Name = "loadModelFromEEPROMToolStripMenuItem";
            this.loadModelFromEEPROMToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadModelFromEEPROMToolStripMenuItem.Text = "Load Model from EEPROM...";
            this.loadModelFromEEPROMToolStripMenuItem.Click += new System.EventHandler(this.loadModelFromEEPROMToolStripMenuItem_Click);
            // 
            // storeModelToEEPROMToolStripMenuItem
            // 
            this.storeModelToEEPROMToolStripMenuItem.Name = "storeModelToEEPROMToolStripMenuItem";
            this.storeModelToEEPROMToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.storeModelToEEPROMToolStripMenuItem.Text = "Store Model to EEPROM...";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem,
            this.toolStripSeparator1,
            this.disableUSBTransmitToolStripMenuItem,
            this.logOutgoingCommandsToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "&System";
            // 
            // initializeToolStripMenuItem
            // 
            this.initializeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patchesToolStripMenuItem,
            this.modelsToolStripMenuItem});
            this.initializeToolStripMenuItem.Name = "initializeToolStripMenuItem";
            this.initializeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.initializeToolStripMenuItem.Text = "Initialize...";
            // 
            // patchesToolStripMenuItem
            // 
            this.patchesToolStripMenuItem.Name = "patchesToolStripMenuItem";
            this.patchesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.patchesToolStripMenuItem.Text = "Patches";
            this.patchesToolStripMenuItem.Click += new System.EventHandler(this.patchesToolStripMenuItem_Click);
            // 
            // modelsToolStripMenuItem
            // 
            this.modelsToolStripMenuItem.Name = "modelsToolStripMenuItem";
            this.modelsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.modelsToolStripMenuItem.Text = "Models";
            this.modelsToolStripMenuItem.Click += new System.EventHandler(this.modelsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // disableUSBTransmitToolStripMenuItem
            // 
            this.disableUSBTransmitToolStripMenuItem.CheckOnClick = true;
            this.disableUSBTransmitToolStripMenuItem.Name = "disableUSBTransmitToolStripMenuItem";
            this.disableUSBTransmitToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.disableUSBTransmitToolStripMenuItem.Text = "Disable USB transmit";
            // 
            // logOutgoingCommandsToolStripMenuItem
            // 
            this.logOutgoingCommandsToolStripMenuItem.Checked = true;
            this.logOutgoingCommandsToolStripMenuItem.CheckOnClick = true;
            this.logOutgoingCommandsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logOutgoingCommandsToolStripMenuItem.Name = "logOutgoingCommandsToolStripMenuItem";
            this.logOutgoingCommandsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.logOutgoingCommandsToolStripMenuItem.Text = "Log outgoing commands";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1364, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 775);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "dspPreamp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadModelFromEEPROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeModelToEEPROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem disableUSBTransmitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutgoingCommandsToolStripMenuItem;
    }
}

