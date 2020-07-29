using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Final_Project.Models
{
    public class BookDetails
    {
        // Book Information displayed
        public string bookCode { get; set; }
        public string bookTitle { get; set; }
        public string bookType { get; set; }
        public decimal bookPrice { get; set; }
        public string bookPaperback { get; set; }
        public string bookPublisher { get; set; }
        public string bookPublisherCode { get; set; }
        public int bookAuthorCode { get; set; }
        public string bookAuthorName { get; set; }

        public BRANCH[] branches { get; set; }
        public int[] onHand { get; set; }
    }
}