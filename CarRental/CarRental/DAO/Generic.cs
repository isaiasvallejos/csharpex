using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {

    abstract class Generic<T> {

        private static List<T> list = new List<T>();

        public static void Add(T t) {
            t.GetType().GetProperty("id").SetValue(t, NextId());
            list.Add(t);
        }

        public static T SelectOneById(int id) {
            return list.FirstOrDefault(t => ((int)t.GetType().GetProperty("id").GetValue(t, null)).Equals(id));
        }

        public static T SelectOneByProperty(string prop, string value) {
            return list.FirstOrDefault(t => ((string)t.GetType().GetProperty(prop).GetValue(t, null)).Equals(value));
        }

        public static List<T> SelectAll() {
            return list;
        }

        public static bool isEmpty() {
            return SelectAll().Count() == 0;
        }

        private static int NextId() {
            return list.Count() + 1;
        }

    }

}
