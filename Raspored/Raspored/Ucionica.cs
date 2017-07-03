using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
