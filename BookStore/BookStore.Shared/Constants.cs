using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
    public static class Constants
    {
        public const string ConnectionString = "Server=.;Database=BookStoreDayOne;Trusted_Connection=True;";
        public static string EncryptionKey = "fkasfdshfjkwjfknbsajkfjka";
        public struct BookFields
        {
            public static string BookId="Mã sách";
            public static string Name="Tên sách";
            public static string Stock = "Số lượng sách";
            public static string Price = "Giá bán";
            public static string AuthorName = "Tên tác giả";
            public static string CategoryName = "Loại";
        }
        public struct AuthorFields
        {
            public static string AuthorId = "Mã tác giả";
            public static string AuthorName = "Tên tác giả";
            public static string PhoneNumber = "Số điện thoại";
            public static string Email = "Email";
          
        }
        public struct CustomerFields
        {
            public static string CustomerId = "Mã khách hàng";
            public static string CustomerName = "Tên khách hàng";
            public static string PhoneNumber = "Số điện thoại";
            public static string Email = "Email";
          
        }
        public struct CategoryFields
        {
            public static string CategoryId = "Mã danh mục";
            public static string CategoryName = "Tên danh mục";
           

        }

        public static class StatusTypes
        {

            public const string Customer = "Customer";
            public const string Book = "Book";
            public const string Category = "Category";
            public const string Author = "Author";
        }
        public static class  ActionTypes
        {
            public const string Get = "Get";
            public const string GetAll = "GetAll";
            public const string Update = "Update";
            public const  string Delete = "Delete";
            public const string GetById = "GetById";
            public const string Add = "Add";
            public const string SaveChanges = "SaveChanges";
            public const string GetAllBooks = "GetAllBooks";

        }

       

    }

}
