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
using System.ComponentModel.DataAnnotations;

namespace InstrumentCatalog.ViewModel
{
    public class ProducerViewModel : MVMaster
    {
        private IProducer _producer;

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }

        public IProducer Producer
        {
            get => _producer;
        }

        [Required(ErrorMessage = "Producer name required")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }
        }

        [Required(ErrorMessage = "Foundation year required")]
        public int Founded
        {
            get => _producer.Founded;
            set
            {
                _producer.Founded = value;
                OnPropertyChanged(nameof(Founded));
                Validate();
            }
        }
    }
}
