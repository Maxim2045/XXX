using System.Data.Entity;
 
namespace WpfAppVedomost.Models
{
    public class StudentContext : DbContext // Связывание с базой данных
    {
        public StudentContext():base("DefaultConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}