namespace EpitmenyadoWebApp.Models
{
    public class Telkek
    {

        public Telkek(int adoSzam, string utcaNev, string hazSzam, char sav, int alapTerulet)
        {
            AdoSzam = adoSzam;
            UtcaNev = utcaNev;
            HazSzam = hazSzam;
            Sav = sav;
            AlapTerulet = alapTerulet;
        }

        public int Id { get; set; }
        public int AdoSzam { get; set; }
        public string UtcaNev { get; set; }
        public string HazSzam { get; set; }
        public char Sav { get; set; }
        public int AlapTerulet { get; set; }
    }
}
