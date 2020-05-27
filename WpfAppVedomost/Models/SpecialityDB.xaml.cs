using System.Windows;
using WpfAppVedomost.Models;
using System.Data.Entity;

namespace WpfAppVedomost
{
    /// <summary>
    /// Interaction logic for SpecialityWindow.xaml
    /// </summary>
    public partial class SpecialityDB : Window
    {
        readonly SpecialityContext db;
        public SpecialityDB()
        {
            InitializeComponent();
            db = new SpecialityContext();
            db.Specialities.Load();
            this.DataContext = db.Specialities.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SpecialityWindow specialityWindow = new SpecialityWindow(new Speciality());
            if (specialityWindow.ShowDialog() == true)
            {
                Speciality speciality = specialityWindow.Speciality;
                db.Specialities.Add(speciality);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (specialityList.SelectedItem == null) return;
            // получаем выделенный объект
            Speciality speciality= specialityList.SelectedItem as Speciality;

            SpecialityWindow specialityWindow = new SpecialityWindow(new Speciality
            {
                IdSpeciality = speciality.IdSpeciality,
                Code = speciality.Code,
                NameSpeciality = speciality.NameSpeciality
            });

            if (specialityWindow.ShowDialog() == true)
            {
                // Получение измененного объекта
                speciality = db.Specialities.Find(specialityWindow.Speciality.IdSpeciality);
                if (speciality != null)
                {
                    speciality.Code = specialityWindow.Speciality.Code;
                    speciality.NameSpeciality = specialityWindow.Speciality.NameSpeciality;
                    db.Entry(speciality).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

      /*  private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Если ни одного объекта не выделено, выход
            if (specialityList.SelectedItem == null) return;
            // Получение выделенного объекта
            Speciality speciality = specialityList.SelectedItem as Speciality;
            db.Specialities.Remove(speciality);
            db.SaveChanges();
        }*/
        private void Student_Click(object sender, RoutedEventArgs e)
        {


            Speciality speciality = specialityList.SelectedItem as Speciality;

            if (speciality.Code == "01.03.02")
            {
                WindowDB window = new WindowDB();
                window.ShowDialog();
            }
            else
                MessageBox.Show("В данном блоке информация отсутствует");
        }
        private void Menu_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MenuWindow window = new MenuWindow();
            window.Show();
            Sp.Close();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow();
            window.Show();
            Sp.Close();
        }
    }
}
