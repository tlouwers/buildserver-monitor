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
            this.cbxLedsId = new MetroFramework.Controls.MetroComboBox();
            this.btnLedsGetAmount = new MetroFramework.Controls.MetroButton();
            this.cbxLedsColor = new MetroFramework.Controls.MetroComboBox();
            this.lblLedsColor = new MetroFramework.Controls.MetroLabel();
            this.lblLedsId = new MetroFramework.Controls.MetroLabel();
            this.btnBuzzerGet = new MetroFramework.Controls.MetroButton();
            this.btnBuzzerSet = new MetroFramework.Controls.MetroButton();
            this.tbxLedsTimeOn = new MetroFramework.Controls.MetroTextBox();
            this.tbxLedsTimeTotal = new MetroFramework.Controls.MetroTextBox();
            this.tbxLedsNrOfRepeats = new MetroFramework.Controls.MetroTextBox();
            this.lblLedsTimeOn = new MetroFramework.Controls.MetroLabel();
            this.lblLedsTimeTotal = new MetroFramework.Controls.MetroLabel();
            this.lblLedsNrOfRepeats = new MetroFramework.Controls.MetroLabel();
            this.lblLedsBrightness = new MetroFramework.Controls.MetroLabel();
            this.tbxLedsBrightness = new MetroFramework.Controls.MetroTextBox();
            this.lblBuzzerNrOfRepeats = new MetroFramework.Controls.MetroLabel();
            this.lblBuzzerTimeTotal = new MetroFramework.Controls.MetroLabel();
            this.lblBuzzerTimeOn = new MetroFramework.Controls.MetroLabel();
            this.tbxBuzzerNrOfRepeats = new MetroFramework.Controls.MetroTextBox();
            this.tbxBuzzerTimeTotal = new MetroFramework.Controls.MetroTextBox();
            this.tbxBuzzerTimeOn = new MetroFramework.Controls.MetroTextBox();
            this.lblVibrationNrOfRepeats = new MetroFramework.Controls.MetroLabel();
            this.lblVibrationTimeTotal = new MetroFramework.Controls.MetroLabel();
            this.lblVibrationTimeOn = new MetroFramework.Controls.MetroLabel();
            this.tbxVibrationNrOfRepeats = new MetroFramework.Controls.MetroTextBox();
            this.tbxVibrationTimeTotal = new MetroFramework.Controls.MetroTextBox();
            this.tbxVibrationTimeOn = new MetroFramework.Controls.MetroTextBox();
            this.btnVibrationSet = new MetroFramework.Controls.MetroButton();
            this.btnVibrationGet = new MetroFramework.Controls.MetroButton();
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
            this.tbxPort.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxPort.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPort.CustomButton.Name = "";
            this.tbxPort.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxPort.CustomButton.TabIndex = 1;
            this.tbxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxPort.CustomButton.UseSelectable = true;
            this.tbxPort.CustomButton.Visible = false;
            this.tbxPort.Lines = new string[] {
        "1234"};
            this.tbxPort.Location = new System.Drawing.Point(812, 94);
            this.tbxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lstBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBox.Name = "lstBox";
            this.lstBox.OwnerDraw = true;
            this.lstBox.ShowGroups = false;
            this.lstBox.Size = new System.Drawing.Size(1004, 181);
            this.lstBox.TabIndex = 6;
            this.lstBox.UseCompatibleStateImageBehavior = false;
            this.lstBox.UseSelectable = true;
            this.lstBox.View = System.Windows.Forms.View.List;
            // 
            // btnVersionGet
            // 
            this.btnVersionGet.Location = new System.Drawing.Point(31, 353);
            this.btnVersionGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVersionGet.Name = "btnVersionGet";
            this.btnVersionGet.Size = new System.Drawing.Size(116, 28);
            this.btnVersionGet.TabIndex = 8;
            this.btnVersionGet.Text = "Version Get";
            this.btnVersionGet.UseSelectable = true;
            this.btnVersionGet.Click += new System.EventHandler(this.btnVersionGet_Click);
            // 
            // btnLedsGet
            // 
            this.btnLedsGet.Location = new System.Drawing.Point(31, 441);
            this.btnLedsGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnLedsSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLedsSet.Name = "btnLedsSet";
            this.btnLedsSet.Size = new System.Drawing.Size(116, 28);
            this.btnLedsSet.TabIndex = 10;
            this.btnLedsSet.Text = "Leds Set";
            this.btnLedsSet.UseSelectable = true;
            this.btnLedsSet.Click += new System.EventHandler(this.btnLedsSet_Click);
            // 
            // cbxLedsId
            // 
            this.cbxLedsId.FormattingEnabled = true;
            this.cbxLedsId.ItemHeight = 24;
            this.cbxLedsId.Location = new System.Drawing.Point(155, 438);
            this.cbxLedsId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxLedsId.Name = "cbxLedsId";
            this.cbxLedsId.Size = new System.Drawing.Size(121, 30);
            this.cbxLedsId.TabIndex = 11;
            this.cbxLedsId.UseSelectable = true;
            // 
            // btnLedsGetAmount
            // 
            this.btnLedsGetAmount.Location = new System.Drawing.Point(31, 404);
            this.btnLedsGetAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLedsGetAmount.Name = "btnLedsGetAmount";
            this.btnLedsGetAmount.Size = new System.Drawing.Size(116, 28);
            this.btnLedsGetAmount.TabIndex = 12;
            this.btnLedsGetAmount.Text = "Leds Get Amount";
            this.btnLedsGetAmount.UseSelectable = true;
            this.btnLedsGetAmount.Click += new System.EventHandler(this.btnLedsGetAmount_Click);
            // 
            // cbxLedsColor
            // 
            this.cbxLedsColor.FormattingEnabled = true;
            this.cbxLedsColor.ItemHeight = 24;
            this.cbxLedsColor.Items.AddRange(new object[] {
            "Off",
            "Purple",
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "LightBlue",
            "Blue",
            "White"});
            this.cbxLedsColor.Location = new System.Drawing.Point(281, 438);
            this.cbxLedsColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxLedsColor.Name = "cbxLedsColor";
            this.cbxLedsColor.Size = new System.Drawing.Size(121, 30);
            this.cbxLedsColor.TabIndex = 13;
            this.cbxLedsColor.UseSelectable = true;
            // 
            // lblLedsColor
            // 
            this.lblLedsColor.AutoSize = true;
            this.lblLedsColor.Location = new System.Drawing.Point(281, 412);
            this.lblLedsColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsColor.Name = "lblLedsColor";
            this.lblLedsColor.Size = new System.Drawing.Size(46, 20);
            this.lblLedsColor.TabIndex = 14;
            this.lblLedsColor.Text = "Color:";
            // 
            // lblLedsId
            // 
            this.lblLedsId.AutoSize = true;
            this.lblLedsId.Location = new System.Drawing.Point(155, 412);
            this.lblLedsId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsId.Name = "lblLedsId";
            this.lblLedsId.Size = new System.Drawing.Size(23, 20);
            this.lblLedsId.TabIndex = 15;
            this.lblLedsId.Text = "Id:";
            // 
            // btnBuzzerGet
            // 
            this.btnBuzzerGet.Location = new System.Drawing.Point(31, 546);
            this.btnBuzzerGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuzzerGet.Name = "btnBuzzerGet";
            this.btnBuzzerGet.Size = new System.Drawing.Size(116, 28);
            this.btnBuzzerGet.TabIndex = 16;
            this.btnBuzzerGet.Text = "Buzzer Get";
            this.btnBuzzerGet.UseSelectable = true;
            this.btnBuzzerGet.Click += new System.EventHandler(this.btnBuzzerGet_Click);
            // 
            // btnBuzzerSet
            // 
            this.btnBuzzerSet.Location = new System.Drawing.Point(31, 582);
            this.btnBuzzerSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuzzerSet.Name = "btnBuzzerSet";
            this.btnBuzzerSet.Size = new System.Drawing.Size(116, 28);
            this.btnBuzzerSet.TabIndex = 17;
            this.btnBuzzerSet.Text = "Buzzer Set";
            this.btnBuzzerSet.UseSelectable = true;
            this.btnBuzzerSet.Click += new System.EventHandler(this.btnBuzzerSet_Click);
            // 
            // tbxLedsTimeOn
            // 
            // 
            // 
            // 
            this.tbxLedsTimeOn.CustomButton.Image = null;
            this.tbxLedsTimeOn.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxLedsTimeOn.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsTimeOn.CustomButton.Name = "";
            this.tbxLedsTimeOn.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxLedsTimeOn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxLedsTimeOn.CustomButton.TabIndex = 1;
            this.tbxLedsTimeOn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxLedsTimeOn.CustomButton.UseSelectable = true;
            this.tbxLedsTimeOn.CustomButton.Visible = false;
            this.tbxLedsTimeOn.Lines = new string[0];
            this.tbxLedsTimeOn.Location = new System.Drawing.Point(519, 441);
            this.tbxLedsTimeOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsTimeOn.MaxLength = 32767;
            this.tbxLedsTimeOn.Name = "tbxLedsTimeOn";
            this.tbxLedsTimeOn.PasswordChar = '\0';
            this.tbxLedsTimeOn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxLedsTimeOn.SelectedText = "";
            this.tbxLedsTimeOn.SelectionLength = 0;
            this.tbxLedsTimeOn.SelectionStart = 0;
            this.tbxLedsTimeOn.ShortcutsEnabled = true;
            this.tbxLedsTimeOn.Size = new System.Drawing.Size(100, 28);
            this.tbxLedsTimeOn.TabIndex = 18;
            this.tbxLedsTimeOn.UseSelectable = true;
            this.tbxLedsTimeOn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxLedsTimeOn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxLedsTimeTotal
            // 
            // 
            // 
            // 
            this.tbxLedsTimeTotal.CustomButton.Image = null;
            this.tbxLedsTimeTotal.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxLedsTimeTotal.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsTimeTotal.CustomButton.Name = "";
            this.tbxLedsTimeTotal.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxLedsTimeTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxLedsTimeTotal.CustomButton.TabIndex = 1;
            this.tbxLedsTimeTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxLedsTimeTotal.CustomButton.UseSelectable = true;
            this.tbxLedsTimeTotal.CustomButton.Visible = false;
            this.tbxLedsTimeTotal.Lines = new string[0];
            this.tbxLedsTimeTotal.Location = new System.Drawing.Point(627, 441);
            this.tbxLedsTimeTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsTimeTotal.MaxLength = 32767;
            this.tbxLedsTimeTotal.Name = "tbxLedsTimeTotal";
            this.tbxLedsTimeTotal.PasswordChar = '\0';
            this.tbxLedsTimeTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxLedsTimeTotal.SelectedText = "";
            this.tbxLedsTimeTotal.SelectionLength = 0;
            this.tbxLedsTimeTotal.SelectionStart = 0;
            this.tbxLedsTimeTotal.ShortcutsEnabled = true;
            this.tbxLedsTimeTotal.Size = new System.Drawing.Size(100, 28);
            this.tbxLedsTimeTotal.TabIndex = 19;
            this.tbxLedsTimeTotal.UseSelectable = true;
            this.tbxLedsTimeTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxLedsTimeTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxLedsNrOfRepeats
            // 
            // 
            // 
            // 
            this.tbxLedsNrOfRepeats.CustomButton.Image = null;
            this.tbxLedsNrOfRepeats.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxLedsNrOfRepeats.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsNrOfRepeats.CustomButton.Name = "";
            this.tbxLedsNrOfRepeats.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxLedsNrOfRepeats.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxLedsNrOfRepeats.CustomButton.TabIndex = 1;
            this.tbxLedsNrOfRepeats.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxLedsNrOfRepeats.CustomButton.UseSelectable = true;
            this.tbxLedsNrOfRepeats.CustomButton.Visible = false;
            this.tbxLedsNrOfRepeats.Lines = new string[0];
            this.tbxLedsNrOfRepeats.Location = new System.Drawing.Point(735, 441);
            this.tbxLedsNrOfRepeats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsNrOfRepeats.MaxLength = 32767;
            this.tbxLedsNrOfRepeats.Name = "tbxLedsNrOfRepeats";
            this.tbxLedsNrOfRepeats.PasswordChar = '\0';
            this.tbxLedsNrOfRepeats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxLedsNrOfRepeats.SelectedText = "";
            this.tbxLedsNrOfRepeats.SelectionLength = 0;
            this.tbxLedsNrOfRepeats.SelectionStart = 0;
            this.tbxLedsNrOfRepeats.ShortcutsEnabled = true;
            this.tbxLedsNrOfRepeats.Size = new System.Drawing.Size(100, 28);
            this.tbxLedsNrOfRepeats.TabIndex = 20;
            this.tbxLedsNrOfRepeats.UseSelectable = true;
            this.tbxLedsNrOfRepeats.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxLedsNrOfRepeats.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLedsTimeOn
            // 
            this.lblLedsTimeOn.AutoSize = true;
            this.lblLedsTimeOn.Location = new System.Drawing.Point(519, 412);
            this.lblLedsTimeOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsTimeOn.Name = "lblLedsTimeOn";
            this.lblLedsTimeOn.Size = new System.Drawing.Size(66, 20);
            this.lblLedsTimeOn.TabIndex = 21;
            this.lblLedsTimeOn.Text = "Time On:";
            // 
            // lblLedsTimeTotal
            // 
            this.lblLedsTimeTotal.AutoSize = true;
            this.lblLedsTimeTotal.Location = new System.Drawing.Point(627, 412);
            this.lblLedsTimeTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsTimeTotal.Name = "lblLedsTimeTotal";
            this.lblLedsTimeTotal.Size = new System.Drawing.Size(75, 20);
            this.lblLedsTimeTotal.TabIndex = 22;
            this.lblLedsTimeTotal.Text = "Time Total:";
            // 
            // lblLedsNrOfRepeats
            // 
            this.lblLedsNrOfRepeats.AutoSize = true;
            this.lblLedsNrOfRepeats.Location = new System.Drawing.Point(735, 412);
            this.lblLedsNrOfRepeats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsNrOfRepeats.Name = "lblLedsNrOfRepeats";
            this.lblLedsNrOfRepeats.Size = new System.Drawing.Size(100, 20);
            this.lblLedsNrOfRepeats.TabIndex = 23;
            this.lblLedsNrOfRepeats.Text = "Nr Of Repeats:";
            // 
            // lblLedsBrightness
            // 
            this.lblLedsBrightness.AutoSize = true;
            this.lblLedsBrightness.Location = new System.Drawing.Point(411, 412);
            this.lblLedsBrightness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLedsBrightness.Name = "lblLedsBrightness";
            this.lblLedsBrightness.Size = new System.Drawing.Size(76, 20);
            this.lblLedsBrightness.TabIndex = 25;
            this.lblLedsBrightness.Text = "Brightness:";
            // 
            // tbxLedsBrightness
            // 
            // 
            // 
            // 
            this.tbxLedsBrightness.CustomButton.Image = null;
            this.tbxLedsBrightness.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxLedsBrightness.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsBrightness.CustomButton.Name = "";
            this.tbxLedsBrightness.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxLedsBrightness.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxLedsBrightness.CustomButton.TabIndex = 1;
            this.tbxLedsBrightness.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxLedsBrightness.CustomButton.UseSelectable = true;
            this.tbxLedsBrightness.CustomButton.Visible = false;
            this.tbxLedsBrightness.Lines = new string[0];
            this.tbxLedsBrightness.Location = new System.Drawing.Point(411, 441);
            this.tbxLedsBrightness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLedsBrightness.MaxLength = 32767;
            this.tbxLedsBrightness.Name = "tbxLedsBrightness";
            this.tbxLedsBrightness.PasswordChar = '\0';
            this.tbxLedsBrightness.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxLedsBrightness.SelectedText = "";
            this.tbxLedsBrightness.SelectionLength = 0;
            this.tbxLedsBrightness.SelectionStart = 0;
            this.tbxLedsBrightness.ShortcutsEnabled = true;
            this.tbxLedsBrightness.Size = new System.Drawing.Size(100, 28);
            this.tbxLedsBrightness.TabIndex = 24;
            this.tbxLedsBrightness.UseSelectable = true;
            this.tbxLedsBrightness.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxLedsBrightness.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblBuzzerNrOfRepeats
            // 
            this.lblBuzzerNrOfRepeats.AutoSize = true;
            this.lblBuzzerNrOfRepeats.Location = new System.Drawing.Point(371, 518);
            this.lblBuzzerNrOfRepeats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuzzerNrOfRepeats.Name = "lblBuzzerNrOfRepeats";
            this.lblBuzzerNrOfRepeats.Size = new System.Drawing.Size(100, 20);
            this.lblBuzzerNrOfRepeats.TabIndex = 31;
            this.lblBuzzerNrOfRepeats.Text = "Nr Of Repeats:";
            // 
            // lblBuzzerTimeTotal
            // 
            this.lblBuzzerTimeTotal.AutoSize = true;
            this.lblBuzzerTimeTotal.Location = new System.Drawing.Point(263, 518);
            this.lblBuzzerTimeTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuzzerTimeTotal.Name = "lblBuzzerTimeTotal";
            this.lblBuzzerTimeTotal.Size = new System.Drawing.Size(75, 20);
            this.lblBuzzerTimeTotal.TabIndex = 30;
            this.lblBuzzerTimeTotal.Text = "Time Total:";
            // 
            // lblBuzzerTimeOn
            // 
            this.lblBuzzerTimeOn.AutoSize = true;
            this.lblBuzzerTimeOn.Location = new System.Drawing.Point(155, 518);
            this.lblBuzzerTimeOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuzzerTimeOn.Name = "lblBuzzerTimeOn";
            this.lblBuzzerTimeOn.Size = new System.Drawing.Size(66, 20);
            this.lblBuzzerTimeOn.TabIndex = 29;
            this.lblBuzzerTimeOn.Text = "Time On:";
            // 
            // tbxBuzzerNrOfRepeats
            // 
            // 
            // 
            // 
            this.tbxBuzzerNrOfRepeats.CustomButton.Image = null;
            this.tbxBuzzerNrOfRepeats.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxBuzzerNrOfRepeats.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerNrOfRepeats.CustomButton.Name = "";
            this.tbxBuzzerNrOfRepeats.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxBuzzerNrOfRepeats.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxBuzzerNrOfRepeats.CustomButton.TabIndex = 1;
            this.tbxBuzzerNrOfRepeats.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxBuzzerNrOfRepeats.CustomButton.UseSelectable = true;
            this.tbxBuzzerNrOfRepeats.CustomButton.Visible = false;
            this.tbxBuzzerNrOfRepeats.Lines = new string[0];
            this.tbxBuzzerNrOfRepeats.Location = new System.Drawing.Point(371, 546);
            this.tbxBuzzerNrOfRepeats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerNrOfRepeats.MaxLength = 32767;
            this.tbxBuzzerNrOfRepeats.Name = "tbxBuzzerNrOfRepeats";
            this.tbxBuzzerNrOfRepeats.PasswordChar = '\0';
            this.tbxBuzzerNrOfRepeats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBuzzerNrOfRepeats.SelectedText = "";
            this.tbxBuzzerNrOfRepeats.SelectionLength = 0;
            this.tbxBuzzerNrOfRepeats.SelectionStart = 0;
            this.tbxBuzzerNrOfRepeats.ShortcutsEnabled = true;
            this.tbxBuzzerNrOfRepeats.Size = new System.Drawing.Size(100, 28);
            this.tbxBuzzerNrOfRepeats.TabIndex = 28;
            this.tbxBuzzerNrOfRepeats.UseSelectable = true;
            this.tbxBuzzerNrOfRepeats.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxBuzzerNrOfRepeats.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxBuzzerTimeTotal
            // 
            // 
            // 
            // 
            this.tbxBuzzerTimeTotal.CustomButton.Image = null;
            this.tbxBuzzerTimeTotal.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxBuzzerTimeTotal.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerTimeTotal.CustomButton.Name = "";
            this.tbxBuzzerTimeTotal.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxBuzzerTimeTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxBuzzerTimeTotal.CustomButton.TabIndex = 1;
            this.tbxBuzzerTimeTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxBuzzerTimeTotal.CustomButton.UseSelectable = true;
            this.tbxBuzzerTimeTotal.CustomButton.Visible = false;
            this.tbxBuzzerTimeTotal.Lines = new string[0];
            this.tbxBuzzerTimeTotal.Location = new System.Drawing.Point(263, 545);
            this.tbxBuzzerTimeTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerTimeTotal.MaxLength = 32767;
            this.tbxBuzzerTimeTotal.Name = "tbxBuzzerTimeTotal";
            this.tbxBuzzerTimeTotal.PasswordChar = '\0';
            this.tbxBuzzerTimeTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBuzzerTimeTotal.SelectedText = "";
            this.tbxBuzzerTimeTotal.SelectionLength = 0;
            this.tbxBuzzerTimeTotal.SelectionStart = 0;
            this.tbxBuzzerTimeTotal.ShortcutsEnabled = true;
            this.tbxBuzzerTimeTotal.Size = new System.Drawing.Size(100, 28);
            this.tbxBuzzerTimeTotal.TabIndex = 27;
            this.tbxBuzzerTimeTotal.UseSelectable = true;
            this.tbxBuzzerTimeTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxBuzzerTimeTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxBuzzerTimeOn
            // 
            // 
            // 
            // 
            this.tbxBuzzerTimeOn.CustomButton.Image = null;
            this.tbxBuzzerTimeOn.CustomButton.Location = new System.Drawing.Point(99, 2);
            this.tbxBuzzerTimeOn.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerTimeOn.CustomButton.Name = "";
            this.tbxBuzzerTimeOn.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.tbxBuzzerTimeOn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxBuzzerTimeOn.CustomButton.TabIndex = 1;
            this.tbxBuzzerTimeOn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxBuzzerTimeOn.CustomButton.UseSelectable = true;
            this.tbxBuzzerTimeOn.CustomButton.Visible = false;
            this.tbxBuzzerTimeOn.Lines = new string[0];
            this.tbxBuzzerTimeOn.Location = new System.Drawing.Point(155, 545);
            this.tbxBuzzerTimeOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBuzzerTimeOn.MaxLength = 32767;
            this.tbxBuzzerTimeOn.Name = "tbxBuzzerTimeOn";
            this.tbxBuzzerTimeOn.PasswordChar = '\0';
            this.tbxBuzzerTimeOn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBuzzerTimeOn.SelectedText = "";
            this.tbxBuzzerTimeOn.SelectionLength = 0;
            this.tbxBuzzerTimeOn.SelectionStart = 0;
            this.tbxBuzzerTimeOn.ShortcutsEnabled = true;
            this.tbxBuzzerTimeOn.Size = new System.Drawing.Size(100, 28);
            this.tbxBuzzerTimeOn.TabIndex = 26;
            this.tbxBuzzerTimeOn.UseSelectable = true;
            this.tbxBuzzerTimeOn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxBuzzerTimeOn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVibrationNrOfRepeats
            // 
            this.lblVibrationNrOfRepeats.AutoSize = true;
            this.lblVibrationNrOfRepeats.Location = new System.Drawing.Point(371, 622);
            this.lblVibrationNrOfRepeats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVibrationNrOfRepeats.Name = "lblVibrationNrOfRepeats";
            this.lblVibrationNrOfRepeats.Size = new System.Drawing.Size(100, 20);
            this.lblVibrationNrOfRepeats.TabIndex = 39;
            this.lblVibrationNrOfRepeats.Text = "Nr Of Repeats:";
            // 
            // lblVibrationTimeTotal
            // 
            this.lblVibrationTimeTotal.AutoSize = true;
            this.lblVibrationTimeTotal.Location = new System.Drawing.Point(263, 622);
            this.lblVibrationTimeTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVibrationTimeTotal.Name = "lblVibrationTimeTotal";
            this.lblVibrationTimeTotal.Size = new System.Drawing.Size(75, 20);
            this.lblVibrationTimeTotal.TabIndex = 38;
            this.lblVibrationTimeTotal.Text = "Time Total:";
            // 
            // lblVibrationTimeOn
            // 
            this.lblVibrationTimeOn.AutoSize = true;
            this.lblVibrationTimeOn.Location = new System.Drawing.Point(155, 622);
            this.lblVibrationTimeOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVibrationTimeOn.Name = "lblVibrationTimeOn";
            this.lblVibrationTimeOn.Size = new System.Drawing.Size(66, 20);
            this.lblVibrationTimeOn.TabIndex = 37;
            this.lblVibrationTimeOn.Text = "Time On:";
            // 
            // tbxVibrationNrOfRepeats
            // 
            // 
            // 
            // 
            this.tbxVibrationNrOfRepeats.CustomButton.Image = null;
            this.tbxVibrationNrOfRepeats.CustomButton.Location = new System.Drawing.Point(74, 2);
            this.tbxVibrationNrOfRepeats.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationNrOfRepeats.CustomButton.Name = "";
            this.tbxVibrationNrOfRepeats.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxVibrationNrOfRepeats.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxVibrationNrOfRepeats.CustomButton.TabIndex = 1;
            this.tbxVibrationNrOfRepeats.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxVibrationNrOfRepeats.CustomButton.UseSelectable = true;
            this.tbxVibrationNrOfRepeats.CustomButton.Visible = false;
            this.tbxVibrationNrOfRepeats.Lines = new string[0];
            this.tbxVibrationNrOfRepeats.Location = new System.Drawing.Point(371, 650);
            this.tbxVibrationNrOfRepeats.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationNrOfRepeats.MaxLength = 32767;
            this.tbxVibrationNrOfRepeats.Name = "tbxVibrationNrOfRepeats";
            this.tbxVibrationNrOfRepeats.PasswordChar = '\0';
            this.tbxVibrationNrOfRepeats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxVibrationNrOfRepeats.SelectedText = "";
            this.tbxVibrationNrOfRepeats.SelectionLength = 0;
            this.tbxVibrationNrOfRepeats.SelectionStart = 0;
            this.tbxVibrationNrOfRepeats.ShortcutsEnabled = true;
            this.tbxVibrationNrOfRepeats.Size = new System.Drawing.Size(100, 28);
            this.tbxVibrationNrOfRepeats.TabIndex = 36;
            this.tbxVibrationNrOfRepeats.UseSelectable = true;
            this.tbxVibrationNrOfRepeats.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxVibrationNrOfRepeats.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxVibrationTimeTotal
            // 
            // 
            // 
            // 
            this.tbxVibrationTimeTotal.CustomButton.Image = null;
            this.tbxVibrationTimeTotal.CustomButton.Location = new System.Drawing.Point(74, 2);
            this.tbxVibrationTimeTotal.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationTimeTotal.CustomButton.Name = "";
            this.tbxVibrationTimeTotal.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxVibrationTimeTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxVibrationTimeTotal.CustomButton.TabIndex = 1;
            this.tbxVibrationTimeTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxVibrationTimeTotal.CustomButton.UseSelectable = true;
            this.tbxVibrationTimeTotal.CustomButton.Visible = false;
            this.tbxVibrationTimeTotal.Lines = new string[0];
            this.tbxVibrationTimeTotal.Location = new System.Drawing.Point(263, 649);
            this.tbxVibrationTimeTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationTimeTotal.MaxLength = 32767;
            this.tbxVibrationTimeTotal.Name = "tbxVibrationTimeTotal";
            this.tbxVibrationTimeTotal.PasswordChar = '\0';
            this.tbxVibrationTimeTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxVibrationTimeTotal.SelectedText = "";
            this.tbxVibrationTimeTotal.SelectionLength = 0;
            this.tbxVibrationTimeTotal.SelectionStart = 0;
            this.tbxVibrationTimeTotal.ShortcutsEnabled = true;
            this.tbxVibrationTimeTotal.Size = new System.Drawing.Size(100, 28);
            this.tbxVibrationTimeTotal.TabIndex = 35;
            this.tbxVibrationTimeTotal.UseSelectable = true;
            this.tbxVibrationTimeTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxVibrationTimeTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxVibrationTimeOn
            // 
            // 
            // 
            // 
            this.tbxVibrationTimeOn.CustomButton.Image = null;
            this.tbxVibrationTimeOn.CustomButton.Location = new System.Drawing.Point(74, 2);
            this.tbxVibrationTimeOn.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationTimeOn.CustomButton.Name = "";
            this.tbxVibrationTimeOn.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbxVibrationTimeOn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxVibrationTimeOn.CustomButton.TabIndex = 1;
            this.tbxVibrationTimeOn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxVibrationTimeOn.CustomButton.UseSelectable = true;
            this.tbxVibrationTimeOn.CustomButton.Visible = false;
            this.tbxVibrationTimeOn.Lines = new string[0];
            this.tbxVibrationTimeOn.Location = new System.Drawing.Point(155, 649);
            this.tbxVibrationTimeOn.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVibrationTimeOn.MaxLength = 32767;
            this.tbxVibrationTimeOn.Name = "tbxVibrationTimeOn";
            this.tbxVibrationTimeOn.PasswordChar = '\0';
            this.tbxVibrationTimeOn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxVibrationTimeOn.SelectedText = "";
            this.tbxVibrationTimeOn.SelectionLength = 0;
            this.tbxVibrationTimeOn.SelectionStart = 0;
            this.tbxVibrationTimeOn.ShortcutsEnabled = true;
            this.tbxVibrationTimeOn.Size = new System.Drawing.Size(100, 28);
            this.tbxVibrationTimeOn.TabIndex = 34;
            this.tbxVibrationTimeOn.UseSelectable = true;
            this.tbxVibrationTimeOn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxVibrationTimeOn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnVibrationSet
            // 
            this.btnVibrationSet.Location = new System.Drawing.Point(31, 686);
            this.btnVibrationSet.Margin = new System.Windows.Forms.Padding(4);
            this.btnVibrationSet.Name = "btnVibrationSet";
            this.btnVibrationSet.Size = new System.Drawing.Size(116, 28);
            this.btnVibrationSet.TabIndex = 33;
            this.btnVibrationSet.Text = "Vibration Set";
            this.btnVibrationSet.UseSelectable = true;
            this.btnVibrationSet.Click += new System.EventHandler(this.btnVibrationSet_Click);
            // 
            // btnVibrationGet
            // 
            this.btnVibrationGet.Location = new System.Drawing.Point(31, 650);
            this.btnVibrationGet.Margin = new System.Windows.Forms.Padding(4);
            this.btnVibrationGet.Name = "btnVibrationGet";
            this.btnVibrationGet.Size = new System.Drawing.Size(116, 28);
            this.btnVibrationGet.TabIndex = 32;
            this.btnVibrationGet.Text = "Vibration Get";
            this.btnVibrationGet.UseSelectable = true;
            this.btnVibrationGet.Click += new System.EventHandler(this.btnVibrationGet_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.lblVibrationNrOfRepeats);
            this.Controls.Add(this.lblVibrationTimeTotal);
            this.Controls.Add(this.lblVibrationTimeOn);
            this.Controls.Add(this.tbxVibrationNrOfRepeats);
            this.Controls.Add(this.tbxVibrationTimeTotal);
            this.Controls.Add(this.tbxVibrationTimeOn);
            this.Controls.Add(this.btnVibrationSet);
            this.Controls.Add(this.btnVibrationGet);
            this.Controls.Add(this.lblBuzzerNrOfRepeats);
            this.Controls.Add(this.lblBuzzerTimeTotal);
            this.Controls.Add(this.lblBuzzerTimeOn);
            this.Controls.Add(this.tbxBuzzerNrOfRepeats);
            this.Controls.Add(this.tbxBuzzerTimeTotal);
            this.Controls.Add(this.tbxBuzzerTimeOn);
            this.Controls.Add(this.lblLedsBrightness);
            this.Controls.Add(this.tbxLedsBrightness);
            this.Controls.Add(this.lblLedsNrOfRepeats);
            this.Controls.Add(this.lblLedsTimeTotal);
            this.Controls.Add(this.lblLedsTimeOn);
            this.Controls.Add(this.tbxLedsNrOfRepeats);
            this.Controls.Add(this.tbxLedsTimeTotal);
            this.Controls.Add(this.tbxLedsTimeOn);
            this.Controls.Add(this.btnBuzzerSet);
            this.Controls.Add(this.btnBuzzerGet);
            this.Controls.Add(this.lblLedsId);
            this.Controls.Add(this.lblLedsColor);
            this.Controls.Add(this.cbxLedsColor);
            this.Controls.Add(this.btnLedsGetAmount);
            this.Controls.Add(this.cbxLedsId);
            this.Controls.Add(this.btnLedsSet);
            this.Controls.Add(this.btnLedsGet);
            this.Controls.Add(this.btnVersionGet);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblNumberOfConnectedClientsValue);
            this.Controls.Add(this.lblNumberOfConnectedClients);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private MetroFramework.Controls.MetroComboBox cbxLedsId;
        private MetroFramework.Controls.MetroButton btnLedsGetAmount;
        private MetroFramework.Controls.MetroComboBox cbxLedsColor;
        private MetroFramework.Controls.MetroLabel lblLedsColor;
        private MetroFramework.Controls.MetroLabel lblLedsId;
        private MetroFramework.Controls.MetroButton btnBuzzerGet;
        private MetroFramework.Controls.MetroButton btnBuzzerSet;
        private MetroFramework.Controls.MetroTextBox tbxLedsTimeOn;
        private MetroFramework.Controls.MetroTextBox tbxLedsTimeTotal;
        private MetroFramework.Controls.MetroTextBox tbxLedsNrOfRepeats;
        private MetroFramework.Controls.MetroLabel lblLedsTimeOn;
        private MetroFramework.Controls.MetroLabel lblLedsTimeTotal;
        private MetroFramework.Controls.MetroLabel lblLedsNrOfRepeats;
        private MetroFramework.Controls.MetroLabel lblLedsBrightness;
        private MetroFramework.Controls.MetroTextBox tbxLedsBrightness;
        private MetroFramework.Controls.MetroLabel lblBuzzerNrOfRepeats;
        private MetroFramework.Controls.MetroLabel lblBuzzerTimeTotal;
        private MetroFramework.Controls.MetroLabel lblBuzzerTimeOn;
        private MetroFramework.Controls.MetroTextBox tbxBuzzerNrOfRepeats;
        private MetroFramework.Controls.MetroTextBox tbxBuzzerTimeTotal;
        private MetroFramework.Controls.MetroTextBox tbxBuzzerTimeOn;
        private MetroFramework.Controls.MetroLabel lblVibrationNrOfRepeats;
        private MetroFramework.Controls.MetroLabel lblVibrationTimeTotal;
        private MetroFramework.Controls.MetroLabel lblVibrationTimeOn;
        private MetroFramework.Controls.MetroTextBox tbxVibrationNrOfRepeats;
        private MetroFramework.Controls.MetroTextBox tbxVibrationTimeTotal;
        private MetroFramework.Controls.MetroTextBox tbxVibrationTimeOn;
        private MetroFramework.Controls.MetroButton btnVibrationSet;
        private MetroFramework.Controls.MetroButton btnVibrationGet;
    }
}

