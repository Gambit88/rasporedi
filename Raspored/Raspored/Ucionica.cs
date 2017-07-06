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
        public bool podrzava(Predmet p)
        {
            if (this.BrMesta < p.VelicinaGrupe)
            {
                Console.WriteLine("1");
                return false;
            }
            if (p.Projektor==true && this.Projektor == false)
            {
                Console.WriteLine("2");
                return false;
            }
            if (p.Tabla == true && this.Tabla == false)
            {
                Console.WriteLine("3");
                return false;
            }
            if (p.Smart == true && this.Smart == false)
            {
                Console.WriteLine("4");
                return false;
            }
            foreach(Softver s in p.Softver.Podaci)
            {
                if (Softver.Podaci.Contains(s))
                {

                }
                else
                {
                    Console.WriteLine("5");
                    return false;
                }
            }
            return true;
        }
    }

}
