using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInstrument
    {
        int ID { get; set; }
        string Name { get; set; }
        int ProductionYear { get; set; }
        IProducer Producer { get; set; }
        Core.InstrumentType Type { get; set; }
    }
}
