using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock1.BO
{
    public class Instrument : IInstrument
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public IProducer Producer { get; set; }
        public InstrumentType Type { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} - {ProductionYear} [ {Producer.Name} ] {Type} ";
        }
    }
}
