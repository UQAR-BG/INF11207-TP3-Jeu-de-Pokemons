using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP3_Jeu_de_Pokemons.Models.Combats
{
    public class Combat
    {
        private int mise;
        private Dresseur joueur;
        private Dresseur adversaire;

        public int Mise
        {
            get { return mise; }
        }

        public Combat(Dresseur joueur, Dresseur adversaire, int mise)
        {
            this.joueur = joueur;
            this.adversaire = adversaire;
            this.mise = mise;
        }

        public void MettreFin()
        {

        }

        private void DeterminerGagnant()
        {

        }

        private void RemporterMise(Dresseur dresseur)
        {

        }

        private void AjouterExperience()
        {

        }
    }
}
