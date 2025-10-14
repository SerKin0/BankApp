public class ViewerRole : WorkerRole
{
    public ViewerRole(string id, string secondName, string firstName, string middleName, string login, string password)
        : base(id, secondName, firstName, middleName, login, password)
    {
    }

    public override bool CanViewFirstName => false;
    public override bool CanViewLastName => false;
    public override bool CanViewMiddleName => false;
    public override bool CanViewPhoneNumber => false;
    public override bool CanViewPassportData => false;
    public override bool CanViewCardNumber => false;
    public override bool CanEditPersonalData => false;
}