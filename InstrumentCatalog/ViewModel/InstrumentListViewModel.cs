using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLC;
using System.Windows.Input;
using System.Windows;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentListViewModel : INotifyPropertyChanged
    {
        private BLC.BLC blc;
        private InstrumentViewModel _currentInstrument;

        public InstrumentListViewModel(BLC.BLC blc)
        {
            MessageBox.Show("InstrumentListViewModel");
            this.blc = blc;
            Instruments = new ObservableCollection<InstrumentViewModel>(
                    blc.GetInstruments().Select(p => new InstrumentViewModel(p)));
            EditCurrentInstrument = new InstrumentViewModel(blc.NewInstrument());
            CreateInstrumentCommand = new RCommand(_ => CreateInstrument());
            SaveInstrumentCommand = new RCommand(_ => SaveInstrument(), _ => EditCurrentInstrument != null);
        }

        public ObservableCollection<InstrumentViewModel> Instruments { get; set; }

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

        private InstrumentViewModel EditCurrentInstrument
        {
            get => _currentInstrument;
            set
            {
                _currentInstrument = value;
                OnPropertyChanged(nameof(EditCurrentInstrument));
            }
        }
        public ICommand CreateInstrumentCommand { get; }
        public ICommand SaveInstrumentCommand { get; }

        private void CreateInstrument()
        {
            IInstrument newInstrument = blc.NewInstrument();
            Instruments.Add(new InstrumentViewModel(newInstrument));
        }
        private void SaveInstrument()
        {
            bool added = blc.AddInstrument(EditCurrentInstrument);
            if (added)
                Instruments.Add(new InstrumentViewModel(EditCurrentInstrument));
        }
    }
}
