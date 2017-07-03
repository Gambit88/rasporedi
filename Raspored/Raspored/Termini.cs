using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Termini
    {
        public List<Termin> Podaci { get; set; }
        private int counter = 1;
        public bool add(int broj, int trajanje, DateTime pocetak)
        {
            if (Podaci.First(item => item.Broj == broj) != null)
            {
                Podaci.Add(new Termin(broj, trajanje, pocetak));
                return true;
            }
            return false;
        }
        public void edit(int broj, DateTime pocetak)
        {
            Termin s = Podaci.First(item => item.Broj == broj);
            s.edit(pocetak);
            return;
        }
        public void remove(int broj)
        {
            Podaci.Remove(Podaci.First(item => item.Broj == broj));
            return;
        }
    }
}
