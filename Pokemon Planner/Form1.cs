﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace Pokemon_Planner
{
    public partial class FormMain : Form
    {
        public static ArrayList names = new ArrayList();
        static HttpClient client = new HttpClient();
        ArrayList placeUrl = new ArrayList();
        ArrayList placeNames = new ArrayList();
        ArrayList filteredUrl = new ArrayList();
        Dictionary<string, string> pokemonCache = new Dictionary<string, string>();
        Dictionary<string, string> conditionCache = new Dictionary<string, string>();
        Dictionary<string, string> gameCache = new Dictionary<string, string>();
        Dictionary<string, string> methodCache = new Dictionary<string, string>();
        Dictionary<string, int> pokedexIndex = new Dictionary<string, int>();
        HashSet<string> pokedex = new HashSet<string>();
        string currentLocationJson;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //writing dll files to base directory
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Newtonsoft.Json.dll", Properties.Resources.Newtonsoft_Json);
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "System.Net.Http.Formatting.dll", Properties.Resources.System_Net_Http_Formatting);
            StreamWriter pokedexCreation = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "pokedex.dat", append:true);//creates a dex if it does not exist
            pokedexCreation.Close();
            StreamReader pokedexReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "pokedex.dat");
            string lineRead = pokedexReader.ReadLine();
            while (lineRead != null)
            {
                pokedex.Add(lineRead);
                lineRead = pokedexReader.ReadLine();
            }
            pokedexReader.Close();
            //Loading list
            StringReader sr = new StringReader(Properties.Resources.places);
            string[] SeperatedLine;
            lineRead = sr.ReadLine();
            while (lineRead != null)
            {
                SeperatedLine = lineRead.Split(new[] { "," }, StringSplitOptions.None);
                listBoxLocations.Items.Add(SeperatedLine[0]);
                placeNames.Add(SeperatedLine[0]);
                placeUrl.Add(SeperatedLine[2]);
                lineRead = sr.ReadLine();
            }
            for (int i = 0; i < placeUrl.Count; i++)
            {
                filteredUrl.Add(i);
            }
            LoadAllPokemon();
        }

        public string ApiRequest(string path)
        {
            var response = client.GetAsync(path).Result;
            string jsonRead;
            if (response.IsSuccessStatusCode)
            {
                jsonRead = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("Failed to get data from path: " + Environment.NewLine + Environment.NewLine + path,"API Request Failed");
                jsonRead = null;
            }
            return jsonRead;
        }

        public void GetPokemon(string json)
        {
            progressBar1.Value = 0;
            flowLayoutPanelPokemon.Controls.Clear();
            List<Tuple<string, string, string>> pokeInfo = new List<Tuple<string, string, string>>();//name, url of image, tag
            List<string> pokeAdded = new List<string>();
            var result = JsonConvert.DeserializeObject<Pokemon_Location.RootObject>(json);
            int noEncounters = result.pokemon_encounters.Count;
            progressBar1.Maximum = noEncounters;
            for (int poke = 0; poke < noEncounters; poke++)
            {
                if (!pokeAdded.Contains(result.pokemon_encounters.ElementAt(poke).pokemon.name))
                {
                    string pokeTag = result.pokemon_encounters.ElementAt(poke).pokemon.name;
                    pokeAdded.Add(pokeTag);
                    string pokeJson = ApiRequest(Convert.ToString(result.pokemon_encounters.ElementAt(poke).pokemon.url));
                    var pokeData = JsonConvert.DeserializeObject<Pokemon_Details.RootObject>(pokeJson);
                    string imageUrl = pokeData.sprites.front_default;

                    string pokeName = "";
                    if (pokemonCache.ContainsKey(pokeTag))
                    {
                        pokeName = pokemonCache[pokeTag];
                    }
                    else
                    {
                        string pokeNameJson = ApiRequest(pokeData.species.url);
                        var pokeSpeciesData = JsonConvert.DeserializeObject<Pokemon_Species.RootObject>(pokeNameJson);
                        for (int language = 0; language < pokeSpeciesData.names.Count; language++)
                        {
                            if (pokeSpeciesData.names.ElementAt(language).language.name == "en")
                            {
                                pokeName = pokeSpeciesData.names.ElementAt(language).name;
                                pokemonCache.Add(pokeTag, pokeName);
                                language = pokeSpeciesData.names.Count;//end for loop 
                            }
                        }
                    }
                    pokeInfo.Add(new Tuple<string, string, string>(pokeName, imageUrl, pokeTag));

                }
                progressBar1.Value = poke + 1;
            }
            for (int i = 0; i < pokeInfo.Count; i++)
            {
                PokemonPicture pp = new PokemonPicture();
                flowLayoutPanelPokemon.Controls.Add(pp);
                pp.SetName(pokeInfo.ElementAt(i).Item1);
                pp.SetPicture(pokeInfo.ElementAt(i).Item2);
                pp.SetTag(pokeInfo.ElementAt(i).Item3);
                pp.MouseClick += new MouseEventHandler(PokemonPicture_Click);
                pp.Controls[0].MouseClick += new MouseEventHandler(PokemonPicture_Click);
                pp.Controls[1].MouseClick += new MouseEventHandler(PokemonPicture_Click);
                if (pokedexIndex.ContainsKey(pokeInfo.ElementAt(i).Item3))
                {
                    if (pokedex.Contains(Convert.ToString(pokedexIndex[pokeInfo.ElementAt(i).Item3])))
                    {
                        pp.Disable();
                    }
                }
            }
        }

        private void listBoxLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewPokemonTable.Rows.Clear();
            int url = Convert.ToInt32(filteredUrl[listBoxLocations.SelectedIndex]);
            string jsonRead = ApiRequest(Convert.ToString(placeUrl[url]));
            currentLocationJson = jsonRead;
            if (jsonRead != null)
            {
                labelCurrentlySelected.Text = "Currently Selected: " + listBoxLocations.SelectedItem;
                GetPokemon(jsonRead);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filteredUrl.Clear();
            listBoxLocations.Items.Clear();
            for (int name = 0; name < placeNames.Count; name++)
            {
                if (Convert.ToString(placeNames[name]).ToLower().Contains(Convert.ToString(textBox1.Text).ToLower()))
                {
                    listBoxLocations.Items.Add(placeNames[name]);
                    filteredUrl.Add(Convert.ToInt32(name));
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        //dict     game              method             condition      min   max  chance
        Dictionary<string, Dictionary<string, Dictionary<string, Tuple<int, int, int>>>> locationData = new Dictionary<string, Dictionary<string, Dictionary<string, Tuple<int, int, int>>>>();
        private void PokemonPicture_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                //deselect all but clicked object
                for (int i = 0; i < flowLayoutPanelPokemon.Controls.Count; i++)
                {
                    PokemonPicture pp1 = (PokemonPicture)flowLayoutPanelPokemon.Controls[i];
                    pp1.Deselect();
                }
                PokemonPicture pp;
                if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    PictureBox pb = (PictureBox)sender;
                    pp = (PokemonPicture)pb.Parent;
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Label pl = (Label)sender;
                    pp = (PokemonPicture)pl.Parent;
                }
                else
                {
                    pp = (PokemonPicture)sender;
                }
                string tag = pp.PokemonSelected();
                progressBar1.Value = 0;
                //get location information

                locationData.Clear();
                var location = JsonConvert.DeserializeObject<Pokemon_Location.RootObject>(currentLocationJson);
                var pokemon = from p in location.pokemon_encounters
                              where p.pokemon.name == tag
                              select p;
                foreach (var version in pokemon.ElementAt(0).version_details)
                {
                    string game;
                    if (gameCache.ContainsKey(version.version.name))
                    {
                        game = gameCache[version.version.name];
                    }
                    else
                    {
                        string gameJson = ApiRequest(version.version.url);
                        var gameData = JsonConvert.DeserializeObject<Pokemon_Game.RootObject>(gameJson);
                        var theGame = from l in gameData.names
                                      where l.language.name == "en"
                                      select l;
                        game = theGame.ElementAt(0).name;
                        gameCache.Add(version.version.name, theGame.ElementAt(0).name);
                    }
                    if (!locationData.ContainsKey(game))
                    {
                        locationData.Add(game, new Dictionary<string, Dictionary<string, Tuple<int, int, int>>>());
                    }
                    string methodType;
                    foreach (var encounter in version.encounter_details)
                    {
                        string condition = "none";
                        //methodType = encounter.method.name;
                        if (methodCache.ContainsKey(encounter.method.name))
                        {
                            methodType = methodCache[encounter.method.name];
                        }
                        else
                        {
                            string methodJson = ApiRequest(encounter.method.url);
                            var methodData = JsonConvert.DeserializeObject<Pokemon_Game.RootObject>(methodJson);
                            var theMethod = from l in methodData.names
                                            where l.language.name == "en"
                                            select l;
                            methodType = theMethod.ElementAt(0).name;
                            methodCache.Add(encounter.method.name, theMethod.ElementAt(0).name);
                        }
                        if (!locationData[game].ContainsKey(methodType))
                        {
                            locationData[game].Add(methodType, new Dictionary<string, Tuple<int, int, int>>());
                        }
                        if (locationData[game][methodType].ContainsKey("none") == false && encounter.condition_values.Count == 0)
                        {
                            locationData[game][methodType].Add("none", new Tuple<int, int, int>(100, 0, 0));
                        }
                        if (encounter.condition_values.Count > 0)
                        {
                            condition = "";
                            foreach (var conditions in encounter.condition_values)
                            {
                                if (conditionCache.ContainsKey(conditions.name))
                                {
                                    condition += conditionCache[conditions.name];
                                }
                                else
                                {
                                    string conditionJson = ApiRequest(conditions.url);
                                    var conditionData = JsonConvert.DeserializeObject<Pokemon_Condition.RootObject>(conditionJson);
                                    var name = from l in conditionData.names
                                               where l.language.name == "en"
                                               select l;
                                    condition += name.ElementAt(0).name;
                                    conditionCache.Add(conditions.name, name.ElementAt(0).name);
                                }
                                condition += " - ";
                            }
                            condition = condition.Remove(condition.Length - 3, 3);
                            if (!locationData[game][methodType].ContainsKey(condition))
                            {
                                locationData[game][methodType].Add(condition, new Tuple<int, int, int>(100, 0, 0));
                            }
                        }
                        int min = locationData[game][methodType][condition].Item1;
                        int max = locationData[game][methodType][condition].Item2;
                        int chance = locationData[game][methodType][condition].Item3;
                        if (encounter.min_level < min)
                        {
                            min = encounter.min_level;
                        }
                        if (encounter.max_level > max)
                        {
                            max = encounter.max_level;
                        }
                        chance += encounter.chance;
                        locationData[game][methodType][condition] = new Tuple<int, int, int>(min, max, chance);
                    }
                }
                dataGridViewPokemonTable.Rows.Clear();
                foreach (var game in locationData)
                {
                    foreach (var method in game.Value)
                    {
                        foreach (var condition in method.Value)
                        {
                            string conditionToWrite = condition.Key;
                            if (conditionToWrite == "none")
                            {
                                conditionToWrite = "";
                            }
                            dataGridViewPokemonTable.Rows.Add(game.Key, method.Key, method.Value[condition.Key].Item1 + " - " + method.Value[condition.Key].Item2, method.Value[condition.Key].Item3 + "%", conditionToWrite);
                        }
                    }
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                PokemonPicture pp;
                if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    PictureBox pb = (PictureBox)sender;
                    pp = (PokemonPicture)pb.Parent;
                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Label pl = (Label)sender;
                    pp = (PokemonPicture)pl.Parent;
                }
                else
                {
                    pp = (PokemonPicture)sender;
                }
                if (pokedexIndex.ContainsKey(Convert.ToString(pp.Tag)))
                {
                    if (!pokedex.Contains(Convert.ToString(pokedexIndex[Convert.ToString(pp.Tag)])))
                    {
                        pokedex.Add(Convert.ToString(pokedexIndex[Convert.ToString(pp.Tag)]));
                        pp.Disable();
                    }
                    else
                    {
                        MessageBox.Show("a");
                    }
                    UpdateNodes();
                }
            }
        }

        private void DataGridViewPokemonTable_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewPokemonTable.ClearSelection();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
             
        }

        private void LoadAllPokemon()//used for initially loading all pokemon
        {
            string listJson = ApiRequest("https://pokeapi.co/api/v2/pokedex?limit=100");
            var pokedexListData = JsonConvert.DeserializeObject<Pokemon_PokedexList.RootObject>(listJson);
            int index = -1;
            for (int i = 0; i < pokedexListData.results.Count; i++)
            {
                string pokedexJson = ApiRequest(pokedexListData.results.ElementAt(i).url);
                var pokedexData = JsonConvert.DeserializeObject<Pokemon_Pokedex.RootObject>(pokedexJson);
                var name = from l in pokedexData.names
                           where l.language.name == "en"
                           select l;
                var tooltip = from l in pokedexData.descriptions
                           where l.language.name == "en"
                           select l;
                if (pokedexData.is_main_series)
                {
                    index++;
                    treeViewPokedex.Nodes.Add(name.ElementAt(0).name);
                    treeViewPokedex.Nodes[index].ToolTipText = tooltip.ElementAt(0).description;
                    foreach (var entry in pokedexData.pokemon_entries)
                    {
                        int dexId;
                        if (pokedexIndex.ContainsKey(entry.pokemon_species.name))
                        {
                            dexId = pokedexIndex[entry.pokemon_species.name];
                        }
                        else if (pokedexData.id == 1)
                        {
                            pokedexIndex.Add(entry.pokemon_species.name, entry.entry_number);
                            dexId = entry.entry_number;
                        }
                        else
                        {
                            dexId = -1;
                            MessageBox.Show("Unknown pokemon found: " + entry.pokemon_species.name);
                        }
                        treeViewPokedex.Nodes[index].Nodes.Add(Convert.ToString(dexId), entry.pokemon_species.name.First().ToString().ToUpper() + entry.pokemon_species.name.Substring(1));
                        UpdateNodes();
                    }
                }
            }
        }

        private void TreeViewPokedex_AfterSelect(object sender, TreeViewEventArgs e)
        {

            MessageBox.Show(Convert.ToString(e.Node.Name));
        }

        private void TreeViewPokedex_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Checked)
            {
                if (pokedex.Contains(e.Node.Name))
                {
                    pokedex.Remove(e.Node.Name);
                }
            }
            else
            {
                pokedex.Add(e.Node.Name);
            }
            UpdateNodes();
        }

        private void UpdateNodes()
        {
            foreach (TreeNode node in treeViewPokedex.Nodes)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    if (pokedex.Contains(child.Name) && child.Checked == false)
                    {
                        child.Checked = true;
                    }
                    else if (!pokedex.Contains(child.Name) && child.Checked)
                    {
                        child.Checked = false;
                    }
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter pokeWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "pokedex.dat");
            for (int i = 0; i < pokedex.Count; i++)
            {
                pokeWriter.WriteLine(pokedex.ElementAt(i));
            }
            pokeWriter.Close();
        }
    }
}
