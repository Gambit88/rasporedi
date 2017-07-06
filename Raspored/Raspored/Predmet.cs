using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Raspored
{
    class Predmet : INotifyPropertyChanged
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
        private string _Naziv;
        private string _Opis;
        private Smer _Smer;
        private int _VelicinaGrupe;
        private int _BrCasovaMin;
        private int _BrTermina;
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
        public string Naziv
        {
            get { return _Naziv; }
            set
            {
                if (value != _Naziv)
                {
                    _Naziv = value;
                    OnPropertyChanged("Naziv");
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
        public Smer Smer
        {
            get { return _Smer; }
            set
            {
                if (value != _Smer)
                {
                    _Smer = value;
                    OnPropertyChanged("Smer");
                }
            }
        }
        public int VelicinaGrupe
        {
            get { return _VelicinaGrupe; }
            set
            {
                if (value != _VelicinaGrupe)
                {
                    _VelicinaGrupe = value;
                    OnPropertyChanged("VelicinaGrupe");
                }
            }
        }
        public int BrCasovaMin
        {
            get { return _BrCasovaMin; }
            set
            {
                if (value != _BrCasovaMin)
                {
                    _BrCasovaMin = value;
                    OnPropertyChanged("BrCasovaMin");
                }
            }
        }
        public int BrTermina
        {
            get { return _BrTermina; }
            set
            {
                if (value != _BrTermina)
                {
                    _BrTermina = value;
                    OnPropertyChanged("BrTermina");
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
            this.Softver = softveri;
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
            this.Softver = softveri;
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
