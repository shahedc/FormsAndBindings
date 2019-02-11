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
    public class DetailsModel : PageModel
    {
        private readonly WebRazor.Data.ApplicationDbContext _context;

        public DetailsModel(WebRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
