using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Pokedex
{
    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Description
    {
        public string description { get; set; }
        public Language language { get; set; }
    }

    public class Language2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language2 language { get; set; }
        public string name { get; set; }
    }

    public class PokemonSpecies
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonEntry
    {
        public int entry_number { get; set; }
        public PokemonSpecies pokemon_species { get; set; }
    }

    public class RootObject
    {
        public List<Description> descriptions { get; set; }
        public int id { get; set; }
        public bool is_main_series { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<PokemonEntry> pokemon_entries { get; set; }
        public object region { get; set; }
        public List<object> version_groups { get; set; }
    }
}
