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
    public class AdoOsszegModel : PageModel
    {
        private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

        public AdoOsszegModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
        {
            _context = context;
        }

        public IList<Telkek> Telkek { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Telkek = await _context.Telkeks.ToListAsync();
            var adoszamok = Telkek.GroupBy(x => x.AdoSzam).ToArray();
            int savAdo = 0;
            foreach (var item in adoszamok)
            {
                var sav = Telkek.Where(x => x.AdoSzam == item.Key).Select(x => x.Sav);
                if (Convert.ToChar(sav) == 'A')
                {
                    savAdo = 800;
                }
                else if (Convert.ToChar(sav) == 'B')
                {
                    savAdo = 600;
                }
                else if (Convert.ToChar(sav) == 'C')
                {
                    savAdo = 100;
                }
                int adoOsszeg = Convert.ToInt32(Telkek.Where(x => x.AdoSzam == item.Key).Select(x => x.AlapTerulet)) + savAdo ;
            }
        }


    }
}
