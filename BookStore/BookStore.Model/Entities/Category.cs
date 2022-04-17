﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Entities
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }


    }
}