using System.Runtime.Serialization;

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
            ApplicationConfiguration.Initialize();

            DbClient = new DatabaseClient("Data Source=client.db");
            DbWorker = new DatabaseWorker("Data source=worker.db");

            Application.Run(new FormMain(1));
        }

        // Метод для безопасного доступа
        public static DatabaseClient GetDbClient()
        {
            return DbClient ?? throw new InvalidOperationException("Database manager is not initialized");
        }

        public static DatabaseWorker GetDbWorker()
        {
            return DbWorker ?? throw new InvalidOperationException("Database manager is not initialized");
        }
    }
}