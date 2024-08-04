using System.Windows;

namespace kursova;

public partial class TwoStepGuide : Window
{
    public TwoStepGuide()
    {
        InitializeComponent();
    }
    
    public void ReturnToUserGuide_Click(object sender, RoutedEventArgs e)
    {
        // Створюємо новий екземпляр MainWindow
        UserGuideWindow UserGuideWindow = new UserGuideWindow();

        // Показуємо нове головне вікно
        UserGuideWindow.Show();

        // Закриваємо поточне вікно (UserAddWindow)
        this.Close();
    }
}