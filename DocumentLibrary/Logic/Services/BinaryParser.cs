using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Logic.Interfaces;
using Logic.Models;
using Logic.Helpers;

namespace Logic.Services
{
    public class BinaryParser:IParser
    {
        public Document Read(string pathDocument)
        {
            BinaryDocument _doc = new BinaryDocument();

            using (BinaryReader reader = new BinaryReader(File.Open(pathDocument, FileMode.Open)))
            {
                _doc.Header = reader.ReadBytes(2);
                _doc.RecordsCount = reader.ReadBytes(4);

                int requests = BitConverter.ToInt32(_doc.RecordsCount, 0);
                if(requests!=0)
                    _doc.Cars = new List<BinaryCar>();

                BinaryCar _car;
                for (int i = 0; i < requests; i++) 
                {
                    _car = new BinaryCar();
                    _car.Date = reader.ReadBytes(8);
                    _car.BrandNameLenght = reader.ReadBytes(2);

                    int nameLenght = BitConverter.ToInt16(_car.BrandNameLenght, 0);
                    _car.BrandName = reader.ReadBytes(nameLenght*2);
                    _car.Price = reader.ReadBytes(4);

                    _doc.Cars.Add(_car);
                }
            }

            return BinaryHelper.GetDocument(_doc);
        }
        public bool Write(Document document, string pathDocument)
        {
            BinaryDocument _doc = new BinaryDocument();
            _doc.Header = BitConverter.GetBytes((Int16)(0x2526));
            _doc.RecordsCount = BitConverter.GetBytes((Int32)document.Cars.Count);
            _doc.Cars = BinaryHelper.GetBinaryCars(document.Cars);

            using (BinaryWriter writer = new BinaryWriter(File.Open(pathDocument, FileMode.OpenOrCreate)))
            {
                writer.Write(_doc.Header);
                writer.Write(_doc.RecordsCount);
                foreach (var car in _doc.Cars)
                {
                    writer.Write(car.Date);
                    writer.Write(car.BrandNameLenght);
                    writer.Write(car.BrandName);
                    writer.Write(car.Price);
                }
            }
            return true;
        }
    }
}
