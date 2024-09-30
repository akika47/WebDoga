using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpitmenyadoWebApp.Models;

namespace EpitmenyadoWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

        public CreateModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Telkek Telkek { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Telkeks.Add(Telkek);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
