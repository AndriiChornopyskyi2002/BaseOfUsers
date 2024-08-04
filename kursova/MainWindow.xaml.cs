using System.IO;
using System.Windows;
using System.Windows.Controls;
using kursova;
using kursova.models.Models;


namespace YourAppName
{
    public partial class MainWindow
    {
        private List<User> users = new List<User>();

        public MainWindow() {
            InitializeComponent();
            LoadDataFromFile();
        }
        
        private void LoadDataFromFile() {
            string filePath = "users.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    // Припустимо, що User - це ваш клас користувача з методом ToString(), який повертає інформацію про користувача у вигляді рядка
                    UserListBox.Items.Add(line);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Помилка зчитування файлу: {ex.Message}");
            }
        }
        
        private void arrangement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedSortingOption = ((ComboBoxItem)arrangement.SelectedItem)?.Content?.ToString();

            if (selectedSortingOption == "За алфавітом")
            {
                users = users.OrderBy(user => user.ProfileData).ToList();
            }
            else if (selectedSortingOption == "За датою останнього коригування")
            {
                // Впорядковуємо за допомогою додаткового поля, наприклад, DataPublication
                users = users.OrderBy(user => user.DataPublication).ToList();
            }

            // Очищаємо ListBox перед оновленням даних
            UserListBox.Items.Clear();

            // Додаємо відсортовані дані до ListBox
            foreach (var user in users)
             {
                 // Додати рядок, який відображатиме користувача у форматі, який вам потрібен
                 UserListBox.Items.Add($"{user.ProfileData}, {user.Address}, {user.PhoneNumber}, {user.WorkplaceOrEducation}, {user.Solvency}, {user.Birth}, {user.Relationship}, {user.BusinessQualities}, {user.Gender}");
             }
        }
        
        private void ViewUsers() {
            
            // Створюємо новий об'єкт вікна UserGuideWindow
            ViewUsers ViewUsers = new ViewUsers();

            // Показуємо вікно UserGuideWindow
            ViewUsers.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void EditUsers() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            EditUsers EditUsers = new EditUsers();

            // Показуємо вікно UserGuideWindow
            EditUsers.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void DeleteUsers() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            DeleteUser DeleteUser = new DeleteUser();

            // Показуємо вікно UserGuideWindow
            DeleteUser.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void UserGuideButton_Click(object sender, RoutedEventArgs e) {
            // Створюємо новий об'єкт вікна UserGuideWindow
            UserGuideWindow userGuideWindow = new UserGuideWindow();

            // Показуємо вікно UserGuideWindow
            userGuideWindow.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void UserAddButton_Click(object sender, RoutedEventArgs e) {
            // Створюємо новий об'єкт вікна UserGuideWindow
            UserAddWindow UserAddWindow = new UserAddWindow();

            // Показуємо вікно UserGuideWindow
            UserAddWindow.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
       private void SearchButton_Click(object sender, RoutedEventArgs e) {
            string searchInput = SearchTextBox.Text;
            
            arrangement_SelectionChanged(null, null);
            
            // Очищаємо ListBox перед пошуком нових результатів
            UserListBox.Items.Clear();

            try
            {
                // Зчитуємо дані з файлу users.txt та створюємо об'єкти користувачів
                string filePath = "users.txt";
                string[] lines = File.ReadAllLines(filePath);
                users = new List<User>();

                    foreach (string line in lines)
                    {
                        string[] userData = line.Split(','); // Зміна роздільника на кому
                        User user = new User
                        {
                            ProfileData = userData[0],
                            Address = userData[1],
                            PhoneNumber = userData[2],
                            WorkplaceOrEducation = userData[3],
                            Solvency = userData[4],
                            Birth = userData[5],
                            Relationship = userData[6],
                            BusinessQualities = userData[7],
                            Gender = userData[8]
                        };
                        users.Add(user);
                    }

                    // Виконуємо пошук серед користувачів за введеними критеріями
                    var searchResults = users.Where(user =>
                        user.ProfileData.Contains(searchInput) ||
                        user.Address.Contains(searchInput) ||
                        user.PhoneNumber.Contains(searchInput) ||
                        user.WorkplaceOrEducation.Contains(searchInput) ||
                        user.Solvency.Contains(searchInput) ||
                        user.Birth.Contains(searchInput) ||
                        user.Relationship.Contains(searchInput) ||
                        user.BusinessQualities.Contains(searchInput) ||
                        user.Gender.Contains(searchInput)).ToList();

                    // Отримуємо вибраний елемент з ComboBox
                    string selectedSortingOption = ((ComboBoxItem)arrangement.SelectedItem)?.Content?.ToString();

                    // Впорядковуємо дані відповідно до вибору користувача
                    if (selectedSortingOption == "За алфавітом")
                    {
                        searchResults = searchResults.OrderBy(user => user.ProfileData).ToList();
                    }
                    else if (selectedSortingOption == "За датою останнього коригування")
                    {
                        // Впорядковуємо за допомогою додаткового поля, наприклад, DataPublication
                        searchResults = searchResults.OrderBy(user => user.DataPublication).ToList();
                    }

                    // Додаємо результати пошуку до ListBox
                    foreach (var user in searchResults)
                    {
                        UserListBox.Items.Add(user.ProfileData + user.Address + user.PhoneNumber + user.WorkplaceOrEducation + user.Solvency + user.Birth + user.Relationship + user.BusinessQualities + user.Gender);
                    }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Помилка зчитування файлу: {ex.Message}");
            }
        }
        
        private void ViewUsers_Click(object sender, RoutedEventArgs e) {
            ViewUsers(); // Викликаємо функцію перегляду користувачів
        }
        
        private void EditUsers_Click(object sender, RoutedEventArgs e) {
            EditUsers(); // Викликаємо функцію перегляду користувачів
        }
        
        private void DeleteUsers_Click(object sender, RoutedEventArgs e) {
            DeleteUsers(); // Викликаємо функцію перегляду користувачів
        }
    }
}
