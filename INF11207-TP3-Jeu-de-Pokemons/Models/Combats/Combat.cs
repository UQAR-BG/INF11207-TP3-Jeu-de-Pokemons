namespace INF11207_TP3_Jeu_de_Pokemons.Models.Combats
{
    public class Combat
    {
        private readonly int experience = 20;

        private int mise;
        private Dresseur joueur;
        private Dresseur adversaire;

        private ResultatCombat gagnant;
        private ResultatCombat perdant;

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
            gagnant = new ResultatCombat(true, mise, experience);
            perdant = new ResultatCombat(false, 0, experience / 2);

            DeterminerGagnant();
        }

        private void DeterminerGagnant()
        {
            if (joueur.EncorePokemonsValides())
            {
                AttribuerResultats(gagnant);
            }
            else
            {
                AttribuerResultats(perdant);
            }
        }

        private void AttribuerResultats(ResultatCombat resultats)
        {
            joueur.TerminerUnCombat(resultats);
        }
    }
}
