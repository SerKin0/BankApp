public class Consultant : WorkerRole
{
    public Consultant(
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
    public override bool CanViewPassportData => false;
    public override bool CanViewCardNumber => false;
    public override bool CanEditPersonalData => false;
}