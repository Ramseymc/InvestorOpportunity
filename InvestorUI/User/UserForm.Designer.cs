namespace InvestorUI
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.textRecordId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.checkBlocked = new System.Windows.Forms.CheckBox();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.WindowClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboSearchList = new System.Windows.Forms.ComboBox();
            this.UndoButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.FirstButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textLastName);
            this.groupBox1.Controls.Add(this.textRecordId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textFirstName);
            this.groupBox1.Controls.Add(this.checkBlocked);
            this.groupBox1.Location = new System.Drawing.Point(5, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 445);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Email \\ Username";
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.Location = new System.Drawing.Point(45, 80);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(222, 25);
            this.textUsername.TabIndex = 1;
            this.textUsername.TextChanged += new System.EventHandler(this.textUsername_TextChanged);
            this.textUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUsername_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "FirstName";
            // 
            // textLastName
            // 
            this.textLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLastName.Location = new System.Drawing.Point(45, 210);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(222, 25);
            this.textLastName.TabIndex = 3;
            this.textLastName.TextChanged += new System.EventHandler(this.textLastName_TextChanged);
            this.textLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLastName_KeyPress);
            // 
            // textRecordId
            // 
            this.textRecordId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textRecordId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRecordId.Location = new System.Drawing.Point(151, 115);
            this.textRecordId.Name = "textRecordId";
            this.textRecordId.Size = new System.Drawing.Size(116, 25);
            this.textRecordId.TabIndex = 32;
            this.textRecordId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(45, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Last Name";
            // 
            // textFirstName
            // 
            this.textFirstName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFirstName.Location = new System.Drawing.Point(45, 145);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(222, 25);
            this.textFirstName.TabIndex = 2;
            this.textFirstName.TextChanged += new System.EventHandler(this.textFirstName_TextChanged);
            this.textFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFirstName_KeyPress);
            // 
            // checkBlocked
            // 
            this.checkBlocked.AutoSize = true;
            this.checkBlocked.Location = new System.Drawing.Point(49, 254);
            this.checkBlocked.Name = "checkBlocked";
            this.checkBlocked.Size = new System.Drawing.Size(67, 21);
            this.checkBlocked.TabIndex = 4;
            this.checkBlocked.Text = "Closed";
            this.checkBlocked.UseVisualStyleBackColor = true;
            this.checkBlocked.CheckedChanged += new System.EventHandler(this.checkBlocked_CheckedChanged);
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
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Portal Users";
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MenuPanel.Controls.Add(this.panel1);
            this.MenuPanel.Controls.Add(this.UndoButton);
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
            this.MenuPanel.Size = new System.Drawing.Size(950, 50);
            this.MenuPanel.TabIndex = 43;
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
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MenuPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textLastName;
        public System.Windows.Forms.TextBox textRecordId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textFirstName;
        public System.Windows.Forms.CheckBox checkBlocked;
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
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textUsername;
    }
}