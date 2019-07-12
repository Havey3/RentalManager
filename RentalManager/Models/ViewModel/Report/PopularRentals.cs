using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManager.Models.ViewModel.Report
{
    public class PopularRentals
    {
        public Rentals rentalStats { get; set; }
        public int numberOfRents { get; set; }

    }
}
