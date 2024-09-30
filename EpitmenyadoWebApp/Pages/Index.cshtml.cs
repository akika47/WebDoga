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
    public class IndexModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

        public IndexModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
        {
            _context = context;
        }

        public IList<Telkek> Telkek { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Telkek = await _context.Telkeks.ToListAsync();
        }
    }
}
