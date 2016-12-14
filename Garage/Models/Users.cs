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
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Users
    {
        public Users()
        {
            this.Cart = new HashSet<Cart>();
        }


        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("^[^<>.!@#%/]+$", ErrorMessage = "Can not use  < > . ! @ # % / ? *")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must be between 5 and 30 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[^<>.!@#%/]+$", ErrorMessage = "Can not use  < > . ! @ # % / ? *")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must be between 5 and 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[^<>!#%/]+$", ErrorMessage = "Can not use  < >  !  # % / ? *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("^[^<>/]+$", ErrorMessage = "Can not use  < > / ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Must be between 5 and 30 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public Nullable<bool> isAdmin { get; set; }
    
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
