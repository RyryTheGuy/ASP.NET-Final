using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Final_Project.Models
{
    public class BrowseByPublisher
    {
        // The publisher selected via the select element on the publisher page
        public string PublisherSelected { get; set; }
        // All the publishers for the select element
        public IEnumerable<SelectListItem> AllPublishers { get; set; }
        // List of books by the specified publisher chosen via the select element
        public List<BOOK> BooksByPublisher { get; set; }
    }
}