using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Models;
using System.Globalization;

namespace Logic.Helpers
{
    public static class BinaryHelper
    {
        public static List<BinaryCar> GetBinaryCars(List<Car> cars)
        {
            List<BinaryCar> _cars = new List<BinaryCar>();
            
            foreach (var car in cars)
            {
                BinaryCar _car = new BinaryCar();
                _car.Date = new byte[8];

                string dateString = car.Date.ToString("ddMMyyyy");
                char[] dateChar = dateString.ToCharArray();
                for (int i = 0; i < dateString.Length; i++)
                    _car.Date[i] = Convert.ToByte(dateChar[i]);
                
                _car.BrandNameLenght = BitConverter.GetBytes((Int16)car.BrandName.Length);
                _car.BrandName = Encoding.Unicode.GetBytes(car.BrandName);
                _car.Price = BitConverter.GetBytes((Int32)car.Price);
                _cars.Add(_car);
                
            }
            return _cars;
        }

        public static Document GetDocument(BinaryDocument document)
        {
            Document _document = new Document();
            Car _car;
            foreach (var car in document.Cars)
            {
                _car = new Car();

                char[] dateChar = new char[car.Date.Length];
                for (int i = 0; i < car.Date.Length; i++)
                    dateChar[i] = Convert.ToChar(car.Date[i]);

                CultureInfo provider = CultureInfo.InvariantCulture;
                _car.Date = DateTime.ParseExact(new string(dateChar), "ddMMyyyy", provider);

                _car.BrandName = Encoding.Unicode.GetString(car.BrandName);
                _car.Price = BitConverter.ToInt32(car.Price, 0);

                _document.Cars.Add(_car);

            }
            return _document;
        }
    }
}
