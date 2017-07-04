using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Termini
    {
        public List<Termin> Podaci { get; set; }
        private int counter = 1;
        public bool add(int broj, int trajanje, DateTime pocetak,Ucionica ucionica)
        {
            if (Podaci.First(item => item.Broj == broj) != null)
            {

                Podaci.Add(new Termin(broj, trajanje, pocetak, ucionica));
                return true;
            }
            return false;
        }
        public void edit(int broj, DateTime pocetak, Ucionica ucionica)
        {
            Termin s = Podaci.First(item => item.Broj == broj);
            s.edit(pocetak,ucionica);
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
        public bool slobodan(DateTime vreme)
        {
            DateTime endtime;
            foreach (Termin podatak in Podaci)
            {
                endtime = podatak.Pocetak.AddHours((double)(podatak.Trajanje));
                if (podatak.Pocetak.CompareTo(vreme) <= 0 && endtime.CompareTo(vreme)>=0)//vece od pocetka manje od kraja
                {
                    return false;
                }
            }
            return true;
        }
        public bool slobodanZa(DateTime vreme, Termin termin)
        {
            DateTime pocetno = termin.Pocetak;
            DateTime zavrsno = pocetno.AddHours(termin.Trajanje);
            DateTime pocetnoPodatak;
            DateTime zavrsnoPodatak;
            foreach (Termin podatak in Podaci)
            {
                pocetnoPodatak = podatak.Pocetak;
                zavrsnoPodatak = podatak.Pocetak.AddHours(podatak.Trajanje);
                if (pocetnoPodatak <= zavrsno && zavrsnoPodatak >= pocetno)
                {
                    return false;
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
