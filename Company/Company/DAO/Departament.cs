using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {

    class Departament {

        private static List<Company.Departament> departaments = new List<Company.Departament>();

        public static void Add(Company.Departament departament) {
            departament.id = DAO.Departament.NextId();
            departaments.Add(departament);
        }

        public static Company.Departament SelectOneById(int id) {
            return departaments.FirstOrDefault(departament => departament.id == id);
        }

        public static Company.Departament SelectOneByName(string name) {
            return departaments.FirstOrDefault(departament => departament.name.Equals(name));
        }

        public static List<Company.Departament> SelectAll() {
            return departaments;
        }

        public static bool isEmpty() {
            return DAO.Departament.SelectAll().Count() == 0;
        }

        private static int NextId() {
            return departaments.Count() + 1;
        }

    }

}
