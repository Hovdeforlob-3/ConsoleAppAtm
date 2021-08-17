using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAtm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter you´re pinkode:");
            string usrPin = Console.ReadLine();

            int pin = ValidtPin(usrPin);

            if (Bank.CheakPin(pin))
            {
                Bankakont Konto = Bank.FindKonto(pin);
                Console.WriteLine("Enter you´re Amount:");
                string usrAmount = Console.ReadLine();

                int amount = ValidtAmount(usrAmount);

                if (Bank.CheakMonnyIsEnough(Konto, amount))
                {
                    Bank.ExtratMonny(Konto, amount);
                    Console.WriteLine("200 ok");
                }
                else
                    throw new ArgumentException("You entede in an invalid amount", "amount");
               
            }
            else
                throw new ArgumentException("You entede in an invalid pin", "pinkode");

            Console.ReadKey();
        }

        static int ValidtAmount(string input)
        {
            if (input.Length >= 1 && input.All(char.IsDigit))
            {
                int amount = Convert.ToInt32(input);
                return amount;
            }
            else
            {
                throw new ArgumentException("You entede in an invalid number of number or you have use char´s ", "Amount");
            }
        }

        static int ValidtPin(string input)
        {
            if (input.Length == 4 && input.All(char.IsDigit))
            {
                int pin = Convert.ToInt32(input);
                return pin;
            }
            else
            {
                throw new ArgumentException("You entede in an invalid number of number or you have use char´s ", "pinKode");
            }
        }
    }
}

