using Bookstore.Data.DTOS;
using BookStore.core.IBookstoreRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Controllers;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<BookController> _logger;
        public AuthorController( IAuthorRepository authorRepository, ILogger<BookController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AuthorDTO author)
        {
            try
            {
                var result = await _authorRepository.AddAuthorAsync(author);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding author");
                return StatusCode(500, "An error occurred while adding the author.");
            }
        }
        [HttpGet("TopSellingAuthors")]
        public async Task<IActionResult> GetTopSellingAuthors()
        {
            try
            {
                var result = await _authorRepository.GetTopSellingAuthorsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top selling authors");
                return StatusCode(500, "An error occurred while getting the top selling authors.");
            }
        }
    }
}
