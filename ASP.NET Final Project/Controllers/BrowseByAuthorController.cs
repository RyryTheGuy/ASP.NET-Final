using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Final_Project.Models;

namespace ASP.NET_Final_Project.Controllers
{
    public class BrowseByAuthorController : Controller
    {
        // Database Connection
        private HENRYEntities db = new HENRYEntities();

        // GET: By default
        public ActionResult Author(int id = -1)
        {
            BrowseByAuthor model = new BrowseByAuthor();         

            // Fill the model with authors
            model.AllAuthors = db.AUTHORs.ToList().Select(c => new SelectListItem
            {
                Text = c.AUTHOR_FIRST + " " + c.AUTHOR_LAST,
                Value = c.AUTHOR_NUM.ToString()
            });

            // An author was selected 
            if (id > 0)
            {
                // Grab the books the author wrote
                var wrotes = db.WROTEs.ToList();
                List<string> bookCodesWrittenByAuthor = new List<string>();
                model.BooksByAuthor = new List<BOOK>();
                // Loop through the WROTE table to pull out the book codes by author code
                foreach (var wrote in wrotes)
                {
                    if (wrote.AUTHOR_NUM.ToString() == id.ToString())
                    {
                        bookCodesWrittenByAuthor.Add(wrote.BOOK_CODE);
                    }
                }
                // Using the books codes, grab the books from the book table by book code 
                foreach (string code in bookCodesWrittenByAuthor)
                {
                    model.BooksByAuthor.Add(db.BOOKs.Find(code));
                }

                return View(model);
            }
            // Default the Books by author list to 0 so no table displays if no author is picked
            model.BooksByAuthor = new List<BOOK>(0);

            return View(model);
        }

        // POST: When the dropdown is changed to a specific author
        [HttpPost]
        public ActionResult Author(BrowseByAuthor model)
        {
            if (model != null)
            {
                // Fill the model with all the authors
                model.AllAuthors = db.AUTHORs.ToList().Select(c => new SelectListItem
                {
                    Text = c.AUTHOR_FIRST + " " + c.AUTHOR_LAST,
                    Value = c.AUTHOR_NUM.ToString()
                });

                // Grab the books the author wrote
                var wrotes = db.WROTEs.ToList();
                List<string> bookCodesWrittenByAuthor = new List<string>();
                model.BooksByAuthor = new List<BOOK>();
                // Loop through the WROTE table to pull out the book codes by author code
                foreach (var wrote in wrotes)
                {
                    if (wrote.AUTHOR_NUM.ToString() == model.AuthorSelected)
                    {
                        bookCodesWrittenByAuthor.Add(wrote.BOOK_CODE);
                    }
                }
                // Using the books codes, grab the books from the book table by book code 
                foreach (string code in bookCodesWrittenByAuthor)
                {
                    model.BooksByAuthor.Add(db.BOOKs.Find(code));
                }

                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}