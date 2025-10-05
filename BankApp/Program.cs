namespace BankApp
{
    internal static class Program
    {
        public static DatabaseManager? DbManager { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DbManager = new DatabaseManager("Data Source=bank.db");

            Application.Run(new FormStart());
        }

        // Метод для безопасного доступа
        public static DatabaseManager GetDbManager()
        {
            return DbManager ?? throw new InvalidOperationException("Database manager is not initialized");
        }
    }
}