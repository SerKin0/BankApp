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
    public partial class FormMain : Form
    {
        private BindingList<ClientData> clientDataList = new BindingList<ClientData>();
        private BindingList<ClientData> displayDataList = new BindingList<ClientData>();

        public FormMain(int mode)
        {
            InitializeComponent();
            doSom();
            InaccessibilityControlsMain();
            LoadClients();
            dataGridViewMainClients.ContextMenuStrip = contextMenuMainTable;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateDataVisibility();
        }

        public void doSom()
        {
            var columns = new[]
            {
                new DataGridViewTextBoxColumn { Name = "id", HeaderText = "ID", DataPropertyName = "Id", Visible = false },
                new DataGridViewTextBoxColumn { Name = "last_name", HeaderText = "Фамилия", DataPropertyName = "LastName" },
                new DataGridViewTextBoxColumn { Name = "first_name", HeaderText = "Имя", DataPropertyName = "FirstName" },
                new DataGridViewTextBoxColumn { Name = "middle_name", HeaderText = "Отчество", DataPropertyName = "MiddleName" },
                new DataGridViewTextBoxColumn { Name = "phone_number", HeaderText = "Номер телефона", DataPropertyName = "PhoneNumber" },
                new DataGridViewTextBoxColumn { Name = "passport_series", HeaderText = "Серия паспорта", DataPropertyName = "PassportSeries" },
                new DataGridViewTextBoxColumn { Name = "passport_number", HeaderText = "Номер паспорта", DataPropertyName = "PassportNumber" },
                new DataGridViewTextBoxColumn { Name = "card_number", HeaderText = "Номер карты", DataPropertyName = "CardNumber" },
            };

            dataGridViewMainClients.Columns.AddRange(columns);
            dataGridViewMainClients.AutoGenerateColumns = false;
            dataGridViewMainClients.DataSource = displayDataList;
        }

        private void LoadClients()
        {
            var db = Program.GetDbClient();
            clientDataList.Clear();
            displayDataList.Clear();

            if (Program.Worker != null)
            {
                var clients = db.GetAllUsers();
                foreach (var client in clients)
                {
                    clientDataList.Add(client);
                }
            }
            UpdateDataVisibility();
        }

        private void UpdateDataVisibility()
        {
            if (Program.Worker == null)
            {
                // Режим без авторизации
                SetControlsAccess(false, false, false, false, false);
                displayDataList.Clear();
                HideAllColumns();
                return;
            }

            // Получаем роль пользователя
            var role = GetCurrentRole();

            // Обновляем видимость колонок (все колонки видимы)
            UpdateColumnsVisibility();

            // Обновляем данные для отображения
            UpdateDisplayData(role);

            // Настраиваем доступность контролов
            SetControlsAccessBasedOnRole();
        }

        private WorkerRole GetCurrentRole()
        {
            return Program.Worker.Post switch
            {
                WorkerRoleType.Manager => new ManagerRole(Program.Worker.Id.ToString(), Program.Worker.LastName, Program.Worker.FirstName, Program.Worker.MiddleName, Program.Worker.Login, Program.Worker.Password),
                WorkerRoleType.Consultant => new Consultant(Program.Worker.Id.ToString(), Program.Worker.LastName, Program.Worker.FirstName, Program.Worker.MiddleName, Program.Worker.Login, Program.Worker.Password),
                _ => new ViewerRole(Program.Worker.Id.ToString(), Program.Worker.LastName, Program.Worker.FirstName, Program.Worker.MiddleName, Program.Worker.Login, Program.Worker.Password)
            };
        }

        private void UpdateColumnsVisibility()
        {
            // Все колонки всегда видимы
            dataGridViewMainClients.Columns["last_name"].Visible = true;
            dataGridViewMainClients.Columns["first_name"].Visible = true;
            dataGridViewMainClients.Columns["middle_name"].Visible = true;
            dataGridViewMainClients.Columns["phone_number"].Visible = true;
            dataGridViewMainClients.Columns["passport_series"].Visible = true;
            dataGridViewMainClients.Columns["passport_number"].Visible = true;
            dataGridViewMainClients.Columns["card_number"].Visible = true;
        }

        private string MaskSensitiveData(string originalValue)
        {
            if (string.IsNullOrEmpty(originalValue))
                return "***";

            // Заменяем все символы на *, сохраняя длину строки
            return new string('*', originalValue.Length);
        }

        private void UpdateDisplayData(WorkerRole role)
        {
            displayDataList.Clear();

            foreach (var client in clientDataList)
            {
                // Для менеджера показываем все данные как есть
                if (role is ManagerRole)
                {
                    displayDataList.Add(client);
                }
                // Для консультанта маскируем чувствительные данные
                else if (role is Consultant)
                {
                    var displayClient = new ClientData(
                        client.LastName,
                        client.FirstName,
                        client.MiddleName,
                        client.PhoneNumber,
                        MaskSensitiveData(client.PassportSeries),
                        MaskSensitiveData(client.PassportNumber),
                        MaskSensitiveData(client.CardNumber)
                    )
                    { Id = client.Id };

                    displayDataList.Add(displayClient);
                }
                // Для других ролей (Viewer) настраиваем по необходимости
                else
                {
                    var displayClient = new ClientData(
                        client.LastName,
                        client.FirstName,
                        client.MiddleName,
                        client.PhoneNumber,
                        role.CanViewPassportData ? client.PassportSeries : MaskSensitiveData(client.PassportSeries),
                        role.CanViewPassportData ? client.PassportNumber : MaskSensitiveData(client.PassportNumber),
                        role.CanViewCardNumber ? client.CardNumber : MaskSensitiveData(client.CardNumber)
                    )
                    { Id = client.Id };

                    displayDataList.Add(displayClient);
                }
            }

            dataGridViewMainClients.Refresh();
        }

        private void SetControlsAccessBasedOnRole()
        {
            if (Program.Worker == null) return;

            switch (Program.Worker.Post)
            {
                case WorkerRoleType.Manager:
                    SetControlsAccess(true, true, true, true, true);
                    break;
                case WorkerRoleType.Consultant:
                    SetControlsAccess(false, true, false, true, false);
                    break;
                default: // Viewer
                    SetControlsAccess(false, true, false, false, false);
                    break;
            }
        }

        private void SetControlsAccess(bool addEnabled, bool reloadEnabled, bool addMenuEnabled, bool changeMenuEnabled, bool deleteMenuEnabled)
        {
            buttonMainAdd.Enabled = addEnabled;
            buttonMainReload.Enabled = reloadEnabled;
            AddClientToolStripMenuItem.Enabled = addMenuEnabled;
            ChangeClientToolStripMenuItem.Enabled = changeMenuEnabled;
            DeleteClientToolStripMenuItem.Enabled = deleteMenuEnabled;
        }

        private void HideAllColumns()
        {
            foreach (DataGridViewColumn column in dataGridViewMainClients.Columns)
            {
                column.Visible = false;
            }
        }

        // Остальные методы без изменений...
        private void labelRegistrationLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("https://github.com/SerKin0/BankApp")
            {
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        private void buttonMainEnterExit_Click(object sender, EventArgs e)
        {
            if (buttonMainEnterExit.Text == "🔑 Вход")
            {
                FormBegin form_begin = new FormBegin();

                if (form_begin.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"Авторизация успешна! Здравствуйте, {Program.Worker?.FirstName ?? "Неизвестный"}");
                    EnterMainManager();
                    form_begin.Close();
                    LoadClients();
                }
                else
                {
                    MessageBox.Show("Авторизация отменена или не удалась.");
                    InaccessibilityControlsMain();
                }
            }
            else if (buttonMainEnterExit.Text == "🔑 Выход")
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти из учетной записи?", "Подтверждение выхода",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.Worker = null;
                    InaccessibilityControlsMain();
                    LoadClients();
                }
            }
        }

        public void InaccessibilityControlsMain()
        {
            SetControlsAccess(false, false, false, false, false);
            dataGridViewMainClients.Enabled = false;
            labelMainRole.Text = "";
            buttonMainEnterExit.Text = "🔑 Вход";
            UpdateDataVisibility();
        }

        public void AvailabilityControlMain()
        {
            dataGridViewMainClients.Enabled = true;
            UpdateDataVisibility();
        }

        public void EnterMainManager()
        {
            if (Program.Worker != null)
            {
                AvailabilityControlMain();
                labelMainRole.Text = $"Логин: {Program.Worker.Login}\nДолжность: {Program.Worker.Post}";
                buttonMainEnterExit.Text = "🔑 Выход";
            }
        }

        private void buttonMainReload_Click(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void buttonMainAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new FormLogin("Добавление"))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                }
            }
        }

        private void dataGridViewMainClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;

            dataGridViewMainClients.ClearSelection();
            dataGridViewMainClients.Rows[e.RowIndex].Selected = true;

            if (dataGridViewMainClients.ContextMenuStrip != null)
            {
                dataGridViewMainClients.ContextMenuStrip.Show(Cursor.Position);
            }
        }

        private void AddClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var addForm = new FormLogin("Добавление"))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                }
            }
        }

        private void ChangeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMainClients.SelectedRows.Count > 0)
            {
                var row = dataGridViewMainClients.SelectedRows[0];
                var displayClient = (ClientData)row.DataBoundItem;

                var originalClient = clientDataList.FirstOrDefault(c => c.Id == displayClient.Id);
                if (originalClient == null) return;

                var editClient = new ClientData(
                    originalClient.LastName,
                    originalClient.FirstName,
                    originalClient.MiddleName,
                    originalClient.PhoneNumber,
                    originalClient.PassportSeries,
                    originalClient.PassportNumber,
                    originalClient.CardNumber
                )
                { Id = originalClient.Id };

                using (var editForm = new FormLogin("Редактирование", editClient))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        var db = Program.GetDbClient();
                        db.UpdateUser(originalClient.Id, editForm.TempUser);

                        originalClient.LastName = editForm.TempUser.LastName;
                        originalClient.FirstName = editForm.TempUser.FirstName;
                        originalClient.MiddleName = editForm.TempUser.MiddleName;
                        originalClient.PhoneNumber = editForm.TempUser.PhoneNumber;
                        originalClient.PassportSeries = editForm.TempUser.PassportSeries;
                        originalClient.PassportNumber = editForm.TempUser.PassportNumber;
                        originalClient.CardNumber = editForm.TempUser.CardNumber;

                        LoadClients();
                    }
                }
            }
        }

        private void DeleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMainClients.SelectedRows.Count > 0)
            {
                var displayClient = (ClientData)dataGridViewMainClients.SelectedRows[0].DataBoundItem;
                var originalClient = clientDataList.FirstOrDefault(c => c.Id == displayClient.Id);

                if (originalClient != null && MessageBox.Show("Вы уверены, что хотите удалить эту строку?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var db = Program.GetDbClient();
                    db.DeleteUser(originalClient.Id);
                    clientDataList.Remove(originalClient);
                    displayDataList.Remove(displayClient);
                }
            }
        }

        private void contextMenuMainTable_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridViewMainClients.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}