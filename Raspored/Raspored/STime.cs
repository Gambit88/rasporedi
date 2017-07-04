using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored
{
    class STime
    {
        public DateTime Vreme {get;set;}
        public bool Zauzeto { get; set; }
        public bool Prvo { get; set; }
        public bool Poslednje { get; set; }
        public bool Aktivno { get; set; }
    }
}
