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
            this.lbxMessages = new MetroFramework.Controls.MetroListView();
            this.tbxSendToServer = new MetroFramework.Controls.MetroTextBox();
            this.btnSendToServer = new MetroFramework.Controls.MetroButton();
            this.lblSendToServer = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tbxPort
            // 
            // 
            // 
            // 
            this.tbxPort.CustomButton.Image = null;
            this.tbxPort.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.tbxPort.CustomButton.Name = "";
            this.tbxPort.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxPort.CustomButton.TabIndex = 1;
            this.tbxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxPort.CustomButton.UseSelectable = true;
            this.tbxPort.CustomButton.Visible = false;
            this.tbxPort.Lines = new string[] {
        "1234"};
            this.tbxPort.Location = new System.Drawing.Point(609, 76);
            this.tbxPort.MaxLength = 32767;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.PasswordChar = '\0';
            this.tbxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxPort.SelectedText = "";
            this.tbxPort.SelectionLength = 0;
            this.tbxPort.SelectionStart = 0;
            this.tbxPort.ShortcutsEnabled = true;
            this.tbxPort.Size = new System.Drawing.Size(75, 23);
            this.tbxPort.TabIndex = 2;
            this.tbxPort.Text = "1234";
            this.tbxPort.UseSelectable = true;
            this.tbxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(690, 76);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(87, 23);
            this.btnConnection.TabIndex = 3;
            this.btnConnection.Text = "Connect";
            this.btnConnection.UseSelectable = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(609, 54);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 19);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(409, 54);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 19);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address:";
            // 
            // tbxAddress
            // 
            // 
            // 
            // 
            this.tbxAddress.CustomButton.Image = null;
            this.tbxAddress.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.tbxAddress.CustomButton.Name = "";
            this.tbxAddress.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbxAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxAddress.CustomButton.TabIndex = 1;
            this.tbxAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxAddress.CustomButton.UseSelectable = true;
            this.tbxAddress.CustomButton.Visible = false;
            this.tbxAddress.Lines = new string[] {
        "localhost"};
            this.tbxAddress.Location = new System.Drawing.Point(409, 76);
            this.tbxAddress.MaxLength = 32767;
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.PasswordChar = '\0';
            this.tbxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxAddress.SelectedText = "";
            this.tbxAddress.SelectionLength = 0;
            this.tbxAddress.SelectionStart = 0;
            this.tbxAddress.ShortcutsEnabled = true;
            this.tbxAddress.Size = new System.Drawing.Size(194, 23);
            this.tbxAddress.TabIndex = 7;
            this.tbxAddress.Text = "localhost";
            this.tbxAddress.UseSelectable = true;
            this.tbxAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbxMessages
            // 
            this.lbxMessages.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbxMessages.FullRowSelect = true;
            this.lbxMessages.Location = new System.Drawing.Point(23, 129);
            this.lbxMessages.Name = "lbxMessages";
            this.lbxMessages.OwnerDraw = true;
            this.lbxMessages.Size = new System.Drawing.Size(491, 367);
            this.lbxMessages.TabIndex = 9;
            this.lbxMessages.UseCompatibleStateImageBehavior = false;
            this.lbxMessages.UseSelectable = true;
            // 
            // tbxSendToServer
            // 
            // 
            // 
            // 
            this.tbxSendToServer.CustomButton.Image = null;
            this.tbxSendToServer.CustomButton.Location = new System.Drawing.Point(376, 1);
            this.tbxSendToServer.CustomButton.Name = "";
            this.tbxSendToServer.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbxSendToServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxSendToServer.CustomButton.TabIndex = 1;
            this.tbxSendToServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxSendToServer.CustomButton.UseSelectable = true;
            this.tbxSendToServer.CustomButton.Visible = false;
            this.tbxSendToServer.Lines = new string[0];
            this.tbxSendToServer.Location = new System.Drawing.Point(23, 554);
            this.tbxSendToServer.MaxLength = 32767;
            this.tbxSendToServer.Name = "tbxSendToServer";
            this.tbxSendToServer.PasswordChar = '\0';
            this.tbxSendToServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSendToServer.SelectedText = "";
            this.tbxSendToServer.SelectionLength = 0;
            this.tbxSendToServer.SelectionStart = 0;
            this.tbxSendToServer.ShortcutsEnabled = true;
            this.tbxSendToServer.Size = new System.Drawing.Size(398, 23);
            this.tbxSendToServer.TabIndex = 10;
            this.tbxSendToServer.UseSelectable = true;
            this.tbxSendToServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxSendToServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(427, 554);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(87, 23);
            this.btnSendToServer.TabIndex = 11;
            this.btnSendToServer.Text = "Send";
            this.btnSendToServer.UseSelectable = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // lblSendToServer
            // 
            this.lblSendToServer.AutoSize = true;
            this.lblSendToServer.Location = new System.Drawing.Point(24, 529);
            this.lblSendToServer.Name = "lblSendToServer";
            this.lblSendToServer.Size = new System.Drawing.Size(98, 19);
            this.lblSendToServer.TabIndex = 12;
            this.lblSendToServer.Text = "Send to server:";
            this.lblSendToServer.UseMnemonic = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblSendToServer);
            this.Controls.Add(this.btnSendToServer);
            this.Controls.Add(this.tbxSendToServer);
            this.Controls.Add(this.lbxMessages);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
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
        private MetroFramework.Controls.MetroListView lbxMessages;
        private MetroFramework.Controls.MetroTextBox tbxSendToServer;
        private MetroFramework.Controls.MetroButton btnSendToServer;
        private MetroFramework.Controls.MetroLabel lblSendToServer;

    }
}

