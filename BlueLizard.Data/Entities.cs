using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BlueLizard.Data.Mapping;
using BlueLizard.Domain;

namespace BlueLizard.Data
{
    public partial class Entities : DbContext
    {
        static Entities()
        {
            Database.SetInitializer<Entities>(null);
        }

        public Entities()
            : base("Name=EFDbContext")
        {
        }

        public DbSet<Demo> Demoes { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DemoMap());
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}
