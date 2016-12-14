using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models
{
    public class UserSignIn
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("^[^<>/]+$", ErrorMessage = "Can not use  < > / ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Must be between 5 and 30 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}