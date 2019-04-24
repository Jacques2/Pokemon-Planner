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

        private void PokemonPicture_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Highlight;
        }
    }
}
