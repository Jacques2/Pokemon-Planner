namespace Pokemon_Planner
{
    partial class PokemonPicture
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PokemonImage = new System.Windows.Forms.PictureBox();
            this.PokemonName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PokemonImage
            // 
            this.PokemonImage.Location = new System.Drawing.Point(3, 0);
            this.PokemonImage.Name = "PokemonImage";
            this.PokemonImage.Size = new System.Drawing.Size(128, 128);
            this.PokemonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PokemonImage.TabIndex = 0;
            this.PokemonImage.TabStop = false;
            // 
            // PokemonName
            // 
            this.PokemonName.Location = new System.Drawing.Point(3, 131);
            this.PokemonName.Name = "PokemonName";
            this.PokemonName.Size = new System.Drawing.Size(130, 23);
            this.PokemonName.TabIndex = 1;
            this.PokemonName.Text = "label";
            this.PokemonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PokemonPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PokemonName);
            this.Controls.Add(this.PokemonImage);
            this.Name = "PokemonPicture";
            this.Size = new System.Drawing.Size(133, 157);
            ((System.ComponentModel.ISupportInitialize)(this.PokemonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PokemonImage;
        private System.Windows.Forms.Label PokemonName;
    }
}
