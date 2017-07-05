using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Termin
    {
        public int Trajanje { get; set; }
        public string IdPredmeta { get; set; }
        public DateTime Pocetak { get; set; }
        public int Broj { get; set; }
        public Ucionica Ucionica { get; set; }
        public string Tekst { get; set; }

        public Termin(int broj, int trajanje, DateTime pocetak, Ucionica ucionica, string idPredmeta)
        {
            this.Broj = broj;
            this.Trajanje = trajanje;
            this.Pocetak = pocetak;
            this.Ucionica = ucionica;
            this.IdPredmeta = idPredmeta;
            this.Tekst = idPredmeta + " (" + trajanje+")";
        }
        public void edit(DateTime pocetak, Ucionica ucionica, int trajanje, string idPredmeta)
        {
            this.Pocetak = pocetak;
            this.Ucionica = ucionica;
            this.Tekst = idPredmeta + " (" + trajanje + ")";
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Trajanje);
            bw.Write(Pocetak.ToBinary());
            bw.Write(Broj);
            bw.Write(IdPredmeta);
            Ucionica.save(bw);

        }
        public void load(BinaryReader br)
        {
            Trajanje = br.ReadInt32();
            Pocetak = DateTime.FromBinary(br.ReadInt64());
            Broj = br.ReadInt32();
            IdPredmeta = br.ReadString();
            Ucionica.load(br);
        }
    }
}
