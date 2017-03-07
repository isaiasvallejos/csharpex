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

                }

            } while (running);

        }
    }
}
