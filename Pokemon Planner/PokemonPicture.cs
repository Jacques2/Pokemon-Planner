using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Planner
{
    public partial class PokemonPicture : UserControl
    {
        public PokemonPicture()
        {
            InitializeComponent();
        }

        public void SetName(string pName)
        {
            PokemonName.Text = pName;
        }

        public void SetPicture(string url)
        {
            PokemonImage.ImageLocation = url;
        }

        public void SetTag(string tag)
        {
            this.Tag = tag;
        }

        public string PokemonSelected()
        {
            this.BackColor = SystemColors.Highlight;
            return this.Tag.ToString();
        }

        public void Deselect()
        {
            this.BackColor = Color.White;
        }
    }
}
