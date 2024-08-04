using System.Windows;
using kursova.Base;
using kursova.services.StaticServices;

namespace kursova
{
    public partial class DeleteUser
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ProfileDataTextBox.Text.Trim(), out int index))
            {
                var result = FileStaticService.DeleteUser(index);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний номер користувача для видалення.");
            }
        }
    }
}
