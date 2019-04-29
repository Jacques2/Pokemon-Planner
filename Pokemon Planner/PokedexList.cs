using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_PokedexList
{
    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
