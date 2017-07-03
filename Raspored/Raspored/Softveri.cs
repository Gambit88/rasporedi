using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Softveri
    {
        public List<Softver> Podaci { get; set; }
        public bool add(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, float cena)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Softver( oznaka,  naziv,  opis,  os,  proizvodjac,  sajt,  godinaIzdanja,  cena));
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, float cena)
        {
            Softver s = Podaci.First(item => item.Oznaka == oznaka);
            s.edit(naziv, opis, os, proizvodjac, sajt, godinaIzdanja, cena);
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }

    }
}
