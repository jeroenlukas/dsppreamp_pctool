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
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchModelNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchPatchNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ddComPorts = new System.Windows.Forms.ToolStripDropDownButton();
            this.logOutgoingCommandsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disableOutgoingCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 753);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1364, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(52, 17);
            this.lblConnectionStatus.Text = "OFFLINE";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchModelNamesToolStripMenuItem,
            this.fetchPatchNamesToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "&Test";
            // 
            // fetchModelNamesToolStripMenuItem
            // 
            this.fetchModelNamesToolStripMenuItem.Name = "fetchModelNamesToolStripMenuItem";
            this.fetchModelNamesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fetchModelNamesToolStripMenuItem.Text = "Fetch model names";
            this.fetchModelNamesToolStripMenuItem.Click += new System.EventHandler(this.fetchModelNamesToolStripMenuItem_Click);
            // 
            // fetchPatchNamesToolStripMenuItem
            // 
            this.fetchPatchNamesToolStripMenuItem.Name = "fetchPatchNamesToolStripMenuItem";
            this.fetchPatchNamesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fetchPatchNamesToolStripMenuItem.Text = "Fetch patch names";
            this.fetchPatchNamesToolStripMenuItem.Click += new System.EventHandler(this.fetchPatchNamesToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem});
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
            this.initializeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.initializeToolStripMenuItem.Text = "Initialize...";
            // 
            // patchesToolStripMenuItem
            // 
            this.patchesToolStripMenuItem.Name = "patchesToolStripMenuItem";
            this.patchesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patchesToolStripMenuItem.Text = "Patches";
            this.patchesToolStripMenuItem.Click += new System.EventHandler(this.patchesToolStripMenuItem_Click);
            // 
            // modelsToolStripMenuItem
            // 
            this.modelsToolStripMenuItem.Name = "modelsToolStripMenuItem";
            this.modelsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modelsToolStripMenuItem.Text = "Models";
            this.modelsToolStripMenuItem.Click += new System.EventHandler(this.modelsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutgoingCommandsToolStripMenuItem1,
            this.disableOutgoingCommandsToolStripMenuItem,
            this.toolStripSeparator1,
            this.preferencesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preferencesToolStripMenuItem.Image")));
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddComPorts});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1364, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ddComPorts
            // 
            this.ddComPorts.Image = ((System.Drawing.Image)(resources.GetObject("ddComPorts.Image")));
            this.ddComPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddComPorts.Name = "ddComPorts";
            this.ddComPorts.Size = new System.Drawing.Size(90, 22);
            this.ddComPorts.Text = "Connect...";
            this.ddComPorts.DropDownOpened += new System.EventHandler(this.ddComPorts_DropDownOpened);
            // 
            // logOutgoingCommandsToolStripMenuItem1
            // 
            this.logOutgoingCommandsToolStripMenuItem1.Checked = true;
            this.logOutgoingCommandsToolStripMenuItem1.CheckOnClick = true;
            this.logOutgoingCommandsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logOutgoingCommandsToolStripMenuItem1.Name = "logOutgoingCommandsToolStripMenuItem1";
            this.logOutgoingCommandsToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.logOutgoingCommandsToolStripMenuItem1.Text = "Log outgoing commands";
            // 
            // disableOutgoingCommandsToolStripMenuItem
            // 
            this.disableOutgoingCommandsToolStripMenuItem.CheckOnClick = true;
            this.disableOutgoingCommandsToolStripMenuItem.Name = "disableOutgoingCommandsToolStripMenuItem";
            this.disableOutgoingCommandsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.disableOutgoingCommandsToolStripMenuItem.Text = "Disable outgoing commands";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fetchModelNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripMenuItem fetchPatchNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton ddComPorts;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutgoingCommandsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableOutgoingCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

