﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock1.BO
{
    public class Producent : IProducer
    {
        public int ID { get ; set; }
        public string Name { get; set; }
        public int Founded { get; set; }

        public override string ToString()
        {
            return $"Nazwa: {Name} ({Founded})";
        }
    }
}
