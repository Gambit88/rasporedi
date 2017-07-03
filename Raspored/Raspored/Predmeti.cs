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
        public bool add(string oznaka, string naziv, string opis, Smer smer, int velicinaGrupe, int brCasovaMin, int brTermina, bool projektor, bool tabla, bool smart, string os, Softveri softveri)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Predmet(oznaka, naziv, opis, smer, velicinaGrupe, brCasovaMin, brTermina, projektor, tabla, smart, os, softveri));
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string naziv, string opis, Smer smer, int velicinaGrupe, int brCasovaMin, int brTermina, bool projektor, bool tabla, bool smart, string os, Softveri softveri)
        {
            Predmet s = Podaci.First(item => item.Oznaka == oznaka);
            s.edit(naziv, opis, smer, velicinaGrupe, brCasovaMin, brTermina, projektor, tabla, smart, os, softveri);
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }
    }
}
