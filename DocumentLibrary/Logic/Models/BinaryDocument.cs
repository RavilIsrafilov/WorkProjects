using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Models
{
    public class BinaryDocument
    {
        public byte[] Header { get; set; }
        public byte[] RecordsCount { get; set; }
        public List<BinaryCar> Cars { get; set; }
        public BinaryDocument() { }
    }
}
