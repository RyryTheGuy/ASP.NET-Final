using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Final_Project.Models
{
    public class BrowseByLocation
    {
        // The location selected via the select element on the location page
        public string LocationSelected { get; set; }
        // The selected location's information
        public BRANCH LocationInfo { get; set; }
        // All the locations for the select element
        public IEnumerable<SelectListItem> AllLocations { get; set; }
        // Array of books at the specified location chosen via the select element
        public BOOK[] Books { get; set; }
        // Array of books on hand at the specific location
        public int[] BooksOnHand { get; set; }
    }
}