
using System.Windows;


namespace WpfAppVedomost.Models
{
    /// <summary>
    /// Interaction logic for SpecialityWindow.xaml
    /// </summary>
    public partial class SpecialityWindow : Window
    {
        public Speciality Speciality { get; private set; }
        public SpecialityWindow(Speciality s)
        {
            InitializeComponent();
            Speciality = s;
            this.DataContext = Speciality;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            if (Speciality.Code == null)
            {
                MessageBox.Show("Поле фамилия должно быть заполнено");
                this.DialogResult = false;
            }
            else if (Speciality.NameSpeciality == null)
            {
                MessageBox.Show("Поле имя должно быть заполнено");
                this.DialogResult = false;
            }
            
            else
                this.DialogResult = true;
        }
      
    }
}
