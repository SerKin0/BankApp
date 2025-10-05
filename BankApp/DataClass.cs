using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class DataUser
{
    private string _secondName;
    private string _firstName;
    private string _middleName;
    private string _phoneNumber;
    private string _passportSeries;
    private string _passportNumber;
    private string _cardNumber;

    private bool _secondName_validate = false;
    private bool _firstName_validate = false;
    private bool _middleName_validate = false;
    private bool _phoneNumber_validate = false;
    private bool _passportSeries_validate = false;
    private bool _passportNumber_validate = false;
    private bool _cardNumber_validate = false;

    private bool _account_is_validate = false;

    public bool Validate
    {
        get => _account_is_validate;
        set { }
    }


    // Фамилия 
    public string SecondName
    {
        get => _secondName;
        set
        {
            try
            {
                _secondName = ValidateName(value, "Фамилия");
                _secondName_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _secondName = string.Empty;
                throw;
            }
        }
    }

    // Имя
    public string FirstName
    {
        get => _firstName;
        set
        {
            try
            {
                _firstName = ValidateName(value, "Имя");
                _firstName_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _firstName = string.Empty;  
                throw;
            }
        }
    }

    // Отчество
    public string MiddleName
    {
        get => _middleName;
        set
        {
            try
            {
                _middleName = ValidateName(value, "Отчество");
                _middleName_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _middleName = string.Empty; 
                throw;
            }
        }
    }

    // Телефонный номер
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            try
            {
                _phoneNumber = ValidatePhone(value);
                _phoneNumber_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _phoneNumber = string.Empty;
                throw;
            }
        }
    }

    // Серия паспорта
    public string PassportSeries
    {
        get => _passportSeries;
        set
        {
            try
            {
                _passportSeries = ValidatePassportSeries(value);
                _passportSeries_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _passportSeries = string.Empty;
                throw;
            }
        }
    }

    // Номер паспорта
    public string PassportNumber
    {
        get => _passportNumber;
        set
        {
            try
            {
                _passportNumber = ValidatePassportNumber(value);
                _passportNumber_validate = true;
                checkValidAccound();
            }
            catch (ArgumentException)
            {
                _passportNumber = string.Empty;
                throw;
            }
        }
    }

    // Номер карты
    public string CardNumber
    {
        get => _cardNumber;
        set
        {
            try
            {
                _cardNumber = ValidateCardNumber(value);
                _cardNumber_validate = true;
                checkValidAccound();
            }
            catch
            {
                _cardNumber = string.Empty;
                throw;
            }
        }
    }

    private bool checkValidAccound()
    {
        if (_firstName_validate &&
            _secondName_validate &&
            _middleName_validate &&
            _phoneNumber_validate &&
            _passportNumber_validate &&
            _passportSeries_validate &&
            _cardNumber_validate)
            _account_is_validate = true;

        return _account_is_validate;
    }

    public DataUser()
    {
        _secondName = string.Empty;
        _firstName = string.Empty;
        _middleName = string.Empty;
        _phoneNumber = string.Empty;
        _passportSeries = string.Empty;
        _passportNumber = string.Empty;
        _cardNumber = string.Empty;
        _account_is_validate = false;
    }

    public DataUser(
        string second_name,
        string first_name,
        string middle_name,
        string phone_number,
        string passport_series,
        string passport_number,
        string card_number)
    {
        _secondName = ValidateName(second_name, "Фамилия");
        _firstName = ValidateName(first_name, "Имя");
        _middleName = ValidateName(middle_name, "Отчество");
        _phoneNumber = ValidatePhone(phone_number);
        _passportSeries = ValidatePassportSeries(passport_series);
        _passportNumber = ValidatePassportNumber(passport_number);
        _cardNumber = ValidateCardNumber(card_number);

        _account_is_validate = true;
    }

    private string ValidateName(string value, string fieldName)
    {
        // Ошибка выдается если строка пустая, null, состоит из пробелов
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{fieldName} не может быть пустым");
        }

        // Убераем лишние пробелы в начале и конце строки
        value = value.Trim();

        // Проверка длины значения строки 
        if (value.Length < 2)
        {
            throw new ArgumentException($"<{fieldName}>. Длина строки содержит меньше 2");
        }

        // Проверяем что все символы являются буквами
        if (!value.All(c => char.IsLetter(c) || c == '-'))
        {
            throw new ArgumentException($"{fieldName} может содеражть только буквы и дефис");
        }

        // Возращаем строку
        return value;
    }

    private string ValidatePhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Строка с номером телефона должна быть не пустой");
        }

        phone = phone.Trim();

        string phone_pattern_ru = @"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";

        if (!Regex.IsMatch(phone, phone_pattern_ru))
        {
            throw new ArgumentException($"Телефонный номер {phone} не соответсвует формату региона");
        }

        return cleanPhone(phone);
    }

    private string cleanPhone(string phone)
    {

        string clean_phone_number = Regex.Replace(phone, @"[^\d+]", "");

        if (clean_phone_number.StartsWith("8") && clean_phone_number.Length == 11)
        {
            clean_phone_number = "+7" + clean_phone_number.Substring(1);
        }
        else if (clean_phone_number.StartsWith("7") && clean_phone_number.Length == 11)
        {
            clean_phone_number = "+" + clean_phone_number;
        }
        else if (clean_phone_number.StartsWith("+") && clean_phone_number.Length == 10)
        {
            clean_phone_number = "+7" + clean_phone_number;
        }

        return string.Format(
            "+7 ({0}) {1}-{2}-{3}",
            clean_phone_number.Substring(2, 3),
            clean_phone_number.Substring(5, 3),
            clean_phone_number.Substring(8, 2),
            clean_phone_number.Substring(10, 2)
        );
    }

    private string ValidatePassportSeries(string series)
    {
        if (!series.All(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Серия паспорта должна состоять только из цифр");
        }

        if (series.Length != 4)
        {
            throw new ArgumentException("Серия паспорта должна состоять только 4 цифр");
        }

        return series;
    }


    private string ValidatePassportNumber(string number)
    {
        number = number.Replace(" ", "");
        if (!number.All(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Номер паспорта должна состоять только из цифр");
        }

        if (number.Length != 6)
        {
            throw new ArgumentException("Номер паспорта должна состоять только 6 цифр");
        }


        //System.Console.WriteLine(number.Substring(3, 3));
        //return string.Format(
        //    "{1} {2}",
        //    number.Substring(0, 3),
        //    number.Substring(3, 3)
        //);
        return number;
    }

    private string ValidateCardNumber(string number)
    {
        number = number.Replace(" ", "");

        if (number.Length != 16)
            throw new ArgumentException($"Нужно 16 цифр, получено: {number.Length}");

        int sum = 0;
        for (int i = 0; i < 16; i++)
        {
            int digit = number[15 - i] - '0';
            sum += (i % 2 == 1) ? (digit * 2 > 9 ? digit * 2 - 9 : digit * 2) : digit;
        }

        if (sum % 10 != 0)
            throw new ArgumentException("Невалидный номер карты");

        return number;
    }
}