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
    
    public partial class BRANCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BRANCH()
        {
            this.INVENTORies = new HashSet<INVENTORY>();
        }
    
        public int BRANCH_NUM { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_LOCATION { get; set; }
        public Nullable<int> NUM_EMPLOYEES { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }
    }
}
