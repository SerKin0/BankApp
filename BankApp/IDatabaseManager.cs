using System.Collections.Generic;

public interface IDatabaseManager
{
    void InsertUser(DataUser user);

    void UpdateUser(int id, DataUser user);

    void DeleteUser(int id);

    DataUser? GetUserById(int id);

    List<DataUser> GetAllUsers();
}
