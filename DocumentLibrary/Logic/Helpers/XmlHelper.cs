using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Models;

namespace Logic.Helper
{
    public static class XmlHelper
    {
        public static XmlDocument GetXmlDocumentFromDocument(Document document)
        {
            XmlDocument _document = new XmlDocument();
            _document.Cars = document.Cars.Select(_x => GetXmlCarFromCar(_x)).ToList();
            return _document;
        }
        public static XmlCar GetXmlCarFromCar(Car car)
        {
            return new XmlCar { BrandName = car.BrandName, Date = car.Date, Price = car.Price };
        }
    }
}
