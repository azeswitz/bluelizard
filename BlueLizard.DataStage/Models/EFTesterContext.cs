using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BlueLizard.DataStage.Models.Mapping;

namespace BlueLizard.DataStage.Models
{
    public partial class EFTesterContext : DbContext
    {
        static EFTesterContext()
        {
            Database.SetInitializer<EFTesterContext>(null);
        }

        public EFTesterContext()
            : base("Name=EFTesterContext")
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
