using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IInstrument
    {
        int ID { get; set; }
        string Name { get; set; }
        float Price { get; set; }

        Core.InstrumentType InstrumentT { get; set; }
    }
}
