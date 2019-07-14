using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLC;

namespace InstrumentCatalog.ViewModel
{
    public class ProducerListViewModel : MVMaster
    {
        private BLC.BLC blc;

        public ObservableCollection<ProducerViewModel> ProducersList { get; set; }
        public RCommand DeleteProducerCommand { get; }


        private ProducerViewModel _currentProducer;
        private Action<int> _tab_no;

        public ProducerListViewModel(BLC.BLC blc, Action<int> tab_no)
        {
            this.blc = blc;
            _tab_no = tab_no;
            ProducersList = new ObservableCollection<ProducerViewModel>(
                    blc.GetProducers().Select(p => new ProducerViewModel(p)));
            AddProducerCommand = new RCommand(_ => AddProducer());
        }

        public void AddProducer()
        {   
            if (CurrentProducer != null)
            {
                ProducerViewModel producer = new ProducerViewModel(blc.CreateProducer(CurrentProducer.Producer));
                MessageBox.Show("Added " + CurrentProducer.Name);
                if (producer == null)
                {
                    MessageBox.Show("Error");
                }
                ProducersList.Add(producer);
            }
        }

        public ICommand AddProducerCommand { get; }

        public ProducerViewModel CurrentProducer
        {
            get => _currentProducer;
            set
            {
                _currentProducer = value;
                OnPropertyChanged(nameof(CurrentProducer));
            }
        }
    }
}
