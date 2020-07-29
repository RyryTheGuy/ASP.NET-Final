using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Final_Project.Models;

namespace ASP.NET_Final_Project.Controllers
{
    public class BrowseByLocationController : Controller
    {
        // Database Connection
        HENRYEntities db = new HENRYEntities();

        // GET: By default
        public ActionResult Location(int id = -1)
        {
            BrowseByLocation model = new BrowseByLocation();
            
            // Fill the model with branches
            model.AllLocations = db.BRANCHes.ToList().Select(b => new SelectListItem
            {
                Text = b.BRANCH_NAME,
                Value = b.BRANCH_NUM.ToString()
            });

            // A location was selected
            if (id > 0)
            {
                // Store the Branches information
                model.LocationInfo = db.BRANCHes.Find(id);

                // Grab all the book codes from the Inventory table
                var inventories = db.INVENTORies.ToList();
                List<string> bookCodesAtBranch = new List<string>();
                List<int> booksOnHandAtBranch = new List<int>();
                List<BOOK> booksAtBranch = new List<BOOK>();

                // Loop through the INVENTORY table to pull out the books codes at the specific branch
                foreach (var i in inventories)
                {
                    if (i.BRANCH_NUM == id)
                    {
                        bookCodesAtBranch.Add(i.BOOK_CODE);
                        booksOnHandAtBranch.Add((int)i.ON_HAND);
                    }
                }
                // Using the book codes, grab the books form the book table by book code
                foreach (string code in bookCodesAtBranch)
                {
                    booksAtBranch.Add(db.BOOKs.Find(code));
                }
                // Convert the lists to arrays so we can iterate through them later
                model.Books = booksAtBranch.ToArray();
                model.BooksOnHand = booksOnHandAtBranch.ToArray();

                return View(model);
            }
            // Default the books at branch array to 0 so no table displays if no location is picked
            model.Books = new BOOK[0];

            return View(model);
        }

        // POST: When the select element is changed to a specific branch
        [HttpPost]
        public ActionResult Location(BrowseByLocation model)
        {
            if (model != null)
            {
                // Store the Branches information
                model.LocationInfo = db.BRANCHes.Find(Int32.Parse(model.LocationSelected));

                // Fill the model with branches
                model.AllLocations = db.BRANCHes.ToList().Select(b => new SelectListItem
                {
                    Text = b.BRANCH_NAME,
                    Value = b.BRANCH_NUM.ToString()
                });

                // Grab all the book codes from the Inventory table
                var inventories = db.INVENTORies.ToList();
                List<string> bookCodesAtBranch = new List<string>();
                List<int> booksOnHandAtBranch = new List<int>();
                List<BOOK> booksAtBranch = new List<BOOK>();

                // Loop through the INVENTORY table to pull out the books codes at the specific branch
                foreach (var i in inventories)
                {
                    if (i.BRANCH_NUM.ToString() == model.LocationSelected)
                    {
                        bookCodesAtBranch.Add(i.BOOK_CODE);
                        booksOnHandAtBranch.Add((int)i.ON_HAND);
                    }
                }
                // Using the book codes, grab the books form the book table by book code
                foreach (string code in bookCodesAtBranch)
                {
                    booksAtBranch.Add(db.BOOKs.Find(code));
                }
                // Convert the lists to arrays so we can iterate through them later
                model.Books = booksAtBranch.ToArray();
                model.BooksOnHand = booksOnHandAtBranch.ToArray();

                return View(model);

            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}