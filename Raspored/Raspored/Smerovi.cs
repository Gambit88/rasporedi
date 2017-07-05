using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace Raspored
{
    class Smerovi
    {
        public ObservableCollection<Smer> Podaci { get; set; }

        public Smerovi()
        {
            Podaci = new ObservableCollection<Smer>();
        }

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
        public Smer get(string oznaka)
        {
            return Podaci.First(item => item.Oznaka == oznaka);
        }
        public void save(BinaryWriter bw)
        {
            foreach (Smer smer in Podaci)
            {
                smer.save(bw);
            }
        }
        public void load(BinaryReader br)
        {
            foreach (Smer smer in Podaci)
            {
                smer.load(br);
            }
        }
    }
}
