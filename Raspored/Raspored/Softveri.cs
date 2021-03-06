﻿using System;
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

        public Softveri()
        {
            Podaci = new ObservableCollection<Softver>();
        }
        public bool add(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, float cena)
        {
            Softver s;
            try
            {
                s = Podaci.First(item => item.Oznaka == oznaka);
            }
            catch (Exception)
            {
                s = null;
            }
            if (s == null)
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
        public override string ToString()
        {
            string podaci = "";
            foreach (var item in this.Podaci)
            {
                podaci = podaci + item.Naziv + " ";
            }
            return podaci;
        }
    }
}
