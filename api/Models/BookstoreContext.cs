using Microsoft.EntityFrameworkCore;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Models
{

    public class BookstoreContext : DbContext
        {

            public BookstoreContext(DbContextOptions<BookstoreContext> options)
                : base(options)
                {
                }

            public DbSet<Book> Book{get; set;}

        }





}