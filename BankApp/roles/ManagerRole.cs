public class ManagerRole : WorkerRole
{
    public ManagerRole(
        string id,
        string secondName,
        string firstName,
        string middleName,
        string login,
        string password)
        : base(id, secondName, firstName, middleName, login, password)
    { }

    public override bool CanViewLastName => true;
    public override bool CanViewFirstName => true;
    public override bool CanViewMiddleName => true;
    public override bool CanViewPhoneNumber => true;
    public override bool CanViewPassportData => false;  // Скрыто в таблице
    public override bool CanViewCardNumber => false;     // Скрыто в таблице
    public override bool CanEditPersonalData => true;
}