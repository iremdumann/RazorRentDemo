using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorRentDemo.Data;
using RazorRentDemo.Model;

namespace RazorRentDemo.Pages.Garage
{

    public enum CarState
    {
        [Display(Name = "Avaliable for Rent")]

        Avaliable,
        NotAvaliable,
        Rent
    }
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CarState CStateEnum { get; set; }
        [BindProperty]
        public string CStateListSelection { get; set; }
        [BindProperty]
        public string TestText { get; set; }


        public List<SelectListItem> CarStateList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MX", Text = "Avaliable" },
            new SelectListItem { Value = "CA", Text = "NotAvaliable" },
            new SelectListItem { Value = "US", Text = "Rented"  },
        };
        private readonly RazorRentDemo.Data.RentDbContext _context;

        public CreateModel(RazorRentDemo.Data.RentDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();
            TempData["success"] = "Added Successfully";
            return RedirectToPage("./Index");
        }
    }
}
