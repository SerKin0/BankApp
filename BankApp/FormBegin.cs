using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class FormBegin : Form
    {
        private Checker checker = new Checker();

        public FormBegin()
        {
            InitializeComponent();
            var db_worker = Program.GetDbWorker();
        }

        private void labelLoginSecondName_Click(object sender, EventArgs e)
        {

        }

        private void labelRegistrationLogin_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string login = textBoxBeginLogin.Text;
            string password = textBoxBeginPassword.Text;

            //MessageBox.Show($"{checker.ckeckLogin(login).ToString()} {checker.checkPassword(password).ToString()}");
            if (!checker.ckeckLogin(login) || !checker.checkPassword(password))
            {
                MessageBox.Show("Please enter both login and password.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get DatabaseWorker instance
            var dbWorker = Program.GetDbWorker();

            // Check credentials
            //MessageBox.Show($"{login} {password}");
            var worker = dbWorker.GetWorkerByCredentials(login, password);

            if (worker == null)
            {
                MessageBox.Show("Invalid login or password.", "Authentication Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Program.Worker = worker;
            this.DialogResult = DialogResult.OK;
            this.Close(); 
        }
    }
}
