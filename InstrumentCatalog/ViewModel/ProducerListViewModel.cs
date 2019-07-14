using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLC;

namespace InstrumentCatalog.ViewModel
{
    public class ProducerListViewModel : MVMaster
    {
        private BLC.BLC blc;

        public ObservableCollection<ProducerViewModel> ProducersList { get; set; }
        public ProducerViewModel AddProducer { get; }
        public RCommand DeleteProducerCommand { get; }


        private ProducerViewModel _currentProducer;
        private Action<int> _tab_no;

        public ProducerListViewModel(BLC.BLC blc, Action<int> tab_no)
        {
            this.blc = blc;
            _tab_no = tab_no;
            ProducersList = new ObservableCollection<ProducerViewModel>(
                    blc.GetProducers().Select(p => new ProducerViewModel(p)));
            AddProducer = new ProducerViewModel(blc.CreateProducer());
        }

        public ProducerViewModel CurrentProducer
        {
            get => _currentProducer;
            set
            {
                MessageBox.Show("Add Producer");
                _currentProducer = value;
                OnPropertyChanged(nameof(CurrentProducer));
            }
        }
    }
}
