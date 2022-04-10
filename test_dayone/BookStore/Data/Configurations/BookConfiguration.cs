using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); 

            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Stock).IsRequired(true).HasDefaultValue(0);
            
            builder.Property(x => x.OriginalPrice).IsRequired();

            builder.HasOne(t => t.Author).WithMany(pc => pc.Books).HasForeignKey(x => x.AuthorId);
        }
    }
}
