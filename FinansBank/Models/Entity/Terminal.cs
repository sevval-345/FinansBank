//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinansBank.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Terminal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terminal()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public decimal TerminalID { get; set; }
        public Nullable<decimal> MerchantID { get; set; }
        public string TerminalName { get; set; }
        public string TerminalTypes { get; set; }
        public string SeriouslyNo { get; set; }
        public string Situation { get; set; }
    
        public virtual Merchant Merchant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
