using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EpitmenyadoWebApp.Models;

namespace EpitmenyadoWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

        public EditModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
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

            var telkek =  await _context.Telkeks.FirstOrDefaultAsync(m => m.Id == id);
            if (telkek == null)
            {
                return NotFound();
            }
            Telkek = telkek;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Telkek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelkekExists(Telkek.Id))
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

        private bool TelkekExists(int id)
        {
            return _context.Telkeks.Any(e => e.Id == id);
        }
    }
}
