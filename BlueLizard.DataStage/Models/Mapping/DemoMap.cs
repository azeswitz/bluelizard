using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlueLizard.DataStage.Models.Mapping
{
    public class DemoMap : EntityTypeConfiguration<Demo>
    {
        public DemoMap()
        {
            // Primary Key
            this.HasKey(t => t.DemoId);

            // Properties
            this.Property(t => t.ColumnOne)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Demo");
            this.Property(t => t.DemoId).HasColumnName("DemoId");
            this.Property(t => t.ColumnOne).HasColumnName("ColumnOne");
        }
    }
}
