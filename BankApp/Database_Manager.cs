using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

public class DatabaseManager : IDatabaseManager, IDisposable
{
    // Создаем переменную для соединения к базе данных (SQLite)
    private readonly SqliteConnection _connection;


    public DatabaseManager(string connectionString = "Data Source=users.db")
    {
        _connection = new SqliteConnection(connectionString);
        _connection.Open();
        CreateTableIfNotExists();
    }

    // Создание таблицы для хранения данных пользователей, если ее нет
    private void CreateTableIfNotExists()
    {
        using var command = _connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                SecondName TEXT NOT NULL,
                FirstName TEXT NOT NULL,
                MiddleName TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL,
                PassportSeries TEXT NOT NULL,
                PassportNumber TEXT NOT NULL,
                CardNumber TEXT NOT NULL
            )";
        command.ExecuteNonQuery();
    }

    // Добавление нового пользователя
    public void InsertUser(DataUser user)
    {
        // Если данные пользователя являются не правильными, то возращаем ошибку
        if (!user.Validate)
            throw new ArgumentException("User data is not valid");

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Users 
            (SecondName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber)
            VALUES ($secondName, $firstName, $middleName, $phoneNumber, $passportSeries, $passportNumber, $cardNumber)";

        // Добавляем в строку с образцом запроса в базу параметры пользователя
        command.Parameters.AddWithValue("$secondName", user.SecondName);
        command.Parameters.AddWithValue("$firstName", user.FirstName);
        command.Parameters.AddWithValue("$middleName", user.MiddleName);
        command.Parameters.AddWithValue("$phoneNumber", user.PhoneNumber);
        command.Parameters.AddWithValue("$passportSeries", user.PassportSeries);
        command.Parameters.AddWithValue("$passportNumber", user.PassportNumber);
        command.Parameters.AddWithValue("$cardNumber", user.CardNumber);

        command.ExecuteNonQuery();
    }

    // Обновление данных пользователя 
    public void UpdateUser(int id, DataUser user)
    {
        // Если данные пользователя являются не правильными, то возращаем ошибку
        if (!user.Validate)
            throw new ArgumentException("User data is not valid");

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            UPDATE Users 
            SET SecondName = $secondName,
                FirstName = $firstName,
                MiddleName = $middleName,
                PhoneNumber = $phoneNumber,
                PassportSeries = $passportSeries,
                PassportNumber = $passportNumber,
                CardNumber = $cardNumber
            WHERE Id = $id";

        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$secondName", user.SecondName);
        command.Parameters.AddWithValue("$firstName", user.FirstName);
        command.Parameters.AddWithValue("$middleName", user.MiddleName);
        command.Parameters.AddWithValue("$phoneNumber", user.PhoneNumber);
        command.Parameters.AddWithValue("$passportSeries", user.PassportSeries);
        command.Parameters.AddWithValue("$passportNumber", user.PassportNumber);
        command.Parameters.AddWithValue("$cardNumber", user.CardNumber);

        command.ExecuteNonQuery();
    }

    // Удаление пользователя из базы данных
    public void DeleteUser(int id)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = "DELETE FROM Users WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    // Получаем данные конкретного пользователя по его ID
    public DataUser? GetUserById(int id)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = @"
            SELECT SecondName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber
            FROM Users WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new DataUser(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6)
            );
        }
        // Если пользователя с данным ID не найдено, то возращем пустое значение
        return null;
    }

    // Возращаем список всех пользователей из базы данных
    public List<DataUser> GetAllUsers()
    {
        // Создаем временную переменную, в которую будет записывать данные пользователей
        var users = new List<DataUser>();

        using var command = _connection.CreateCommand();
        command.CommandText = "SELECT SecondName, FirstName, MiddleName, PhoneNumber, PassportSeries, PassportNumber, CardNumber FROM Users";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            users.Add(new DataUser(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6)
            ));
        }

        return users;
    }

    // Отключение от базы данных
    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}