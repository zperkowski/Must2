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
using System.Reflection;

namespace InstrumentCatalog.ViewModel
{
    public class InstrumentListViewModel : INotifyPropertyChanged
    {
        private BLC.BLC blc;
        private InstrumentViewModel _currentInstrument;

        public InstrumentListViewModel(BLC.BLC blc)
        {
            this.blc = blc;
            Instruments = new ObservableCollection<InstrumentViewModel>(
                    blc.GetInstruments().Select(p => new InstrumentViewModel(p)));
            CreateInstrumentCommand = new RCommand(_ => CreateInstrument());
            DeleteInstrumentCommand = new RCommand(_ => DeleteInstrument(), _ => CurrentInstrument != null);
            SaveInstrumentCommand = new RCommand(_ => SaveInstrument(), _ => CurrentInstrument != null);
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

        public InstrumentViewModel CurrentInstrument
        {
            get => _currentInstrument;
            set
            {
                MessageBox.Show("CurrentInstrument " + value);
                _currentInstrument = value;
                OnPropertyChanged(nameof(CurrentInstrument));
            }
        }
        public ICommand CreateInstrumentCommand { get; }
        public ICommand SelectInstrumentCommand { get; set; }
        public ICommand DeleteInstrumentCommand { get; }
        public ICommand SaveInstrumentCommand { get; }

        private void CreateInstrument()
        {
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
            }
        }
        private void DeleteInstrument()
        {
            MessageBox.Show("DeleteInstrument");
            if (blc.DeleteInstrument(CurrentInstrument.Instrument))
                Instruments.Remove(SelectInstrument);
        }
        private void SaveInstrument()
        {
            bool added = blc.AddInstrument(CurrentInstrument);
            if (added)
                Instruments.Add(new InstrumentViewModel(CurrentInstrument));
        }

        public void NotifyAllProperties()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo property in properties)
                OnPropertyChanged(property.Name);
        }
    }
}
