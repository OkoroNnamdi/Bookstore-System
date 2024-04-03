using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data.Model
{
    [Table("Author", Schema = "dbo")]
    public  class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("NAME")]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column("NATIONALITY")]
        public string? Nationality { get; set; }
        [Required]
        [StringLength(11)]
        [Column("MOBILE")]
        public string? Mobile { get; set; }
        [Required]
        [StringLength(10)]
        [Column("GENDER")]
        public string? Gender{  get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [Column("EMAIL")]
        public string? Email { get; set; }
        // Navigation property for books
        public ICollection<Book>? Books { get; set; }
    }
}
