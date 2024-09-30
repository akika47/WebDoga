using EpitmenyadoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EpitmenyadoWebApp.Pages
{
    public class FajlFeltoltesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly EpitmenyDbContext _context;

        public FajlFeltoltesModel(IWebHostEnvironment env, EpitmenyDbContext context)
        {
            _env = env;
            _context = context;
        }

        [BindProperty]
        public IFormFile Feltoltes { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Feltoltes == null)
            {
                return Page();
            }

            var UploadDirPath = Path.Combine(_env.ContentRootPath, "uploads");
            var UploadFilePath = Path.Combine(UploadDirPath, Feltoltes.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {

                var sor = sr.ReadLine();
                string[] mezok = sor.Split(' ');
                int adoSzam = Convert.ToInt32(mezok[0]);
                string utcaNev = mezok[1];
                string hazSzam = mezok[2];
                char sav = Convert.ToChar(mezok[3]); ;
                int alapTerulet = Convert.ToInt32(mezok[4]);
                Telkek ujTelek = new Telkek(adoSzam, utcaNev, hazSzam, sav, alapTerulet);
                _context.Telkeks.Add(ujTelek);
            }

            sr.Close();
            await _context.SaveChangesAsync();
            System.IO.File.Delete(UploadFilePath);

            return Page();
        }
    }
}
