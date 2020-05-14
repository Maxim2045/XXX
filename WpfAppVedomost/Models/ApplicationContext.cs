using System.Data.Entity;
 
namespace WpfAppVedomost.Models
{
    public class ApplicationContext : DbContext // Связывание с базой данных
    {
        public ApplicationContext():base("DefaultConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}