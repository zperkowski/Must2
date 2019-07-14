
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentViewModel : MVMaster
    {

        public InstrumentViewModel(IInstrument instrument)
        {
            this.instrument = instrument;
        }

        private IInstrument instrument;

        public IInstrument Instrument
        {
            get => instrument;
        }

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

        public InstrumentType Type
        {
            get => instrument.Type;
            set
            {
                instrument.Type = value;
                MessageBox.Show("Type " + value);
                OnPropertyChanged(nameof(Type));
            }
        }
    }
}
