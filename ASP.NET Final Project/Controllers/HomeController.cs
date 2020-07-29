using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Final_Project.Models;

namespace ASP.NET_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private HENRYEntities db = new HENRYEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            // Grab all the books from the database
            var bookList = db.BOOKs.ToList();
            
            return View(bookList);
        }

        public ActionResult BookDetails(string id)
        {
            BookDetails model = new BookDetails();
            BOOK book = db.BOOKs.Find(id);

            if (book != null)
            {
                // Fill the model
                model.bookCode = book.BOOK_CODE;
                model.bookTitle = book.TITLE;
                model.bookPrice = (decimal)book.PRICE;

                // Display Paperback (0 or 1) in a legible fashion (T or F)
                model.bookPaperback = (book.PAPERBACK == "1") ? "Yes" : "No";

                model.bookType = book.TYPE;
                model.bookPublisherCode = book.PUBLISHER_CODE;

                // Grab the Publisher for the book
                var publisherList = db.PUBLISHERs.ToList();
                foreach (var publisher in publisherList)
                {
                    if (publisher.PUBLISHER_CODE == model.bookPublisherCode)
                    {
                        model.bookPublisher = publisher.PUBLISHER_NAME;
                    }
                }

                // Grab the Author's name and code
                var wroteList = db.WROTEs.ToList();
                foreach (var wrote in wroteList)
                {
                    if (wrote.BOOK_CODE == model.bookCode)
                    {
                        // Store the author number in the model
                        model.bookAuthorCode = wrote.AUTHOR_NUM;

                        // Find the author and save their name
                        AUTHOR a = db.AUTHORs.Find(model.bookAuthorCode);
                        model.bookAuthorName = a.AUTHOR_FIRST + " " + a.AUTHOR_LAST;
                    }
                }

                // Grab the Branches that have the book and how many they have
                var inventory = db.INVENTORies.ToList();
                List<BRANCH> b = new List<BRANCH>();
                List<int> onHand = new List<int>();

                foreach (var branch in inventory)
                {
                    if (branch.BOOK_CODE == model.bookCode)
                    {
                        b.Add(branch.BRANCH);
                        onHand.Add((int)branch.ON_HAND);
                    }
                }
                // Convert to array so we can iterate through them later
                model.branches = b.ToArray();
                model.onHand = onHand.ToArray();

                return View(model);
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Management()
        {
            ManagementFilter model = new ManagementFilter();
            model.AllBranches = db.BRANCHes.ToList().Select(b => new SelectListItem
            {
                Text = b.BRANCH_NAME,
                Value = b.BRANCH_NUM.ToString()
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult Management(ManagementFilter model)
        {
            if (ModelState.IsValid)
            {
                if (model.email == model.confirmEmail)
                {
                    return Json(model);
                }
            }

            return RedirectToAction("Management", "Home");
        }
    }
}