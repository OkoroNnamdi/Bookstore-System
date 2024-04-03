using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using BookStore.core.IBookstoreRepository;
using Bookstore.Data.DTOS;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository bookRepository, IOrderRepository orderRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(BookDTO book)
        {
            try
            {
                var result = await _bookRepository.AddBookAsync(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding book");
                return StatusCode(500, "An error occurred while adding the book.");
            }
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks(List<BookDTO> books)
        {
            try
            {
                var result = await _bookRepository.AddBooksAsync(books);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding books");
                return StatusCode(500, "An error occurred while adding the books.");
            }
        }

        [HttpPost("DeleteBooks")]
        public async Task<IActionResult> DeleteBooks(List<int> bookIds)
        {
            try
            {
                var result = await _bookRepository.DeleteBooksAsync(bookIds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting books");
                return StatusCode(500, "An error occurred while deleting the books.");
            }
        }
 
    }
}

