using System.Windows;
using System.Windows.Controls;
using YourAppName;

namespace kursova
{
    public partial class UserGuideWindow
    {
        public UserGuideWindow()
        {
            InitializeComponent();
        }

        public void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Створюємо новий екземпляр MainWindow
            MainWindow mainWindow = new MainWindow();

            // Показуємо нове головне вікно
            mainWindow.Show();

            // Закриваємо поточне вікно (UserGuideWindow)
            this.Close();
        }
        
        private void OneStepGuide_Click(object sender, RoutedEventArgs e) {
            OneStepGuide(); // Викликаємо функцію перегляду користувачів
        }
        
        private void TwoStepGuide_Click(object sender, RoutedEventArgs e) {
            TwoStepGuide(); // Викликаємо функцію перегляду користувачів
        }
        
        private void ThreeStepGuide_Click(object sender, RoutedEventArgs e) {
            ThreeStepGuide(); // Викликаємо функцію перегляду користувачів
        }
        
        private void FourStepGuide_Click(object sender, RoutedEventArgs e) {
            FourStepGuide(); // Викликаємо функцію перегляду користувачів
        }
        
        private void FiveStepGuide_Click(object sender, RoutedEventArgs e) {
            FiveStepGuide(); // Викликаємо функцію перегляду користувачів
        }
        
        private void OneStepGuide() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            OneStepGuide OneStepGuide = new OneStepGuide();

            // Показуємо вікно UserGuideWindow
            OneStepGuide.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void TwoStepGuide() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            TwoStepGuide TwoStepGuide = new TwoStepGuide();

            // Показуємо вікно UserGuideWindow
            TwoStepGuide.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void ThreeStepGuide() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            ThreeStepGuide ThreeStepGuide = new ThreeStepGuide();

            // Показуємо вікно UserGuideWindow
            ThreeStepGuide.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void FourStepGuide() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            FourStepGuide FourStepGuide = new FourStepGuide();

            // Показуємо вікно UserGuideWindow
            FourStepGuide.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
        
        private void FiveStepGuide() {
            // Створюємо новий об'єкт вікна UserGuideWindow
            FiveStepGuide FiveStepGuide = new FiveStepGuide();

            // Показуємо вікно UserGuideWindow
            FiveStepGuide.Show();

            // Закриваємо поточне вікно (MainWindow)
            this.Close();
        }
    }
}