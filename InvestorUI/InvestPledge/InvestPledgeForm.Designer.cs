namespace InvestorUI
{
    partial class InvestPledgeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvestPledgeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.WindowClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.checkIncludeTransferred = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboSearchList = new System.Windows.Forms.ComboBox();
            this.radioName = new System.Windows.Forms.RadioButton();
            this.UndoButton = new System.Windows.Forms.Button();
            this.radioCode = new System.Windows.Forms.RadioButton();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.FirstButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gridInvestments = new System.Windows.Forms.DataGridView();
            this.pledge_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opportunity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrustInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transferred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonTransferPledge = new System.Windows.Forms.Button();
            this.checkTransferred = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBlocked = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateContractDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboContractPeriod = new System.Windows.Forms.ComboBox();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textInvestmentInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTrustInterestRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboInvestor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboOpportunity = new System.Windows.Forms.ComboBox();
            this.textInvestmentAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRecordId = new System.Windows.Forms.TextBox();
            this.HeaderPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.HeaderPanel.TabIndex = 42;
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
            this.WindowClose.Click += new System.EventHandler(this.WindowClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Investment Pledges";
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MenuPanel.Controls.Add(this.checkIncludeTransferred);
            this.MenuPanel.Controls.Add(this.panel1);
            this.MenuPanel.Controls.Add(this.radioName);
            this.MenuPanel.Controls.Add(this.UndoButton);
            this.MenuPanel.Controls.Add(this.radioCode);
            this.MenuPanel.Controls.Add(this.ForwardButton);
            this.MenuPanel.Controls.Add(this.LastButton);
            this.MenuPanel.Controls.Add(this.FirstButton);
            this.MenuPanel.Controls.Add(this.BackButton);
            this.MenuPanel.Controls.Add(this.AddButton);
            this.MenuPanel.Controls.Add(this.DeleteButton);
            this.MenuPanel.Controls.Add(this.SaveButton);
            this.MenuPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPanel.Location = new System.Drawing.Point(0, 33);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(950, 65);
            this.MenuPanel.TabIndex = 43;
            // 
            // checkIncludeTransferred
            // 
            this.checkIncludeTransferred.AutoSize = true;
            this.checkIncludeTransferred.Location = new System.Drawing.Point(557, 41);
            this.checkIncludeTransferred.Name = "checkIncludeTransferred";
            this.checkIncludeTransferred.Size = new System.Drawing.Size(118, 21);
            this.checkIncludeTransferred.TabIndex = 39;
            this.checkIncludeTransferred.TabStop = false;
            this.checkIncludeTransferred.Text = "Incl Transferred";
            this.checkIncludeTransferred.UseVisualStyleBackColor = true;
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
            this.comboSearchList.SelectionChangeCommitted += new System.EventHandler(this.comboSearchList_SelectionChangeCommitted);
            this.comboSearchList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSearchList_KeyDown);
            this.comboSearchList.Leave += new System.EventHandler(this.comboSearchList_Leave);
            // 
            // radioName
            // 
            this.radioName.AutoSize = true;
            this.radioName.Location = new System.Drawing.Point(474, 41);
            this.radioName.Name = "radioName";
            this.radioName.Size = new System.Drawing.Size(61, 21);
            this.radioName.TabIndex = 38;
            this.radioName.Text = "Name";
            this.radioName.UseVisualStyleBackColor = true;
            this.radioName.CheckedChanged += new System.EventHandler(this.radioName_CheckedChanged);
            // 
            // UndoButton
            // 
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.Location = new System.Drawing.Point(171, 6);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(80, 35);
            this.UndoButton.TabIndex = 43;
            this.UndoButton.Text = "Undo";
            this.UndoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // radioCode
            // 
            this.radioCode.AutoSize = true;
            this.radioCode.Location = new System.Drawing.Point(411, 41);
            this.radioCode.Name = "radioCode";
            this.radioCode.Size = new System.Drawing.Size(57, 21);
            this.radioCode.TabIndex = 60;
            this.radioCode.Text = "Code";
            this.radioCode.UseVisualStyleBackColor = true;
            this.radioCode.CheckedChanged += new System.EventHandler(this.radioCode_CheckedChanged);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("ForwardButton.Image")));
            this.ForwardButton.Location = new System.Drawing.Point(795, 6);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(70, 35);
            this.ForwardButton.TabIndex = 48;
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // LastButton
            // 
            this.LastButton.Image = ((System.Drawing.Image)(resources.GetObject("LastButton.Image")));
            this.LastButton.Location = new System.Drawing.Point(864, 6);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(70, 35);
            this.LastButton.TabIndex = 49;
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // FirstButton
            // 
            this.FirstButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstButton.Image")));
            this.FirstButton.Location = new System.Drawing.Point(657, 6);
            this.FirstButton.Name = "FirstButton";
            this.FirstButton.Size = new System.Drawing.Size(70, 35);
            this.FirstButton.TabIndex = 46;
            this.FirstButton.UseVisualStyleBackColor = true;
            this.FirstButton.Click += new System.EventHandler(this.FirstButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(726, 6);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(70, 35);
            this.BackButton.TabIndex = 47;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(9, 6);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 35);
            this.AddButton.TabIndex = 41;
            this.AddButton.Text = "Add";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(252, 6);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 35);
            this.DeleteButton.TabIndex = 44;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.Control;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(90, 6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 35);
            this.SaveButton.TabIndex = 42;
            this.SaveButton.Text = "Save";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboInvestor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboOpportunity);
            this.groupBox1.Controls.Add(this.textInvestmentAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textRecordId);
            this.groupBox1.Location = new System.Drawing.Point(5, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 540);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridInvestments);
            this.groupBox4.Location = new System.Drawing.Point(6, 294);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(928, 240);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInvestments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridInvestments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInvestments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pledge_id,
            this.Code,
            this.Opportunity,
            this.Amount,
            this.ContractDate,
            this.DepositDate,
            this.ReleaseDate,
            this.TrustInterest,
            this.Transferred});
            this.gridInvestments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvestments.EnableHeadersVisualStyles = false;
            this.gridInvestments.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestments.Location = new System.Drawing.Point(3, 21);
            this.gridInvestments.Name = "gridInvestments";
            this.gridInvestments.ReadOnly = true;
            this.gridInvestments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridInvestments.RowHeadersWidth = 15;
            this.gridInvestments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.gridInvestments.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridInvestments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridInvestments.Size = new System.Drawing.Size(922, 216);
            this.gridInvestments.TabIndex = 2;
            this.gridInvestments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvestments_CellClick);
            // 
            // pledge_id
            // 
            this.pledge_id.DataPropertyName = "pledge_id";
            this.pledge_id.HeaderText = "InvestmentId";
            this.pledge_id.Name = "pledge_id";
            this.pledge_id.ReadOnly = true;
            this.pledge_id.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Opportunity
            // 
            this.Opportunity.DataPropertyName = "Opportunity";
            this.Opportunity.HeaderText = "Opportunity";
            this.Opportunity.Name = "Opportunity";
            this.Opportunity.ReadOnly = true;
            this.Opportunity.Width = 200;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "investment_amount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // ContractDate
            // 
            this.ContractDate.DataPropertyName = "contract_signed_date";
            this.ContractDate.HeaderText = "Contract Date";
            this.ContractDate.Name = "ContractDate";
            this.ContractDate.ReadOnly = true;
            // 
            // DepositDate
            // 
            this.DepositDate.DataPropertyName = "deposit_date";
            this.DepositDate.HeaderText = "Deposit Date";
            this.DepositDate.Name = "DepositDate";
            this.DepositDate.ReadOnly = true;
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.DataPropertyName = "release_date";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ReleaseDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.ReleaseDate.HeaderText = "Release Date";
            this.ReleaseDate.Name = "ReleaseDate";
            this.ReleaseDate.ReadOnly = true;
            // 
            // TrustInterest
            // 
            this.TrustInterest.DataPropertyName = "trust_interest_rate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.TrustInterest.DefaultCellStyle = dataGridViewCellStyle9;
            this.TrustInterest.HeaderText = "Trust Interest";
            this.TrustInterest.Name = "TrustInterest";
            this.TrustInterest.ReadOnly = true;
            // 
            // Transferred
            // 
            this.Transferred.DataPropertyName = "investment_transferred";
            this.Transferred.HeaderText = "Transferred";
            this.Transferred.Name = "Transferred";
            this.Transferred.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonTransferPledge);
            this.groupBox5.Controls.Add(this.checkTransferred);
            this.groupBox5.Location = new System.Drawing.Point(729, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 111);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transfer";
            // 
            // buttonTransferPledge
            // 
            this.buttonTransferPledge.Location = new System.Drawing.Point(11, 31);
            this.buttonTransferPledge.Name = "buttonTransferPledge";
            this.buttonTransferPledge.Size = new System.Drawing.Size(173, 32);
            this.buttonTransferPledge.TabIndex = 1;
            this.buttonTransferPledge.Text = "Transfer to Investment";
            this.buttonTransferPledge.UseVisualStyleBackColor = true;
            this.buttonTransferPledge.Click += new System.EventHandler(this.buttonTransferPledge_Click);
            // 
            // checkTransferred
            // 
            this.checkTransferred.AutoSize = true;
            this.checkTransferred.Location = new System.Drawing.Point(15, 75);
            this.checkTransferred.Name = "checkTransferred";
            this.checkTransferred.Size = new System.Drawing.Size(95, 21);
            this.checkTransferred.TabIndex = 2;
            this.checkTransferred.Text = "Transferred";
            this.checkTransferred.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBlocked);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dateReleaseDate);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dateContractDate);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dateDepositDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboContractPeriod);
            this.groupBox3.Controls.Add(this.dateEndDate);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(231, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 162);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Terms";
            // 
            // checkBlocked
            // 
            this.checkBlocked.AutoSize = true;
            this.checkBlocked.Location = new System.Drawing.Point(269, 120);
            this.checkBlocked.Name = "checkBlocked";
            this.checkBlocked.Size = new System.Drawing.Size(67, 21);
            this.checkBlocked.TabIndex = 63;
            this.checkBlocked.Text = "Closed";
            this.checkBlocked.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label12.Location = new System.Drawing.Point(265, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 53;
            this.label12.Text = "Release Date";
            // 
            // dateReleaseDate
            // 
            this.dateReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateReleaseDate.Location = new System.Drawing.Point(265, 59);
            this.dateReleaseDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateReleaseDate.Name = "dateReleaseDate";
            this.dateReleaseDate.Size = new System.Drawing.Size(110, 25);
            this.dateReleaseDate.TabIndex = 8;
            this.dateReleaseDate.ValueChanged += new System.EventHandler(this.dateReleaseDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label7.Location = new System.Drawing.Point(20, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "Contract Signed";
            // 
            // dateContractDate
            // 
            this.dateContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateContractDate.Location = new System.Drawing.Point(20, 59);
            this.dateContractDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateContractDate.Name = "dateContractDate";
            this.dateContractDate.Size = new System.Drawing.Size(110, 25);
            this.dateContractDate.TabIndex = 6;
            this.dateContractDate.ValueChanged += new System.EventHandler(this.dateContractDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label10.Location = new System.Drawing.Point(144, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 20);
            this.label10.TabIndex = 46;
            this.label10.Text = "Deposit Date";
            // 
            // dateDepositDate
            // 
            this.dateDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDepositDate.Location = new System.Drawing.Point(144, 59);
            this.dateDepositDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateDepositDate.Name = "dateDepositDate";
            this.dateDepositDate.Size = new System.Drawing.Size(110, 25);
            this.dateDepositDate.TabIndex = 7;
            this.dateDepositDate.ValueChanged += new System.EventHandler(this.dateDepositDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label9.Location = new System.Drawing.Point(144, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 50;
            this.label9.Text = "End Date";
            // 
            // comboContractPeriod
            // 
            this.comboContractPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboContractPeriod.DropDownHeight = 120;
            this.comboContractPeriod.FormattingEnabled = true;
            this.comboContractPeriod.IntegralHeight = false;
            this.comboContractPeriod.Location = new System.Drawing.Point(18, 116);
            this.comboContractPeriod.Name = "comboContractPeriod";
            this.comboContractPeriod.Size = new System.Drawing.Size(108, 25);
            this.comboContractPeriod.TabIndex = 9;
            this.comboContractPeriod.SelectionChangeCommitted += new System.EventHandler(this.comboContractPeriod_SelectionChangeCommitted);
            // 
            // dateEndDate
            // 
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEndDate.Location = new System.Drawing.Point(144, 116);
            this.dateEndDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(110, 25);
            this.dateEndDate.TabIndex = 10;
            this.dateEndDate.ValueChanged += new System.EventHandler(this.dateEndDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label8.Location = new System.Drawing.Point(18, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Contract Period";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textInvestmentInterestRate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textTrustInterestRate);
            this.groupBox2.Location = new System.Drawing.Point(45, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 164);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interest Rate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label11.Location = new System.Drawing.Point(24, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 58;
            this.label11.Text = "Investment";
            // 
            // textInvestmentInterestRate
            // 
            this.textInvestmentInterestRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInvestmentInterestRate.Location = new System.Drawing.Point(24, 118);
            this.textInvestmentInterestRate.Name = "textInvestmentInterestRate";
            this.textInvestmentInterestRate.Size = new System.Drawing.Size(115, 25);
            this.textInvestmentInterestRate.TabIndex = 5;
            this.textInvestmentInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textInvestmentInterestRate.TextChanged += new System.EventHandler(this.textInvestmentInterestRate_TextChanged);
            this.textInvestmentInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInvestmentInterestRate_KeyPress);
            this.textInvestmentInterestRate.Leave += new System.EventHandler(this.textInvestmentInterestRate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(24, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Trust";
            // 
            // textTrustInterestRate
            // 
            this.textTrustInterestRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTrustInterestRate.Location = new System.Drawing.Point(24, 59);
            this.textTrustInterestRate.Name = "textTrustInterestRate";
            this.textTrustInterestRate.Size = new System.Drawing.Size(115, 25);
            this.textTrustInterestRate.TabIndex = 4;
            this.textTrustInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTrustInterestRate.TextChanged += new System.EventHandler(this.textTrustInterestRate_TextChanged);
            this.textTrustInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTrustInterestRate_KeyPress);
            this.textTrustInterestRate.Leave += new System.EventHandler(this.textTrustInterestRate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(45, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "Investor";
            // 
            // comboInvestor
            // 
            this.comboInvestor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboInvestor.DropDownHeight = 120;
            this.comboInvestor.FormattingEnabled = true;
            this.comboInvestor.IntegralHeight = false;
            this.comboInvestor.Location = new System.Drawing.Point(45, 82);
            this.comboInvestor.Name = "comboInvestor";
            this.comboInvestor.Size = new System.Drawing.Size(176, 25);
            this.comboInvestor.TabIndex = 1;
            this.comboInvestor.SelectedIndexChanged += new System.EventHandler(this.comboInvestor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(227, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Opportunity";
            // 
            // comboOpportunity
            // 
            this.comboOpportunity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOpportunity.DropDownHeight = 120;
            this.comboOpportunity.FormattingEnabled = true;
            this.comboOpportunity.IntegralHeight = false;
            this.comboOpportunity.Location = new System.Drawing.Point(227, 82);
            this.comboOpportunity.Name = "comboOpportunity";
            this.comboOpportunity.Size = new System.Drawing.Size(174, 25);
            this.comboOpportunity.TabIndex = 2;
            this.comboOpportunity.SelectedIndexChanged += new System.EventHandler(this.comboOpportunity_SelectedIndexChanged);
            // 
            // textInvestmentAmount
            // 
            this.textInvestmentAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInvestmentAmount.Location = new System.Drawing.Point(407, 82);
            this.textInvestmentAmount.Name = "textInvestmentAmount";
            this.textInvestmentAmount.Size = new System.Drawing.Size(126, 25);
            this.textInvestmentAmount.TabIndex = 3;
            this.textInvestmentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textInvestmentAmount.TextChanged += new System.EventHandler(this.textInvestmentAmount_TextChanged);
            this.textInvestmentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInvestmentAmount_KeyPress);
            this.textInvestmentAmount.Leave += new System.EventHandler(this.textInvestmentAmount_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(407, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Investment";
            // 
            // textRecordId
            // 
            this.textRecordId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textRecordId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRecordId.Location = new System.Drawing.Point(105, 51);
            this.textRecordId.Name = "textRecordId";
            this.textRecordId.Size = new System.Drawing.Size(116, 25);
            this.textRecordId.TabIndex = 32;
            this.textRecordId.Visible = false;
            // 
            // InvestPledgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MenuPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InvestPledgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvestPledgeForm";
            this.Load += new System.EventHandler(this.InvestPledgeForm_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button WindowClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox comboSearchList;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.Button FirstButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboContractPeriod;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dateDepositDate;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textInvestmentAmount;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textTrustInterestRate;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dateContractDate;
        public System.Windows.Forms.TextBox textRecordId;
        public System.Windows.Forms.CheckBox checkTransferred;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboInvestor;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboOpportunity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox textInvestmentInterestRate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.DateTimePicker dateReleaseDate;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button buttonTransferPledge;
        public System.Windows.Forms.CheckBox checkIncludeTransferred;
        public System.Windows.Forms.RadioButton radioName;
        public System.Windows.Forms.RadioButton radioCode;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.DataGridView gridInvestments;
        private System.Windows.Forms.DataGridViewTextBoxColumn pledge_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opportunity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrustInterest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transferred;
        public System.Windows.Forms.CheckBox checkBlocked;
    }
}