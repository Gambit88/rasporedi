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
        public bool add(int broj, string naziv, string opis, DateTime datum)
        {
            if (Podaci.First(item => item.Broj == broj) != null)
            {
                Podaci.Add(new Termin());
                return true;
            }
            return false;
        }
        public void edit(int broj, string naziv, string opis, DateTime datum)
        {
            Termin s = Podaci.First(item => item.Broj == broj);
            s.Broj = broj;
            return;
        }
        public void remove(int broj)
        {
            Podaci.Remove(Podaci.First(item => item.Broj == broj));
            return;
        }
    }
}
