//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StableNotes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Care
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Care()
        {
            this.Action = new HashSet<Action>();
        }
    
        public int CareId { get; set; }
        public string Type { get; set; }
        public string Quantity { get; set; }
        public string Note { get; set; }
        public Nullable<int> PersonId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Action { get; set; }
        public virtual Person Person { get; set; }
    }
}
