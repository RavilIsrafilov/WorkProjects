using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IParser
    {
        Document Read(string pathDocument);
        bool Write(Document document, string path);
    }
}
