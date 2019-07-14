using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IInstrument> GetAllInstruments();
        bool AddInstrument(IInstrument instrument);
        IInstrument NewInstrument();
        bool DeleteInstrument(IInstrument instrument);
        IProducer NewProducer();
        bool DeleteProducer(IProducer producer);
    }
}
