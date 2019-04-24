using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace Pokemon_Planner
{
    public partial class Form1 : Form
    {
        public static ArrayList names = new ArrayList();
        static HttpClient client = new HttpClient();
        ArrayList placeUrl = new ArrayList();
        ArrayList placeNames = new ArrayList();
        ArrayList filteredUrl = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Loading list
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"Data\places.csv");
            string[] SeperatedLine;
            string lineRead = sr.ReadLine();
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
        }
        
        public void GetLocation(string path)
        {
            var response = client.GetAsync(path).Result;
            dataGridViewPokemonTable.Rows.Clear();
            if (response.IsSuccessStatusCode)
            {
                string jsonRead = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Pokemon_Location.RootObject>(jsonRead);
                for (int poke = 0; poke < result.pokemon_encounters.Count; poke++)
                {
                    for (int version = 0; version < result.pokemon_encounters[poke].version_details.Count; version++)
                    {
                        string name = result.pokemon_encounters[poke].pokemon.name;
                        string method = "";
                        int chance = 0;
                        for (int encounter = 0; encounter < result.pokemon_encounters[poke].version_details[version].encounter_details.Count; encounter++)
                        {
                            if (encounter != 0)
                            {
                                method += ", ";
                            }
                            method += result.pokemon_encounters[poke].version_details[version].encounter_details[encounter].method.name;
                            chance += result.pokemon_encounters[poke].version_details[version].encounter_details[encounter].chance;
                        }
                        string pVersion = result.pokemon_encounters[poke].version_details[version].version.name;
                        object conditions = "";
                        /*if (result.pokemon_encounters[poke].version_details[version].encounter_details[encounter].condition_values.Count > 0)
                        {
                            conditions = result.pokemon_encounters[poke].version_details[version].encounter_details[encounter].condition_values[0];
                        }*/
                        dataGridViewPokemonTable.Rows.Add(name,method,pVersion,chance, conditions.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString("Could not access server, check your internet connection and try again"));
            }
        }

        private void listBoxLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            int url = Convert.ToInt32(filteredUrl[listBoxLocations.SelectedIndex]);
            GetLocation(Convert.ToString(placeUrl[url]));
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
    }
}
