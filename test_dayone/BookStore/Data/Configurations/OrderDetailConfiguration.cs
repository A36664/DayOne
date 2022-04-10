using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            // khóa chính là hai thằng
            builder.HasKey(x => new { x.OrderId, x.BookId });

            // lấy ra thăng order trong orderDetail ,trong order có list OrderDetails tham chiếu tới OrderId của orderDetail 
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Book).WithMany(x => x.OrderDetails).HasForeignKey(x => x.BookId);

        }
    }
}
