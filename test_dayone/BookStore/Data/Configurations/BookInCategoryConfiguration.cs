using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class BookInCategoryConfiguration : IEntityTypeConfiguration<BookInCategory>
    {
        public void Configure(EntityTypeBuilder<BookInCategory> builder)
        {
            builder.HasKey(t=> new {t.CategoryId,t.BookId});
            builder.ToTable("BookInCategories");

            builder.HasOne(t => t.Book).WithMany(pc => pc.BookInCategories).HasForeignKey(x=>x.BookId);
            builder.HasOne(t=>t.Category).WithMany(ct=>ct.BookInCategories).HasForeignKey(x=>x.CategoryId);

        }
    }
}
