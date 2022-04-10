using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class OutputConfiguration : IEntityTypeConfiguration<OutPut>
    {
        public void Configure(EntityTypeBuilder<OutPut> builder)
        {
            builder.ToTable("Outputs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Total).IsRequired();
            builder.HasOne(t => t.Book).WithMany(pc => pc.Outputs).HasForeignKey(x => x.BookId);

        }
    }
}
