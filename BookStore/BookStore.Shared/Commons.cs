using System.Collections.Generic;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;

namespace BookStore.Shared
{
    public static class Commons
    {
        public struct Messages
        {
            public static string MessageWarring = "Chú ý";
            public static string MessageError = "Lỗi ngoại lệ";
            public static string MessageSearch = "Vui lòng nhập giá trị tìm";
            public struct Book
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
        public static List<BookViewModel> GetBookViewModels()
        {
            var bookViewModels = new List<BookViewModel>()
            {
                new BookViewModel(){Price = 456.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 1,Name = "Book 1",AuthorName = "author 1",CategoryName = "category 1",Id = 1},
                new BookViewModel(){Price = 145.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 3,Name = "Book 2",AuthorName = "author 2",CategoryName = "category 3",Id = 2},
                new BookViewModel(){Price = 345.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 2,Name = "Book 3",AuthorName = "author 3",CategoryName = "category 2",Id = 3},
                new BookViewModel(){Price = 123.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 3,Name = "Book 4",AuthorName = "author 4",CategoryName = "category 3",Id = 4},
                new BookViewModel(){Price = 567.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 2,Name = "Book 5",AuthorName = "author 5",CategoryName = "category 2",Id = 5}
            };

            return bookViewModels;
        }  
        public static List<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1, AuthorId = 1, Name = "Book 1", Price = 456.45m, OriginalPrice = 145.6m, CategoryId = 2,
                    Stock = 450
                },
                new Book()
                {
                    Id = 2, AuthorId = 2, Name = "Book 2", Price = 345.45m, OriginalPrice = 145.6m, CategoryId = 1,
                    Stock = 345
                },
                new Book()
                {
                    Id = 3, AuthorId = 3, Name = "Book 3", Price = 674.45m, OriginalPrice = 145.6m, CategoryId = 2,
                    Stock = 145
                },
                new Book()
                {
                    Id = 4, AuthorId = 1, Name = "Book 4", Price = 156.45m, OriginalPrice = 89.6m, CategoryId = 3,
                    Stock = 789
                },
                new Book()
                {
                    Id = 5, AuthorId = 2, Name = "Book 5", Price = 256.45m, OriginalPrice = 145.6m, CategoryId = 1,
                    Stock = 267
                }
            };

            return books;
        }
        public static List<OrderViewModel> OrderViewModels()
        {
            var orderViewModels = new List<OrderViewModel>()
            {
                new OrderViewModel()
                {CustomerName = "Customer 1",
                    CustomerPhoneNumber = "09883432", CustomerEmail = "Customer1@gmail.com", OrderId = 2,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            Book =  new Book()
                            {
                                Id = 1, AuthorId = 1, Name = "Book 1", Price = 456.45m, OriginalPrice = 145.6m, CategoryId = 2,
                                Stock = 450
                            },
                            BookId = 1,
                            Price = 456.45m,
                            Quantity = 345
                        }
                    }
                },
                new OrderViewModel()
                {
                    CustomerName = "Customer 2",
                    CustomerPhoneNumber = "097932132", CustomerEmail = "Customer2@gmail.com",  OrderId = 3,
                    OrderDetails = new List<OrderDetail>() {
                        new OrderDetail()
                        {
                            Book =   new Book()
                            {
                                Id = 4, AuthorId = 1, Name = "Book 4", Price = 156.45m, OriginalPrice = 89.6m, CategoryId = 3,
                                Stock = 789
                            },
                            BookId = 4,
                            Price = 145.67m,
                            Quantity = 627
                        }
                    }
                }
            };

            return orderViewModels;
        }
    }
}
