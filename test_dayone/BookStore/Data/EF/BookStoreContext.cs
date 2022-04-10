using BookStore.Data.Configurations;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data.EF
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookInCategory> BookInCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<OutPut> OutPuts { get; set; }
        public DbSet<BookStore.Models.BookViewModel> BookViewModel { get; set; }
        public DbSet<BookStore.Models.CustomerViewModel> CustomerViewModel { get; set; }
    }
}
