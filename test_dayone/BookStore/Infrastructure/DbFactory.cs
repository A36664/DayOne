using BookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private BookStoreContext _context;
        
        public DbFactory()
        {
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }

        public BookStoreContext Init()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory()) 
             .AddJsonFile("appsettings.json") 
             .AddJsonFile("appsettings.Development.json")
             .Build();


            var ConectionString = configuration.GetConnectionString("booksSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<BookStoreContext>();
            optionsBuilder.UseSqlServer(ConectionString);

            return _context ?? (_context = new BookStoreContext(optionsBuilder.Options));
        }
    }
}
