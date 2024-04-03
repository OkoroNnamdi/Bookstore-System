using BookStore.core.BookStoreRespository;
using BookStore.core.IBookstoreRepository;

namespace BookStore.Api.Extension
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

        }
    }
}
