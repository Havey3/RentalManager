using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalManager.Data;
using RentalManager.Models;
using RentalManager.Models.ViewModel;

namespace RentalManager.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public RentalsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Rentals
        public async Task<IActionResult> Index(string searchQuery, string filterQuery, int? id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            List<Rentals> rentals = await _context.Rentals
                //Getting the users attatched to the admin
                .Where(r => r.ApplicationUserId == user.Id)
                //Displaying the users who are not archived
                .Where(r => r.isArchived == false)
                //|| u.isArchived == false
                .Include(r => r.UserRentals)
                .ToListAsync();

            var attempt = _context.Rentals.Include(r => r.UserRentals).Where(r => r.ApplicationUserId == user.Id).Where(r => r.isArchived == false);

            //Checking to see if the admin is using the search bar
            if (searchQuery != null)
            {
                //checking to see if searchQuery = user.Firstname and or LastName
                rentals = rentals.Where(r => r.Name.Contains(searchQuery) || r.Location.Contains(searchQuery)).ToList();
            }
            //Shows available rentals
            if (filterQuery == "1")
            {
                rentals = attempt.Where(r => r.UserRentals.All(ur => ur.endDate <= DateTime.Now) || r.UserRentals.Count == 0).ToList();
            }
            //Shows rented out rentals
            else if (filterQuery == "2")
            {
                rentals = attempt.Where(r => r.UserRentals.Any(ur => ur.endDate > DateTime.Now) && r.UserRentals.Count > 0).ToList();
            }
            return View(rentals);
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rentals = await _context.Rentals
                .Include(r => r.UserRentals)
                    .ThenInclude(ur => ur.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await GetCurrentUserAsync();
                rentals.ApplicationUserId = appUser.Id;
                _context.Add(rentals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals.FindAsync(id);
            if (rentals == null)
            {
                return NotFound();
            }
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Rentals rentals)
        {
            if (id != rentals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalsExists(rentals.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ApplicationUser appUser = await GetCurrentUserAsync();
                rentals.ApplicationUserId = appUser.Id;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentals);
        }



        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        //GET Rentals/Book
        public async Task<IActionResult> Book(int id)
        {

            ApplicationUser appUser = await GetCurrentUserAsync();
            List<User> users = await _context.User.ToListAsync();
            Rentals rentals = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            RentalVM vm = new RentalVM()
            {
                //Get Rentals to display Name, Location for View
                Rentals = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id),
                UserOptions = users.Where(u => u.ApplicationUserId == appUser.Id && u.isArchived == false).Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.FirstName
                })
                .ToList()
            };
            vm.UserOptions.Insert(0, new SelectListItem
            {
                Text = "Choose a User",
                Value = "0"
            });
            
            return View(vm);
        }


        // POST: Rentals/Book/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int id, RentalVM vm)
        {
            //Check to see if Rental.Id == UserRentalId?

            var Users = await _context.Users.ToListAsync();
            //User users = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            string errormessage = "End Date must be before Start Date";

            UserRentals userRentals = new UserRentals()
            {
                rentalId = id,
                userId = vm.userRentals.userId,
                startDate = vm.userRentals.startDate.Date,
                endDate = vm.userRentals.endDate.Date
            };
            if (userRentals.startDate.Date < userRentals.endDate.Date && userRentals.startDate.Date > DateTime.Now){
                _context.Add(userRentals);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else{
                return NotFound(errormessage);
            }

            //return RedirectToAction(nameof(Index));
        }
  




        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentals = await _context.Rentals.FindAsync(id);
            rentals.isArchived = true;
            _context.Rentals.Update(rentals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalsExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }
    }


}
