//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Cart
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        [Display(Name = "Date Purchased")]
        public Nullable<System.DateTime> DatePurchased { get; set; }

        [Display(Name = "Is in Cart")]
        public bool IsInCart { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Users Users { get; set; }
    }
}
