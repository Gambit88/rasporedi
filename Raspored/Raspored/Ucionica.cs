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
        public Softveri softver { get; set; }
    }

}
