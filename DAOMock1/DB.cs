using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAOMock1
{
    public class DB : IDAO
    {
        private List<IProducer> _producers;
        private List<IInstrument> _instruments;

        public DB()
        {
            _producers = new List<IProducer>()
            {
                new BO.Producent{ ID=1, Name="Yamaha", Founded=1887 },
                new BO.Producent{ ID=2, Name="Roland", Founded=1972 },
                new BO.Producent{ ID=3, Name="Sennheiser", Founded=1945}
            };

            _instruments = new List<IInstrument>()
            {
                new BO.Instrument
                {
                    ID = 0,
                    Name ="Guitar1",
                    Producer = _producers[0],
                    ProductionYear = 1999,
                    Type = Core.InstrumentType.Guitar
                },
                new BO.Instrument
                {
                    ID = 1,
                    Name ="Guitar2",
                    Producer = _producers[0],
                    ProductionYear = 2009,
                    Type = Core.InstrumentType.Guitar
                },
                new BO.Instrument
                {
                    ID = 2,
                    Name ="Piano1",
                    Producer = _producers[1],
                    ProductionYear = 2000,
                    Type = Core.InstrumentType.Piano
                },
                new BO.Instrument
                {
                    ID = 3,
                    Name ="Piano2",
                    Producer = _producers[0],
                    ProductionYear = 2007,
                    Type = Core.InstrumentType.Piano
                },
                new BO.Instrument
                {
                    ID = 4,
                    Name ="Guitar3",
                    Producer = _producers[2],
                    ProductionYear = 2002,
                    Type = Core.InstrumentType.Guitar
                }


            };
        }

        public IEnumerable<IInstrument> GetAllInstruments()
        {
            return _instruments;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public bool AddInstrument(IInstrument instrument)
        {
            if (_instruments.Contains(instrument))
                return false;
            instrument.ID = _instruments.Count();
            _instruments.Add(instrument);
            return true;
        }

        public IInstrument NewInstrument()
        {
            IInstrument newI = new BO.Instrument
            {
                ID = _instruments.Count(),
                Name = "New",
                Producer = null,
                ProductionYear = 0,
                Type = Core.InstrumentType.Unknown
            };
            _instruments.Add(newI);
            MessageBox.Show("DB NewInstrument " + _instruments.Count());
            return newI;
        }

        public bool DeleteInstrument(IInstrument instrument)
        {
            MessageBox.Show("DB DeleteInstrument");
            return _instruments.Remove(instrument);
        }
    }
}
