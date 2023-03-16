using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentDemo.Data;
using RazorRentDemo.Model;
using System;

namespace RazorRentDemo.Pages.Rent
{
    public class ReturnProcModel : PageModel
    {
        public Reservation? Reservation { get; set; }

        private readonly RentDbContext _context;

        public ReturnProcModel(RentDbContext context)
        {
            _context = context;
        }

        // reservation id !!! primary key
        public IActionResult OnGet(int id)
        {
            Reservation = _context
                .Reservations
                .Include(c => c.Car)
                .FirstOrDefault(d => d.Id == id);

            if (Reservation is not null)
            {
                Reservation.End = DateTime.Now;
                Reservation.TotalPrice = CalculatePrice(Reservation);
                return Page();
            }

            return NotFound();
        }

        // asp-page-handler
        public IActionResult OnGetReturnOK(int id)
        {
            var res = _context.Reservations.Include(c => c.Car).FirstOrDefault(d => d.Id == id);

            if (res is not null)
            {
                res.End = DateTime.Now;
                res.TotalPrice = CalculatePrice(res);
                res.Car.Avaliable = true;

                _context.Reservations.Update(res);
                _context.SaveChanges();

                return RedirectToPage("index");
            }

            return NotFound();
        }
        public IActionResult Test()
        {
            ViewData["TESTDATAKEY"] = "TESTDATA";
            return Page();
        }
        private int CalculatePrice(Reservation r)
        {
            var duration = r.End - r.Start;
            var p = (int)duration.TotalMinutes * r.Car.UnitPrice;

            return p;
        }
    }
}
