using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    public class BLC
    {
        private IDAO dao = new DAOMock1.DB();

        public IEnumerable<IInstrument> GetInstruments()
        {
            return dao.GetAllInstruments();
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetAllProducers();
        }
    }
}
