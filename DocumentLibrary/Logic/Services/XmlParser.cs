using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Logic.Models;
using Logic.Interfaces;
using Logic.Helper;

using XmlDocument = Logic.Models.XmlDocument;

namespace Logic.Services
{
    public class XmlParser:IParser
    {
        public Document Read(string pathDocument)
        {
            XmlDocument _document = new XmlDocument();
            _document.Cars = new List<XmlCar>();

            XmlSerializer formatter = new XmlSerializer(typeof(XmlDocument));
            using (FileStream fs = new FileStream(pathDocument, FileMode.OpenOrCreate))
            {
                _document = (XmlDocument)formatter.Deserialize(fs);
            }

            Document document = _document.GetDocument();            
            return document;
        }
        public bool Write(Document document,string pathDocument)
        {
            XmlDocument _document = XmlHelper.GetXmlDocumentFromDocument(document);            
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer formatter = new XmlSerializer(typeof(XmlDocument));
            XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
            {
                CloseOutput = false,
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = false,
                Indent = true
            };

            using (FileStream fs = new FileStream(pathDocument, FileMode.OpenOrCreate))
            {
                using (var wrXml = XmlWriter.Create(fs, xmlWriterSettings))
                {
                    formatter.Serialize(wrXml, _document, ns);                    
                }
            }
            return true;
        }
    }
}





//StringBuilder output = new StringBuilder();
//XmlTextReader reader = new XmlTextReader(path);

//while (reader.Read())
//{                
//    switch (reader.NodeType)
//    {
//        case XmlNodeType.Element:
//            output.AppendLine("<" + reader.Name + ">");                        
//            break;
//        case XmlNodeType.Text:
//            output.AppendLine(reader.Value);
//            break;
//        case XmlNodeType.EndElement:
//            output.AppendLine("</" + reader.Name + ">");                        
//            break;
//    }
//}

//Car car;
//XDocument xdoc = XDocument.Load(path);
//foreach (XElement carElement in xdoc.Element("Document").Elements("Car"))
//{
//    XElement dateElement = carElement.Element("Date");
//    XElement priceElement = carElement.Element("Price");
//    XElement brandNameElement = carElement.Element("BrandName");

//    if (dateElement != null && priceElement != null && brandNameElement != null)
//    {
//        car = new Car();
//        double price;
//        double.TryParse(priceElement.Value, out price);
//        DateTime date;
//        DateTime.TryParse(dateElement.Value, out date);

//        car.BrandName = brandNameElement.Value;
//        car.Price = price;
//        car.Date = date;

//        document.Cars.Add(car);
//    }                
//}

//return document;