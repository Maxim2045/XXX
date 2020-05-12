using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WpfAppVedomost.Models
{
    public class Student : INotifyPropertyChanged
    {
      
        private string firstName;
        private string lastName;
        private string patronimic;
        private int recordNumber;
        private int idGroup;

        
       [Key]  public int IdStudent { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Patronimic
        {
            get { return patronimic; }
            set
            {
                patronimic = value;
                OnPropertyChanged("Patronimic");
            }
        }
        public int RecordNumber
        {
            get { return recordNumber; }
            set
            {
                recordNumber = value;
                OnPropertyChanged("RecordNumber");
            }
        }
        public int IdGroup
        {
            get { return idGroup; }
            set
            {
                idGroup = value;
                OnPropertyChanged("IdGroup");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
