using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRazor.Data;
using WebRazor.Models;

namespace WebRazor.Pages.Human
{
    public class CreateModel : PageModel
    {
        private readonly WebRazor.Data.ApplicationDbContext _context;

        public CreateModel(WebRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HumanModel HumanModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HumanModel.Add(HumanModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}