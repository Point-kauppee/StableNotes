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
    
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Streetname { get; set; }
        public string Postnumber { get; set; }
        public string Community { get; set; }
        public Nullable<int> PersonId { get; set; }
        public string StableId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Stable Stable { get; set; }
    }
}