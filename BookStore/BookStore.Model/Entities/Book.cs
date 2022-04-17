using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Entities
{
    [Table("Books")]
    public class Book
    {
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Inputs = new HashSet<Input>();
            OutPuts = new HashSet<OutPut>();
        }

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

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int AuthorId { set; get; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { set; get; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Input> Inputs { get; set; }
        public ICollection<OutPut> OutPuts { get; set; }


    }
}