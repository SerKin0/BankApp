namespace BankApp
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxLoginSecondName = new TextBox();
            labelLoginSecondName = new Label();
            labelLoginFirstName = new Label();
            textBoxLoginFirstName = new TextBox();
            textBoxLoginMiddleName = new TextBox();
            labelLoginMiddleName = new Label();
            textBoxLoginNumberPhone = new TextBox();
            labelLoginPhoneNumber = new Label();
            textBoxLoginPassportSeries = new TextBox();
            labelLoginNumberPhone = new Label();
            textBoxLoginPassportNumber = new TextBox();
            labelLoginPassportNumber = new Label();
            textBoxLoginCardNumber = new TextBox();
            labelLoginCardNumber = new Label();
            buttonConfirm = new Button();
            labelRegistrationLogin = new Label();
            SuspendLayout();
            // 
            // textBoxLoginSecondName
            // 
            textBoxLoginSecondName.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginSecondName.Location = new Point(16, 93);
            textBoxLoginSecondName.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginSecondName.Name = "textBoxLoginSecondName";
            textBoxLoginSecondName.PlaceholderText = "Иванович";
            textBoxLoginSecondName.Size = new Size(362, 25);
            textBoxLoginSecondName.TabIndex = 1;
            textBoxLoginSecondName.LostFocus += textBoxLoginSecondName_LostFocus;
            // 
            // labelLoginSecondName
            // 
            labelLoginSecondName.AutoSize = true;
            labelLoginSecondName.Font = new Font("Sansation", 14.25F);
            labelLoginSecondName.Location = new Point(12, 65);
            labelLoginSecondName.Name = "labelLoginSecondName";
            labelLoginSecondName.Size = new Size(95, 21);
            labelLoginSecondName.TabIndex = 2;
            labelLoginSecondName.Text = "Фамилия";
            // 
            // labelLoginFirstName
            // 
            labelLoginFirstName.AutoSize = true;
            labelLoginFirstName.Font = new Font("Sansation", 14.25F);
            labelLoginFirstName.Location = new Point(12, 132);
            labelLoginFirstName.Name = "labelLoginFirstName";
            labelLoginFirstName.Size = new Size(49, 21);
            labelLoginFirstName.TabIndex = 3;
            labelLoginFirstName.Text = "Имя";
            // 
            // textBoxLoginFirstName
            // 
            textBoxLoginFirstName.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginFirstName.Location = new Point(16, 160);
            textBoxLoginFirstName.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginFirstName.Name = "textBoxLoginFirstName";
            textBoxLoginFirstName.PlaceholderText = "Иван";
            textBoxLoginFirstName.Size = new Size(362, 25);
            textBoxLoginFirstName.TabIndex = 4;
            textBoxLoginFirstName.LostFocus += textBoxLoginFirstName_LostFocus;
            // 
            // textBoxLoginMiddleName
            // 
            textBoxLoginMiddleName.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginMiddleName.Location = new Point(16, 227);
            textBoxLoginMiddleName.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginMiddleName.Name = "textBoxLoginMiddleName";
            textBoxLoginMiddleName.PlaceholderText = "Иванов";
            textBoxLoginMiddleName.Size = new Size(362, 25);
            textBoxLoginMiddleName.TabIndex = 6;
            textBoxLoginMiddleName.LostFocus += textBoxLoginMiddleName_LostFocus;
            // 
            // labelLoginMiddleName
            // 
            labelLoginMiddleName.AutoSize = true;
            labelLoginMiddleName.Font = new Font("Sansation", 14.25F);
            labelLoginMiddleName.Location = new Point(12, 199);
            labelLoginMiddleName.Name = "labelLoginMiddleName";
            labelLoginMiddleName.Size = new Size(97, 21);
            labelLoginMiddleName.TabIndex = 5;
            labelLoginMiddleName.Text = "Отчество";
            // 
            // textBoxLoginNumberPhone
            // 
            textBoxLoginNumberPhone.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginNumberPhone.Location = new Point(388, 93);
            textBoxLoginNumberPhone.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginNumberPhone.Name = "textBoxLoginNumberPhone";
            textBoxLoginNumberPhone.PlaceholderText = "+7 (000) 000-00-00";
            textBoxLoginNumberPhone.Size = new Size(362, 25);
            textBoxLoginNumberPhone.TabIndex = 8;
            textBoxLoginNumberPhone.TextChanged += textBoxLoginNumberPhone_TextChanged;
            textBoxLoginNumberPhone.LostFocus += textBoxLoginNumberPhone_LostFocus;
            // 
            // labelLoginPhoneNumber
            // 
            labelLoginPhoneNumber.AutoSize = true;
            labelLoginPhoneNumber.Font = new Font("Sansation", 14.25F);
            labelLoginPhoneNumber.Location = new Point(384, 65);
            labelLoginPhoneNumber.Name = "labelLoginPhoneNumber";
            labelLoginPhoneNumber.Size = new Size(165, 21);
            labelLoginPhoneNumber.TabIndex = 7;
            labelLoginPhoneNumber.Text = "Номер телефона";
            // 
            // textBoxLoginPassportSeries
            // 
            textBoxLoginPassportSeries.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginPassportSeries.Location = new Point(388, 160);
            textBoxLoginPassportSeries.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginPassportSeries.Name = "textBoxLoginPassportSeries";
            textBoxLoginPassportSeries.PlaceholderText = "0000";
            textBoxLoginPassportSeries.Size = new Size(362, 25);
            textBoxLoginPassportSeries.TabIndex = 10;
            textBoxLoginPassportSeries.LostFocus += textBoxLoginPassportSeries_LostFocus;
            // 
            // labelLoginNumberPhone
            // 
            labelLoginNumberPhone.AutoSize = true;
            labelLoginNumberPhone.Font = new Font("Sansation", 14.25F);
            labelLoginNumberPhone.Location = new Point(384, 132);
            labelLoginNumberPhone.Name = "labelLoginNumberPhone";
            labelLoginNumberPhone.Size = new Size(157, 21);
            labelLoginNumberPhone.TabIndex = 9;
            labelLoginNumberPhone.Text = "Серия паспорта";
            // 
            // textBoxLoginPassportNumber
            // 
            textBoxLoginPassportNumber.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginPassportNumber.Location = new Point(388, 227);
            textBoxLoginPassportNumber.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginPassportNumber.Name = "textBoxLoginPassportNumber";
            textBoxLoginPassportNumber.PlaceholderText = "000 000";
            textBoxLoginPassportNumber.Size = new Size(362, 25);
            textBoxLoginPassportNumber.TabIndex = 12;
            textBoxLoginPassportNumber.LostFocus += textBoxLoginPassportNumber_LostFocus;
            // 
            // labelLoginPassportNumber
            // 
            labelLoginPassportNumber.AutoSize = true;
            labelLoginPassportNumber.Font = new Font("Sansation", 14.25F);
            labelLoginPassportNumber.Location = new Point(384, 199);
            labelLoginPassportNumber.Name = "labelLoginPassportNumber";
            labelLoginPassportNumber.Size = new Size(157, 21);
            labelLoginPassportNumber.TabIndex = 11;
            labelLoginPassportNumber.Text = "Серия паспорта";
            // 
            // textBoxLoginCardNumber
            // 
            textBoxLoginCardNumber.Font = new Font("Sansation", 12F, FontStyle.Italic);
            textBoxLoginCardNumber.ForeColor = SystemColors.WindowText;
            textBoxLoginCardNumber.Location = new Point(208, 294);
            textBoxLoginCardNumber.Margin = new Padding(7, 3, 3, 10);
            textBoxLoginCardNumber.Name = "textBoxLoginCardNumber";
            textBoxLoginCardNumber.PlaceholderText = "0000 0000 0000 0000";
            textBoxLoginCardNumber.Size = new Size(362, 25);
            textBoxLoginCardNumber.TabIndex = 14;
            textBoxLoginCardNumber.TextAlign = HorizontalAlignment.Center;
            textBoxLoginCardNumber.LostFocus += textBoxLoginCardNumber_LostFocus;
            // 
            // labelLoginCardNumber
            // 
            labelLoginCardNumber.AutoSize = true;
            labelLoginCardNumber.Font = new Font("Sansation", 14.25F);
            labelLoginCardNumber.Location = new Point(316, 266);
            labelLoginCardNumber.Name = "labelLoginCardNumber";
            labelLoginCardNumber.Size = new Size(131, 21);
            labelLoginCardNumber.TabIndex = 13;
            labelLoginCardNumber.Text = "Номер карты";
            // 
            // buttonConfirm
            // 
            buttonConfirm.Font = new Font("Sansation", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonConfirm.Location = new Point(24, 351);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(734, 44);
            buttonConfirm.TabIndex = 15;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // labelRegistrationLogin
            // 
            labelRegistrationLogin.AutoSize = true;
            labelRegistrationLogin.BackColor = Color.Transparent;
            labelRegistrationLogin.Font = new Font("Sansation", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRegistrationLogin.Location = new Point(12, 9);
            labelRegistrationLogin.Margin = new Padding(3, 0, 3, 20);
            labelRegistrationLogin.Name = "labelRegistrationLogin";
            labelRegistrationLogin.Size = new Size(179, 30);
            labelRegistrationLogin.TabIndex = 0;
            labelRegistrationLogin.Text = "Регистрация";
            labelRegistrationLogin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(770, 407);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxLoginCardNumber);
            Controls.Add(labelLoginCardNumber);
            Controls.Add(textBoxLoginPassportNumber);
            Controls.Add(labelLoginPassportNumber);
            Controls.Add(textBoxLoginPassportSeries);
            Controls.Add(labelLoginNumberPhone);
            Controls.Add(textBoxLoginNumberPhone);
            Controls.Add(labelLoginPhoneNumber);
            Controls.Add(textBoxLoginMiddleName);
            Controls.Add(labelLoginMiddleName);
            Controls.Add(textBoxLoginFirstName);
            Controls.Add(labelLoginFirstName);
            Controls.Add(labelLoginSecondName);
            Controls.Add(textBoxLoginSecondName);
            Controls.Add(labelRegistrationLogin);
            Name = "FormLogin";
            ShowIcon = false;
            Text = "Регистрация (C# Предприятие)";
            //Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxLoginSecondName;
        private Label labelLoginSecondName;
        private Label labelLoginFirstName;
        private TextBox textBoxLoginFirstName;
        private TextBox textBoxLoginMiddleName;
        private Label labelLoginMiddleName;
        private TextBox textBoxLoginNumberPhone;
        private Label labelLoginPhoneNumber;
        private TextBox textBoxLoginPassportSeries;
        private Label labelLoginNumberPhone;
        private TextBox textBoxLoginPassportNumber;
        private Label labelLoginPassportNumber;
        private TextBox textBoxLoginCardNumber;
        private Label labelLoginCardNumber;
        private Button buttonConfirm;
        private Label labelRegistrationLogin;
    }
}
