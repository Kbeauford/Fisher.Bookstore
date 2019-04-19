using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db) => this.db = db;

        [HttpGet()]
        public IActionResult GetBooks()
        {
            // Use ASP.NET framework for proper status codes
            // the Ok method returns the model inside the HTTP 200 OK response
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            // try to find the correct book 
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            // if no book is found with the id key, return HTTP 404 Not Found
            if (book == null)
            {
                return NotFound();
            }

            // return the Book inside HTTP 200 OK
            return Ok(book);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            var bookToEdit = db.Books.FirstOrDefault(b => b.Id == id);
            if (bookToEdit == null)
            {
                return NotFound();
            }

            bookToEdit.Title = book.Title;
            bookToEdit.ISBN = book.ISBN;

            db.Books.Update(bookToEdit);
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();
            return NoContent();
        }
    }
}