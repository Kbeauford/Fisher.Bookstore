using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{

    [Route("api/book")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db= db;
            if (this.db.Book.Count() == 0)
            {
                this.db.Book.Add(new Book()
                {
                    Id = 1,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "978-0201633610"
                });
                this.db.Book.Add(new Book()
                {
                    Id = 2,
                    Title = "Continuous Delivery",
                    Author = "Jez Humble",
                    ISBN = "978-0321601919"
                });
                this.db.Book.Add(new Book()
                {
                    Id = 3,
                    Title = "The DevOps Handbook",
                    Author = "Gene Kim",
                    ISBN = "978-1942788003"
                });
            }
            this.db.SaveChanges();
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Book);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = db.Book.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


    }



}