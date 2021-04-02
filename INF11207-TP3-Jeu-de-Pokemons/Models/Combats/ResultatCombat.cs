namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class ResultatCombat
    {
        private bool victoire;
        private int mise;
        private int experience;

        public bool Victoire { get { return victoire; } }
        public int Mise { get { return mise; } }
        public int Experience { get { return experience; } }

        public ResultatCombat(bool victoire, int mise, int experience)
        {
            this.victoire = victoire;
            this.mise = mise;
            this.experience = experience;
        }
    }
}
