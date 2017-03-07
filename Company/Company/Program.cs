using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {

            bool running = true;
            string option;

            do
            {

                Console.Clear();

                Console.WriteLine("***** COMPANY *****");
                Console.Write("\n");
                Console.WriteLine("1 - Create departament");
                Console.WriteLine("2 - Register employee");
                Console.WriteLine("3 - Consult departament");
                Console.Write("\n");
                Console.Write("Selecione uma opção: ");

                option = Console.ReadLine();

                switch (option)
                {

                    case "1":

                        Console.Clear();

                        Console.WriteLine("***** CREATE DEPARTAMENT *****");
                        Console.Write("\n");
                        Console.ReadLine();

                        Console.Write("Press any key to back to menu.");
                        Console.ReadLine();
                       
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        break;

                }

            } while (running);

        }
    }
}
