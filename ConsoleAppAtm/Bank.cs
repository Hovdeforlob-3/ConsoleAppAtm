using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAtm
{
    public class Bank
    {
      public  static List<Bankakont> bKonto = new List<Bankakont> 
       { 
           new Bankakont (1234, "Marius", 10000),
           new Bankakont (4321, "Jens", 120000),
           new Bankakont (3476, "Jeff", 10000000)
       };

        public static bool CheakPin(int usrTypedPin)
        {
            foreach (var item in bKonto)
            {
                if (item.PinKode == usrTypedPin)
                    return true;
            }
            return false;
        }

        public static Bankakont FindKonto(int usrTypedPin)
        {
            return bKonto.Find(p => p.PinKode == usrTypedPin);
        }

        public static void ExtratMonny(Bankakont konto, int usrAmunot)
        {
            konto.KontoValue = konto.KontoValue - usrAmunot;
        }

        public static void AddNewkonto(List<Bankakont> kontolst, Bankakont newKonto)
        {
            if (string.IsNullOrWhiteSpace(newKonto.Name))
            {
                throw new ArgumentException("You entede in invalid parameter", "Name"); 
            }

            kontolst.Add(newKonto);
        }

        public static bool CheakMonnyIsEnough(Bankakont Konto, int usrTypedValue)
        {
            if (Konto.KontoValue >= usrTypedValue)
            {
                return true;
            }
            return false;
        }
    }
}
