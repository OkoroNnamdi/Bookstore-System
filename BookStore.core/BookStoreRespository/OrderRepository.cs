using AspNetCoreHero.Results;
using AutoMapper;
using Bookstore.Data;
using Bookstore.Data.DTOS;
using Bookstore.Data.Model;
using BookStore.core.IBookstoreRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.core.BookStoreRespository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderRepository(BookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public async Task<Result<decimal>> GetRevenueAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var revenue = await _dbContext.OrderDetails
                    .Where(od => od.Order.OrderDate >= startDate && od.Order.OrderDate <= endDate)
                    .SumAsync(od => od.Quantity * od.UnitPrice);
                return new Result<decimal>
                {
                    Data=revenue,
                    Message=$"The revenue generate starting from{startDate} to{endDate} is {revenue}",
                    Succeeded=true
                };
            }
            catch (Exception ex)
            {
                return Result<decimal>.Fail(ex.Message);
            }
        }

        public async Task<Result<string>> PlaceOrderAsync(OrderDetailDTO orderDetail)
        {
            try
            {
                var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == orderDetail.BookId);
                if (book == null)
                    return Result<string>.Fail("Book not found");

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    BookId = book.Id,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = book.Price
                }
            }
                };

                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                

                return Result<string>.Success("Order sucessfully placed");
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(ex.Message);
            }
        }

    }
}
