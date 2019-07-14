using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLC
{
    public class BLC
    {
        private IDAO dao = new DAOMock1.DB();

        public BLC(string DAOFilename)
        {
            Assembly ddl = Assembly.Load(DAOFilename);
            Type daoType = FindDaoType(ddl);
            object o = Activator.CreateInstance(daoType);
            dao = (IDAO)o;
        }
        private static Type FindDaoType(Assembly ddl)
        {
            var types = ddl.GetTypes();
            var i = Array.FindIndex(types, t => t.Name.StartsWith("DB"));
            if (i == -1)
                throw new System.TypeLoadException("DAO not found");
            return types[i];
        }
        public IEnumerable<IInstrument> GetInstruments()
        {
            return dao.GetAllInstruments();
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetAllProducers();
        }

        public bool AddInstrument(IInstrument instrument)
        {
            return dao.AddInstrument(instrument);
        }

        public IInstrument NewInstrument()
        {
            return dao.NewInstrument();
        }
        public bool DeleteInstrument(IInstrument instrument)
        {
            return dao.DeleteInstrument(instrument);
        }

        public IProducer CreateProducer()
        {
            return dao.NewProducer();
        }
        public bool DeleteProducer(IProducer producer)
        {
            return dao.DeleteProducer(producer);
        }
    }
}
