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
    public class ProducerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IProducer _producer;

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
            MessageBox.Show("ProducerViewModel Constructor " + Name);
        }

        public IProducer Producer
        {
            get => _producer;
        }

        public string Name
        {
            get => _producer.Name;
        }
    }
}
