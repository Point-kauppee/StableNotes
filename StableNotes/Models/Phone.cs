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
    
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string Number_1 { get; set; }
        public string Number_2 { get; set; }
        public Nullable<int> PersonId { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
