using System;
using System.Text;

namespace BankApp
{
    public static class Security
    {
        private const int CAESAR_SHIFT = 3; // Сдвиг для шифра Цезаря

        // Шифрование строки алгоритмом Цезаря для кириллицы
        public static string CaesarEncrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    // Шифрование цифр
                    char encrypted = (char)(((c - '0' + CAESAR_SHIFT) % 10) + '0');
                    result.Append(encrypted);
                }
                else if (c >= 'А' && c <= 'Я') // Русские заглавные
                {
                    char encrypted = (char)(((c - 'А' + CAESAR_SHIFT) % 32) + 'А');
                    result.Append(encrypted);
                }
                else if (c >= 'а' && c <= 'я') // Русские строчные
                {
                    char encrypted = (char)(((c - 'а' + CAESAR_SHIFT) % 32) + 'а');
                    result.Append(encrypted);
                }
                else if (c >= 'A' && c <= 'Z') // Английские заглавные
                {
                    char encrypted = (char)(((c - 'A' + CAESAR_SHIFT) % 26) + 'A');
                    result.Append(encrypted);
                }
                else if (c >= 'a' && c <= 'z') // Английские строчные
                {
                    char encrypted = (char)(((c - 'a' + CAESAR_SHIFT) % 26) + 'a');
                    result.Append(encrypted);
                }
                else
                {
                    // Остальные символы (пробелы, скобки, дефисы) оставляем как есть
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // Дешифрование строки алгоритмом Цезаря для кириллицы
        public static string CaesarDecrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    // Дешифрование цифр
                    int decryptedValue = (c - '0' - CAESAR_SHIFT + 10) % 10;
                    char decrypted = (char)(decryptedValue + '0');
                    result.Append(decrypted);
                }
                else if (c >= 'А' && c <= 'Я') // Русские заглавные
                {
                    int decryptedValue = (c - 'А' - CAESAR_SHIFT + 32) % 32;
                    char decrypted = (char)(decryptedValue + 'А');
                    result.Append(decrypted);
                }
                else if (c >= 'а' && c <= 'я') // Русские строчные
                {
                    int decryptedValue = (c - 'а' - CAESAR_SHIFT + 32) % 32;
                    char decrypted = (char)(decryptedValue + 'а');
                    result.Append(decrypted);
                }
                else if (c >= 'A' && c <= 'Z') // Английские заглавные
                {
                    int decryptedValue = (c - 'A' - CAESAR_SHIFT + 26) % 26;
                    char decrypted = (char)(decryptedValue + 'A');
                    result.Append(decrypted);
                }
                else if (c >= 'a' && c <= 'z') // Английские строчные
                {
                    int decryptedValue = (c - 'a' - CAESAR_SHIFT + 26) % 26;
                    char decrypted = (char)(decryptedValue + 'a');
                    result.Append(decrypted);
                }
                else
                {
                    // Остальные символы оставляем как есть
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // Шифрование данных клиента (для сохранения в БД)
        public static ClientData? EncryptClientData(ClientData client)
        {
            if (client == null) return null;

            return new ClientData(
                CaesarEncrypt(client.LastName),
                CaesarEncrypt(client.FirstName),
                CaesarEncrypt(client.MiddleName),
                CaesarEncrypt(client.PhoneNumber),
                CaesarEncrypt(client.PassportSeries),
                CaesarEncrypt(client.PassportNumber),
                CaesarEncrypt(client.CardNumber)
            )
            { Id = client.Id };
        }

        // Дешифрование данных клиента (для чтения из БД)
        public static ClientData? DecryptClientData(ClientData client)
        {
            if (client == null) return null;

            return new ClientData(
                CaesarDecrypt(client.LastName),
                CaesarDecrypt(client.FirstName),
                CaesarDecrypt(client.MiddleName),
                CaesarDecrypt(client.PhoneNumber),
                CaesarDecrypt(client.PassportSeries),
                CaesarDecrypt(client.PassportNumber),
                CaesarDecrypt(client.CardNumber)
            )
            { Id = client.Id };
        }
    }
}