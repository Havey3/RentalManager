using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models
{
    public class Rentals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool isArchived { get; set; }
    }
}
