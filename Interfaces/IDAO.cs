using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IDAO
    {
        IEnumerable<IInstrument> GetAllInstruments();
        IEnumerable<IProducer> GetAllProducers();
        IInstrument CreateEmptyInstrument();
    }
}
