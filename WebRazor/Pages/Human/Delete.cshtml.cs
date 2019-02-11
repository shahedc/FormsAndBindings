using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazor.Data;
using WebRazor.Models;

namespace WebRazor.Pages.Human
{
    public class DeleteModel : PageModel
    {
        private readonly WebRazor.Data.ApplicationDbContext _context;

        public DeleteModel(WebRazor.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HumanModel = await _context.HumanModel.FindAsync(id);

            if (HumanModel != null)
            {
                _context.HumanModel.Remove(HumanModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
