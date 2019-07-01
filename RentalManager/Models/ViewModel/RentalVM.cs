using Microsoft.AspNetCore.Mvc.Rendering;
using RentalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models.ViewModel
{
    public class RentalVM
    {
        public Rentals Rentals { get; set; }
        public UserRentals userRentals { get; set; }
        public List<SelectListItem> UserOptions { get; set; }
    }
}
