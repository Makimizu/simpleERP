//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace simpleERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class poH
    {
        public int poId { get; set; }
        public Nullable<System.DateTime> podate { get; set; }
        public string companyId { get; set; }
        public string note { get; set; }
        public Nullable<decimal> totalTax { get; set; }
        public Nullable<decimal> totalDisc { get; set; }
        public Nullable<decimal> total { get; set; }
    }
}
