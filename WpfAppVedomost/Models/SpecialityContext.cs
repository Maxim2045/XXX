using System.Data.Entity;

namespace WpfAppVedomost.Models
{
    class SpecialityContext : DbContext
    {
        public SpecialityContext() : base("DefaultConnection")
        {
        }
        public DbSet<Speciality> Specialities { get; set; }
    }
}
