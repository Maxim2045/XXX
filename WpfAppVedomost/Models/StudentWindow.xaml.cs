
using System.Windows;

namespace WpfAppVedomost.Models
{

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
        {   if(Student.FirstName==null)
            {
                MessageBox.Show("Поле фамилия должно быть заполнено");
                this.DialogResult = false;
            }
            else if (Student.LastName == null)
            {
                MessageBox.Show("Поле имя должно быть заполнено");
                this.DialogResult = false;
            }
            else if (Student.RecordNumber == 0)
            {
                MessageBox.Show("Поле номер студента должно быть заполнено");
                this.DialogResult = false;
            }
            else if (Student.IdGroup == 0)
            {
                MessageBox.Show("Поле группа должно быть заполнено");
                this.DialogResult = false;
            }
            else
            this.DialogResult = true;
        }
    }
}
