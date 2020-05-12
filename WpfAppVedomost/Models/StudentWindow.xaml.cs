
using System.Windows;

namespace WpfAppVedomost.Models
{
    /// <summary>
    /// Interaction logic for PhoneWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student { get; private set; }

        public StudentWindow(Student s)
        {
            InitializeComponent();
            Student = s;
            this.DataContext = Student;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
