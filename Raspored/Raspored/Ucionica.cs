using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Ucionica
    {
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public int BrMesta { get; set; }
        public bool Projektor { get; set; }
        public bool Tabla { get; set; }
        public bool Smart { get; set; }
        public string Os { get; set; }
        public Softveri Softver { get; set; }

        public Ucionica(string oznaka, string opis, int brMesta, bool projektor, bool tabla, bool smart, string os, Softveri softver)
        {
            this.Oznaka = oznaka;
            this.Opis = opis;
            this.BrMesta = brMesta;
            this.Projektor = projektor;
            this.Tabla = tabla;
            this.Smart = smart;
            this.Os = os;
            this.Softver = softver;
        }
        public void edit(string opis, int brMesta, bool projektor, bool tabla, bool smart, string os, Softveri softver)
        {
            this.Opis = opis;
            this.BrMesta = brMesta;
            this.Projektor = projektor;
            this.Tabla = tabla;
            this.Smart = smart;
            this.Os = os;
            this.Softver = softver;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Opis);
            bw.Write(BrMesta);
            bw.Write(Projektor);
            bw.Write(Tabla);
            bw.Write(Smart);
            bw.Write(Os);
            Softver.save(bw);
        }
        public void load(BinaryReader br)
        {
            Oznaka = br.ReadString();
            Opis = br.ReadString();
            BrMesta = br.ReadInt32();
            Projektor = br.ReadBoolean();
            Tabla = br.ReadBoolean();
            Smart = br.ReadBoolean();
            Os = br.ReadString();
            Softver.load(br);
        }
    }

}
