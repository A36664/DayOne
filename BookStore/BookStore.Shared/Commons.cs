using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
    public static class Commons
    {
        public struct Messages
        {
            public static string MessageWarring = "Chú ý";
            public static string MessageError = "Lỗi ngoại lệ";
            public static string MessageSearch = "Vui lòng nhập giá trị tìm";
          public  struct Book
            {
                public static string MessageOne = "Vui lòng nhập tên sách";
                public static string MessageTwo = "Vui lòng nhập giá sách ";
                public static string MessageThree = "Vui lòng nhập số lượng sách";
                public static string MessageFour = "Vui lòng nhập giá gốc";
                public static string MessageFive = "Thêm sách";
            }
          public struct Author
          {
              public static string MessageOne = "Vui lòng nhập tên tác giả";
              public static string MessageTwo = "Vui lòng nhập số điện thoại ";
              public static string MessageThree = "Vui lòng nhập email";
              public static string MessageFour = "Thêm tác giả";
          }
          public struct Customer
          {
              public static string MessageOne = "Vui lòng nhập tên Khách hàng";
              public static string MessageTwo = "Vui lòng nhập Email ";
              public static string MessageThree = "Vui lòng nhập số điện thoại";
              public static string MessageFour = "Thêm khách hàng";
          }
        }
    }
}
