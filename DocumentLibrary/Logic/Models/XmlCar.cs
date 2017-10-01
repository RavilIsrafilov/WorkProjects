using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Logic.Models
{
    [Serializable]
    public class XmlCar
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement(ElementName = "Date")]
        public string DateString
        {
            get { return Date.ToString("dd.MM.yyyy"); }
            set { Date = DateTime.Parse(value); }
        }
        public string BrandName { get; set; }
        public int Price { get; set; }
        public XmlCar() { }

        public Car GetCarFromXmlCar()
        {
            return new Car { Date = Date, Price = Price, BrandName = BrandName };
            //DateTime _date;            
            //int _price;

            //if (int.TryParse(Price, out _price)) //&& DateTime.TryParseExact(Date, pattern, null, System.Globalization.DateTimeStyles.None, out _date))
            //    return new Car { Date = Date, Price = _price, BrandName = BrandName };
            //else
            //    return null;
        }
    }
}
