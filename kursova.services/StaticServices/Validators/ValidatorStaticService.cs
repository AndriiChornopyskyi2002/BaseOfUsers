using System.Globalization;
using System.Text.RegularExpressions;
using kursova.models.Models;

namespace kursova.services.StaticServices.Validators;

public static class ValidatorStaticService
{
    public static string ValidateUser(User user)
    {
        // Перевіряємо коректність введених даних
        if (string.IsNullOrEmpty(user.ProfileData) ||
            string.IsNullOrEmpty(user.Address) ||
            string.IsNullOrEmpty(user.PhoneNumber) ||
            string.IsNullOrEmpty(user.WorkplaceOrEducation) ||
            string.IsNullOrEmpty(user.Relationship) ||
            string.IsNullOrEmpty(user.BusinessQualities) ||
            string.IsNullOrEmpty(user.Gender) ||
            string.IsNullOrEmpty(user.Birth) ||
            string.IsNullOrEmpty(user.Solvency)
           )
        {
            return "Будь ласка, заповніть всі поля.";
        }

        // Перевіряємо телефонний номер
        if (!ValidatePhoneNumber(user.PhoneNumber))
        {
            return "Неправильний формат телефонного номера. Введіть номер у форматі +380123456789.";
        }

        // Перевіряємо дату народження
        if (!ValidateBirthDate(user.Birth))
        {
            return "Неправильний формат дати народження. Введіть дату у форматі dd.MM.yyyy (наприклад, 01.01.2000).";
        }

        return string.Empty;
    }
    
    private static bool ValidatePhoneNumber(string phoneNumber)
    {
        // Перевірка формату телефонного номера (наприклад, формат +380123456789)
        if (!Regex.IsMatch(phoneNumber, @"^\+\d{12}$"))
        {
            return false;
        }

        return true;
    }

    private static bool ValidateBirthDate(string birthDate)
    {
        // Перевірка формату дати народження (наприклад, формат 01.01.2000)
        if (!DateTime.TryParseExact(birthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _))
        {
            return false;
        }

        return true;
    }
}