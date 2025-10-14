public enum WorkerRoleType
{
    Viewer = 0,
    Consultant = 1,
    Manager = 2,
}

public abstract class WorkerRole
{
    public string Id { get; set; }
    public string lastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    protected WorkerRole(
        string id,
        string secondName,
        string firstName,
        string middleName,
        string login,
        string password)
    {
        Id = id;
        lastName = secondName;
        FirstName = firstName;
        MiddleName = middleName;
        Login = login;
        Password = password;
    }

    public virtual bool CanViewFirstName { get; } = false;
    public virtual bool CanViewLastName { get; } = false;
    public virtual bool CanViewMiddleName { get; } = false;
    public virtual bool CanViewPhoneNumber { get; } = false;
    public virtual bool CanViewPassportData { get; } = false;
    public virtual bool CanViewCardNumber { get; } = false;

    public virtual bool CanEditPersonalData { get; } = false;
}