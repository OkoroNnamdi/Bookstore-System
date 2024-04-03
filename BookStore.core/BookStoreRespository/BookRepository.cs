using AspNetCoreHero.Results;
using AutoMapper;
using Bookstore.Data;
using Bookstore.Data.DTOS;
using Bookstore.Data.Model;
using BookStore.core.IBookstoreRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.core.BookStoreRespository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookRepository(BookstoreDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Result<string>> AddBookAsync(BookDTO book)
        {
            try
            {
                var newBook = _mapper.Map<Book>(book);
                  _dbContext.Books.AddAsync(newBook);
                await _dbContext.SaveChangesAsync();
                return Result<string>.Success("Book added Sucessful");
            }
            catch (Exception ex)
            {
                return Result<string >.Fail(ex.Message);
            }
        }

        public async Task<Result<string>> AddBooksAsync(List<BookDTO> books)
        {
            try
            {
                var newBooks = _mapper.Map<List<Book>>(books);
                _dbContext.Books.AddRange(newBooks);
                await _dbContext.SaveChangesAsync();
                return Result<string>.Success("Books added Sucessful");
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(ex.Message);
            }
        }

        public async Task<Result<string>> DeleteBooksAsync(List<int> bookIds)
        {
            try
            {
                var booksToDelete = await _dbContext.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();
                _dbContext.Books.RemoveRange(booksToDelete);
                await _dbContext.SaveChangesAsync();
                return Result<string>.Success();
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(ex.Message);
            }
        }
    }
}
