using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Smerovi
    {
        public List<Smer> Podaci { get; set; }

        public bool add(string oznaka, string naziv, string opis, DateTime datum)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Smer(oznaka,naziv,opis,datum));
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string naziv, string opis, DateTime datum)
        {
            Smer s = Podaci.First(item => item.Oznaka == oznaka);
            s.edit(naziv, opis, datum);
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }
    }
}
