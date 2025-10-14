using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    public partial class FormLogin : Form
    {
        public ClientData TempUser { get; private set; }
        private Checker _checker;

        public FormLogin(string title = "Регистрация", ClientData? userData = null)
        {
            InitializeComponent();
            labelRegistrationLogin.Text = title;
            TempUser = userData ?? new ClientData();
            _checker = new Checker();

            this.Load += FormLogin_Load;
            InitializeValidationEvents();
        }

        private void InitializeValidationEvents()
        {
            // Подписываемся на события потери фокуса для валидации
            textBoxLoginSecondName.LostFocus += ValidateLastName;
            textBoxLoginFirstName.LostFocus += ValidateFirstName;
            textBoxLoginMiddleName.LostFocus += ValidateMiddleName;
            textBoxLoginNumberPhone.LostFocus += ValidatePhoneNumber;
            textBoxLoginPassportSeries.LostFocus += ValidatePassportSeries;
            textBoxLoginPassportNumber.LostFocus += ValidatePassportNumber;
            textBoxLoginCardNumber.LostFocus += ValidateCardNumber;
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

            // Валидируем загруженные данные
            ValidateAllFields();
        }

        private void ValidateAllFields()
        {
            ValidateLastName(null, EventArgs.Empty);
            ValidateFirstName(null, EventArgs.Empty);
            ValidateMiddleName(null, EventArgs.Empty);
            ValidatePhoneNumber(null, EventArgs.Empty);
            ValidatePassportSeries(null, EventArgs.Empty);
            ValidatePassportNumber(null, EventArgs.Empty);
            ValidateCardNumber(null, EventArgs.Empty);
        }

        private void ValidateLastName(object? sender, EventArgs e)
        {
            var isValid = _checker.checkName(textBoxLoginSecondName.Text);
            textBoxLoginSecondName.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.LastName = textBoxLoginSecondName.Text;

            UpdateConfirmButton();
        }

        private void ValidateFirstName(object? sender, EventArgs e)
        {
            var isValid = _checker.checkName(textBoxLoginFirstName.Text);
            textBoxLoginFirstName.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.FirstName = textBoxLoginFirstName.Text;

            UpdateConfirmButton();
        }

        private void ValidateMiddleName(object? sender, EventArgs e)
        {
            var isValid = _checker.checkName(textBoxLoginMiddleName.Text);
            textBoxLoginMiddleName.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.MiddleName = textBoxLoginMiddleName.Text;

            UpdateConfirmButton();
        }

        private void ValidatePhoneNumber(object? sender, EventArgs e)
        {
            var isValid = _checker.checkPhoneNumber(textBoxLoginNumberPhone.Text);
            textBoxLoginNumberPhone.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.PhoneNumber = textBoxLoginNumberPhone.Text;

            UpdateConfirmButton();
        }

        private void ValidatePassportSeries(object? sender, EventArgs e)
        {
            var isValid = _checker.ckeckPassportSeries(textBoxLoginPassportSeries.Text);
            textBoxLoginPassportSeries.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.PassportSeries = textBoxLoginPassportSeries.Text;

            UpdateConfirmButton();
        }

        private void ValidatePassportNumber(object? sender, EventArgs e)
        {
            var isValid = _checker.ckeckPassportNumber(textBoxLoginPassportNumber.Text);
            textBoxLoginPassportNumber.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.PassportNumber = textBoxLoginPassportNumber.Text;

            UpdateConfirmButton();
        }

        private void ValidateCardNumber(object? sender, EventArgs e)
        {
            var isValid = _checker.checkCardNumber(textBoxLoginCardNumber.Text);
            textBoxLoginCardNumber.BackColor = isValid ? Color.White : Color.LightPink;

            if (isValid)
                TempUser.CardNumber = textBoxLoginCardNumber.Text;

            UpdateConfirmButton();
        }

        private void UpdateConfirmButton()
        {
            // Проверяем все поля на валидность
            bool allValid = _checker.checkName(textBoxLoginSecondName.Text) &&
                           _checker.checkName(textBoxLoginFirstName.Text) &&
                           _checker.checkName(textBoxLoginMiddleName.Text) &&
                           _checker.checkPhoneNumber(textBoxLoginNumberPhone.Text) &&
                           _checker.ckeckPassportSeries(textBoxLoginPassportSeries.Text) &&
                           _checker.ckeckPassportNumber(textBoxLoginPassportNumber.Text) &&
                           _checker.checkCardNumber(textBoxLoginCardNumber.Text);

            buttonConfirm.Enabled = allValid;
        }

        private void buttonConfirm_Click(object? sender, EventArgs e)
        {
            try
            {
                // Обновляем данные из полей
                TempUser.LastName = textBoxLoginSecondName.Text;
                TempUser.FirstName = textBoxLoginFirstName.Text;
                TempUser.MiddleName = textBoxLoginMiddleName.Text;
                TempUser.PhoneNumber = textBoxLoginNumberPhone.Text;
                TempUser.PassportSeries = textBoxLoginPassportSeries.Text;
                TempUser.PassportNumber = textBoxLoginPassportNumber.Text;
                TempUser.CardNumber = textBoxLoginCardNumber.Text;

                var db = Program.GetDbClient();

                if (labelRegistrationLogin.Text == "Редактирование")
                {
                    if (TempUser.Id == 0)
                    {
                        MessageBox.Show("ID пользователя не установлен для редактирования.");
                        return;
                    }
                    db.UpdateUser(TempUser.Id, TempUser);
                    Logger.LogInformation($"Пользователь обновлен: ID={TempUser.Id}, ФИО={TempUser.LastName} {TempUser.FirstName}");
                    MessageBox.Show("Данные пользователя обновлены!");
                }
                else
                {
                    db.InsertUser(TempUser);
                    Logger.LogInformation($"Пользователь создан: ID={TempUser.Id}, ФИО={TempUser.LastName} {TempUser.FirstName}");
                    MessageBox.Show("Пользователь создан успешно!");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Ошибка при сохранении пользователя");
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void textBoxLoginNumberPhone_TextChanged(object? sender, EventArgs e)
        {
            // Динамическая валидация номера телефона (опционально)
            ValidatePhoneNumber(sender, e);
        }

        // Остальные методы можно удалить, так как они заменены Validate-методами
    }
}