using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {

    class TripUser {

        public User user {
            get;
            set;
        }

        public bool hasBaggage;

        public TripUser(User user, bool hasBaggage) {
            this.user = user;
            this.hasBaggage = hasBaggage;
        }

    }

}
