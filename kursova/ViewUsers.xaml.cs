using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace kursova
{
    public partial class ViewUsers
    {
        private string[] lines;

        public ViewUsers()
        {
            InitializeComponent();
            ReadAllLines();
            PopulateListBox(lines);
        }

        private void ReadAllLines()
        {
            // Зчитуємо всі рядки з файлу
            string filePath = "users.txt";
            lines = File.ReadAllLines(filePath);
        }

        private void PopulateListBox(string[] lines)
        {
            // Очищаємо попередні елементи списку
            userListBox.Items.Clear();

            // Додаємо кожний рядок (користувача) до ListBox
            foreach (string line in lines)
            {
                userListBox.Items.Add(line);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевіряємо, чи вибрано значення у комбо-боксі "Тип Сортування"
            if (SortComboBox.SelectedIndex == -1)
            {
                // Фільтруємо користувачів
                FilterUsers();
                return; // Припиняємо виконання коду сортування
            }

            // Створюємо копію оригінального масиву lines
            string[] filteredLines = new string[lines.Length];
            Array.Copy(lines, filteredLines, lines.Length);

            // Фільтр за характером знайомства
            if (RelationshipTextBox.SelectedItem != null)
            {
                string selectedRelationship = ((ComboBoxItem)RelationshipTextBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedRelationship)).ToArray();
            }

            // Фільтр за діловими якостями
            if (BusinessQualitiesTextBox.SelectedItem != null)
            {
                string selectedBusinessQuality = ((ComboBoxItem)BusinessQualitiesTextBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedBusinessQuality)).ToArray();
            }

            // Фільтр за статтю
            if (GenderComboBox.SelectedItem != null)
            {
                string selectedGender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedGender)).ToArray();
            }

            // Отримуємо тип сортування (за зростанням або за спаданням)
            bool ascending = SortComboBox.SelectedIndex == 0; // 0 - За зростанням, 1 - За спаданням

            // Сортуємо відфільтрованих користувачів
            SortUsers(filteredLines, ascending);
        }

        private void SortUsers(string[] filteredLines, bool ascending)
        {
            Array.Sort(filteredLines, StringComparer.CurrentCulture);
            if (!ascending)
            {
                Array.Reverse(filteredLines);
            }
            PopulateListBox(filteredLines);
        }

        private void FilterUsers()
        {
            // Створюємо копію оригінального масиву lines
            string[] filteredLines = new string[lines.Length];
            Array.Copy(lines, filteredLines, lines.Length);

            // Фільтр за характером знайомства
            if (RelationshipTextBox.SelectedItem != null)
            {
                string selectedRelationship = ((ComboBoxItem)RelationshipTextBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedRelationship)).ToArray();
            }

            // Фільтр за діловими якостями
            if (BusinessQualitiesTextBox.SelectedItem != null)
            {
                string selectedBusinessQuality = ((ComboBoxItem)BusinessQualitiesTextBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedBusinessQuality)).ToArray();
            }

            // Фільтр за статтю
            if (GenderComboBox.SelectedItem != null)
            {
                string selectedGender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
                filteredLines = filteredLines.Where(line => line.Contains(selectedGender)).ToArray();
            }

            // Оновлюємо дані для відображення в ListBox
            PopulateListBox(filteredLines);
        }
    }
}
