﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.ViewModels
{
    public class BookViewModel
    {
        public int Id { set; get; }
       
        public string Name { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public decimal Price { set; get; }
        public string AuthorName { set; get; }
        public int AtuhorId { set; get; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

    }
}