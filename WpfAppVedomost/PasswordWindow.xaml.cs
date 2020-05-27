
using System.Windows;


namespace WpfAppVedomost
{
    /// <summary>
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            
                if (passwordBox.Password == "1")
                {                   
                    MenuWindow window = new MenuWindow();
                    window.Show();
                    AutorizationWindow.Close();
                }
                else
                    MessageBox.Show("Неверный пароль");                     
        }
        private void Deny_Click(object sender, RoutedEventArgs e)
        {
         // CreateDB db = new CreateDB();
         // db.Create();
          AutorizationWindow.Close();
        }
    }
}
