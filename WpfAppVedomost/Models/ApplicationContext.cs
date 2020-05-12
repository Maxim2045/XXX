using System.Data.Entity;
 
namespace WpfAppVedomost.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("DefaultConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}