using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpitmenyadoWebApp.Models;

namespace EpitmenyadoWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

        public DeleteModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telkek Telkek { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telkek = await _context.Telkeks.FirstOrDefaultAsync(m => m.Id == id);

            if (telkek == null)
            {
                return NotFound();
            }
            else
            {
                Telkek = telkek;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telkek = await _context.Telkeks.FindAsync(id);
            if (telkek != null)
            {
                Telkek = telkek;
                _context.Telkeks.Remove(Telkek);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
