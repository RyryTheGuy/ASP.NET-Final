//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET_Final_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WROTE
    {
        public string BOOK_CODE { get; set; }
        public int AUTHOR_NUM { get; set; }
        public Nullable<int> SEQUENCE { get; set; }
    
        public virtual AUTHOR AUTHOR { get; set; }
        public virtual BOOK BOOK { get; set; }
    }
}