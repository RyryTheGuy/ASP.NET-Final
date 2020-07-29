using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Foolproof;

namespace ASP.NET_Final_Project.Models
{
    public class ManagementFilter
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, MinimumLength = 3)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, MinimumLength = 3)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        public string email { get; set; }

        [EmailAddress]
        [System.ComponentModel.DataAnnotations.Compare(nameof(email), ErrorMessage = "Emails do not match.")]
        public string confirmEmail { get; set; }

        public string branch { get; set; }
        public IEnumerable<SelectListItem> AllBranches { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.MultilineText)]
        public string comments { get; set; }
    }
}