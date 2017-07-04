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
        public DateTime Pocetak { get; set; }
        public int Broj { get; set; }
        public Ucionica Ucionica { get; set; }

        public Termin(int broj, int trajanje, DateTime pocetak, Ucionica ucionica)
        {
            this.Broj = broj;
            this.Trajanje = trajanje;
            this.Pocetak = pocetak;
            this.Ucionica = ucionica;
        }
        public void edit(DateTime pocetak, Ucionica ucionica)
        {
            this.Pocetak = pocetak;
            this.Ucionica = ucionica;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Trajanje);
            bw.Write(Pocetak.ToBinary());
            bw.Write(Broj);
            Ucionica.save(bw);

        }
        public void load(BinaryReader br)
        {
            Trajanje = br.ReadInt32();
            Pocetak = DateTime.FromBinary(br.ReadInt64());
            Broj = br.ReadInt32();
            Ucionica.load(br);
        }
    }
}
