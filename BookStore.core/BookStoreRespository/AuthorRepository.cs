using AspNetCoreHero.Results;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public AuthorRepository(BookstoreDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<Author>> AddAuthorAsync(AuthorDTO author)
        {
            try
            {
                var newAuthor = _mapper.Map<Author>(author);
                await _dbContext.Authors.AddAsync(newAuthor);
                await _dbContext.SaveChangesAsync();
                return new Result<Author>
                { 
                    Data=newAuthor,
                    Message ="Author sucessfully added",
                    Succeeded =true
                   
                };
            }
            catch (Exception ex)
            {
                return Result<Author>.Fail(ex.Message);
            }
        }

        public async Task<Result<List<Author>>> GetTopSellingAuthorsAsync()
        {
            try
            {
                var authorsWithOrderDetails = await _dbContext.Authors
                    .Select(a => new
                    {
                        Author = a,
                        TotalQuantitySold = a.Books
                            .SelectMany(b => b.OrderDetails)
                            .Sum(od => od.Quantity)
                    })
                    .OrderByDescending(author => author.TotalQuantitySold)
                    .Take(10)
                    .ToListAsync();

                // Extract authors from the anonymous type and return
                var topAuthors = authorsWithOrderDetails.Select(item => item.Author).ToList();


                return new Result<List<Author>>
                {
                    Data = topAuthors,
                    Message = "Succeeded",
                    Succeeded = true
                };
            }
            catch (Exception ex)
            {
                return Result<List<Author>>.Fail(ex.Message);
            }
        }

    }
}
