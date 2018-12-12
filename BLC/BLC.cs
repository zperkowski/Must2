using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    class BLC
    {
        private IDAO dao;

        public BLC(string dbName)
        {
            Assembly a = Assembly.UnsafeLoadFrom(dbName);

            Type daoToCreate = null;
            Type daoType = typeof(IDAO);

            foreach (var t in a.GetTypes())
            {
                foreach (var i in t.GetInterfaces())
                {
                    if (i == daoType)
                    {
                        daoToCreate = t;
                    }
                    Console.WriteLine("\t" + i);
                }
            }
        }

        public IEnumerable<IInstrument> GetInstruments()
        {

        }
    }
}
