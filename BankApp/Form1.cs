namespace BankApp
{
    public partial class FormLogin : Form
    {
        public DataUser temp_user;

        public FormLogin(string title="Регистраfdsfция")
        {
            InitializeComponent();
            labelRegistrationLogin.Text = title;
            temp_user = new DataUser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelRegistrationLogin_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Имя: {temp_user.FirstName} \n" +
            //    $"Фамилия: {temp_user.SecondName} \n" +
            //    $"Отчество: {temp_user.MiddleName} \n" +
            //    $"Номер телефона: {temp_user.PhoneNumber} \n" +
            //    $"Серия паспорта: {temp_user.PassportSeries} \n" +
            //    $"Номер паспорта: {temp_user.PassportNumber} \n" +
            //    $"Номер карты: {temp_user.CardNumber} \n" +
            //    $"Валидность: {temp_user.Validate}");
            if (temp_user.Validate)
            {
                // Функция добавления пользователя в БД
                MessageBox.Show("Пользователь создан удачно!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте введенный данные в полях");
            }
        }

        // Фамилия
        private void textBoxLoginSecondName_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.SecondName = textBoxLoginSecondName.Text;
                textBoxLoginSecondName.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginSecondName.BackColor = Color.LightPink;
            }
        }

        // Имя
        private void textBoxLoginFirstName_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.FirstName = textBoxLoginFirstName.Text;
                textBoxLoginFirstName.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginFirstName.BackColor = Color.LightPink;
            }
        }

        // Отчество
        private void textBoxLoginMiddleName_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.MiddleName = textBoxLoginMiddleName.Text;
                textBoxLoginMiddleName.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginMiddleName.BackColor = Color.LightPink;
            }
        }
        
        // Номер телефона
        private void textBoxLoginNumberPhone_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.PhoneNumber = textBoxLoginNumberPhone.Text;
                textBoxLoginNumberPhone.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginNumberPhone.BackColor = Color.LightPink;
            }
        }

        // Серия паспорта
        private void textBoxLoginPassportSeries_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.PassportSeries = textBoxLoginPassportSeries.Text;
                textBoxLoginPassportSeries.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginPassportSeries.BackColor = Color.LightPink;
            }
        }

        // Номер паспорта
        private void textBoxLoginPassportNumber_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.PassportNumber = textBoxLoginPassportNumber.Text;
                textBoxLoginPassportNumber.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginPassportNumber.BackColor = Color.LightPink;
            }
        }

        // Номер карты
        private void textBoxLoginCardNumber_LostFocus(object sender, EventArgs e)
        {
            try
            {
                temp_user.CardNumber = textBoxLoginCardNumber.Text;
                textBoxLoginCardNumber.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                textBoxLoginCardNumber.BackColor = Color.LightPink;
            }
        }
    }
}
