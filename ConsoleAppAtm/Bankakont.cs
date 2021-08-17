using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAtm
{
    public class Bankakont
    {
        public int PinKode { get; set; }
        public string Name { get; set; }
        public int KontoValue { get; set; }

        public Bankakont(int pinKode, string name, int kontoValue)
        {
            PinKode = pinKode;
            Name = name;
            KontoValue = kontoValue;
        }
    }
}
