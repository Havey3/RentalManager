using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class UserRentals
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int rentalId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
