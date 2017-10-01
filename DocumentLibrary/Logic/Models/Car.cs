using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Models
{
    [Serializable]
    public class Car
    {
        public DateTime Date { get; set; }
        public string BrandName { get; set; }
        public int Price { get; set; }
        public Car() { }
    }
}
