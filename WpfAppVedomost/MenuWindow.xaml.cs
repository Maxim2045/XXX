using System.Windows;

namespace WpfAppVedomost
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }
        private void Vedomost_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Menu.Close();           
        }
        private void StudentInfo_Click(object sender, RoutedEventArgs e)
        {
            SpecialityDB window = new SpecialityDB();
            window.Show();
            Menu.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            ReferenceWindow window = new ReferenceWindow();
            window.Show();
        }
    }
}
