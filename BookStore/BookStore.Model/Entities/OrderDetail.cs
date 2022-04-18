using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


    }
}