using BookStore.Model.Entities;
using System.Data.Entity;

namespace BookStore.Data.EF
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("MyDBConnectionString")
        {
            
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OutPut> Outputs { get; set; }

    }
}
