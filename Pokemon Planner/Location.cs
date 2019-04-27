using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Location
{
    public class EncounterMethod
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionDetail
    {
        public int rate { get; set; }
        public Version version { get; set; }
    }

    public class EncounterMethodRate
    {
        public EncounterMethod encounter_method { get; set; }
        public List<VersionDetail> version_details { get; set; }
    }

    public class Location
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

    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class EncounterDetail
    {
        public int chance { get; set; }
        public List<ConditionValue> condition_values { get; set; }
        public int max_level { get; set; }
        public Method method { get; set; }
        public int min_level { get; set; }
    }

    public class ConditionValue
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionDetail2
    {
        public List<EncounterDetail> encounter_details { get; set; }
        public int max_chance { get; set; }
        public Version2 version { get; set; }
    }

    public class PokemonEncounter
    {
        public Pokemon pokemon { get; set; }
        public List<VersionDetail2> version_details { get; set; }
    }

    public class RootObject
    {
        public List<EncounterMethodRate> encounter_method_rates { get; set; }
        public int game_index { get; set; }
        public int id { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<PokemonEncounter> pokemon_encounters { get; set; }
    }
}
