using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace BankApp
{
    internal static class Program
    {
        public static DatabaseClient? DbClient { get; private set; }
        public static DatabaseWorker? DbWorker { get; private set; }
        public static WorkerData? Worker { get; set; }

        [STAThread]
        static void Main()
        {
            // Минимальное логирование запуска
            Logger.LogInformation("BankApp запущено");

            try
            {
                ApplicationConfiguration.Initialize();

                // Инициализация баз данных
                DbClient = new DatabaseClient("Data Source=client.db");
                DbWorker = new DatabaseWorker("Data source=worker.db");

                Application.Run(new FormMain(1));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Критическая ошибка при запуске");
                MessageBox.Show($"Критическая ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.LogInformation("BankApp завершено");
                CleanupResources();
            }
        }

        private static void CleanupResources()
        {
            try
            {
                DbClient?.Dispose();
                DbWorker?.Dispose();
                Logger.Dispose();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Ошибка при очистке ресурсов");
            }
        }

        // Метод для безопасного доступа
        public static DatabaseClient GetDbClient()
        {
            if (DbClient == null)
            {
                Logger.LogError("Попытка доступа к неинициализированной БД клиентов");
                throw new InvalidOperationException("Database manager is not initialized");
            }
            return DbClient;
        }

        public static DatabaseWorker GetDbWorker()
        {
            if (DbWorker == null)
            {
                Logger.LogError("Попытка доступа к неинициализированной БД сотрудников");
                throw new InvalidOperationException("Database manager is not initialized");
            }
            return DbWorker;
        }

        // Метод для логирования смены пользователя
        public static void LogUserChange(WorkerData? newWorker)
        {
            if (newWorker != null)
            {
                Logger.LogInformation($"Вход: {newWorker.Login} ({newWorker.Post})");
            }
            else
            {
                Logger.LogInformation("Выход из системы");
            }
        }
    }
}