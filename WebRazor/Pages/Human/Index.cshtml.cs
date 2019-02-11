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
    public class IndexModel : PageModel
    {
        private readonly WebRazor.Data.ApplicationDbContext _context;

        public IndexModel(WebRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HumanModel> HumanModel { get;set; }

        public async Task OnGetAsync()
        {
            HumanModel = await _context.HumanModel.ToListAsync();
        }
    }
}
