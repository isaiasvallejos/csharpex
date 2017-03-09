using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {

    class User {

        // Key attribute
        public int id {
            get;
            set;
        }

        public string name {
            get;
            set;
        }

        // Unique attribute
        public string document {
            get;
            set;
        }

        public User(string name, string document) {
            this.name = name;
            this.document = document;
        }

    }

}
