using FavBooks.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FavBooks.DataAccess.EntityConfigurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasKey(e => e.ISBN);

            Property(e => e.Authors)
               .IsRequired()
               .HasMaxLength(500);

            Property(e => e.CoverThumb)
               .IsMaxLength();

            Property(e => e.Description)
               .HasMaxLength(2000);

            Property(e => e.ISBN)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.Subjects)
               .HasMaxLength(500);

            Property(e => e.Subtitle)
              .HasMaxLength(500);

            Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(500);
            
        }

    }
}
