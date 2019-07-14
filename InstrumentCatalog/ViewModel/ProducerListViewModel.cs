using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InstrumentCatalog.ViewModel
{
    class ProducerListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BLC.BLC blc;

        public ObservableCollection<ProducerViewModel> ProducersList { get; set; }
        public ProducerViewModel AddProducer { get; }
        public RCommand DeleteProducerCommand { get; }

        public ProducerListViewModel(BLC.BLC blc)
        {
            this.blc = blc;
            ProducersList = new ObservableCollection<ProducerViewModel>(
                    blc.GetProducers().Select(p => new ProducerViewModel(p)));
            AddProducer = new ProducerViewModel(blc.CreateProducer());
            DeleteProducerCommand = new RCommand(_ => DeleteProducer(), _ => CurrentProducer != null);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        private ProducerViewModel _currentProducer;

        public ProducerViewModel CurrentProducer
        {
            get => _currentProducer;
            set
            {
                _currentProducer = value;
                OnPropertyChanged(nameof(CurrentProducer));
            }
        }
        private void DeleteProducer()
        {
            MessageBox.Show("Delete Producer");
            if (blc.DeleteProducer(CurrentProducer.Producer))
                ProducersList.Remove(CurrentProducer);
        }
    }
}
