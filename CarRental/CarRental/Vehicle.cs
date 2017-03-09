using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {

    class Vehicle {

        // Key attribute
        public int id {
            get;
            set;
        }

        public string brand {
            get;
            set;
        }

        // Unique attribute
        public string board {
            get;
            set;
        }

        public Vehicle(string brand, string board) {
            this.brand = brand;
            this.board = board;
        }

    }

}
