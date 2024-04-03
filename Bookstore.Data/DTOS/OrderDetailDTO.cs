using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data.DTOS
{
   public  class OrderDetailDTO
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
