using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Formatter
{
    public static string formatName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return string.Empty;

        name = name.Trim();

        // Приводим к формату: Первая буква заглавная, остальные строчные
        if (name.Length > 0)
        {
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        // Обрабатываем двойные имена через дефис
        if (name.Contains('-'))
        {
            var parts = name.Split('-');
            var normalizedParts = parts.Select(part =>
                part.Length > 0 ? char.ToUpper(part[0]) + part.Substring(1).ToLower() : ""
            );
            name = string.Join("-", normalizedParts);
        }

        return name;
    }

    public static string phoneNumber(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return string.Empty;

        // Удаляем все нецифровые символы, кроме +
        var digits = new string(phone.Where(c => char.IsDigit(c) || c == '+').ToArray());

        // Приводим к формату: +7XXXXXXXXXX
        if (digits.StartsWith("+7"))
        {
            return digits.Length == 12 ? digits : string.Empty;
        }
        else if (digits.StartsWith("7"))
        {
            return digits.Length == 11 ? "+" + digits : string.Empty;
        }
        else if (digits.StartsWith("8"))
        {
            return digits.Length == 11 ? "+7" + digits.Substring(1) : string.Empty;
        }
        else if (digits.Length == 10)
        {
            return "+7" + digits;
        }

        return string.Empty;
    }

    public static string passportSeries(string series)
    {
        if (string.IsNullOrWhiteSpace(series)) return string.Empty;

        series = new string(series.Where(char.IsDigit).ToArray());

        return series.Length == 4 ? series : string.Empty;
    }

    public static string passportNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number)) return string.Empty;

        number = new string(number.Where(char.IsDigit).ToArray());

        return number.Length == 6 ? number : string.Empty;
    }

    public static string cardNumber(string number)
    {
        number = Formatter.cardNumber(number);
        if (number.Length != 16) return number;

        // Форматируем как XXXX XXXX XXXX XXXX
        return $"{number.Substring(0, 4)} {number.Substring(4, 4)} {number.Substring(8, 4)} {number.Substring(12, 4)}";
    }
}