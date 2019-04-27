using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Condition
{
    public class Condition
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public Condition condition { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
    }
}
