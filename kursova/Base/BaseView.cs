using System.Windows;
using YourAppName;

namespace kursova.Base;

public class BaseView : Window
{
    public void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}