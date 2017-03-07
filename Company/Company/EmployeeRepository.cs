using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company {

    class EmployeeRepository {

        private static List<Employee> employees = new List<Employee>();

        public static void Add(Employee employee) {
            employee.id = EmployeeRepository.NextId();
            employees.Add(employee);
        }

        public static Employee SelectOneById(int id) {
            return employees.FirstOrDefault(employee => employee.id == id);
        }

        public static Employee SelectOneByDocument(string document) {
            return employees.FirstOrDefault(employee => employee.document.Equals(document));
        }

        public static List<Employee> SelectAll() {
            return employees;
        }

        public static List<Employee> SelectAllByDepartament(Departament departament) {
            return employees.Where(employee => employee.departament.Equals(departament)).ToList();
        }

        public static int NextId() {
            return employees.Count() + 1;
        }

    }

}