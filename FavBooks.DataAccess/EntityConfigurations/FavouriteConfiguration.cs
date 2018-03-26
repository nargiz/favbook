using FavBooks.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FavBooks.DataAccess.EntityConfigurations
{
    public class FavouriteConfiguration : EntityTypeConfiguration<Favourite>
    {
        public FavouriteConfiguration()
        {
            HasKey(e => new {  e.UserId, e.ISBN });

            Property(e => e.ISBN)
                .IsRequired();

            Property(e => e.DateCreated)
               .IsRequired();

            Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(128);

            HasRequired(e => e.Book)
                .WithMany(e=> e.Favourites)
                .HasForeignKey(e => e.ISBN)
                .WillCascadeOnDelete(false);

            HasIndex(e => new { e.UserId });

        }
    }
}
