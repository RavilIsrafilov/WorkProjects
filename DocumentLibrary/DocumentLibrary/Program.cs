using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Services;
using Logic.Models;

namespace DocumentLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlParser parser = new XmlParser();
            BinaryParser binParser = new BinaryParser();
            Document _document = new Document();
            _document.Cars.Add(new Car { Date = DateTime.Today, BrandName = "asd1231deqd", Price = 121212 });
            _document.Cars.Add(new Car { Date = DateTime.Today, BrandName = "asdsda as ", Price = 12212 });
            _document.Cars.Add(new Car { Date = DateTime.Today, BrandName = "a1", Price = 112212 });

            //binParser.Write(_document, @"C:\Users\IsrafilovR\Desktop\_MyProjects\test35.dat");
            binParser.Read(@"C:\Users\IsrafilovR\Desktop\_MyProjects\test35.dat");

        }
    }
}
