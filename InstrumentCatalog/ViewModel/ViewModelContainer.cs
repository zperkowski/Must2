using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentCatalog.ViewModel
{
    public class ViewModelContainer : MVMaster
    {
        public InstrumentListViewModel InstVM { get; }
        public ProducerListViewModel ProdVM { get; }

        private int _currentTab;

        public ViewModelContainer(BLC.BLC blc)
        {
            ProdVM = new ProducerListViewModel(blc, tab_no => CurrentTab = tab_no);
            InstVM = new InstrumentListViewModel(blc, tab_no => CurrentTab = tab_no, ProdVM.ProducersList);
        }
        public int CurrentTab
        {
            get => _currentTab;
            set
            {
                _currentTab = value;
                OnPropertyChanged(nameof(CurrentTab));
            }
        }
    }
}
