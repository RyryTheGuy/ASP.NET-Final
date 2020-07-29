using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Final_Project.Models;

namespace ASP.NET_Final_Project.Controllers
{
    public class BrowseByPublisherController : Controller
    {
        // Database Connection
        private HENRYEntities db = new HENRYEntities();

        // GET: By default
        public ActionResult Publisher(string id = "")
        {
            BrowseByPublisher model = new BrowseByPublisher();         

            // Fill the model with publishers
            model.AllPublishers = db.PUBLISHERs.ToList().Select(c => new SelectListItem
            {
                Text = c.PUBLISHER_NAME,
                Value = c.PUBLISHER_CODE
            });

            // A Publisher was selected 
            if (!String.IsNullOrEmpty(id))
            {
                // Grab all the books from the database that have the same publisher code as the publisher selected
                var allBooks = from b in db.BOOKs where b.PUBLISHER_CODE == id select b;
                // Fill the model's list of books by the publisher
                model.BooksByPublisher = allBooks.ToList();

                return View(model);
            }
            // Default the Books by author list to 0 so no table displays if no author is picked
            model.BooksByPublisher = new List<BOOK>(0);

            return View(model);
        }

        // POST: When the dropdown is changed to a specific author
        [HttpPost]
        public ActionResult Publisher(BrowseByPublisher model)
        {
            if (model != null)
            {
                // Fill the model with publishers
                model.AllPublishers = db.PUBLISHERs.ToList().Select(c => new SelectListItem
                {
                    Text = c.PUBLISHER_NAME,
                    Value = c.PUBLISHER_CODE
                });

                // Grab all the books from the database that have the same publisher code as the publisher selected
                var allBooks = from b in db.BOOKs where b.PUBLISHER_CODE == model.PublisherSelected select b;
                // Fill the model's list of books by the publisher
                model.BooksByPublisher = allBooks.ToList();

                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}