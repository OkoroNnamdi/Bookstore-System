using AspNetCoreHero.Results;
using Bookstore.Data.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.core.IBookstoreRepository
{
   public  interface IOrderRepository
    {
        Task<Result<string>> PlaceOrderAsync(OrderDetailDTO orderDetail);
        Task<Result<decimal>> GetRevenueAsync(DateTime startDate, DateTime endDate);
        //Task PlaceOrderAsync(OrderDetailDTO orderDetail);
        //Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate);
    }
}
