using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
