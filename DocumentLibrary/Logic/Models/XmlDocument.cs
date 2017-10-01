using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Logic.Models
{
    [Serializable]
    [XmlRoot(ElementName = "Document")]
    public class XmlDocument
    {
        [XmlElement(ElementName = "Car")]
        public List<XmlCar> Cars { get; set; }
        public XmlDocument() { }

        public Document GetDocument()
        {
            Document _document = new Document();
            if (Cars != null)
                _document.Cars = Cars.Select(_x => _x.GetCarFromXmlCar()).ToList();
            return _document;            
        }      
    }   

}
