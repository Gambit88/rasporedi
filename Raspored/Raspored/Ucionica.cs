using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Raspored
{
    class Ucionica : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _Oznaka;
        private string _Opis;
        private int _BrMesta;
        private bool _Projektor;
        private bool _Tabla;
        private bool _Smart;
        private string _Os;
        private Softveri _Softver;

        public string Oznaka
        {
            get { return _Oznaka; }
            set
            {
                if (value != _Oznaka)
                {
                    _Oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }
        public string Opis
        {
            get { return _Opis; }
            set
            {
                if (value != _Opis)
                {
                    _Opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public int BrMesta
        {
            get { return _BrMesta; }
            set
            {
                if (value != _BrMesta)
                {
                    _BrMesta = value;
                    OnPropertyChanged("BrMesta");
                }
            }
        }
        public bool Projektor
        {
            get { return _Projektor; }
            set
            {
                if (value != _Projektor)
                {
                    _Projektor = value;
                    OnPropertyChanged("Projektor");
                }
            }
        }
        public bool Tabla
        {
            get { return _Tabla; }
            set
            {
                if (value != _Tabla)
                {
                    _Tabla = value;
                    OnPropertyChanged("Tabla");
                }
            }
        }
        public bool Smart
        {
            get { return _Smart; }
            set
            {
                if (value != _Smart)
                {
                    _Smart = value;
                    OnPropertyChanged("Smart");
                }
            }
        }
        public string Os
        {
            get { return _Os; }
            set
            {
                if (value != _Os)
                {
                    _Os = value;
                    OnPropertyChanged("Os");
                }
            }
        }

        public Softveri Softver
        {
            get { return _Softver; }
            set
            {
                if (value != _Softver)
                {
                    _Softver = value;
                    OnPropertyChanged("Softver");
                }
            }
        }


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
                return false;
            }
            if (p.Projektor == true && this.Projektor == false)
            {
                return false;
            }
            if (p.Tabla == true && this.Tabla == false)
            {
                return false;
            }
            if (p.Smart == true && this.Smart == false)
            {
                return false;
            }
            foreach (Softver s in p.Softver.Podaci)
            {
                if (Softver.Podaci.Contains(s))
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

}
