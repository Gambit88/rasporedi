using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
