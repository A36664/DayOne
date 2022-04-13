using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Entities
{
    [Table("BookInCategories")]
    public class BookInCategory
    {
        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Column(Order = 2)]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }


    }
}
