namespace BuildserverMonitor
{
    partial class frmMain
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
            this.tbxPort = new MetroFramework.Controls.MetroTextBox();
            this.btnConnection = new MetroFramework.Controls.MetroButton();
            this.lblPort = new MetroFramework.Controls.MetroLabel();
            this.lblAddress = new MetroFramework.Controls.MetroLabel();
            this.tbxAddress = new MetroFramework.Controls.MetroTextBox();
            this.lstBox = new MetroFramework.Controls.MetroListView();
            this.tbxSendToServer = new MetroFramework.Controls.MetroTextBox();
            this.btnSendToServer = new MetroFramework.Controls.MetroButton();
            this.lblSendToServer = new MetroFramework.Controls.MetroLabel();
            this.ledBulb1 = new Bulb.LedBulb();
            this.ledBulb2 = new Bulb.LedBulb();
            this.ledBulb3 = new Bulb.LedBulb();
            this.ledBulb4 = new Bulb.LedBulb();
            this.cbxBuzzer = new MetroFramework.Controls.MetroCheckBox();
            this.cbxVibration = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // tbxPort
            // 
            // 
            // 
            // 
            this.tbxPort.CustomButton.Image = null;
            this.tbxPort.CustomButton.Location = new System.Drawing.Point(74, 2);
            this.tbxPort.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPort.CustomButton.Name = "";
            this.tbxPort.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxPort.CustomButton.TabIndex = 1;
            this.tbxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxPort.CustomButton.UseSelectable = true;
            this.tbxPort.CustomButton.Visible = false;
            this.tbxPort.Lines = new string[] {
        "1234"};
            this.tbxPort.Location = new System.Drawing.Point(812, 94);
            this.tbxPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPort.MaxLength = 32767;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.PasswordChar = '\0';
            this.tbxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxPort.SelectedText = "";
            this.tbxPort.SelectionLength = 0;
            this.tbxPort.SelectionStart = 0;
            this.tbxPort.ShortcutsEnabled = true;
            this.tbxPort.Size = new System.Drawing.Size(100, 28);
            this.tbxPort.TabIndex = 2;
            this.tbxPort.Text = "1234";
            this.tbxPort.UseSelectable = true;
            this.tbxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(920, 94);
            this.btnConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(116, 28);
            this.btnConnection.TabIndex = 3;
            this.btnConnection.Text = "Connect";
            this.btnConnection.UseSelectable = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(812, 66);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 20);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(545, 66);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 20);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address:";
            // 
            // tbxAddress
            // 
            // 
            // 
            // 
            this.tbxAddress.CustomButton.Image = null;
            this.tbxAddress.CustomButton.Location = new System.Drawing.Point(233, 2);
            this.tbxAddress.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAddress.CustomButton.Name = "";
            this.tbxAddress.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxAddress.CustomButton.TabIndex = 1;
            this.tbxAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxAddress.CustomButton.UseSelectable = true;
            this.tbxAddress.CustomButton.Visible = false;
            this.tbxAddress.Lines = new string[] {
        "localhost"};
            this.tbxAddress.Location = new System.Drawing.Point(545, 94);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAddress.MaxLength = 32767;
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.PasswordChar = '\0';
            this.tbxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxAddress.SelectedText = "";
            this.tbxAddress.SelectionLength = 0;
            this.tbxAddress.SelectionStart = 0;
            this.tbxAddress.ShortcutsEnabled = true;
            this.tbxAddress.Size = new System.Drawing.Size(259, 28);
            this.tbxAddress.TabIndex = 7;
            this.tbxAddress.Text = "localhost";
            this.tbxAddress.UseSelectable = true;
            this.tbxAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lstBox
            // 
            this.lstBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstBox.FullRowSelect = true;
            this.lstBox.Location = new System.Drawing.Point(31, 159);
            this.lstBox.Margin = new System.Windows.Forms.Padding(4);
            this.lstBox.Name = "lstBox";
            this.lstBox.OwnerDraw = true;
            this.lstBox.Size = new System.Drawing.Size(653, 451);
            this.lstBox.TabIndex = 9;
            this.lstBox.UseCompatibleStateImageBehavior = false;
            this.lstBox.UseSelectable = true;
            this.lstBox.View = System.Windows.Forms.View.List;
            // 
            // tbxSendToServer
            // 
            // 
            // 
            // 
            this.tbxSendToServer.CustomButton.Image = null;
            this.tbxSendToServer.CustomButton.Location = new System.Drawing.Point(505, 2);
            this.tbxSendToServer.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSendToServer.CustomButton.Name = "";
            this.tbxSendToServer.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxSendToServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxSendToServer.CustomButton.TabIndex = 1;
            this.tbxSendToServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxSendToServer.CustomButton.UseSelectable = true;
            this.tbxSendToServer.CustomButton.Visible = false;
            this.tbxSendToServer.Lines = new string[0];
            this.tbxSendToServer.Location = new System.Drawing.Point(31, 682);
            this.tbxSendToServer.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSendToServer.MaxLength = 32767;
            this.tbxSendToServer.Name = "tbxSendToServer";
            this.tbxSendToServer.PasswordChar = '\0';
            this.tbxSendToServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSendToServer.SelectedText = "";
            this.tbxSendToServer.SelectionLength = 0;
            this.tbxSendToServer.SelectionStart = 0;
            this.tbxSendToServer.ShortcutsEnabled = true;
            this.tbxSendToServer.Size = new System.Drawing.Size(531, 28);
            this.tbxSendToServer.TabIndex = 10;
            this.tbxSendToServer.UseSelectable = true;
            this.tbxSendToServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxSendToServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(569, 682);
            this.btnSendToServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(116, 28);
            this.btnSendToServer.TabIndex = 11;
            this.btnSendToServer.Text = "Send";
            this.btnSendToServer.UseSelectable = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // lblSendToServer
            // 
            this.lblSendToServer.AutoSize = true;
            this.lblSendToServer.Location = new System.Drawing.Point(32, 651);
            this.lblSendToServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSendToServer.Name = "lblSendToServer";
            this.lblSendToServer.Size = new System.Drawing.Size(104, 20);
            this.lblSendToServer.TabIndex = 12;
            this.lblSendToServer.Text = "Send to server:";
            this.lblSendToServer.UseMnemonic = false;
            // 
            // ledBulb1
            // 
            this.ledBulb1.Location = new System.Drawing.Point(812, 159);
            this.ledBulb1.Name = "ledBulb1";
            this.ledBulb1.On = false;
            this.ledBulb1.Size = new System.Drawing.Size(40, 40);
            this.ledBulb1.TabIndex = 13;
            this.ledBulb1.Text = "ledBulb1";
            // 
            // ledBulb2
            // 
            this.ledBulb2.Location = new System.Drawing.Point(858, 159);
            this.ledBulb2.Name = "ledBulb2";
            this.ledBulb2.On = false;
            this.ledBulb2.Size = new System.Drawing.Size(40, 40);
            this.ledBulb2.TabIndex = 14;
            this.ledBulb2.Text = "ledBulb2";
            // 
            // ledBulb3
            // 
            this.ledBulb3.Location = new System.Drawing.Point(904, 159);
            this.ledBulb3.Name = "ledBulb3";
            this.ledBulb3.On = false;
            this.ledBulb3.Size = new System.Drawing.Size(40, 40);
            this.ledBulb3.TabIndex = 15;
            this.ledBulb3.Text = "ledBulb3";
            // 
            // ledBulb4
            // 
            this.ledBulb4.Location = new System.Drawing.Point(950, 159);
            this.ledBulb4.Name = "ledBulb4";
            this.ledBulb4.On = false;
            this.ledBulb4.Size = new System.Drawing.Size(40, 40);
            this.ledBulb4.TabIndex = 16;
            this.ledBulb4.Text = "ledBulb4";
            // 
            // cbxBuzzer
            // 
            this.cbxBuzzer.AutoSize = true;
            this.cbxBuzzer.Enabled = false;
            this.cbxBuzzer.Location = new System.Drawing.Point(812, 246);
            this.cbxBuzzer.Name = "cbxBuzzer";
            this.cbxBuzzer.Size = new System.Drawing.Size(68, 17);
            this.cbxBuzzer.TabIndex = 17;
            this.cbxBuzzer.Text = "Buzzing";
            this.cbxBuzzer.UseSelectable = true;
            // 
            // cbxVibration
            // 
            this.cbxVibration.AutoSize = true;
            this.cbxVibration.Enabled = false;
            this.cbxVibration.Location = new System.Drawing.Point(812, 269);
            this.cbxVibration.Name = "cbxVibration";
            this.cbxVibration.Size = new System.Drawing.Size(77, 17);
            this.cbxVibration.TabIndex = 18;
            this.cbxVibration.Text = "Vibrating";
            this.cbxVibration.UseSelectable = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.cbxVibration);
            this.Controls.Add(this.cbxBuzzer);
            this.Controls.Add(this.ledBulb4);
            this.Controls.Add(this.ledBulb3);
            this.Controls.Add(this.ledBulb2);
            this.Controls.Add(this.ledBulb1);
            this.Controls.Add(this.lblSendToServer);
            this.Controls.Add(this.btnSendToServer);
            this.Controls.Add(this.tbxSendToServer);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(853, 591);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Buildserver Monitor - Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbxPort;
        private MetroFramework.Controls.MetroButton btnConnection;
        private MetroFramework.Controls.MetroLabel lblPort;
        private MetroFramework.Controls.MetroLabel lblAddress;
        private MetroFramework.Controls.MetroTextBox tbxAddress;
        private MetroFramework.Controls.MetroListView lstBox;
        private MetroFramework.Controls.MetroTextBox tbxSendToServer;
        private MetroFramework.Controls.MetroButton btnSendToServer;
        private MetroFramework.Controls.MetroLabel lblSendToServer;
        private Bulb.LedBulb ledBulb1;
        private Bulb.LedBulb ledBulb2;
        private Bulb.LedBulb ledBulb3;
        private Bulb.LedBulb ledBulb4;
        private MetroFramework.Controls.MetroCheckBox cbxBuzzer;
        private MetroFramework.Controls.MetroCheckBox cbxVibration;
    }
}

