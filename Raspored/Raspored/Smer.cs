using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Raspored
{
    public class Smer : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _oznaka;
        private string _naziv;
        private string _opis;
        private DateTime _datum;

        public string Oznaka
        {
            get { return _oznaka; }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Naziv
        {
            get { return _naziv; }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Opis
        {
            get { return _opis; }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }


        public DateTime Datum
        {
            get { return _datum; }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public Smer()
        {

        }

        public Smer(string oznaka, string naziv, string opis, DateTime datum)
        {
            this.Oznaka = oznaka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Datum = datum;
        }
        public void edit(string naziv, string opis, DateTime datum)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Datum = datum;
        }
        public void save(BinaryWriter bw)
        {
            bw.Write(Oznaka);
            bw.Write(Naziv);
            bw.Write(Opis);
            bw.Write(Datum.ToBinary());
        }
        public void load(BinaryReader br)
        {
            Oznaka = br.ReadString();
            Naziv = br.ReadString();
            Opis = br.ReadString();
            Datum = DateTime.FromBinary(br.ReadInt64());
        }
        public override string ToString()
        {
            return this.Oznaka;
        }
    }
}
