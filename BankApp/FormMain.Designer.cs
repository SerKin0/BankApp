namespace BankApp
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            buttonMainAdd = new Button();
            buttonMainEnterExit = new Button();
            labelMainEmployer = new Label();
            buttonMainReload = new Button();
            labelRegistrationLogin = new Label();
            dataGridViewMainClients = new DataGridView();
            AddClientToolStripMenuItem = new ToolStripMenuItem();
            ChangeClientToolStripMenuItem = new ToolStripMenuItem();
            DeleteClientToolStripMenuItem = new ToolStripMenuItem();
            contextMenuMainTable = new ContextMenuStrip(components);
            labelMainRole = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMainClients).BeginInit();
            contextMenuMainTable.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMainAdd
            // 
            buttonMainAdd.BackColor = Color.White;
            buttonMainAdd.Font = new Font("Sansation", 12F);
            buttonMainAdd.ForeColor = Color.Black;
            buttonMainAdd.Location = new Point(12, 387);
            buttonMainAdd.Name = "buttonMainAdd";
            buttonMainAdd.Size = new Size(120, 28);
            buttonMainAdd.TabIndex = 19;
            buttonMainAdd.Text = "➕ Добавить";
            buttonMainAdd.UseVisualStyleBackColor = false;
            buttonMainAdd.Click += AddClientToolStripMenuItem_Click;
            // 
            // buttonMainEnterExit
            // 
            buttonMainEnterExit.Font = new Font("Sansation", 14F);
            buttonMainEnterExit.Location = new Point(1014, 387);
            buttonMainEnterExit.Name = "buttonMainEnterExit";
            buttonMainEnterExit.Size = new Size(213, 29);
            buttonMainEnterExit.TabIndex = 20;
            buttonMainEnterExit.Text = "🔑 Вход";
            buttonMainEnterExit.UseVisualStyleBackColor = true;
            buttonMainEnterExit.Click += buttonMainEnterExit_Click;
            // 
            // labelMainEmployer
            // 
            labelMainEmployer.AutoSize = true;
            labelMainEmployer.Font = new Font("Sansation", 9F);
            labelMainEmployer.Location = new Point(569, 369);
            labelMainEmployer.Name = "labelMainEmployer";
            labelMainEmployer.Size = new Size(0, 14);
            labelMainEmployer.TabIndex = 21;
            // 
            // buttonMainReload
            // 
            buttonMainReload.Font = new Font("Sansation", 12F);
            buttonMainReload.Location = new Point(138, 387);
            buttonMainReload.Name = "buttonMainReload";
            buttonMainReload.Size = new Size(120, 28);
            buttonMainReload.TabIndex = 23;
            buttonMainReload.Text = "🔄 Обновить";
            buttonMainReload.UseVisualStyleBackColor = true;
            buttonMainReload.Click += buttonMainReload_Click;
            // 
            // labelRegistrationLogin
            // 
            labelRegistrationLogin.AutoSize = true;
            labelRegistrationLogin.BackColor = Color.Transparent;
            labelRegistrationLogin.Font = new Font("Sansation", 18F, FontStyle.Bold);
            labelRegistrationLogin.Location = new Point(1014, 11);
            labelRegistrationLogin.Margin = new Padding(3, 0, 3, 19);
            labelRegistrationLogin.Name = "labelRegistrationLogin";
            labelRegistrationLogin.Size = new Size(213, 27);
            labelRegistrationLogin.TabIndex = 27;
            labelRegistrationLogin.Text = "C# Предприятие";
            labelRegistrationLogin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataGridViewMainClients
            // 
            dataGridViewMainClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMainClients.BackgroundColor = Color.White;
            dataGridViewMainClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewMainClients.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewMainClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewMainClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMainClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMainClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewMainClients.Enabled = false;
            dataGridViewMainClients.EnableHeadersVisualStyles = false;
            dataGridViewMainClients.GridColor = Color.FromArgb(200, 200, 200);
            dataGridViewMainClients.Location = new Point(12, 11);
            dataGridViewMainClients.Name = "dataGridViewMainClients";
            dataGridViewMainClients.RowHeadersVisible = false;
            dataGridViewMainClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMainClients.Size = new Size(996, 371);
            dataGridViewMainClients.TabIndex = 28;
            dataGridViewMainClients.CellMouseClick += dataGridViewMainClients_CellMouseClick;
            // 
            // AddClientToolStripMenuItem
            // 
            AddClientToolStripMenuItem.Name = "AddClientToolStripMenuItem";
            AddClientToolStripMenuItem.Size = new Size(201, 22);
            AddClientToolStripMenuItem.Text = "Добавить клиента";
            AddClientToolStripMenuItem.Click += AddClientToolStripMenuItem_Click;
            // 
            // ChangeClientToolStripMenuItem
            // 
            ChangeClientToolStripMenuItem.Name = "ChangeClientToolStripMenuItem";
            ChangeClientToolStripMenuItem.Size = new Size(201, 22);
            ChangeClientToolStripMenuItem.Text = "Редактировать клиента";
            ChangeClientToolStripMenuItem.Click += ChangeClientToolStripMenuItem_Click;
            // 
            // DeleteClientToolStripMenuItem
            // 
            DeleteClientToolStripMenuItem.Name = "DeleteClientToolStripMenuItem";
            DeleteClientToolStripMenuItem.Size = new Size(201, 22);
            DeleteClientToolStripMenuItem.Text = "Удалить клиента";
            DeleteClientToolStripMenuItem.Click += DeleteClientToolStripMenuItem_Click;
            // 
            // contextMenuMainTable
            // 
            contextMenuMainTable.Items.AddRange(new ToolStripItem[] { AddClientToolStripMenuItem, ChangeClientToolStripMenuItem, DeleteClientToolStripMenuItem });
            contextMenuMainTable.Name = "contextMenuStrip1";
            contextMenuMainTable.Size = new Size(202, 70);
            contextMenuMainTable.Opening += contextMenuMainTable_Opening;
            // 
            // labelMainRole
            // 
            labelMainRole.AutoSize = true;
            labelMainRole.Location = new Point(1014, 57);
            labelMainRole.Name = "labelMainRole";
            labelMainRole.Size = new Size(0, 14);
            labelMainRole.TabIndex = 29;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1239, 427);
            Controls.Add(labelMainRole);
            Controls.Add(dataGridViewMainClients);
            Controls.Add(labelRegistrationLogin);
            Controls.Add(buttonMainReload);
            Controls.Add(labelMainEmployer);
            Controls.Add(buttonMainEnterExit);
            Controls.Add(buttonMainAdd);
            Font = new Font("Sansation", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormMain";
            ShowIcon = false;
            Text = "Клиенты (C# Предприятие)";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMainClients).EndInit();
            contextMenuMainTable.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonMainAdd;
        private Button buttonMainEnterExit;
        private Label labelMainEmployer;
        private Button buttonMainReload;
        private Label labelRegistrationLogin;
        private DataGridView dataGridViewMainClients;
        private ToolStripMenuItem AddClientToolStripMenuItem;
        private ToolStripMenuItem ChangeClientToolStripMenuItem;
        private ToolStripMenuItem DeleteClientToolStripMenuItem;
        private ContextMenuStrip contextMenuMainTable;
        private Label labelMainRole;
    }
}