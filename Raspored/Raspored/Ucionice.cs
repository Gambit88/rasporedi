using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raspored
{
    class Ucionice
    {
        public List<Ucionica> Podaci { get; set; }
        public bool add(string oznaka, string opis, int brMesta, bool projektor, bool tabla, bool smart, string os, Softveri softver)
        {
            if (Podaci.First(item => item.Oznaka == oznaka) != null)
            {
                Podaci.Add(new Ucionica(oznaka, opis, brMesta, projektor, tabla, smart, os, softver));
                return true;
            }
            return false;
        }
        public void edit(string oznaka, string opis, int brMesta, bool projektor, bool tabla, bool smart, string os, Softveri softver)
        {
            Ucionica s = Podaci.First(item => item.Oznaka == oznaka);
            s.edit(opis, brMesta, projektor, tabla, smart, os, softver);
            return;
        }
        public void remove(string oznaka)
        {
            Podaci.Remove(Podaci.First(item => item.Oznaka == oznaka));
            return;
        }
        public Ucionica get(string oznaka)
        {
            return Podaci.First(item => item.Oznaka == oznaka);
        }
        public void save(BinaryWriter bw)
        {
            foreach(Ucionica ucionica in Podaci)
            {
                ucionica.save(bw);
            }
        }
        public void load(BinaryReader br)
        {
            foreach(Ucionica ucionica in Podaci)
            {
                ucionica.load(br);
            }
        }
    }
}
