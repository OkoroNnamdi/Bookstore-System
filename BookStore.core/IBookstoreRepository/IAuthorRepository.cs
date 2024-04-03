using AspNetCoreHero.Results;
using Bookstore.Data.DTOS;
using Bookstore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.core.IBookstoreRepository
{
   public interface IAuthorRepository
    {
        Task<Result<List<Author>>> GetTopSellingAuthorsAsync();
        Task<Result<Author>> AddAuthorAsync(AuthorDTO author);
        //Task<List<AuthorDTO>> GetTopSellingAuthorsAsync();
    }
}
