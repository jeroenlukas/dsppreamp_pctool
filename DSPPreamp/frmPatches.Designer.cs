namespace DSPPreamp
{
    partial class frmPatches
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
            this.knobGain = new KnobControl.KnobControl();
            this.knobLow = new KnobControl.KnobControl();
            this.knobMid = new KnobControl.KnobControl();
            this.knobPresence = new KnobControl.KnobControl();
            this.knobHigh = new KnobControl.KnobControl();
            this.knobVolume = new KnobControl.KnobControl();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGoToModel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // knobGain
            // 
            this.knobGain.BackColor = System.Drawing.Color.White;
            this.knobGain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.knobGain.EndAngle = 405F;
            this.knobGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobGain.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobGain.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobGain.KnobBackColor = System.Drawing.Color.Gray;
            this.knobGain.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobGain.LargeChange = 5;
            this.knobGain.Location = new System.Drawing.Point(13, 19);
            this.knobGain.Maximum = 100;
            this.knobGain.Minimum = 0;
            this.knobGain.Name = "knobGain";
            this.knobGain.PointerColor = System.Drawing.Color.Black;
            this.knobGain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobGain.ScaleColor = System.Drawing.Color.Black;
            this.knobGain.ScaleDivisions = 11;
            this.knobGain.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobGain.ScaleFontAutoSize = false;
            this.knobGain.ScaleSubDivisions = 4;
            this.knobGain.ShowLargeScale = true;
            this.knobGain.ShowSmallScale = false;
            this.knobGain.Size = new System.Drawing.Size(136, 136);
            this.knobGain.SmallChange = 1;
            this.knobGain.StartAngle = 135F;
            this.knobGain.TabIndex = 2;
            this.knobGain.Value = 50;
            this.knobGain.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobGain_ValueChanged);
            // 
            // knobLow
            // 
            this.knobLow.BackColor = System.Drawing.Color.White;
            this.knobLow.EndAngle = 405F;
            this.knobLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobLow.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobLow.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobLow.KnobBackColor = System.Drawing.Color.Gray;
            this.knobLow.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobLow.LargeChange = 5;
            this.knobLow.Location = new System.Drawing.Point(6, 19);
            this.knobLow.Maximum = 100;
            this.knobLow.Minimum = 0;
            this.knobLow.Name = "knobLow";
            this.knobLow.PointerColor = System.Drawing.Color.Black;
            this.knobLow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobLow.ScaleColor = System.Drawing.Color.Black;
            this.knobLow.ScaleDivisions = 11;
            this.knobLow.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobLow.ScaleFontAutoSize = false;
            this.knobLow.ScaleSubDivisions = 4;
            this.knobLow.ShowLargeScale = true;
            this.knobLow.ShowSmallScale = false;
            this.knobLow.Size = new System.Drawing.Size(136, 136);
            this.knobLow.SmallChange = 1;
            this.knobLow.StartAngle = 135F;
            this.knobLow.TabIndex = 23;
            this.knobLow.Value = 50;
            this.knobLow.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobLow_ValueChanged_1);
            // 
            // knobMid
            // 
            this.knobMid.BackColor = System.Drawing.Color.White;
            this.knobMid.EndAngle = 405F;
            this.knobMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobMid.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobMid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobMid.KnobBackColor = System.Drawing.Color.Gray;
            this.knobMid.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobMid.LargeChange = 5;
            this.knobMid.Location = new System.Drawing.Point(148, 19);
            this.knobMid.Maximum = 100;
            this.knobMid.Minimum = 0;
            this.knobMid.Name = "knobMid";
            this.knobMid.PointerColor = System.Drawing.Color.Black;
            this.knobMid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobMid.ScaleColor = System.Drawing.Color.Black;
            this.knobMid.ScaleDivisions = 11;
            this.knobMid.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobMid.ScaleFontAutoSize = false;
            this.knobMid.ScaleSubDivisions = 4;
            this.knobMid.ShowLargeScale = true;
            this.knobMid.ShowSmallScale = false;
            this.knobMid.Size = new System.Drawing.Size(136, 136);
            this.knobMid.SmallChange = 1;
            this.knobMid.StartAngle = 135F;
            this.knobMid.TabIndex = 24;
            this.knobMid.Value = 50;
            this.knobMid.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobMid_ValueChanged_1);
            // 
            // knobPresence
            // 
            this.knobPresence.BackColor = System.Drawing.Color.White;
            this.knobPresence.EndAngle = 405F;
            this.knobPresence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobPresence.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobPresence.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobPresence.KnobBackColor = System.Drawing.Color.Gray;
            this.knobPresence.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobPresence.LargeChange = 5;
            this.knobPresence.Location = new System.Drawing.Point(432, 19);
            this.knobPresence.Maximum = 100;
            this.knobPresence.Minimum = 0;
            this.knobPresence.Name = "knobPresence";
            this.knobPresence.PointerColor = System.Drawing.Color.Black;
            this.knobPresence.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobPresence.ScaleColor = System.Drawing.Color.Black;
            this.knobPresence.ScaleDivisions = 11;
            this.knobPresence.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobPresence.ScaleFontAutoSize = false;
            this.knobPresence.ScaleSubDivisions = 4;
            this.knobPresence.ShowLargeScale = true;
            this.knobPresence.ShowSmallScale = false;
            this.knobPresence.Size = new System.Drawing.Size(136, 136);
            this.knobPresence.SmallChange = 1;
            this.knobPresence.StartAngle = 135F;
            this.knobPresence.TabIndex = 26;
            this.knobPresence.Value = 50;
            this.knobPresence.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobPresence_ValueChanged_1);
            // 
            // knobHigh
            // 
            this.knobHigh.BackColor = System.Drawing.Color.White;
            this.knobHigh.EndAngle = 405F;
            this.knobHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobHigh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobHigh.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobHigh.KnobBackColor = System.Drawing.Color.Gray;
            this.knobHigh.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobHigh.LargeChange = 5;
            this.knobHigh.Location = new System.Drawing.Point(290, 19);
            this.knobHigh.Maximum = 100;
            this.knobHigh.Minimum = 0;
            this.knobHigh.Name = "knobHigh";
            this.knobHigh.PointerColor = System.Drawing.Color.Black;
            this.knobHigh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobHigh.ScaleColor = System.Drawing.Color.Black;
            this.knobHigh.ScaleDivisions = 11;
            this.knobHigh.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobHigh.ScaleFontAutoSize = false;
            this.knobHigh.ScaleSubDivisions = 4;
            this.knobHigh.ShowLargeScale = true;
            this.knobHigh.ShowSmallScale = false;
            this.knobHigh.Size = new System.Drawing.Size(136, 136);
            this.knobHigh.SmallChange = 1;
            this.knobHigh.StartAngle = 135F;
            this.knobHigh.TabIndex = 25;
            this.knobHigh.Value = 50;
            this.knobHigh.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobHigh_ValueChanged);
            // 
            // knobVolume
            // 
            this.knobVolume.BackColor = System.Drawing.Color.White;
            this.knobVolume.EndAngle = 405F;
            this.knobVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobVolume.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.knobVolume.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobVolume.KnobBackColor = System.Drawing.Color.Gray;
            this.knobVolume.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobVolume.LargeChange = 5;
            this.knobVolume.Location = new System.Drawing.Point(6, 19);
            this.knobVolume.Maximum = 100;
            this.knobVolume.Minimum = 0;
            this.knobVolume.Name = "knobVolume";
            this.knobVolume.PointerColor = System.Drawing.Color.Black;
            this.knobVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.knobVolume.ScaleColor = System.Drawing.Color.Black;
            this.knobVolume.ScaleDivisions = 11;
            this.knobVolume.ScaleFont = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobVolume.ScaleFontAutoSize = false;
            this.knobVolume.ScaleSubDivisions = 4;
            this.knobVolume.ShowLargeScale = true;
            this.knobVolume.ShowSmallScale = false;
            this.knobVolume.Size = new System.Drawing.Size(136, 136);
            this.knobVolume.SmallChange = 1;
            this.knobVolume.StartAngle = 135F;
            this.knobVolume.TabIndex = 27;
            this.knobVolume.Value = 50;
            this.knobVolume.ValueChanged += new KnobControl.ValueChangedEventHandler(this.knobVolume_ValueChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.knobVolume);
            this.groupBox7.Location = new System.Drawing.Point(778, 76);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(153, 208);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(45, 164);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 18);
            this.label22.TabIndex = 17;
            this.label22.Text = "Volume";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.knobGain);
            this.groupBox6.Location = new System.Drawing.Point(35, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(155, 208);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gain";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.knobPresence);
            this.groupBox5.Controls.Add(this.knobMid);
            this.groupBox5.Controls.Add(this.knobHigh);
            this.groupBox5.Controls.Add(this.knobLow);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Location = new System.Drawing.Point(196, 76);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(576, 208);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(198, 164);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 18);
            this.label19.TabIndex = 14;
            this.label19.Text = "Mid";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(340, 164);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 18);
            this.label20.TabIndex = 15;
            this.label20.Text = "High";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(53, 164);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 18);
            this.label18.TabIndex = 13;
            this.label18.Text = "Low";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(464, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 18);
            this.label21.TabIndex = 16;
            this.label21.Text = "Presence";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(856, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Store";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnGoToModel
            // 
            this.btnGoToModel.Location = new System.Drawing.Point(226, 47);
            this.btnGoToModel.Name = "btnGoToModel";
            this.btnGoToModel.Size = new System.Drawing.Size(24, 23);
            this.btnGoToModel.TabIndex = 33;
            this.btnGoToModel.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "M06 SLO100"});
            this.comboBox1.Location = new System.Drawing.Point(99, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Model:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 29);
            this.textBox1.TabIndex = 35;
            this.textBox1.Text = "Dly Solo";
            // 
            // frmPatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 417);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGoToModel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPatches";
            this.Text = "Patches";
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KnobControl.KnobControl knobGain;
        private KnobControl.KnobControl knobLow;
        private KnobControl.KnobControl knobMid;
        private KnobControl.KnobControl knobPresence;
        private KnobControl.KnobControl knobHigh;
        private KnobControl.KnobControl knobVolume;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGoToModel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}