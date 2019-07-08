using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class UserRentals
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int rentalId { get; set; }
        public User User { get; set; }
        public Rentals Rental { get; set; }

        [DataType(DataType.Date)]
        [Display (Name ="Start Date")]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
    }

    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //{
    //    if (LocalDelivery && string.IsNullOrEmpty(City))
    //    {
    //        yield return new ValidationResult(
    //            $"You must select a city for delivery."
    //         );
    //    }
    //}
}
