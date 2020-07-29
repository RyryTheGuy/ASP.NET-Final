using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Final_Project.Models
{
    public class BrowseByAuthor
    {
        // The author selected via the select element on the author page
        public string AuthorSelected { get; set; }
        // All the authors for the select element
        public IEnumerable<SelectListItem> AllAuthors { get; set; }
        // List of books by the specified author chosen via the select element
        public List<BOOK> BooksByAuthor { get; set; }
    }
}