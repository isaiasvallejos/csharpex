using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company {

    class Departament {
        // Key attribute
        public int id {
            get;
            set;
        }

        // Unique attribute
        public string name {
            get;
            set;
        }

        public Departament(string name) {
            this.id = DepartamentRepository.NextId();
            this.name = name;
        }

    }

}
