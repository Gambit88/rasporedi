using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace Raspored
{
    class Softveri
    {
        public ObservableCollection<Softver> Podaci { get; set; }
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
        public Softver get(string oznaka)
        {
            return Podaci.First(item => item.Oznaka == oznaka);
        }
        public void save(BinaryWriter bw)
        {
            foreach (Softver softver in Podaci)
            {
                softver.save(bw);
            }
        }
        public void load(BinaryReader br)
        {
            foreach (Softver softver in Podaci)
            {
                softver.load(br);
            }
        }

    }
}
