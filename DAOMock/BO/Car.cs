using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock1.BO
{
    public class Car : IInstrument
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public InstrumentType Instrument { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} - {Price} {Instrument} ";
        }
    }
}
