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
            this.SuspendLayout();
            // 
            // lblNumberOfConnectedClients
            // 
            this.lblNumberOfConnectedClients.AutoSize = true;
            this.lblNumberOfConnectedClients.Location = new System.Drawing.Point(23, 80);
            this.lblNumberOfConnectedClients.Name = "lblNumberOfConnectedClients";
            this.lblNumberOfConnectedClients.Size = new System.Drawing.Size(180, 19);
            this.lblNumberOfConnectedClients.TabIndex = 0;
            this.lblNumberOfConnectedClients.Text = "Number of connected clients:";
            // 
            // lblNumberOfConnectedClientsValue
            // 
            this.lblNumberOfConnectedClientsValue.AutoSize = true;
            this.lblNumberOfConnectedClientsValue.Location = new System.Drawing.Point(209, 80);
            this.lblNumberOfConnectedClientsValue.Name = "lblNumberOfConnectedClientsValue";
            this.lblNumberOfConnectedClientsValue.Size = new System.Drawing.Size(0, 0);
            this.lblNumberOfConnectedClientsValue.TabIndex = 1;
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
            this.tbxPort.Lines = new string[0];
            this.tbxPort.Location = new System.Drawing.Point(621, 76);
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
            this.tbxPort.UseSelectable = true;
            this.tbxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(702, 76);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 3;
            this.btnConnection.Text = "Start";
            this.btnConnection.UseSelectable = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblNumberOfConnectedClientsValue);
            this.Controls.Add(this.lblNumberOfConnectedClients);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
            this.Text = "Buildserver Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNumberOfConnectedClients;
        private MetroFramework.Controls.MetroLabel lblNumberOfConnectedClientsValue;
        private MetroFramework.Controls.MetroTextBox tbxPort;
        private MetroFramework.Controls.MetroButton btnConnection;

    }
}

