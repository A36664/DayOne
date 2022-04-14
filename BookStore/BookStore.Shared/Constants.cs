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

    }

}
