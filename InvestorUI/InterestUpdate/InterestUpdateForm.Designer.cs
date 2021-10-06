namespace InvestorUI
{
    partial class InterestUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterestUpdateForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.UpdateInvestments = new System.Windows.Forms.Button();
            this.gridInvestments = new System.Windows.Forms.DataGridView();
            this.investor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Investor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewInterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.updatePledges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gridInvestPledges = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateChangeDate = new System.Windows.Forms.DateTimePicker();
            this.textNewInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.WindowClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.textOldInterestRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestPledges)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(8, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 457);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 425);
            this.tabControl1.TabIndex = 92;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.UpdateInvestments);
            this.tabPage1.Controls.Add(this.gridInvestments);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Investments";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label12.Location = new System.Drawing.Point(482, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Update Interest To";
            // 
            // UpdateInvestments
            // 
            this.UpdateInvestments.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateInvestments.Image = ((System.Drawing.Image)(resources.GetObject("UpdateInvestments.Image")));
            this.UpdateInvestments.Location = new System.Drawing.Point(751, 6);
            this.UpdateInvestments.Name = "UpdateInvestments";
            this.UpdateInvestments.Size = new System.Drawing.Size(160, 35);
            this.UpdateInvestments.TabIndex = 42;
            this.UpdateInvestments.Text = "Update Investments";
            this.UpdateInvestments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateInvestments.UseVisualStyleBackColor = false;
            this.UpdateInvestments.Click += new System.EventHandler(this.UpdateInvestments_Click);
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
            this.investor_id,
            this.ReleaseDate,
            this.Investor,
            this.Amount,
            this.InterestRate,
            this.Spacer,
            this.NewInterestRate,
            this.Selected});
            this.gridInvestments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridInvestments.EnableHeadersVisualStyles = false;
            this.gridInvestments.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestments.Location = new System.Drawing.Point(3, 47);
            this.gridInvestments.Name = "gridInvestments";
            this.gridInvestments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridInvestments.RowHeadersWidth = 15;
            this.gridInvestments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.gridInvestments.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gridInvestments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridInvestments.Size = new System.Drawing.Size(911, 345);
            this.gridInvestments.TabIndex = 2;
            this.gridInvestments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvestments_CellContentClick);
            this.gridInvestments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridInvestments_DataError);
            // 
            // investor_id
            // 
            this.investor_id.DataPropertyName = "investor_id";
            this.investor_id.HeaderText = "investor_id";
            this.investor_id.Name = "investor_id";
            this.investor_id.Visible = false;
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.DataPropertyName = "investor_acc_number";
            dataGridViewCellStyle2.NullValue = null;
            this.ReleaseDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReleaseDate.HeaderText = "Code";
            this.ReleaseDate.Name = "ReleaseDate";
            // 
            // Investor
            // 
            this.Investor.DataPropertyName = "Investor";
            this.Investor.HeaderText = "Investor";
            this.Investor.Name = "Investor";
            this.Investor.ReadOnly = true;
            this.Investor.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // InterestRate
            // 
            this.InterestRate.DataPropertyName = "InterestRate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.InterestRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.InterestRate.HeaderText = "Interest Rate";
            this.InterestRate.Name = "InterestRate";
            // 
            // Spacer
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Spacer.DefaultCellStyle = dataGridViewCellStyle5;
            this.Spacer.FillWeight = 15F;
            this.Spacer.HeaderText = "";
            this.Spacer.Name = "Spacer";
            this.Spacer.Width = 15;
            // 
            // NewInterestRate
            // 
            this.NewInterestRate.DataPropertyName = "NewInterestRate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.NewInterestRate.DefaultCellStyle = dataGridViewCellStyle6;
            this.NewInterestRate.HeaderText = "New Rate";
            this.NewInterestRate.Name = "NewInterestRate";
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "Select";
            this.Selected.Name = "Selected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Current Investments";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.updatePledges);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.gridInvestPledges);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(917, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pledges";
            // 
            // updatePledges
            // 
            this.updatePledges.BackColor = System.Drawing.SystemColors.Control;
            this.updatePledges.Image = ((System.Drawing.Image)(resources.GetObject("updatePledges.Image")));
            this.updatePledges.Location = new System.Drawing.Point(751, 6);
            this.updatePledges.Name = "updatePledges";
            this.updatePledges.Size = new System.Drawing.Size(160, 35);
            this.updatePledges.TabIndex = 43;
            this.updatePledges.Text = "Update Pledges";
            this.updatePledges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.updatePledges.UseVisualStyleBackColor = false;
            this.updatePledges.Click += new System.EventHandler(this.updatePledges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label1.Location = new System.Drawing.Point(482, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Update Interest To";
            // 
            // gridInvestPledges
            // 
            this.gridInvestPledges.AllowUserToAddRows = false;
            this.gridInvestPledges.AllowUserToDeleteRows = false;
            this.gridInvestPledges.AllowUserToResizeColumns = false;
            this.gridInvestPledges.AllowUserToResizeRows = false;
            this.gridInvestPledges.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestPledges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInvestPledges.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInvestPledges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridInvestPledges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInvestPledges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewCheckBoxColumn1});
            this.gridInvestPledges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridInvestPledges.EnableHeadersVisualStyles = false;
            this.gridInvestPledges.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gridInvestPledges.Location = new System.Drawing.Point(3, 47);
            this.gridInvestPledges.Name = "gridInvestPledges";
            this.gridInvestPledges.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridInvestPledges.RowHeadersWidth = 15;
            this.gridInvestPledges.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.gridInvestPledges.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.gridInvestPledges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridInvestPledges.Size = new System.Drawing.Size(911, 345);
            this.gridInvestPledges.TabIndex = 5;
            this.gridInvestPledges.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridInvestPledges_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "investor_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "investor_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "investor_acc_number";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Investor";
            this.dataGridViewTextBoxColumn3.HeaderText = "Investor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Amount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "InterestRate";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Interest Rate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.FillWeight = 15F;
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 15;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NewInterestRate";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn7.HeaderText = "New Rate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Selected";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Investments";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label10.Location = new System.Drawing.Point(217, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 91;
            this.label10.Text = "Effective Date";
            // 
            // dateChangeDate
            // 
            this.dateChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateChangeDate.Location = new System.Drawing.Point(325, 14);
            this.dateChangeDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateChangeDate.Name = "dateChangeDate";
            this.dateChangeDate.Size = new System.Drawing.Size(106, 25);
            this.dateChangeDate.TabIndex = 2;
            this.dateChangeDate.Leave += new System.EventHandler(this.dateChangeDate_Leave);
            // 
            // textNewInterestRate
            // 
            this.textNewInterestRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNewInterestRate.Location = new System.Drawing.Point(529, 14);
            this.textNewInterestRate.Name = "textNewInterestRate";
            this.textNewInterestRate.Size = new System.Drawing.Size(115, 25);
            this.textNewInterestRate.TabIndex = 3;
            this.textNewInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textNewInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNewInterestRate_KeyPress);
            this.textNewInterestRate.Leave += new System.EventHandler(this.textNewInterestRate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(450, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "New Rate";
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
            this.HeaderPanel.TabIndex = 48;
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
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Update Interest";
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MenuPanel.Controls.Add(this.textOldInterestRate);
            this.MenuPanel.Controls.Add(this.label4);
            this.MenuPanel.Controls.Add(this.label10);
            this.MenuPanel.Controls.Add(this.dateChangeDate);
            this.MenuPanel.Controls.Add(this.textNewInterestRate);
            this.MenuPanel.Controls.Add(this.label3);
            this.MenuPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPanel.Location = new System.Drawing.Point(0, 33);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(950, 50);
            this.MenuPanel.TabIndex = 49;
            // 
            // textOldInterestRate
            // 
            this.textOldInterestRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOldInterestRate.Location = new System.Drawing.Point(96, 14);
            this.textOldInterestRate.Name = "textOldInterestRate";
            this.textOldInterestRate.Size = new System.Drawing.Size(115, 25);
            this.textOldInterestRate.TabIndex = 1;
            this.textOldInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOldInterestRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textOldInterestRate_KeyPress);
            this.textOldInterestRate.Leave += new System.EventHandler(this.textOldInterestRate_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(17, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 93;
            this.label4.Text = "Old Rate";
            // 
            // InterestUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MenuPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InterestUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterestUpdateForm";
            this.Load += new System.EventHandler(this.InterestUpdateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestments)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvestPledges)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView gridInvestments;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button WindowClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button UpdateInvestments;
        private System.Windows.Forms.DataGridViewTextBoxColumn investor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Investor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewInterestRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dateChangeDate;
        public System.Windows.Forms.TextBox textNewInterestRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView gridInvestPledges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updatePledges;
        public System.Windows.Forms.TextBox textOldInterestRate;
        private System.Windows.Forms.Label label4;
    }
}