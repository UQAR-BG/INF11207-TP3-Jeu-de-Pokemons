using INF11207_TP3_Jeu_de_Pokemons.ViewModels;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public abstract class Jauge : Binding
    {
        private int value;
        private int maxValue;

        public int Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MaxValue 
        { 
            get { return maxValue; }
            set
            {
                if (maxValue != value)
                {
                    maxValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public Jauge(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public Jauge() { }

        public abstract void AugmenterNiveau(Personnage personnage);
    }
}
