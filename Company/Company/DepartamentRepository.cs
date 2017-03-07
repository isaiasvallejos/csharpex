using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company {

    class DepartamentRepository {

        private static List<Departament> departaments = new List<Departament>();

        public static void Add(Departament departament) {
            departament.id = DepartamentRepository.NextId();
            departaments.Add(departament);
        }

        public static Departament SelectOneById(int id) {
            return departaments.FirstOrDefault(departament => departament.id == id);
        }

        public static Departament SelectOneByName(string name) {
            return departaments.FirstOrDefault(departament => departament.name.Equals(name));
        }

        public static List<Departament> SelectAll() {
            return departaments;
        }

        private static int NextId() {
            return departaments.Count() + 1;
        }

    }

}
