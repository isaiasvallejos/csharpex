using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company {

    class Program {

        static void Main(string[] args) {

            bool running = true;
            string option;

            do {

                Console.Clear();

                Console.WriteLine("***** COMPANY *****");
                Console.Write("\n");
                Console.WriteLine("1 - Create departament");
                Console.WriteLine("2 - Register employee");
                Console.WriteLine("3 - Consult departament");
                Console.WriteLine("4 - Exit");
                Console.Write("\n");
                Console.Write("Selecione uma opção: ");

                option = Console.ReadLine();

                switch (option) {

                    case "1":

                        Console.Clear();

                        Console.WriteLine("***** CREATE DEPARTAMENT *****");
                        Console.Write("\n");

                        Console.Write("Departament: (name) ");
                        string departamentName = Console.ReadLine();

                        if (DepartamentRepository.SelectOneByName(departamentName) != null) {
                            Console.WriteLine("\nDepartament name already registred.");

                            break;
                        }

                        Departament departament = new Departament(departamentName);

                        DepartamentRepository.Add(departament);

                        Console.WriteLine("\nDepartment registered successfully!");

                        break;

                    case "2":

                        Console.Clear();

                        Console.WriteLine("***** REGISTER EMPLOYEE *****");
                        Console.Write("\n");

                        Console.Write("Employee: (name) ");
                        string employeeName = Console.ReadLine();

                        Console.Write("Employee: (document) ");
                        string employeeDocument = Console.ReadLine();

                        if (EmployeeRepository.SelectOneByDocument(employeeDocument) != null) {
                            Console.WriteLine("\nEmployee document already registred.");

                            break;
                        }

                        Console.Write("Departament: (name) ");
                        Departament employeeDepartament = DepartamentRepository.SelectOneByName(Console.ReadLine());

                        if (employeeDepartament == null) {
                            Console.WriteLine("\nDepartament not found.");

                            break;
                        }

                        Employee employee = new Employee(employeeName, employeeDocument, employeeDepartament);

                        EmployeeRepository.Add(employee);

                        Console.WriteLine("\nEmployee registered successfully!");

                        break;

                    case "3":

                        Console.Clear();

                        Console.WriteLine("***** CONSULT DEPARTAMENT *****");
                        Console.Write("\n");

                        Console.Write("Departament: (name) ");
                        List<Employee> departamentEmployees = EmployeeRepository.SelectAllByDepartament(
                            DepartamentRepository.SelectOneByName(Console.ReadLine())
                        );

                        Console.Write("\n");

                        Console.WriteLine("Employees in departament: ");

                        foreach (Employee departamentEmployee in departamentEmployees) {
                            Console.Write("- {0}\n", departamentEmployee.name);
                        }

                        break;

                    case "4":

                        running = false;

                        Console.WriteLine("\nBye, bye!");

                        break;

                    default:

                        Console.Clear();

                        Console.WriteLine("***** ERROR *****");
                        Console.WriteLine("\nEnter a valid option.");

                        break;

                }

                if (running) {
                    Console.Write("\nPlease, press any key to back to menu.");
                }

                Console.ReadLine();

            } while (running);

        }
    }

}
