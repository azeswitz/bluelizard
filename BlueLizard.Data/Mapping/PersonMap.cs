using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BlueLizard.Domain;

namespace BlueLizard.Data.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonId);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(50);

            this.Property(t => t.StreetAddress1)
                .HasMaxLength(50);

            this.Property(t => t.StreetAddress2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(20);

            this.Property(t => t.State)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(250);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(250);

            this.Property(t => t.UpdateBy)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.StreetAddress1).HasColumnName("StreetAddress1");
            this.Property(t => t.StreetAddress2).HasColumnName("StreetAddress2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
        }
    }
}
