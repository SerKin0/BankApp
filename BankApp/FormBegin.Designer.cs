namespace BankApp
{
    partial class FormBegin
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
            textBoxBeginPassword = new TextBox();
            labelBeginPassword = new Label();
            labelBeginLogin = new Label();
            textBoxBeginLogin = new TextBox();
            labelBeginAutorisation = new Label();
            buttonBeginConfirm = new Button();
            SuspendLayout();
            // 
            // textBoxBeginPassword
            // 
            textBoxBeginPassword.Font = new Font("Sansation", 12F);
            textBoxBeginPassword.Location = new Point(16, 149);
            textBoxBeginPassword.Margin = new Padding(7, 3, 3, 9);
            textBoxBeginPassword.Name = "textBoxBeginPassword";
            textBoxBeginPassword.Size = new Size(362, 25);
            textBoxBeginPassword.TabIndex = 9;
            textBoxBeginPassword.UseSystemPasswordChar = true;
            // 
            // labelBeginPassword
            // 
            labelBeginPassword.AutoSize = true;
            labelBeginPassword.Font = new Font("Sansation", 14.25F);
            labelBeginPassword.Location = new Point(12, 123);
            labelBeginPassword.Name = "labelBeginPassword";
            labelBeginPassword.Size = new Size(80, 21);
            labelBeginPassword.TabIndex = 8;
            labelBeginPassword.Text = "Пароль";
            // 
            // labelBeginLogin
            // 
            labelBeginLogin.AutoSize = true;
            labelBeginLogin.Font = new Font("Sansation", 14.25F);
            labelBeginLogin.Location = new Point(12, 61);
            labelBeginLogin.Name = "labelBeginLogin";
            labelBeginLogin.Size = new Size(200, 21);
            labelBeginLogin.TabIndex = 7;
            labelBeginLogin.Text = "Логин пользователя";
            labelBeginLogin.Click += labelLoginSecondName_Click;
            // 
            // textBoxBeginLogin
            // 
            textBoxBeginLogin.Font = new Font("Sansation", 12F);
            textBoxBeginLogin.Location = new Point(16, 87);
            textBoxBeginLogin.Margin = new Padding(7, 3, 3, 9);
            textBoxBeginLogin.Name = "textBoxBeginLogin";
            textBoxBeginLogin.Size = new Size(362, 25);
            textBoxBeginLogin.TabIndex = 6;
            // 
            // labelBeginAutorisation
            // 
            labelBeginAutorisation.AutoSize = true;
            labelBeginAutorisation.BackColor = Color.Transparent;
            labelBeginAutorisation.Font = new Font("Sansation", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBeginAutorisation.Location = new Point(12, 8);
            labelBeginAutorisation.Margin = new Padding(3, 0, 3, 19);
            labelBeginAutorisation.Name = "labelBeginAutorisation";
            labelBeginAutorisation.Size = new Size(187, 30);
            labelBeginAutorisation.TabIndex = 5;
            labelBeginAutorisation.Text = "Авторизация";
            labelBeginAutorisation.TextAlign = ContentAlignment.MiddleRight;
            labelBeginAutorisation.Click += labelRegistrationLogin_Click;
            // 
            // buttonBeginConfirm
            // 
            buttonBeginConfirm.Font = new Font("Sansation", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBeginConfirm.Location = new Point(16, 195);
            buttonBeginConfirm.Name = "buttonBeginConfirm";
            buttonBeginConfirm.Size = new Size(362, 41);
            buttonBeginConfirm.TabIndex = 16;
            buttonBeginConfirm.Text = "Войти";
            buttonBeginConfirm.UseVisualStyleBackColor = true;
            buttonBeginConfirm.Click += buttonConfirm_Click;
            // 
            // FormBegin
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(390, 247);
            Controls.Add(buttonBeginConfirm);
            Controls.Add(textBoxBeginPassword);
            Controls.Add(labelBeginPassword);
            Controls.Add(labelBeginLogin);
            Controls.Add(textBoxBeginLogin);
            Controls.Add(labelBeginAutorisation);
            Font = new Font("Sansation", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormBegin";
            ShowIcon = false;
            Text = "Авторизация (C# Предприятие)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxBeginPassword;
        private Label labelBeginPassword;
        private Label labelBeginLogin;
        private TextBox textBoxBeginLogin;
        private Label labelBeginAutorisation;
        private Button buttonBeginConfirm;
    }
}