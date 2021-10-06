namespace InvestorUI
{
    partial class PledgeTransferForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeTransferForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridInvestments = new System.Windows.Forms.DataGridView();
            this.pledge_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeInvestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitRollover = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseOpportunity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ReleaseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.WindowClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboSearchList = new System.Windows.Forms.ComboBox();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.FirstButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(8, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 445);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.gridInvestments);
            this.groupBox4.Location = new System.Drawing.Point(6, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(928, 398);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label12.Location = new System.Drawing.Point(360, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Released To Investments ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label5.Location = new System.Drawing.Point(20, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Current Pledges";
            // 
            // gridInvestments
            // 
            this.gridInvestments.AllowUserToAddRows = false;
            this.gridInvestments.AllowUserToDeleteRows = false;
            this.gridInvestments.AllowUserToResizeColumns = false;
            this.gridInvestments.AllowUserToResizeRows = false;
            this.gridInvestments.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInvestments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInvestments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInvestments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInvestments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pledge_id,
            this.CodeInvestor,
            this.Amount,
            this.InterestRate,
            this.Spacer,
            this.ExitRollover,
            this.ReleaseDate,
            this.ReleaseOpportunity,
            this.ReleaseAmount,
            this.ReleaseInterest});
            this.gridInvestments.EnableHeadersVisualStyles = false;
            this.gridInvestments.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestments.Location = new System.Drawing.Point(5, 56);
            this.gridInvestments.Name = "gridInvestments";
            this.gridInvestments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridInvestments.RowHeadersWidth = 15;
            this.gridInvestments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.gridInvestments.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gridInvestments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridInvestments.Size = new System.Drawing.Size(910, 331);
            this.gridInvestments.TabIndex = 2;
            // 
            // pledge_id
            // 
            this.pledge_id.DataPropertyName = "pledge_id";
            this.pledge_id.HeaderText = "InvestmentId";
            this.pledge_id.Name = "pledge_id";
            this.pledge_id.Visible = false;
            // 
            // CodeInvestor
            // 
            this.CodeInvestor.DataPropertyName = "CodeInvestor";
            this.CodeInvestor.HeaderText = "Investor";
            this.CodeInvestor.Name = "CodeInvestor";
            this.CodeInvestor.ReadOnly = true;
            this.CodeInvestor.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "investment_amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // InterestRate
            // 
            this.InterestRate.DataPropertyName = "investment_interest_rate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.InterestRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.InterestRate.FillWeight = 75F;
            this.InterestRate.HeaderText = "Interest %";
            this.InterestRate.Name = "InterestRate";
            this.InterestRate.ReadOnly = true;
            this.InterestRate.Width = 75;
            // 
            // Spacer
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Spacer.DefaultCellStyle = dataGridViewCellStyle4;
            this.Spacer.FillWeight = 15F;
            this.Spacer.HeaderText = " ";
            this.Spacer.Name = "Spacer";
            this.Spacer.Width = 15;
            // 
            // ExitRollover
            // 
            this.ExitRollover.DataPropertyName = "ExitRollover";
            this.ExitRollover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitRollover.HeaderText = "ExitRollover";
            this.ExitRollover.Name = "ExitRollover";
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.DataPropertyName = "ReleaseDate";
            dataGridViewCellStyle5.NullValue = null;
            this.ReleaseDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ReleaseDate.HeaderText = "Date";
            this.ReleaseDate.Name = "ReleaseDate";
            // 
            // ReleaseOpportunity
            // 
            this.ReleaseOpportunity.DataPropertyName = "Opportunity_id";
            this.ReleaseOpportunity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReleaseOpportunity.HeaderText = "Opportunity";
            this.ReleaseOpportunity.Name = "ReleaseOpportunity";
            this.ReleaseOpportunity.Width = 150;
            // 
            // ReleaseAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.ReleaseAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ReleaseAmount.HeaderText = "Amount";
            this.ReleaseAmount.Name = "ReleaseAmount";
            // 
            // ReleaseInterest
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.ReleaseInterest.DefaultCellStyle = dataGridViewCellStyle7;
            this.ReleaseInterest.HeaderText = "Interest %";
            this.ReleaseInterest.Name = "ReleaseInterest";
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HeaderPanel.Controls.Add(this.WindowClose);
            this.HeaderPanel.Controls.Add(this.label6);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(950, 30);
            this.HeaderPanel.TabIndex = 45;
            // 
            // WindowClose
            // 
            this.WindowClose.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WindowClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WindowClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowClose.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WindowClose.Image = ((System.Drawing.Image)(resources.GetObject("WindowClose.Image")));
            this.WindowClose.Location = new System.Drawing.Point(918, 1);
            this.WindowClose.Name = "WindowClose";
            this.WindowClose.Size = new System.Drawing.Size(30, 27);
            this.WindowClose.TabIndex = 5;
            this.WindowClose.TabStop = false;
            this.WindowClose.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pledge Releases";
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MenuPanel.Controls.Add(this.panel1);
            this.MenuPanel.Controls.Add(this.ForwardButton);
            this.MenuPanel.Controls.Add(this.LastButton);
            this.MenuPanel.Controls.Add(this.FirstButton);
            this.MenuPanel.Controls.Add(this.BackButton);
            this.MenuPanel.Controls.Add(this.UpdateButton);
            this.MenuPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPanel.Location = new System.Drawing.Point(0, 33);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(950, 50);
            this.MenuPanel.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.comboSearchList);
            this.panel1.Location = new System.Drawing.Point(408, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 35);
            this.panel1.TabIndex = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(205, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 29);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // comboSearchList
            // 
            this.comboSearchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSearchList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboSearchList.DropDownHeight = 120;
            this.comboSearchList.DropDownWidth = 199;
            this.comboSearchList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSearchList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearchList.FormattingEnabled = true;
            this.comboSearchList.IntegralHeight = false;
            this.comboSearchList.Location = new System.Drawing.Point(3, 6);
            this.comboSearchList.Name = "comboSearchList";
            this.comboSearchList.Size = new System.Drawing.Size(199, 25);
            this.comboSearchList.TabIndex = 1;
            // 
            // ForwardButton
            // 
            this.ForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("ForwardButton.Image")));
            this.ForwardButton.Location = new System.Drawing.Point(795, 6);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(70, 35);
            this.ForwardButton.TabIndex = 48;
            this.ForwardButton.UseVisualStyleBackColor = true;
            // 
            // LastButton
            // 
            this.LastButton.Image = ((System.Drawing.Image)(resources.GetObject("LastButton.Image")));
            this.LastButton.Location = new System.Drawing.Point(864, 6);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(70, 35);
            this.LastButton.TabIndex = 49;
            this.LastButton.UseVisualStyleBackColor = true;
            // 
            // FirstButton
            // 
            this.FirstButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstButton.Image")));
            this.FirstButton.Location = new System.Drawing.Point(657, 6);
            this.FirstButton.Name = "FirstButton";
            this.FirstButton.Size = new System.Drawing.Size(70, 35);
            this.FirstButton.TabIndex = 46;
            this.FirstButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(726, 6);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(70, 35);
            this.BackButton.TabIndex = 47;
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateButton.Image")));
            this.UpdateButton.Location = new System.Drawing.Point(9, 6);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(85, 35);
            this.UpdateButton.TabIndex = 42;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateButton.UseVisualStyleBackColor = false;
            // 
            // PledgeTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MenuPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PledgeTransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PledgeTransferForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button WindowClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox comboSearchList;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.Button FirstButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView gridInvestments;
        private System.Windows.Forms.DataGridViewTextBoxColumn pledge_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeInvestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spacer;
        private System.Windows.Forms.DataGridViewComboBoxColumn ExitRollover;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ReleaseOpportunity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseInterest;
    }
}