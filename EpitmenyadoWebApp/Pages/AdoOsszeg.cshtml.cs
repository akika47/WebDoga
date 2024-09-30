using EpitmenyadoWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class AdoOsszegModel : PageModel
{
    private readonly EpitmenyadoWebApp.Models.EpitmenyDbContext _context;

    public AdoOsszegModel(EpitmenyadoWebApp.Models.EpitmenyDbContext context)
    {
        _context = context;
    }

    public IList<Telkek> Telkek { get; set; } = default!;
    public Dictionary<int, int> TotalTaxes { get; set; } = new Dictionary<int, int>();

    public async Task OnGetAsync()
    {
        Telkek = await _context.Telkeks.ToListAsync();
        var adoszamok = Telkek.GroupBy(x => x.AdoSzam).ToArray();
        foreach (var item in adoszamok)
        {
            int savAdo = 0;
            var sav = Telkek.Where(x => x.AdoSzam == item.Key).Select(x => x.Sav);
            if (sav.All(x => x == 'A'))
            {
                savAdo = 800;
            }
            else if (sav.All(x => x == 'B'))
            {
                savAdo = 600;
            }
            else if (sav.All(x => x == 'C'))
            {
                savAdo = 100;
            }
            int adoOsszeg = Convert.ToInt32(Telkek.Where(x => x.AdoSzam == item.Key).Sum(x => x.AlapTerulet)) * savAdo;
            if (adoOsszeg < 10000)
            {
                adoOsszeg = 0;
            }
            TotalTaxes.Add(item.Key, adoOsszeg);
        }
    }
}