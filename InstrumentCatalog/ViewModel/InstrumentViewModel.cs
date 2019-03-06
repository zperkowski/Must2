
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentViewModel : INotifyPropertyChanged, IInstrument
    {

        public InstrumentViewModel(IInstrument instrument)
        {
            this.instrument = instrument;
        }

        private IInstrument instrument;

        public int ID
        {
            get => instrument.ID;
            set
            {
                instrument.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get => instrument.Name;
            set
            {
                instrument.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int ProductionYear
        {
            get => instrument.ProductionYear;
            set
            {
                instrument.ProductionYear = value;
                OnPropertyChanged(nameof(ProductionYear));
            }
        }

        public IProducer Producer
        {
            get => instrument.Producer;
            set
            {
                instrument.Producer = value;
                OnPropertyChanged(nameof(Producer));
            }
        }

        public Core.InstrumentType Transmission
        {
            get => instrument.Type;
            set
            {
                instrument.Type = value;
                OnPropertyChanged(nameof(Transmission));
            }
        }

        public InstrumentType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
