using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Predmet
    {
        public string Oznaka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Smer Smer { get; set; }
        public int VelicinaGrupe { get; set; }
        public int BrCasovaMin { get; set; }
        public int BrTermina { get; set; }
        public bool Projektor { get; set; }
        public bool Tabla { get; set; }
        public bool Smart { get; set; }
        public string Os { get; set; }
        public Softveri Softver { get; set; }

        public Predmet(string oznaka, string naziv, string opis, Smer smer, int velicinaGrupe, int brCasovaMin, int brTermina, bool projektor, bool tabla, bool smart, string os, Softveri softveri)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Smer = smer;
            this.VelicinaGrupe = velicinaGrupe;
            this.BrCasovaMin = brCasovaMin;
            this.BrTermina = brTermina;
            this.Projektor = projektor;
            this.Tabla = tabla;
            this.Smart = smart;
            this.Os = os;
            this.Softver = Softver;
        }
        public void edit(string naziv, string opis, Smer smer, int velicinaGrupe, int brCasovaMin, int brTermina, bool projektor, bool tabla, bool smart, string os, Softveri softveri)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Smer = smer;
            this.VelicinaGrupe = velicinaGrupe;
            this.BrCasovaMin = brCasovaMin;
            this.BrTermina = brTermina;
            this.Projektor = projektor;
            this.Tabla = tabla;
            this.Smart = smart;
            this.Os = os;
            this.Softver = Softver;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Naziv);
            bw.Write(Opis);
            bw.Write(VelicinaGrupe);
            bw.Write(BrCasovaMin);
            bw.Write(BrTermina);
            bw.Write(Projektor);
            bw.Write(Tabla);
            bw.Write(Smart);
            bw.Write(Os);
            Smer.save(bw);
            Softver.save(bw);

        }
        public void load(BinaryReader br)
        {
            this.Oznaka = br.ReadString();
            this.Naziv = br.ReadString();
            this.Opis = br.ReadString();
            this.VelicinaGrupe = br.ReadInt32();
            this.BrCasovaMin = br.ReadInt32();
            this.BrTermina = br.ReadInt32();
            this.Projektor = br.ReadBoolean();
            this.Tabla = br.ReadBoolean();
            this.Smart = br.ReadBoolean();
            this.Os = br.ReadString();
            this.Smer.load(br);
            this.Softver.load(br);
        }
    }
}
