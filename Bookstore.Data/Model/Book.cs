using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bookstore.Data.Model
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column ("TITLE")]
        public string? Title { get; set; }
        [Required]
        [StringLength(50)]
        [Column("AUTHOR")]
        public string? Author { get; set; }
        [Required]
        [Column("PRICE")]
        public decimal Price { get; set; }
        // Navigation property for order details
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
