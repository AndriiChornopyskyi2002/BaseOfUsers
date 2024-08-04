using System.Windows;
using System.Windows.Controls;
using kursova.models.Models;
using kursova.services.StaticServices;
using kursova.services.StaticServices.Validators;

namespace kursova
{
    public partial class UserAddWindow
    {
        public UserAddWindow()
        {
            InitializeComponent();
        }

        private void AddUser()
        {
            var user = GetUser();
            var validation = ValidatorStaticService.ValidateUser(user);

            if (!string.IsNullOrEmpty(validation))
            {
                MessageBox.Show(validation);
            }
            else
            {
                // Записуємо дані користувача у текстовий файл без індексу
                var result = FileStaticService.SaveUser(user);
                MessageBox.Show(result);

                // Очищаємо поля введення після додавання користувача
                ClearFields();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser(); // Викликаємо функцію додавання користувача
        }

        private void ClearFields()
        {
            // Очищаємо всі поля введення
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

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClearFields(); // Викликаємо функцію очищення полів введення
        }

        private User GetUser()
        {
            // Отримуємо дані з полів введення
            string profileData = ProfileDataTextBox.Text;
            string address = AddressTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string workplaceOrEducation = WorkplaceOrEducationTextBox.Text;
            string relationship = RelationshipTextBox.Text;
            string businessQualities = BusinessQualitiesTextBox.Text;
            string gender = ((ComboBoxItem)GenderComboBox.SelectedItem)?.Content?.ToString();
            string birth = Birth.Text;
            string solvency = Solvency.Text;
            
            // Створюємо нового користувача з отриманими даними
            User newUser = new User
            {
                ProfileData = profileData,
                Address = address,
                PhoneNumber = phoneNumber,
                WorkplaceOrEducation = workplaceOrEducation,
                Relationship = relationship,
                BusinessQualities = businessQualities,
                Gender = gender,
                Birth = birth,
                Solvency = solvency,
                DataPublication =  DateTime.Now.ToString("dd.MM.yyyy") // Додаємо поточну дату публікації
            };

            return newUser;
        }
    }
}
