using kursova.models.Models;

namespace kursova.services.StaticServices;

public static class FileStaticService
{
    private const string _path = "users.txt";

    public static string SaveUser(User user)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(_path, true);
            writer.WriteLine(
                $"Анкетні дані: {user.ProfileData}, " +
                $"Адреса: {user.Address}, " +
                $"Телефонний номер: {user.PhoneNumber}, " +
                $"Місце роботи або навчання: {user.WorkplaceOrEducation}, " +
                $"Солвентність: {user.Solvency}, " +
                $"Дата народження: {user.Birth},  " +
                $"Характер знайомства: {user.Relationship}, " +
                $"Ділові якості: {user.BusinessQualities}, " +
                $"Стать: {user.Gender}, " +
                $"Дата останнього коригування: {DateTime.Now}");

            return "Новий користувач успішно доданий та записаний у файл.";
        }
        catch (Exception e)
        {
            return "Помилка під час запису.";
        }
    }

    public static string DeleteUser(int index)
    {

        try
        {
            // Зчитуємо всі рядки з файлу
            string[] lines = File.ReadAllLines(_path);

            // Видаляємо користувача зі списку за вказаним індексом
            if (index >= 0 && index < lines.Length)
            {
                lines = lines.Where((source, i) => i != index).ToArray();

                // Записуємо оновлений список користувачів назад у файл
                File.WriteAllLines(_path, lines);

                return "Користувача видалено успішно.";
            }
            else
            {
                return "Немає користувача з таким індексом.";
            }
        }
        catch (Exception ex)
        {
            return "Помилка під час запису.";
        }
    }
}