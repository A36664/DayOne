using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.EF
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("Server=.;Database=BookStoreDayOne;Trusted_Connection=True;")
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<BookInCategory> BookInCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OutPut> Outputs { get; set; }  

    }
}
