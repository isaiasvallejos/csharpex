using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {

    class Trip {

        // Key attribute
        public int id {
            get;
            set;
        }

        public string start {
            get;
            set;
        }

        public string finish {
            get;
            set;
        }

        public DateTime date {
            get;
            set;
        }

        public Vehicle vehicle {
            get;
            set;
        }

        public Driver driver {
            get;
            set;
        }

        public List<TripUser> users {
            get;
            set;
        }

        public Trip(string start, string finish, DateTime date, Vehicle vehicle, Driver driver, List<TripUser> users) {
            this.start = start;
            this.finish = finish;
            this.date = date;
            this.vehicle = vehicle;
            this.driver = driver;
            this.users = users;
        }

    }

}
