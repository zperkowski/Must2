using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentListViewModel : INotifyPropertyChanged
    {
        private BLC.BLC blc;

        private ObservableCollection<IInstrument> instruments;

        public ObservableCollection<IInstrument> Instruments
        {
            get => instruments;
            set
            {
                instruments = value;
                OnPropertyChanged(nameof(Instruments));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<IProducer> producers;

        public ObservableCollection<IProducer> Producers
        {
            get => producers;
        }
    }
}
