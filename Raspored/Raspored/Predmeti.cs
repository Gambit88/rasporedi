using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Predmeti
    {
        public List<Predmet> Podaci { get; set; }
        public bool add(string oznaka, string naziv, string opis, DateTime datum)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Predmet());
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string naziv, string opis, DateTime datum)
        {
            Predmet s = Podaci.First(item => item.Oznaka == oznaka);
            s.Oznaka = oznaka;
            s.Naziv = naziv;
            s.Opis = opis;
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }
    }
}
