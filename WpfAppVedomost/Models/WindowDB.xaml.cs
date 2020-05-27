using System.Data.Entity;
using System.Windows;


namespace WpfAppVedomost.Models
{
    /// <summary>
    /// Interaction logic for WindowDB.xaml
    /// </summary>
    public partial class WindowDB : Window
    {
        readonly StudentContext db;
        public WindowDB()
        {     
            InitializeComponent();

            db = new StudentContext();
            db.Students.Load();
            this.DataContext = db.Students.Local.ToBindingList();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow(new Student());
            if (studentWindow.ShowDialog() == true)
            {
                Student student = studentWindow.Student;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (studentsList.SelectedItem == null) return;
            // получаем выделенный объект
            Student student = studentsList.SelectedItem as Student;

            StudentWindow studentWindow = new StudentWindow(new Student
            {
                IdStudent = student.IdStudent,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Patronimic = student.Patronimic,
                RecordNumber = student.RecordNumber,
                IdGroup=student.IdGroup
            }) ;

            if (studentWindow.ShowDialog() == true)
            {
                // Получение измененного объекта
                student = db.Students.Find(studentWindow.Student.IdStudent);
                if (student != null)
                {
                    student.FirstName = studentWindow.Student.FirstName;
                    student.LastName = studentWindow.Student.LastName;
                    student.Patronimic = studentWindow.Student.Patronimic;
                    student.RecordNumber = studentWindow.Student.RecordNumber;
                    student.IdGroup = studentWindow.Student.IdGroup;
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Если ни одного объекта не выделено, выход
            if (studentsList.SelectedItem == null) return;
            // Получение выделенного объекта
            Student student = studentsList.SelectedItem as Student;
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
