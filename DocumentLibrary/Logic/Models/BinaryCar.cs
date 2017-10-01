using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logic.Models
{
    public class BinaryCar
    {
        public byte[] Date { get; set; }
        public byte[] BrandName { get; set; }
        public byte[] BrandNameLenght { get; set; }
        public byte[] Price { get; set; }
        public BinaryCar() { }
    }

}

