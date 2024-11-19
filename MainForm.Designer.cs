namespace Lab12BPDT
{
    partial class MainForm
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
            Data = new TextBox();
            label1 = new Label();
            SaveDataBTN = new Button();
            DeleteDataBTN = new Button();
            DeleteUserBTN = new Button();
            ViewData = new Button();
            dataGridView = new DataGridView();
            ViewUsersBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Data
            // 
            Data.Location = new Point(130, 75);
            Data.Name = "Data";
            Data.Size = new Size(125, 27);
            Data.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 52);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter data";
            // 
            // SaveDataBTN
            // 
            SaveDataBTN.Location = new Point(77, 113);
            SaveDataBTN.Name = "SaveDataBTN";
            SaveDataBTN.Size = new Size(94, 29);
            SaveDataBTN.TabIndex = 2;
            SaveDataBTN.Text = "Save Data";
            SaveDataBTN.UseVisualStyleBackColor = true;
            SaveDataBTN.Click += SaveDataBTN_Click;
            // 
            // DeleteDataBTN
            // 
            DeleteDataBTN.Location = new Point(277, 113);
            DeleteDataBTN.Name = "DeleteDataBTN";
            DeleteDataBTN.Size = new Size(104, 29);
            DeleteDataBTN.TabIndex = 3;
            DeleteDataBTN.Text = "Delete Data";
            DeleteDataBTN.UseVisualStyleBackColor = true;
            DeleteDataBTN.Click += DeleteDataBTN_Click;
            // 
            // DeleteUserBTN
            // 
            DeleteUserBTN.Location = new Point(619, 116);
            DeleteUserBTN.Name = "DeleteUserBTN";
            DeleteUserBTN.Size = new Size(94, 29);
            DeleteUserBTN.TabIndex = 4;
            DeleteUserBTN.Text = "Delete User";
            DeleteUserBTN.UseVisualStyleBackColor = true;
            DeleteUserBTN.Click += DeleteUserBTN_Click;
            // 
            // ViewData
            // 
            ViewData.Location = new Point(177, 113);
            ViewData.Name = "ViewData";
            ViewData.Size = new Size(94, 29);
            ViewData.TabIndex = 5;
            ViewData.Text = "View Data";
            ViewData.UseVisualStyleBackColor = true;
            ViewData.Click += ViewData_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(203, 243);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(510, 188);
            dataGridView.TabIndex = 6;
            // 
            // ViewUsersBTN
            // 
            ViewUsersBTN.Location = new Point(500, 116);
            ViewUsersBTN.Name = "ViewUsersBTN";
            ViewUsersBTN.Size = new Size(94, 29);
            ViewUsersBTN.TabIndex = 7;
            ViewUsersBTN.Text = "View Users";
            ViewUsersBTN.UseVisualStyleBackColor = true;
            ViewUsersBTN.Click += ViewUsersBTN_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ViewUsersBTN);
            Controls.Add(dataGridView);
            Controls.Add(ViewData);
            Controls.Add(DeleteUserBTN);
            Controls.Add(DeleteDataBTN);
            Controls.Add(SaveDataBTN);
            Controls.Add(label1);
            Controls.Add(Data);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Data;
        private Label label1;
        private Button SaveDataBTN;
        private Button DeleteDataBTN;
        private Button DeleteUserBTN;
        private Button ViewData;
        private DataGridView dataGridView;
        private Button ViewUsersBTN;
    }
}