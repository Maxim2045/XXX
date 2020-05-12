using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace WpfAppVedomost.Models
{
    /// <summary>
    /// Interaction logic for WindowDB.xaml
    /// </summary>
    public partial class WindowDB : Window
    {
        readonly ApplicationContext db;
        public WindowDB()
        {     
            InitializeComponent();

            db = new ApplicationContext();
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
                // получаем измененный объект
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
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (studentsList.SelectedItem == null) return;
            // получаем выделенный объект
            Student student = studentsList.SelectedItem as Student;
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
