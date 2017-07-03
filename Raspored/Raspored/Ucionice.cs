using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Ucionice
    {
        public List<Ucionica> Podaci { get; set; }
        public bool add(string oznaka, string naziv, string opis, DateTime datum)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Ucionica());
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string naziv, string opis, DateTime datum)
        {
            Ucionica s = Podaci.First(item => item.Oznaka == oznaka);
            s.Oznaka = oznaka;
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }
    }
}
