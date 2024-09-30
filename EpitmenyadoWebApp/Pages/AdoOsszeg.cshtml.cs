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
        var telkeks = await _context.Telkeks.ToListAsync();
        var personTaxes = new Dictionary<int, int>();
        var persons = telkeks.GroupBy(x => x.AdoSzam).ToArray();

        foreach (var person in persons)
        {
            int totalTax = 0;

            var savGroups = person.GroupBy(x => x.Sav).ToArray();

            foreach (var sav in savGroups)
            {
                int savAdo = 0;
                switch (sav.Key)
                {
                    case 'A':
                        savAdo = 800;
                        break;
                    case 'B':
                        savAdo = 600;
                        break;
                    case 'C':
                        savAdo = 100;
                        break;
                }

                var alapterulet = sav.Sum(x => x.AlapTerulet);
                totalTax += alapterulet * savAdo;
            }

            if (totalTax >= 10000)
            {
                personTaxes.Add(person.Key, totalTax);
            }
        }

        TotalTaxes = personTaxes;
    }
}