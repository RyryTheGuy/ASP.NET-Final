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
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.INVENTORies = new HashSet<INVENTORY>();
            this.WROTEs = new HashSet<WROTE>();
        }
    
        public string BOOK_CODE { get; set; }
        public string TITLE { get; set; }
        public string PUBLISHER_CODE { get; set; }
        public string TYPE { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public string PAPERBACK { get; set; }
    
        public virtual PUBLISHER PUBLISHER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WROTE> WROTEs { get; set; }
    }
}
