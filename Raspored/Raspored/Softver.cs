using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public double Cena { get; set; }

        public Softver(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, double cena)
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
        public void edit(string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, double cena)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Os = os;
            this.Proizvodjac = proizvodjac;
            this.Sajt = sajt;
            this.GodinaIzdanja = godinaIzdanja;
            this.Cena = cena;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Naziv);
            bw.Write(Opis);
            bw.Write(Os);
            bw.Write(Proizvodjac);
            bw.Write(Sajt);
            bw.Write(GodinaIzdanja);
            bw.Write(Cena);
        }
        public void load(BinaryReader br)
        {
            Oznaka = br.ReadString();
            Naziv = br.ReadString();
            Opis = br.ReadString();
            Os = br.ReadString();
            Proizvodjac = br.ReadString();
            Sajt= br.ReadString();
            GodinaIzdanja = br.ReadString();
            Cena = br.ReadDouble();
        }
    }
}
