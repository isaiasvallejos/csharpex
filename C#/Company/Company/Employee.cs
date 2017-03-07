using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Employee
    {
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        // Unique attribute
        public string document
        {
            get;
            set;
        }

        public Departament departament
        {
            get;
            set;
        }

    }
}
