using System;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Controllers
{

    public class AuthorController: Controller
    {
        public IActionResult Index()
        {
            //return Content("The Writer ");
            return View();
        }

        public IActionResult Featured()
        {
            //return Content("The Best Writer");
            // return View();

            // we would normally get this from a database
            var featuredAuthor = new Author()
                {
                    AuthorId = 1,
                    Name = "J.K. Rowling" //or pick your favorite
                    
                };
                    return View(featuredAuthor);
        }
        
            

    }

}