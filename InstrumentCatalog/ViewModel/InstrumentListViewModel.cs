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
using System.Reflection;
using System.Windows;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentListViewModel : MVMaster
    {
        private BLC.BLC blc;
        private InstrumentViewModel _currentInstrument;
        private Action<int> _tab_no;

        public InstrumentListViewModel(BLC.BLC blc, Action<int> tab_no, ObservableCollection<ProducerViewModel> producers)
        {
            this.blc = blc;
            _tab_no = tab_no;
            Instruments = new ObservableCollection<InstrumentViewModel>(
                    blc.GetInstruments().Select(p => new InstrumentViewModel(p)));
            CreateInstrumentCommand = new RCommand(_ => CreateInstrument());
            DeleteInstrumentCommand = new RCommand(_ => DeleteInstrument(), _ => CurrentInstrument != null);
            SaveInstrumentCommand = new RCommand(_ => SaveInstrument(), _ => CurrentInstrument != null);
            AvailableProducers = producers;
        }

        public ObservableCollection<InstrumentViewModel> Instruments { get; set; }

        public ObservableCollection<ProducerViewModel> AvailableProducers
        {
            get;
        }

        public InstrumentViewModel CurrentInstrument
        {
            get => _currentInstrument;
            set
            {
                _currentInstrument = value;
                OnPropertyChanged(nameof(CurrentInstrument));
                Validate();
            }
        }
        public ICommand CreateInstrumentCommand { get; }
        public ICommand SelectInstrumentCommand { get; set; }
        public ICommand DeleteInstrumentCommand { get; }
        public ICommand SaveInstrumentCommand { get; }

        private void CreateInstrument()
        {
            MessageBox.Show("Instrument created");
            IInstrument newInstrument = blc.NewInstrument();
            Instruments.Add(new InstrumentViewModel(newInstrument));
        }
        private InstrumentViewModel SelectInstrument
        {
            get => _currentInstrument;
            set
            {
                _currentInstrument = value;
                OnPropertyChanged(nameof(SelectInstrument));
                Validate();
            }
        }
        private void DeleteInstrument()
        {
            if (blc.DeleteInstrument(CurrentInstrument.Instrument))
                Instruments.Remove(SelectInstrument);
        }
        private void SaveInstrument()
        {
            bool added = blc.AddInstrument(CurrentInstrument.Instrument);
            if (added)
                Instruments.Add(new InstrumentViewModel(CurrentInstrument.Instrument));
        }
    }
}
