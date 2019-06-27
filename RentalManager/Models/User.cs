using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        public bool isArchived { get; set; }
        public string ApplicationUserId { get; set; }
        public UserRentals UserRentals { get; set; }
    }
}
