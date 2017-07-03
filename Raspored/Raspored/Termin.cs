using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Termin
    {
        public int Trajanje { get; set; }
        public DateTime Pocetak { get; set; }
        public int Broj { get; set; }

        public Termin(int broj, int trajanje, DateTime pocetak)
        {
            this.Broj = broj;
            this.Trajanje = trajanje;
            this.Pocetak = pocetak;
        }
        public void edit(DateTime pocetak)
        {
            this.Pocetak = pocetak;
        }
    }
}
