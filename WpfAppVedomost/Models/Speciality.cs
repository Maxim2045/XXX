
using System.ComponentModel.DataAnnotations;


namespace WpfAppVedomost.Models
{
   public class Speciality
    {
     [Key] public int IdSpeciality { get; set; }

        public string Code { get; set; }
        public string NameSpeciality { get; set; }
    }
}
