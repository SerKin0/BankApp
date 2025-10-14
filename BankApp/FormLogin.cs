using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    public partial class FormLogin : Form
    {
        public ClientData TempUser { get; private set; }

        public FormLogin(string title = "Регистрация", ClientData? userData = null)
        {
            InitializeComponent();
            labelRegistrationLogin.Text = title;
            TempUser = userData ?? new ClientData(); // Без параметров, так как конструктор теперь безопасен
            this.Load += FormLogin_Load;
            textBoxLoginNumberPhone.TextChanged += textBoxLoginNumberPhone_TextChanged;
        }

        private void FormLogin_Load(object? sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            textBoxLoginSecondName.Text = TempUser.LastName;
            textBoxLoginFirstName.Text = TempUser.FirstName;
            textBoxLoginMiddleName.Text = TempUser.MiddleName;
            textBoxLoginNumberPhone.Text = TempUser.PhoneNumber;
            textBoxLoginPassportSeries.Text = TempUser.PassportSeries;
            textBoxLoginPassportNumber.Text = TempUser.PassportNumber;
            textBoxLoginCardNumber.Text = TempUser.CardNumber;
        }

        private void buttonConfirm_Click(object? sender, EventArgs e)
        {
            // Проверяем валидность всех полей перед сохранением
            try
            {
                TempUser.LastName = textBoxLoginSecondName.Text;
                TempUser.FirstName = textBoxLoginFirstName.Text;
                TempUser.MiddleName = textBoxLoginMiddleName.Text;
                TempUser.PhoneNumber = textBoxLoginNumberPhone.Text;
                TempUser.PassportSeries = textBoxLoginPassportSeries.Text;
                TempUser.PassportNumber = textBoxLoginPassportNumber.Text;
                TempUser.CardNumber = textBoxLoginCardNumber.Text;

                if (!TempUser.isValidate)
                {
                    MessageBox.Show("Проверьте введенные данные в полях. Все поля должны быть корректно заполнены.");
                    return;
                }

                var db = Program.GetDbClient();
                if (labelRegistrationLogin.Text == "Редактирование")
                {
                    if (TempUser.Id == 0)
                    {
                        MessageBox.Show("ID пользователя не установлен для редактирования.");
                        return;
                    }
                    db.UpdateUser(TempUser.Id, TempUser);
                    MessageBox.Show("Данные пользователя обновлены!");
                }
                else
                {
                    db.InsertUser(TempUser);
                    MessageBox.Show("Пользователь создан удачно!");
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void textBoxLoginSecondName_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.LastName = textBoxLoginSecondName.Text;
                textBoxLoginSecondName.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginSecondName.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginFirstName_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.FirstName = textBoxLoginFirstName.Text;
                textBoxLoginFirstName.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginFirstName.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginMiddleName_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.MiddleName = textBoxLoginMiddleName.Text;
                textBoxLoginMiddleName.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginMiddleName.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginNumberPhone_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.PhoneNumber = textBoxLoginNumberPhone.Text;
                textBoxLoginNumberPhone.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginNumberPhone.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginPassportSeries_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.PassportSeries = textBoxLoginPassportSeries.Text;
                textBoxLoginPassportSeries.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginPassportSeries.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginPassportNumber_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.PassportNumber = textBoxLoginPassportNumber.Text;
                textBoxLoginPassportNumber.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginPassportNumber.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginCardNumber_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                TempUser.CardNumber = textBoxLoginCardNumber.Text;
                textBoxLoginCardNumber.BackColor = TempUser.isValidate ? Color.White : Color.LightPink;
            }
            catch (Exception)
            {
                textBoxLoginCardNumber.BackColor = Color.LightPink;
            }
        }

        private void textBoxLoginNumberPhone_TextChanged(object? sender, EventArgs e)
        {
            // Можно оставить пустым или добавить динамическую валидацию
        }
    }
}