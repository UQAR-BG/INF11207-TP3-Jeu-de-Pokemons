using INF11207_TP3_Jeu_de_Pokemons.ViewModels;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public abstract class Jauge : Binding
    {
        private int valeurActuelle;
        private readonly int valeurMax;

        public int ValeurActuelle
        {
            get { return valeurActuelle; }
            set
            {
                if (valeurActuelle != value)
                {
                    valeurActuelle = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ValeurMax { get { return valeurMax; } }

        public Jauge(int valeurMax)
        {
            this.valeurMax = valeurMax;
        }

        public abstract void AugmenterNiveau(Personnage personnage);

        public virtual void DiminuerVie(int montant)
        {

        }
    }
}
