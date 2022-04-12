using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        public decimal OriginalPrice { set; get; }
        [Required]
        public int Stock { set; get; }
        [Required]
        public decimal Price { set; get; }

      
        public int AuthorId { set; get; }
        public Author Author { set; get; }

       
    }
}
