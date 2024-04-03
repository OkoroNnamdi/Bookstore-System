using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data.DTOS
{
    public class AuthorDTO
    {
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nationality { get; set; }
        [Required]
        [StringLength(11)]
        public string? Mobile { get; set; }
        [Required]
        [StringLength(10)]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string? Email { get; set; }

    }
}

