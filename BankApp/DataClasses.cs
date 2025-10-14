public class ClientData
{
    public int Id { get; set; } = 0;

    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _phoneNumber = string.Empty;
    private string _passportSeries = string.Empty;
    private string _passportNumber = string.Empty;
    private string _cardNumber = string.Empty;

    private bool _lastName_validate = false;
    private bool _firstName_validate = false;
    private bool _middleName_validate = false;
    private bool _phoneNumber_validate = false;
    private bool _passportSeries_validate = false;
    private bool _passportNumber_validate = false;
    private bool _cardNumber_validate = false;

    private bool _account_is_validate = false;

    private Checker checker = new Checker();

    public bool isValidate => _account_is_validate;

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value ?? string.Empty;
            _lastName_validate = string.IsNullOrEmpty(value) || checker.checkName(value);
            checkValidAccount();
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value ?? string.Empty;
            _firstName_validate = string.IsNullOrEmpty(value) || checker.checkName(value);
            checkValidAccount();
        }
    }

    public string MiddleName
    {
        get => _middleName;
        set
        {
            _middleName = value ?? string.Empty;
            _middleName_validate = string.IsNullOrEmpty(value) || checker.checkName(value);
            checkValidAccount();
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value ?? string.Empty;
            _phoneNumber_validate = string.IsNullOrEmpty(value) || checker.checkPhoneNumber(value);
            checkValidAccount();
        }
    }

    public string PassportSeries
    {
        get => _passportSeries;
        set
        {
            _passportSeries = value ?? string.Empty;
            _passportSeries_validate = string.IsNullOrEmpty(value) || checker.ckeckPassportSeries(value);
            checkValidAccount();
        }
    }

    public string PassportNumber
    {
        get => _passportNumber;
        set
        {
            _passportNumber = value ?? string.Empty;
            _passportNumber_validate = string.IsNullOrEmpty(value) || checker.ckeckPassportNumber(value);
            checkValidAccount();
        }
    }

    public string CardNumber
    {
        get => _cardNumber;
        set
        {
            _cardNumber = value ?? string.Empty;
            _cardNumber_validate = string.IsNullOrEmpty(value) || checker.checkCardNumber(value);
            checkValidAccount();
        }
    }

    private bool checkValidAccount()
    {
        _account_is_validate = _lastName_validate && _firstName_validate && _middleName_validate &&
                               _phoneNumber_validate && _passportSeries_validate && _passportNumber_validate &&
                               _cardNumber_validate;
        return _account_is_validate;
    }

    public ClientData(string lastName = "", string firstName = "", string middleName = "", string phoneNumber = "",
                      string passportSeries = "", string passportNumber = "", string cardNumber = "")
    {
        // Прямое присваивание без вызова сеттеров
        _lastName = lastName ?? string.Empty;
        _firstName = firstName ?? string.Empty;
        _middleName = middleName ?? string.Empty;
        _phoneNumber = phoneNumber ?? string.Empty;
        _passportSeries = passportSeries ?? string.Empty;
        _passportNumber = passportNumber ?? string.Empty;
        _cardNumber = cardNumber ?? string.Empty;

        // Проверка валидности после инициализации
        _lastName_validate = string.IsNullOrEmpty(lastName) || checker.checkName(lastName);
        _firstName_validate = string.IsNullOrEmpty(firstName) || checker.checkName(firstName);
        _middleName_validate = string.IsNullOrEmpty(middleName) || checker.checkName(middleName);
        _phoneNumber_validate = string.IsNullOrEmpty(phoneNumber) || checker.checkPhoneNumber(phoneNumber);
        _passportSeries_validate = string.IsNullOrEmpty(passportSeries) || checker.ckeckPassportSeries(passportSeries);
        _passportNumber_validate = string.IsNullOrEmpty(passportNumber) || checker.ckeckPassportNumber(passportNumber);
        _cardNumber_validate = string.IsNullOrEmpty(cardNumber) || checker.checkCardNumber(cardNumber);

        checkValidAccount();
    }
}

public class WorkerData
{
    private int _id = 0;
    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _login = string.Empty;
    private string _password = string.Empty;
    private WorkerRoleType _post = WorkerRoleType.Viewer;

    private bool _id_validate = false;
    private bool _lastName_validate = false;
    private bool _firstName_validate = false;
    private bool _middleName_validate = false;
    private bool _login_validate = false;
    private bool _password_validate = false;
    private bool _post_validate = false;

    private bool _worker_is_validate = false;

    private Checker checker = new Checker();

    public bool isValidate { get => _worker_is_validate; }

    // ID сотрудника
    public int Id
    {
        get => _id;
        set
        {
            if (value > 0)
            {
                _id = value;
                _id_validate = true;
                checkValidWorker();
            }
            else _id = 0;
        }
    }

    // Фамилия
    public string LastName
    {
        get => _lastName;
        set
        {
            if (checker.checkName(value))
            {
                _lastName = value;
                _lastName_validate = true;
                checkValidWorker();
            }
            else _lastName = string.Empty;
        }
    }

    // Имя 
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (checker.checkName(value))
            {
                _firstName = value;
                _firstName_validate = true;
                checkValidWorker();
            }
            else _firstName = string.Empty;
        }
    }

    // Отчество
    public string MiddleName
    {
        get => _middleName;
        set
        {
            if (checker.checkName(value))
            {
                _middleName = value;
                _middleName_validate = true;
                checkValidWorker();
            }
            else _middleName = string.Empty;
        }
    }

    // Логин
    public string Login
    {
        get => _login;
        set
        {
            if (checker.ckeckLogin(value))
            {
                _login = value;
                _login_validate = true;
                checkValidWorker();
            }
            else _login = string.Empty;
        }
    }

    // Пароль
    public string Password
    {
        get => _password;
        set
        {
            if (checker.checkPassword(value))
            {
                _password = value;
                _password_validate = true;
                checkValidWorker();
            }
            else _password = string.Empty;
        }
    }

    // Должность (тип работника)
    public WorkerRoleType Post
    {
        get => _post;
        set
        {
            _post = value;
            _post_validate = true;
            checkValidWorker();
        }
    }

    private bool checkValidWorker()
    {
        if (_id_validate &&
            _firstName_validate &&
            _lastName_validate &&
            _middleName_validate &&
            _login_validate &&
            _password_validate &&
            _post_validate)
            _worker_is_validate = true;

        return _worker_is_validate;
    }

    public WorkerData() { }

    public WorkerData(
        int id,
        string first_name,
        string last_name,
        string middle_name,
        string login,
        string password,
        WorkerRoleType post)
    {
        Id = id;
        FirstName = first_name;
        LastName = last_name;
        MiddleName = middle_name;
        Login = login;
        Password = password;
        Post = post;
    }
}