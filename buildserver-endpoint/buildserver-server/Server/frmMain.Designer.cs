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
            this.tbxMessages = new MetroFramework.Controls.MetroTextBox();
            this.lblPort = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblNumberOfConnectedClients
            // 
            this.lblNumberOfConnectedClients.AutoSize = true;
            this.lblNumberOfConnectedClients.Location = new System.Drawing.Point(23, 80);
            this.lblNumberOfConnectedClients.Name = "lblNumberOfConnectedClients";
            this.lblNumberOfConnectedClients.Size = new System.Drawing.Size(180, 19);
            this.lblNumberOfConnectedClients.TabIndex = 3;
            this.lblNumberOfConnectedClients.Text = "Number of connected clients:";
            // 
            // lblNumberOfConnectedClientsValue
            // 
            this.lblNumberOfConnectedClientsValue.AutoSize = true;
            this.lblNumberOfConnectedClientsValue.Location = new System.Drawing.Point(209, 80);
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
            this.tbxPort.TabIndex = 0;
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
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Connect";
            this.btnConnection.UseSelectable = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // tbxMessages
            // 
            // 
            // 
            // 
            this.tbxMessages.CustomButton.Image = null;
            this.tbxMessages.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.tbxMessages.CustomButton.Name = "";
            this.tbxMessages.CustomButton.Size = new System.Drawing.Size(459, 459);
            this.tbxMessages.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxMessages.CustomButton.TabIndex = 1;
            this.tbxMessages.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxMessages.CustomButton.UseSelectable = true;
            this.tbxMessages.CustomButton.Visible = false;
            this.tbxMessages.Lines = new string[0];
            this.tbxMessages.Location = new System.Drawing.Point(23, 116);
            this.tbxMessages.MaxLength = 32767;
            this.tbxMessages.Multiline = true;
            this.tbxMessages.Name = "tbxMessages";
            this.tbxMessages.PasswordChar = '\0';
            this.tbxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessages.SelectedText = "";
            this.tbxMessages.SelectionLength = 0;
            this.tbxMessages.SelectionStart = 0;
            this.tbxMessages.ShortcutsEnabled = true;
            this.tbxMessages.Size = new System.Drawing.Size(488, 461);
            this.tbxMessages.TabIndex = 2;
            this.tbxMessages.UseSelectable = true;
            this.tbxMessages.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxMessages.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(609, 54);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 19);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.tbxMessages);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblNumberOfConnectedClientsValue);
            this.Controls.Add(this.lblNumberOfConnectedClients);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
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
        private MetroFramework.Controls.MetroTextBox tbxMessages;
        private MetroFramework.Controls.MetroLabel lblPort;

    }
}

