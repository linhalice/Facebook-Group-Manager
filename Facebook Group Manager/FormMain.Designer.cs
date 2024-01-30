namespace Facebook_Group_Manager
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dataGridViewGroup = new DataGridView();
            label1 = new Label();
            textBoxCookie = new TextBox();
            button1 = new Button();
            textBoxToken = new TextBox();
            label2 = new Label();
            button2 = new Button();
            cIndex = new DataGridViewTextBoxColumn();
            cId = new DataGridViewTextBoxColumn();
            cMember = new DataGridViewTextBoxColumn();
            cStatus = new DataGridViewTextBoxColumn();
            cLink = new DataGridViewTextBoxColumn();
            cName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGroup).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGroup
            // 
            dataGridViewGroup.AllowUserToAddRows = false;
            dataGridViewGroup.AllowUserToDeleteRows = false;
            dataGridViewGroup.AllowUserToResizeRows = false;
            dataGridViewGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGroup.Columns.AddRange(new DataGridViewColumn[] { cIndex, cId, cMember, cStatus, cLink, cName });
            dataGridViewGroup.Location = new Point(12, 12);
            dataGridViewGroup.Name = "dataGridViewGroup";
            dataGridViewGroup.Size = new Size(901, 309);
            dataGridViewGroup.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 334);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Cookie:";
            label1.Click += label1_Click;
            // 
            // textBoxCookie
            // 
            textBoxCookie.Location = new Point(68, 330);
            textBoxCookie.Name = "textBoxCookie";
            textBoxCookie.Size = new Size(764, 23);
            textBoxCookie.TabIndex = 2;
            textBoxCookie.TextChanged += textBoxCookie_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(838, 365);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Check";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxToken
            // 
            textBoxToken.Location = new Point(68, 365);
            textBoxToken.Name = "textBoxToken";
            textBoxToken.Size = new Size(764, 23);
            textBoxToken.TabIndex = 5;
            textBoxToken.TextChanged += textBoxToken_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 369);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 4;
            label2.Text = "Token:";
            // 
            // button2
            // 
            button2.Location = new Point(838, 327);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Dán group";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // cIndex
            // 
            cIndex.HeaderText = "Index";
            cIndex.Name = "cIndex";
            cIndex.Width = 80;
            // 
            // cId
            // 
            cId.HeaderText = "Id";
            cId.Name = "cId";
            cId.Width = 150;
            // 
            // cMember
            // 
            cMember.HeaderText = "Member";
            cMember.Name = "cMember";
            // 
            // cStatus
            // 
            cStatus.HeaderText = "Status";
            cStatus.Name = "cStatus";
            cStatus.Width = 200;
            // 
            // cLink
            // 
            cLink.HeaderText = "Link";
            cLink.Name = "cLink";
            // 
            // cName
            // 
            cName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cName.HeaderText = "Name";
            cName.Name = "cName";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 400);
            Controls.Add(button2);
            Controls.Add(textBoxToken);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBoxCookie);
            Controls.Add(label1);
            Controls.Add(dataGridViewGroup);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý group";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewGroup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewGroup;
        private Label label1;
        private TextBox textBoxCookie;
        private Button button1;
        private TextBox textBoxToken;
        private Label label2;
        private Button button2;
        private DataGridViewTextBoxColumn cIndex;
        private DataGridViewTextBoxColumn cId;
        private DataGridViewTextBoxColumn cMember;
        private DataGridViewTextBoxColumn cStatus;
        private DataGridViewTextBoxColumn cLink;
        private DataGridViewTextBoxColumn cName;
    }
}