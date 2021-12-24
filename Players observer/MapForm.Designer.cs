namespace Players_observer
{
    partial class MapForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.MapPictureBox = new System.Windows.Forms.PictureBox();
            this.MapsListComboBox = new System.Windows.Forms.ComboBox();
            this.PlayerInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.ZoneIDLabel = new System.Windows.Forms.Label();
            this.ZoneIDTextBox = new System.Windows.Forms.TextBox();
            this.PositionYLabel = new System.Windows.Forms.Label();
            this.PositionYTextBox = new System.Windows.Forms.TextBox();
            this.PositionZLabel = new System.Windows.Forms.Label();
            this.PositionZTextBox = new System.Windows.Forms.TextBox();
            this.PositionXLabel = new System.Windows.Forms.Label();
            this.PositionXTextBox = new System.Windows.Forms.TextBox();
            this.StopObservingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).BeginInit();
            this.PlayerInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapPictureBox
            // 
            this.MapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MapPictureBox.Name = "MapPictureBox";
            this.MapPictureBox.Size = new System.Drawing.Size(512, 512);
            this.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MapPictureBox.TabIndex = 0;
            this.MapPictureBox.TabStop = false;
            this.MapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MapPictureBoxPaint);
            // 
            // MapsListComboBox
            // 
            this.MapsListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapsListComboBox.FormattingEnabled = true;
            this.MapsListComboBox.Location = new System.Drawing.Point(525, 12);
            this.MapsListComboBox.Name = "MapsListComboBox";
            this.MapsListComboBox.Size = new System.Drawing.Size(247, 21);
            this.MapsListComboBox.TabIndex = 0;
            this.MapsListComboBox.SelectionChangeCommitted += new System.EventHandler(this.MapsListSelectionChangeCommitted);
            // 
            // PlayerInfoGroupBox
            // 
            this.PlayerInfoGroupBox.Controls.Add(this.UserIDLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.UserIDTextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.ZoneIDLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.ZoneIDTextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionXLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionXTextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionZLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionZTextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionYLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.PositionYTextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.StopObservingButton);
            this.PlayerInfoGroupBox.Location = new System.Drawing.Point(518, 39);
            this.PlayerInfoGroupBox.Name = "PlayerInfoGroupBox";
            this.PlayerInfoGroupBox.Size = new System.Drawing.Size(254, 246);
            this.PlayerInfoGroupBox.TabIndex = 1;
            this.PlayerInfoGroupBox.TabStop = false;
            this.PlayerInfoGroupBox.Text = "Player Info";
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(7, 16);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(40, 13);
            this.UserIDLabel.TabIndex = 2;
            this.UserIDLabel.Text = "UserID";
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Location = new System.Drawing.Point(10, 32);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.ReadOnly = true;
            this.UserIDTextBox.Size = new System.Drawing.Size(234, 20);
            this.UserIDTextBox.TabIndex = 3;
            // 
            // ZoneIDLabel
            // 
            this.ZoneIDLabel.AutoSize = true;
            this.ZoneIDLabel.Location = new System.Drawing.Point(7, 55);
            this.ZoneIDLabel.Name = "ZoneIDLabel";
            this.ZoneIDLabel.Size = new System.Drawing.Size(43, 13);
            this.ZoneIDLabel.TabIndex = 4;
            this.ZoneIDLabel.Text = "ZoneID";
            // 
            // ZoneIDTextBox
            // 
            this.ZoneIDTextBox.Location = new System.Drawing.Point(10, 71);
            this.ZoneIDTextBox.Name = "ZoneIDTextBox";
            this.ZoneIDTextBox.ReadOnly = true;
            this.ZoneIDTextBox.Size = new System.Drawing.Size(234, 20);
            this.ZoneIDTextBox.TabIndex = 5;
            // 
            // PositionXLabel
            // 
            this.PositionXLabel.AutoSize = true;
            this.PositionXLabel.Location = new System.Drawing.Point(7, 94);
            this.PositionXLabel.Name = "PositionXLabel";
            this.PositionXLabel.Size = new System.Drawing.Size(54, 13);
            this.PositionXLabel.TabIndex = 6;
            this.PositionXLabel.Text = "Position X";
            // 
            // PositionXTextBox
            // 
            this.PositionXTextBox.Location = new System.Drawing.Point(10, 110);
            this.PositionXTextBox.Name = "PositionXTextBox";
            this.PositionXTextBox.ReadOnly = true;
            this.PositionXTextBox.Size = new System.Drawing.Size(234, 20);
            this.PositionXTextBox.TabIndex = 7;
            // 
            // PositionZLabel
            // 
            this.PositionZLabel.AutoSize = true;
            this.PositionZLabel.Location = new System.Drawing.Point(7, 133);
            this.PositionZLabel.Name = "PositionZLabel";
            this.PositionZLabel.Size = new System.Drawing.Size(54, 13);
            this.PositionZLabel.TabIndex = 8;
            this.PositionZLabel.Text = "Position Z";
            // 
            // PositionZTextBox
            // 
            this.PositionZTextBox.Location = new System.Drawing.Point(10, 149);
            this.PositionZTextBox.Name = "PositionZTextBox";
            this.PositionZTextBox.ReadOnly = true;
            this.PositionZTextBox.Size = new System.Drawing.Size(234, 20);
            this.PositionZTextBox.TabIndex = 9;
            // 
            // PositionYLabel
            // 
            this.PositionYLabel.AutoSize = true;
            this.PositionYLabel.Location = new System.Drawing.Point(7, 172);
            this.PositionYLabel.Name = "PositionYLabel";
            this.PositionYLabel.Size = new System.Drawing.Size(54, 13);
            this.PositionYLabel.TabIndex = 10;
            this.PositionYLabel.Text = "Position Y";
            // 
            // PositionYTextBox
            // 
            this.PositionYTextBox.Location = new System.Drawing.Point(10, 188);
            this.PositionYTextBox.Name = "PositionYTextBox";
            this.PositionYTextBox.ReadOnly = true;
            this.PositionYTextBox.Size = new System.Drawing.Size(234, 20);
            this.PositionYTextBox.TabIndex = 11;
            // 
            // StopObservingButton
            // 
            this.StopObservingButton.Enabled = false;
            this.StopObservingButton.Location = new System.Drawing.Point(10, 214);
            this.StopObservingButton.Name = "StopObservingButton";
            this.StopObservingButton.Size = new System.Drawing.Size(234, 23);
            this.StopObservingButton.TabIndex = 12;
            this.StopObservingButton.Text = "Stop observing";
            this.StopObservingButton.UseVisualStyleBackColor = true;
            this.StopObservingButton.Click += new System.EventHandler(this.StopObservingButtonClick);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.PlayerInfoGroupBox);
            this.Controls.Add(this.MapsListComboBox);
            this.Controls.Add(this.MapPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapForm";
            this.Text = "Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MapPictureBox)).EndInit();
            this.PlayerInfoGroupBox.ResumeLayout(false);
            this.PlayerInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox MapPictureBox;
        private System.Windows.Forms.ComboBox MapsListComboBox;
        private System.Windows.Forms.GroupBox PlayerInfoGroupBox;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label ZoneIDLabel;
        private System.Windows.Forms.TextBox ZoneIDTextBox;
        private System.Windows.Forms.Label PositionXLabel;
        private System.Windows.Forms.TextBox PositionXTextBox;
        private System.Windows.Forms.Label PositionZLabel;
        private System.Windows.Forms.TextBox PositionZTextBox;
        private System.Windows.Forms.Label PositionYLabel;
        private System.Windows.Forms.TextBox PositionYTextBox;
        private System.Windows.Forms.Button StopObservingButton;
    }
}