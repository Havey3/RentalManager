using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RentalManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Rentals> Rentals { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<UserRentals> UserRentals { get; set; }
    }
}
