using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {

    class Driver {

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

        // Unique attribute
        public string license {
            get;
            set;
        }

        public Driver(string name, string document, string license) {
            this.name = name;
            this.document = document;
            this.license = license;
        }

    }

}
