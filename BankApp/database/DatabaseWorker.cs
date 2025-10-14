using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class DatabaseWorker : IDisposable
{
    private readonly SqliteConnection _connection;

    public DatabaseWorker(string connectionString = "Data Source=workers.db")
    {
        _connection = new SqliteConnection(connectionString);
        _connection.Open();
        CreateTableIfNotExists();
    }

    private void CreateTableIfNotExists()
    {
        using var command = _connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Workers (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                LastName TEXT NOT NULL,
                FirstName TEXT NOT NULL,
                MiddleName TEXT NOT NULL,
                Login TEXT UNIQUE NOT NULL,
                Password TEXT NOT NULL,
                Post INTEGER NOT NULL
            )";
        command.ExecuteNonQuery();
    }

    public void AddWorker(WorkerData worker)
    {
        if (!worker.isValidate)
            throw new ArgumentException("Worker data is not valid");

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Workers (LastName, FirstName, MiddleName, Login, Password, Post)
            VALUES ($lastName, $firstName, $middleName, $login, $password, $post)";

        command.Parameters.AddWithValue("$lastName", worker.LastName);
        command.Parameters.AddWithValue("$firstName", worker.FirstName);
        command.Parameters.AddWithValue("$middleName", worker.MiddleName);
        command.Parameters.AddWithValue("$login", worker.Login);
        command.Parameters.AddWithValue("$password", worker.Password); // В реальном приложении хэшируйте пароль!
        command.Parameters.AddWithValue("$post", (int)worker.Post);

        command.ExecuteNonQuery();
    }

    public void UpdateWorker(WorkerData worker)
    {
        if (!worker.isValidate)
            throw new ArgumentException("Worker data is not valid");

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            UPDATE Workers 
            SET LastName = $lastName,
                FirstName = $firstName,
                MiddleName = $middleName,
                Login = $login,
                Password = $password,
                Post = $post
            WHERE Id = $id";

        command.Parameters.AddWithValue("$id", worker.Id);
        command.Parameters.AddWithValue("$lastName", worker.LastName);
        command.Parameters.AddWithValue("$firstName", worker.FirstName);
        command.Parameters.AddWithValue("$middleName", worker.MiddleName);
        command.Parameters.AddWithValue("$login", worker.Login);
        command.Parameters.AddWithValue("$password", worker.Password);
        command.Parameters.AddWithValue("$post", (int)worker.Post);

        command.ExecuteNonQuery();
    }

    public void DeleteWorker(int id)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = "DELETE FROM Workers WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    public WorkerData? GetWorkerById(int id)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, LastName, FirstName, MiddleName, Login, Password, Post
            FROM Workers WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new WorkerData
            {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                MiddleName = reader.GetString(3),
                Login = reader.GetString(4),
                Password = reader.GetString(5),
                Post = (WorkerRoleType)reader.GetInt32(6)
            };
        }
        return null;
    }

    public WorkerData? GetWorkerByCredentials(string login, string password)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, LastName, FirstName, MiddleName, Login, Password, Post
            FROM Workers WHERE Login = $login AND Password = $password";
        command.Parameters.AddWithValue("$login", login);
        command.Parameters.AddWithValue("$password", password);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new WorkerData
            {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                MiddleName = reader.GetString(3),
                Login = reader.GetString(4),
                Password = reader.GetString(5),
                Post = (WorkerRoleType)reader.GetInt32(6)
            };
        }
        return null;
    }

    public List<WorkerData> GetAllWorkers()
    {
        var workers = new List<WorkerData>();

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, LastName, FirstName, MiddleName, Login, Password, Post
            FROM Workers";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            workers.Add(new WorkerData
            {
                Id = reader.GetInt32(0),
                LastName = reader.GetString(1),
                FirstName = reader.GetString(2),
                MiddleName = reader.GetString(3),
                Login = reader.GetString(4),
                Password = reader.GetString(5),
                Post = (WorkerRoleType)reader.GetInt32(6)
            });
        }

        return workers;
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}