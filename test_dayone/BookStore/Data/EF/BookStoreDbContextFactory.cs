using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Data.EF
{
    public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreContext>
    {
        public BookStoreContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory()) // để có SetBasePath tải thêm Microsoft.Extensions.Configuration.FileExtensions
              .AddJsonFile("appsettings.json") // để có AddJsonFile tải thêm  Microsoft.Extensions.Configuration.Json
              .AddJsonFile("appsettings.Development.json")
              .Build();

           
            var ConectionString = configuration.GetConnectionString("booksSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<BookStoreContext>();
            optionsBuilder.UseSqlServer(ConectionString);// chuyền ConectionString vào

            return new BookStoreContext(optionsBuilder.Options);

            //throw new System.Exception();
        }
    }
}
