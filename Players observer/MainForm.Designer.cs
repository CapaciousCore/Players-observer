namespace Players_observer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ObserveButton = new System.Windows.Forms.Button();
            this.OpenMapButton = new System.Windows.Forms.Button();
            this.ServerStatisticsLabel = new System.Windows.Forms.Label();
            this.UsersList = new System.Windows.Forms.DataGridView();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // ObserveButton
            // 
            this.ObserveButton.Location = new System.Drawing.Point(12, 12);
            this.ObserveButton.Name = "ObserveButton";
            this.ObserveButton.Size = new System.Drawing.Size(75, 23);
            this.ObserveButton.TabIndex = 0;
            this.ObserveButton.Text = "Observe";
            this.ObserveButton.UseVisualStyleBackColor = true;
            this.ObserveButton.Click += new System.EventHandler(this.ObserveButtonClick);
            // 
            // OpenMapButton
            // 
            this.OpenMapButton.Enabled = false;
            this.OpenMapButton.Location = new System.Drawing.Point(94, 12);
            this.OpenMapButton.Name = "OpenMapButton";
            this.OpenMapButton.Size = new System.Drawing.Size(75, 23);
            this.OpenMapButton.TabIndex = 1;
            this.OpenMapButton.Text = "Open map";
            this.OpenMapButton.UseVisualStyleBackColor = true;
            this.OpenMapButton.Click += new System.EventHandler(this.OpenMapButtonClick);
            // 
            // ServerStatisticsLabel
            // 
            this.ServerStatisticsLabel.Location = new System.Drawing.Point(672, 17);
            this.ServerStatisticsLabel.Name = "ServerStatisticsLabel";
            this.ServerStatisticsLabel.Size = new System.Drawing.Size(100, 13);
            this.ServerStatisticsLabel.TabIndex = 2;
            this.ServerStatisticsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsersList
            // 
            this.UsersList.AllowUserToAddRows = false;
            this.UsersList.AllowUserToDeleteRows = false;
            this.UsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Offset,
            this.IsUpdated,
            this.AccountID,
            this.UserID,
            this.ZoneID,
            this.X,
            this.Z,
            this.Y});
            this.UsersList.Location = new System.Drawing.Point(12, 41);
            this.UsersList.Name = "UsersList";
            this.UsersList.ReadOnly = true;
            this.UsersList.Size = new System.Drawing.Size(760, 309);
            this.UsersList.TabIndex = 3;
            this.UsersList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UsersListCellMouseDoubleClick);
            // 
            // Offset
            // 
            this.Offset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Offset.HeaderText = "Offset";
            this.Offset.Name = "Offset";
            this.Offset.ReadOnly = true;
            this.Offset.Visible = false;
            // 
            // IsUpdated
            // 
            this.IsUpdated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsUpdated.HeaderText = "IsUpdated";
            this.IsUpdated.Name = "IsUpdated";
            this.IsUpdated.ReadOnly = true;
            this.IsUpdated.Visible = false;
            // 
            // AccountID
            // 
            this.AccountID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // ZoneID
            // 
            this.ZoneID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ZoneID.HeaderText = "ZoneID";
            this.ZoneID.Name = "ZoneID";
            this.ZoneID.ReadOnly = true;
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            // 
            // Z
            // 
            this.Z.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.ReadOnly = true;
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.OpenMapButton);
            this.Controls.Add(this.ServerStatisticsLabel);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.ObserveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Players observer";
            ((System.ComponentModel.ISupportInitialize)(this.UsersList)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ObserveButton;
        private System.Windows.Forms.Button OpenMapButton;
        private System.Windows.Forms.Label ServerStatisticsLabel;
        private System.Windows.Forms.DataGridView UsersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;        
    }
}