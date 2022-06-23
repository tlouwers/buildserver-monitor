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
            this.lblNumberOfConnectedClients = new MetroFramework.Controls.MetroLabel();
            this.lblNumberOfConnectedClientsValue = new MetroFramework.Controls.MetroLabel();
            this.tbxPort = new MetroFramework.Controls.MetroTextBox();
            this.btnConnection = new MetroFramework.Controls.MetroButton();
            this.lblPort = new MetroFramework.Controls.MetroLabel();
            this.lstBox = new MetroFramework.Controls.MetroListView();
            this.btnVersionGet = new MetroFramework.Controls.MetroButton();
            this.btnLedsGet = new MetroFramework.Controls.MetroButton();
            this.btnLedsSet = new MetroFramework.Controls.MetroButton();
            this.cbxLedId = new MetroFramework.Controls.MetroComboBox();
            this.btnLedsGetAmount = new MetroFramework.Controls.MetroButton();
            this.cbxLedColor = new MetroFramework.Controls.MetroComboBox();
            this.lblLedColor = new MetroFramework.Controls.MetroLabel();
            this.lblLedId = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblNumberOfConnectedClients
            // 
            this.lblNumberOfConnectedClients.AutoSize = true;
            this.lblNumberOfConnectedClients.Location = new System.Drawing.Point(31, 98);
            this.lblNumberOfConnectedClients.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfConnectedClients.Name = "lblNumberOfConnectedClients";
            this.lblNumberOfConnectedClients.Size = new System.Drawing.Size(193, 20);
            this.lblNumberOfConnectedClients.TabIndex = 3;
            this.lblNumberOfConnectedClients.Text = "Number of connected clients:";
            // 
            // lblNumberOfConnectedClientsValue
            // 
            this.lblNumberOfConnectedClientsValue.AutoSize = true;
            this.lblNumberOfConnectedClientsValue.Location = new System.Drawing.Point(279, 98);
            this.lblNumberOfConnectedClientsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfConnectedClientsValue.Name = "lblNumberOfConnectedClientsValue";
            this.lblNumberOfConnectedClientsValue.Size = new System.Drawing.Size(0, 0);
            this.lblNumberOfConnectedClientsValue.TabIndex = 4;
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
            this.tbxPort.TabIndex = 0;
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
            this.btnConnection.TabIndex = 1;
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
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port:";
            // 
            // lstBox
            // 
            this.lstBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstBox.FullRowSelect = true;
            this.lstBox.Location = new System.Drawing.Point(31, 148);
            this.lstBox.Margin = new System.Windows.Forms.Padding(4);
            this.lstBox.Name = "lstBox";
            this.lstBox.OwnerDraw = true;
            this.lstBox.ShowGroups = false;
            this.lstBox.Size = new System.Drawing.Size(629, 211);
            this.lstBox.TabIndex = 6;
            this.lstBox.UseCompatibleStateImageBehavior = false;
            this.lstBox.UseSelectable = true;
            this.lstBox.View = System.Windows.Forms.View.List;
            // 
            // btnVersionGet
            // 
            this.btnVersionGet.Location = new System.Drawing.Point(717, 188);
            this.btnVersionGet.Margin = new System.Windows.Forms.Padding(4);
            this.btnVersionGet.Name = "btnVersionGet";
            this.btnVersionGet.Size = new System.Drawing.Size(116, 28);
            this.btnVersionGet.TabIndex = 8;
            this.btnVersionGet.Text = "Version Get";
            this.btnVersionGet.UseSelectable = true;
            this.btnVersionGet.Click += new System.EventHandler(this.btnVersionGet_Click);
            // 
            // btnLedsGet
            // 
            this.btnLedsGet.Location = new System.Drawing.Point(31, 440);
            this.btnLedsGet.Margin = new System.Windows.Forms.Padding(4);
            this.btnLedsGet.Name = "btnLedsGet";
            this.btnLedsGet.Size = new System.Drawing.Size(116, 28);
            this.btnLedsGet.TabIndex = 9;
            this.btnLedsGet.Text = "Leds Get";
            this.btnLedsGet.UseSelectable = true;
            this.btnLedsGet.Click += new System.EventHandler(this.btnLedsGet_Click);
            // 
            // btnLedsSet
            // 
            this.btnLedsSet.Location = new System.Drawing.Point(31, 476);
            this.btnLedsSet.Margin = new System.Windows.Forms.Padding(4);
            this.btnLedsSet.Name = "btnLedsSet";
            this.btnLedsSet.Size = new System.Drawing.Size(116, 28);
            this.btnLedsSet.TabIndex = 10;
            this.btnLedsSet.Text = "Leds Set";
            this.btnLedsSet.UseSelectable = true;
            this.btnLedsSet.Click += new System.EventHandler(this.btnLedsSet_Click);
            // 
            // cbxLedId
            // 
            this.cbxLedId.FormattingEnabled = true;
            this.cbxLedId.ItemHeight = 24;
            this.cbxLedId.Location = new System.Drawing.Point(154, 438);
            this.cbxLedId.Name = "cbxLedId";
            this.cbxLedId.Size = new System.Drawing.Size(121, 30);
            this.cbxLedId.TabIndex = 11;
            this.cbxLedId.UseSelectable = true;
            // 
            // btnLedsGetAmount
            // 
            this.btnLedsGetAmount.Location = new System.Drawing.Point(31, 404);
            this.btnLedsGetAmount.Margin = new System.Windows.Forms.Padding(4);
            this.btnLedsGetAmount.Name = "btnLedsGetAmount";
            this.btnLedsGetAmount.Size = new System.Drawing.Size(116, 28);
            this.btnLedsGetAmount.TabIndex = 12;
            this.btnLedsGetAmount.Text = "Leds Get Amount";
            this.btnLedsGetAmount.UseSelectable = true;
            this.btnLedsGetAmount.Click += new System.EventHandler(this.btnLedsGetAmount_Click);
            // 
            // cbxLedColor
            // 
            this.cbxLedColor.FormattingEnabled = true;
            this.cbxLedColor.ItemHeight = 24;
            this.cbxLedColor.Items.AddRange(new object[] {
            "Off",
            "Purple",
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "LightBlue",
            "Blue",
            "White"});
            this.cbxLedColor.Location = new System.Drawing.Point(281, 438);
            this.cbxLedColor.Name = "cbxLedColor";
            this.cbxLedColor.Size = new System.Drawing.Size(121, 30);
            this.cbxLedColor.TabIndex = 13;
            this.cbxLedColor.UseSelectable = true;
            // 
            // lblLedColor
            // 
            this.lblLedColor.AutoSize = true;
            this.lblLedColor.Location = new System.Drawing.Point(281, 412);
            this.lblLedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedColor.Name = "lblLedColor";
            this.lblLedColor.Size = new System.Drawing.Size(46, 20);
            this.lblLedColor.TabIndex = 14;
            this.lblLedColor.Text = "Color:";
            // 
            // lblLedId
            // 
            this.lblLedId.AutoSize = true;
            this.lblLedId.Location = new System.Drawing.Point(155, 412);
            this.lblLedId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedId.Name = "lblLedId";
            this.lblLedId.Size = new System.Drawing.Size(23, 20);
            this.lblLedId.TabIndex = 15;
            this.lblLedId.Text = "Id:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.lblLedId);
            this.Controls.Add(this.lblLedColor);
            this.Controls.Add(this.cbxLedColor);
            this.Controls.Add(this.btnLedsGetAmount);
            this.Controls.Add(this.cbxLedId);
            this.Controls.Add(this.btnLedsSet);
            this.Controls.Add(this.btnLedsGet);
            this.Controls.Add(this.btnVersionGet);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblNumberOfConnectedClientsValue);
            this.Controls.Add(this.lblNumberOfConnectedClients);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(853, 591);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Buildserver Monitor - Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNumberOfConnectedClients;
        private MetroFramework.Controls.MetroLabel lblNumberOfConnectedClientsValue;
        private MetroFramework.Controls.MetroTextBox tbxPort;
        private MetroFramework.Controls.MetroButton btnConnection;
        private MetroFramework.Controls.MetroLabel lblPort;
        private MetroFramework.Controls.MetroListView lstBox;
        private MetroFramework.Controls.MetroButton btnVersionGet;
        private MetroFramework.Controls.MetroButton btnLedsGet;
        private MetroFramework.Controls.MetroButton btnLedsSet;
        private MetroFramework.Controls.MetroComboBox cbxLedId;
        private MetroFramework.Controls.MetroButton btnLedsGetAmount;
        private MetroFramework.Controls.MetroComboBox cbxLedColor;
        private MetroFramework.Controls.MetroLabel lblLedColor;
        private MetroFramework.Controls.MetroLabel lblLedId;

    }
}

