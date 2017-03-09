using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {

    class Employee {

        private static List<Company.Employee> employees = new List<Company.Employee>();

        public static void Add(Company.Employee employee) {
            employee.id = DAO.Employee.NextId();
            employees.Add(employee);
        }

        public static Company.Employee SelectOneById(int id) {
            return employees.FirstOrDefault(employee => employee.id == id);
        }

        public static Company.Employee SelectOneByDocument(string document) {
            return employees.FirstOrDefault(employee => employee.document.Equals(document));
        }

        public static List<Company.Employee> SelectAll() {
            return employees;
        }

        public static List<Company.Employee> SelectAllByDepartament(Company.Departament departament) {
            return employees.Where(employee => employee.departament.Equals(departament)).ToList();
        }

        public static bool isEmpty() {
            return DAO.Employee.SelectAll().Count() == 0;
        }

        private static int NextId() {
            return employees.Count() + 1;
        }

    }

}