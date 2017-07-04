using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Smer
    {
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }

        public Smer(string oznaka, string naziv, string opis, DateTime datum)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Datum = datum;
        }
        public void edit(string naziv, string opis, DateTime datum)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Datum = datum;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Naziv);
            bw.Write(Opis);
            bw.Write(Datum.ToBinary());
        }
        public void load(BinaryReader br)
        {
            Oznaka = br.ReadString();
            Naziv = br.ReadString();
            Opis = br.ReadString();
            Datum = DateTime.FromBinary(br.ReadInt64());
        }
    }
}
