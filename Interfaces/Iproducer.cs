using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProducer
    {
        int ID { get; set; }
        string Name { get; set; }
        int Founded { get; set; }
    }
}
