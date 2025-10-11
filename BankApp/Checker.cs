using System.Text.RegularExpressions;

public class Checker
{
    public static bool checkName(string name) // Имя
    {
        if (string.IsNullOrEmpty(name)) return false;

        name = name.Trim();

        if (name.Contains(' ')) return false;

        if (!name.All(c => char.IsLetter(c) || c == '-') || name[0] == '-' || name[name.Length - 1] == '-') return false;

        return true;
    }

    public static bool ckeckPassportNumber(string number) // Номер паспорта
    {
        number = number.Replace(" ", "");

        if (!number.All(c => char.IsDigit(c))) return false;

        if (number.Length != 6) return false;

        return true;
    }

    public static bool ckeckPassportSeries(string series) // Серия паспорта
    {
        series = series.Replace(" ", "");

        if (!series.All(c => char.IsDigit(c))) return false;

        if (series.Length != 4) return false;

        return true;
    }

    public static bool ckeckPhoneNumber(string phone) // Номер телефона
    {
        string phone_pattern_ru = @"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";

        if (string.IsNullOrWhiteSpace(phone)) return false;

        phone = phone.Trim();

        if (!Regex.IsMatch(phone, phone_pattern_ru)) return false;

        return true;
    }

    public static bool checkCardNumber(string number) // Номер карты
    {
        number = number.Replace(" ", "");

        if (number.Length != 16) return false;

        if (!number.All(char.IsDigit)) return false;

        int sum = 0;
        for (int i = 0; i < 16; i++)
        {
            int digit = number[15 - i] - '0';
            sum += (i % 2 == 1) ? (digit * 2 > 9 ? digit * 2 - 9 : digit * 2) : digit;
        }

        if (sum % 10 != 0) return false;

        return true;
    }

    public bool ckeckLogin(string login) => !string.IsNullOrWhiteSpace(login) && login.Length > 3;

    public bool checkPassword(string password) => !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
}