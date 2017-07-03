using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class Softver
    {
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Os { get; set; }
        public string Proizvodjac { get; set; }
        public string Sajt { get; set; }
        public string GodinaIzdanja { get; set; }
        public float Cena { get; set; }

        public Softver(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, float cena)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Os = os;
            this.Proizvodjac = proizvodjac;
            this.Sajt = sajt;
            this.GodinaIzdanja = godinaIzdanja;
            this.Cena = cena;
        }
        public void edit(string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, float cena)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Os = os;
            this.Proizvodjac = proizvodjac;
            this.Sajt = sajt;
            this.GodinaIzdanja = godinaIzdanja;
            this.Cena = cena;
        }
    }
}
