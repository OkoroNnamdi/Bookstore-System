using AutoMapper;
using Bookstore.Data.DTOS;
using Bookstore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.core.Utility
{
    public class MapInitializer: Profile
    {
        public Mapper? regMapper { get; set; }
        public MapInitializer()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<AuthorDTO, Author>();
        }
    }
}
