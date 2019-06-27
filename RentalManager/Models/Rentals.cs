using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location Required")]
        public string Location { get; set; }
        public bool isArchived { get; set; }
        public string ApplicationUserId { get; set; }
        public UserRentals UserRentals { get; set; }
    }
}
