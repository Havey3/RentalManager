using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManager.Models.ViewModel.Report;

namespace RentalManager.Models.ViewModel
{
    public class Stats
    {
        public List<PopularRentals> topRentals { get; set; } = new List<PopularRentals>();
        public List<PopularDate> topDates { get; set; } = new List<PopularDate>();

    }
}
