using Microsoft.Data.Sqlite;

namespace BankApp
{
    public class DatabaseClient : IDisposable
    {
        private readonly SqliteConnection _connection;

        public DatabaseClient(string connectionString = "Data Source=client.db")
        {
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            CreateTableIfNotExists();
        }

        private void CreateTableIfNotExists()
        {
            using var command = _connection.CreateCommand();
            command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                LastName TEXT NOT NULL,
                FirstName TEXT NOT NULL,
                MiddleName TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL,
                PassportSeries TEXT NOT NULL,
                PassportNumber TEXT NOT NULL,
                CardNumber TEXT NOT NULL
            )";
            command.ExecuteNonQuery();
        }

        public void InsertUser(ClientData user)
        {
            if (!user.isValidate)
                throw new ArgumentException("User data is not valid");

            // Шифруем данные перед сохранением в БД
            var encryptedUser = Security.EncryptClientData(user);

            using var command = _connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO Users 
            (LastName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber)
            VALUES ($lastName, $firstName, $middleName, $phoneNumber, $passportSeries, $passportNumber, $cardNumber);
            SELECT last_insert_rowid();";

            command.Parameters.AddWithValue("$lastName", encryptedUser.LastName);
            command.Parameters.AddWithValue("$firstName", encryptedUser.FirstName);
            command.Parameters.AddWithValue("$middleName", encryptedUser.MiddleName);
            command.Parameters.AddWithValue("$phoneNumber", encryptedUser.PhoneNumber);
            command.Parameters.AddWithValue("$passportSeries", encryptedUser.PassportSeries);
            command.Parameters.AddWithValue("$passportNumber", encryptedUser.PassportNumber);
            command.Parameters.AddWithValue("$cardNumber", encryptedUser.CardNumber);

            user.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public void UpdateUser(int id, ClientData user)
        {
            if (!user.isValidate)
                throw new ArgumentException("User data is not valid");

            // Шифруем данные перед сохранением в БД
            var encryptedUser = Security.EncryptClientData(user);

            using var command = _connection.CreateCommand();
            command.CommandText = @"
            UPDATE Users 
            SET LastName = $lastName,
                FirstName = $firstName,
                MiddleName = $middleName,
                PhoneNumber = $phoneNumber,
                PassportSeries = $passportSeries,
                PassportNumber = $passportNumber,
                CardNumber = $cardNumber
            WHERE Id = $id";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$lastName", encryptedUser.LastName);
            command.Parameters.AddWithValue("$firstName", encryptedUser.FirstName);
            command.Parameters.AddWithValue("$middleName", encryptedUser.MiddleName);
            command.Parameters.AddWithValue("$phoneNumber", encryptedUser.PhoneNumber);
            command.Parameters.AddWithValue("$passportSeries", encryptedUser.PassportSeries);
            command.Parameters.AddWithValue("$passportNumber", encryptedUser.PassportNumber);
            command.Parameters.AddWithValue("$cardNumber", encryptedUser.CardNumber);

            command.ExecuteNonQuery();
        }

        public void DeleteUser(int id)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = "DELETE FROM Users WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }

        public ClientData? GetUserById(int id)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = @"
            SELECT Id, LastName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber
            FROM Users WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var encryptedClient = new ClientData(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7)
                )
                { Id = reader.GetInt32(0) };

                // Дешифруем данные после чтения из БД
                return Security.DecryptClientData(encryptedClient);
            }
            return null;
        }

        public List<ClientData> GetAllUsers()
        {
            var users = new List<ClientData>();

            using var command = _connection.CreateCommand();
            command.CommandText = @"
            SELECT Id, LastName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber 
            FROM Users";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var encryptedClient = new ClientData(
                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                    reader.IsDBNull(2) ? "" : reader.GetString(2),
                    reader.IsDBNull(3) ? "" : reader.GetString(3),
                    reader.IsDBNull(4) ? "" : reader.GetString(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.IsDBNull(6) ? "" : reader.GetString(6),
                    reader.IsDBNull(7) ? "" : reader.GetString(7)
                )
                { Id = reader.GetInt32(0) };

                // Дешифруем данные после чтения из БД
                users.Add(Security.DecryptClientData(encryptedClient));
            }

            return users;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}