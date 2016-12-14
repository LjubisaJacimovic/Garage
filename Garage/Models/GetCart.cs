using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models
{
    public class GetCart : Cart
    {
        [Display(Name = "Full Price")]
        public int? FullPrice { get; set; }
    }
}