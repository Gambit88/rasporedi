using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Raspored
{
    public class Softver : INotifyPropertyChanged
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
        private string _Os;
        private string _Proizvodjac;
        private string _Sajt;
        private string _GodinaIzdanja;
        private double _Cena;

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
        public string Proizvodjac
        {
            get { return _Proizvodjac; }
            set
            {
                if (value != _Proizvodjac)
                {
                    _Proizvodjac = value;
                    OnPropertyChanged("Proizvodjac");
                }
            }
        }
        public string Sajt
        {
            get { return _Sajt; }
            set
            {
                if (value != _Sajt)
                {
                    _Sajt = value;
                    OnPropertyChanged("Sajt");
                }
            }
        }
        public string GodinaIzdanja
        {
            get { return _GodinaIzdanja; }
            set
            {
                if (value != _GodinaIzdanja)
                {
                    _GodinaIzdanja = value;
                    OnPropertyChanged("GodinaIzdanja");
                }
            }
        }
        public double Cena
        {
            get { return _Cena; }
            set
            {
                if (value != _Cena)
                {
                    _Cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }
        public Softver()
        {

        }

        public Softver(string oznaka, string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, double cena)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Os = os;
            this.Proizvodjac = proizvodjac;
            this.Sajt = sajt;
            this.GodinaIzdanja = godinaIzdanja;
            this.Cena = cena;
        }
        public void edit(string naziv, string opis, string os, string proizvodjac, string sajt, string godinaIzdanja, double cena)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Os = os;
            this.Proizvodjac = proizvodjac;
            this.Sajt = sajt;
            this.GodinaIzdanja = godinaIzdanja;
            this.Cena = cena;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Naziv);
            bw.Write(Opis);
            bw.Write(Os);
            bw.Write(Proizvodjac);
            bw.Write(Sajt);
            bw.Write(GodinaIzdanja);
            bw.Write(Cena);
        }
        public void load(BinaryReader br)
        {
            Oznaka = br.ReadString();
            Naziv = br.ReadString();
            Opis = br.ReadString();
            Os = br.ReadString();
            Proizvodjac = br.ReadString();
            Sajt = br.ReadString();
            GodinaIzdanja = br.ReadString();
            Cena = br.ReadDouble();
        }
    }
}
