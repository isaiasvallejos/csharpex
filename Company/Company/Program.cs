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
                Console.Write("Choose an option: ");

                option = Console.ReadLine();

                switch (option) {

                    case "1":

                        Console.Clear();

                        Console.WriteLine("***** CREATE DEPARTAMENT *****");
                        Console.Write("\n");

                        Console.Write("Departament: (name) ");
                        string departamentName = Console.ReadLine();

                        if (DAO.Departament.SelectOneByName(departamentName) != null) {
                            Console.WriteLine("\nDepartament name already registred.");

                            break;
                        }

                        Departament departament = new Departament(departamentName);

                        DAO.Departament.Add(departament);

                        Console.WriteLine("\nDepartment #{0} registered successfully!", departament.id);

                        break;

                    case "2":

                        Console.Clear();

                        Console.WriteLine("***** REGISTER EMPLOYEE *****");
                        Console.Write("\n");

                        if (DAO.Departament.isEmpty()) {
                            Console.WriteLine("Employees needs a department registred.");

                            break;
                        }

                        Console.Write("Employee: (name) ");
                        string employeeName = Console.ReadLine();

                        Console.Write("Employee: (document) ");
                        string employeeDocument = Console.ReadLine();

                        if (DAO.Employee.SelectOneByDocument(employeeDocument) != null) {
                            Console.WriteLine("\nEmployee document already registred.");

                            break;
                        }

                        Console.Write("Departament: (name) ");
                        Departament employeeDepartament = DAO.Departament.SelectOneByName(Console.ReadLine());

                        if (employeeDepartament == null) {
                            Console.WriteLine("\nDepartament not found.");

                            break;
                        }

                        Employee employee = new Employee(employeeName, employeeDocument, employeeDepartament);

                        DAO.Employee.Add(employee);

                        Console.WriteLine("\nEmployee #{0} registered successfully!", employee.id);

                        break;

                    case "3":

                        Console.Clear();

                        Console.WriteLine("***** CONSULT DEPARTAMENT *****");
                        Console.Write("\n");

                        if (DAO.Departament.isEmpty()) {
                            Console.WriteLine("No registered departments.");

                            break;
                        }

                        Console.Write("Departament: (name) ");
                        List<Employee> departamentEmployees = DAO.Employee.SelectAllByDepartament(
                            DAO.Departament.SelectOneByName(Console.ReadLine())
                        );

                        Console.Write("\n");

                        if(departamentEmployees.Count() == 0) {
                            Console.Write("Departament is empty.\n");
                        } else {
                            Console.WriteLine("Employees in departament: ");
                            foreach (Employee departamentEmployee in departamentEmployees) {
                                Console.Write("- {0}\n", departamentEmployee.name);
                            }
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
