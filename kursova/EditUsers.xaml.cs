using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace kursova
{
    public partial class EditUsers
    {
        private string filePath = "users.txt";
        private int currentIndex = -1;

        public EditUsers()
        {
            InitializeComponent();
        }

        // Метод для очищення полів введення
        private void ClearFields()
        {
            ProfileDataTextBox.Clear();
            AddressTextBox.Clear();
            PhoneNumberTextBox.Clear();
            WorkplaceOrEducationTextBox.Clear();
            RelationshipTextBox.SelectedIndex = -1;
            BusinessQualitiesTextBox.SelectedIndex = -1;
            GenderComboBox.SelectedIndex = -1;
            Birth.Clear();
            Solvency.Clear();
        }

        // Метод для збереження оновлених даних у файлі
        private void SaveDataToFile()
        {
            if (currentIndex >= 0)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    if (currentIndex < lines.Length)
                    {
                        lines[currentIndex] = $"{ProfileDataTextBox.Text.Trim()}, Адреса: {AddressTextBox.Text.Trim()}, Телефонний номер: {PhoneNumberTextBox.Text.Trim()}, Місце роботи або навчання: {WorkplaceOrEducationTextBox.Text.Trim()}, Солвентність: {Solvency.Text.Trim()}, Дата народження: {Birth.Text.Trim()}, Характер знайомства: {((ComboBoxItem)RelationshipTextBox.SelectedItem).Content}, Ділові якості: {((ComboBoxItem)BusinessQualitiesTextBox.SelectedItem).Content}, Стать: {((ComboBoxItem)GenderComboBox.SelectedItem).Content}";
                        File.WriteAllLines(filePath, lines);
                        MessageBox.Show("Дані успішно збережено у файлі.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні даних у файлі: " + ex.Message);
                }
            }
        }

        // Метод для пошуку користувача за індексом
        private void FindUser(int index)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    if (index >= 0 && index < lines.Length)
                    {
                        string userData = lines[index];
                        string[] userDataArray = userData.Split(',');

                            ProfileDataTextBox.Text = userDataArray[0].Split(':')[1].Trim();
                            AddressTextBox.Text = userDataArray[1].Split(':')[1].Trim();
                            PhoneNumberTextBox.Text = userDataArray[2].Split(':')[1].Trim();
                            WorkplaceOrEducationTextBox.Text = userDataArray[3].Split(':')[1].Trim();
                            Solvency.Text = userDataArray[4].Split(':')[1].Trim();
                            Birth.Text = userDataArray[5].Split(':')[1].Trim();

                            RelationshipTextBox.SelectedItem = RelationshipTextBox.Items.Cast<ComboBoxItem>()
                                .FirstOrDefault(item => item.Content.ToString() == userDataArray[6].Substring(userDataArray[6].IndexOf(':') + 1).Trim());

                            BusinessQualitiesTextBox.SelectedItem = BusinessQualitiesTextBox.Items.Cast<ComboBoxItem>()
                                .FirstOrDefault(item => item.Content.ToString() == userDataArray[7].Substring(userDataArray[7].IndexOf(':') + 1).Trim());

                            GenderComboBox.SelectedItem = GenderComboBox.Items.Cast<ComboBoxItem>()
                                .FirstOrDefault(item => item.Content.ToString() == userDataArray[8].Substring(userDataArray[8].IndexOf(':') + 1).Trim());

                            currentIndex = index;
                            
                    }
                    else
                    {
                        MessageBox.Show("Немає користувача з таким індексом.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл користувачів не знайдено.");
            }
        }

        // Обробник події натискання кнопки "Пошук"
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text.Trim(), out int index))
            {
                FindUser(index);
            }
            else
            {
                MessageBox.Show("Введіть коректний номер користувача.");
            }
        }

        // Обробник події натискання кнопки "Очистити"
        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        // Обробник події натискання кнопки "Зберегти"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveDataToFile();
        }
    }
}
