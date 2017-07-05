using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace Raspored
{
    class Termini
    {
        public ObservableCollection<Termin> Podaci { get; set; }

        private int Counter = 1;
        public Termini()
        {
            Podaci = new ObservableCollection<Termin>();
        }
        public void add(Termin term)
        {
            Podaci.Add(term);
        }
        public bool add(int trajanje, DateTime pocetak,Ucionica ucionica, string predmet)
        {
            Podaci.Add(new Termin(this.Counter, trajanje, pocetak, ucionica,predmet));
            this.Counter++;
            return true;
        }
        public void edit(int broj, int trajanje, DateTime pocetak, Ucionica ucionica, string predmet)
        {
            Termin s = Podaci.First(item => item.Broj == broj);
            s.edit(pocetak,ucionica,trajanje,predmet);
            return;
        }
        public void remove(int broj)
        {
            Podaci.Remove(Podaci.First(item => item.Broj == broj));
            return;
        }
        public bool istekao(DateTime vreme)
        {
            if (DateTime.Now.CompareTo(vreme)<=0)
                return true;
            else
                return false;
        }
        public bool slobodan(DateTime vreme,Ucionica u)
        {
            DateTime endtime;
            foreach (Termin podatak in Podaci)
            {
                if (podatak.Ucionica.Oznaka == u.Oznaka)
                {
                    endtime = podatak.Pocetak.AddHours((double)(podatak.Trajanje));
                    if (podatak.Pocetak.CompareTo(vreme) <= 0 && endtime.CompareTo(vreme) >= 0)//vece od pocetka manje od kraja
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool slobodanZa(DateTime vreme, Termin termin, Ucionica u)
        {
            DateTime pocetno = termin.Pocetak;
            DateTime zavrsno = pocetno.AddHours(termin.Trajanje);
            DateTime pocetnoPodatak;
            DateTime zavrsnoPodatak;
            foreach (Termin podatak in Podaci)
            {
                if (podatak.Ucionica.Oznaka == u.Oznaka)
                {
                    pocetnoPodatak = podatak.Pocetak;
                    zavrsnoPodatak = podatak.Pocetak.AddHours(podatak.Trajanje);
                    if (pocetnoPodatak <= zavrsno && zavrsnoPodatak >= pocetno)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool slobodnaUcionica(Ucionica u)
        {
            DateTime dt = DateTime.Now;
            DateTime pocetnoPodatak;
            DateTime zavrsnoPodatak;
            foreach (Termin podatak in Podaci)
            {
                if (podatak.Ucionica.Oznaka == u.Oznaka) { 
                    pocetnoPodatak = podatak.Pocetak;
                    zavrsnoPodatak = podatak.Pocetak.AddHours(podatak.Trajanje);
                    if (pocetnoPodatak <= dt && zavrsnoPodatak >= dt)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public Termin get(int broj)
        {
            return Podaci.First(item => item.Broj == broj);
        }
        public void save(BinaryWriter bw)
        {
            foreach (Termin termin in Podaci)
            {
                termin.save(bw);
            }
        }
        public void load(BinaryReader br)
        {
            foreach (Termin termin in Podaci)
            {
                termin.load(br);
            }
        }
    }
}
