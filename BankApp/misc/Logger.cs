using System;
using System.IO;
using System.Text;
using System.Threading;

namespace BankApp
{
    public static class Logger
    {
        private static readonly string _logDir;
        private static readonly object _lockObject = new object();

        static Logger()
        {
            _logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(_logDir))
                Directory.CreateDirectory(_logDir);

            LogToFile("INFO", "=== BankApp Logger initialized ===");
        }

        private static string GetLogFilePath()
        {
            return Path.Combine(_logDir, $"bankapp-{DateTime.Now:yyyyMMdd}.log");
        }

        public static void LogInformation(string message)
        {
            LogToFile("INFO", message);
            WriteToConsole($"INFO: {message}");
        }

        public static void LogInformation(string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            LogToFile("INFO", formattedMessage);
            WriteToConsole($"INFO: {formattedMessage}");
        }

        public static void LogWarning(string message)
        {
            LogToFile("WARN", message);
            WriteToConsole($"WARN: {message}", ConsoleColor.Yellow);
        }

        public static void LogWarning(string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            LogToFile("WARN", formattedMessage);
            WriteToConsole($"WARN: {formattedMessage}", ConsoleColor.Yellow);
        }

        public static void LogError(string message)
        {
            LogToFile("ERROR", message);
            WriteToConsole($"ERROR: {message}", ConsoleColor.Red);
        }

        public static void LogError(string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            LogToFile("ERROR", formattedMessage);
            WriteToConsole($"ERROR: {formattedMessage}", ConsoleColor.Red);
        }

        public static void LogError(Exception exception, string message)
        {
            var fullMessage = $"{message}. Exception: {exception}";
            LogToFile("ERROR", fullMessage);
            WriteToConsole($"ERROR: {fullMessage}", ConsoleColor.Red);
        }

        public static void LogError(Exception exception, string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            var fullMessage = $"{formattedMessage}. Exception: {exception}";
            LogToFile("ERROR", fullMessage);
            WriteToConsole($"ERROR: {fullMessage}", ConsoleColor.Red);
        }

        public static void LogDebug(string message)
        {
            LogToFile("DEBUG", message);
            WriteToConsole($"DEBUG: {message}", ConsoleColor.Gray);
        }

        public static void LogDebug(string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            LogToFile("DEBUG", formattedMessage);
            WriteToConsole($"DEBUG: {formattedMessage}", ConsoleColor.Gray);
        }

        private static void LogToFile(string level, string message)
        {
            lock (_lockObject)
            {
                try
                {
                    var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}{Environment.NewLine}";
                    File.AppendAllText(GetLogFilePath(), logEntry, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    // Если не можем записать в файл, пишем в консоль
                    WriteToConsole($"LOGGER ERROR: Failed to write to log file: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        private static void WriteToConsole(string message, ConsoleColor color = ConsoleColor.White)
        {
            try
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ForegroundColor = originalColor;
            }
            catch
            {
                // Игнорируем ошибки вывода в консоль
            }
        }

        public static void Dispose()
        {
            LogToFile("INFO", "=== BankApp Logger disposed ===");
        }
    }
}