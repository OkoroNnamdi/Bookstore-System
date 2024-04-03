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
    public interface IBookRepository
    {
        Task<Result<string>> AddBookAsync(BookDTO book);
        Task<Result<string>> AddBooksAsync(List<BookDTO> books);
        Task<Result<string>> DeleteBooksAsync(List<int> bookIds);

        //Task AddBookAsync(BookDTO book);
        //Task AddBooksAsync(List<BookDTO> books);
        //Task DeleteBooksAsync(List<int> bookIds);
    }
}
