using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRazor.Data;
using WebRazor.Models;

namespace WebRazor.Pages.Human
{
    public class EditModel : PageModel
    {
        private readonly WebRazor.Data.ApplicationDbContext _context;

        public EditModel(WebRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HumanModel HumanModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HumanModel = await _context.HumanModel.FirstOrDefaultAsync(m => m.Id == id);

            if (HumanModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HumanModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanModelExists(HumanModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HumanModelExists(int id)
        {
            return _context.HumanModel.Any(e => e.Id == id);
        }
    }
}
