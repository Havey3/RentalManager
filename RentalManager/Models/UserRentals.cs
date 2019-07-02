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
        [DataType(DataType.Date)]
        [Display (Name ="Start Date")]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
    }
}
