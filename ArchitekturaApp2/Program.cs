using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Must
{
    class Program
    {
        static void Main(string[] args)
        {
            BLC.BLC blc = new BLC.BLC();

            foreach (var prod in blc.GetProducers())
            {
                Console.WriteLine(prod);
            }

            Console.WriteLine("####################");
            foreach (var instrument in blc.GetInstruments())
            {
                Console.WriteLine(instrument);
            }
            Console.ReadLine();
        }
    }
}
