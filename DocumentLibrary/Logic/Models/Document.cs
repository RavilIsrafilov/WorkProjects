using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Logic.Models
{
    public class Document
    {
        public List<Car> Cars { get; set; }
        public Document()
        {
            Cars = new List<Car>();
        }
    }
}
