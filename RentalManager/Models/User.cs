using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class User
    {

        public int Id { get; set; }
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
