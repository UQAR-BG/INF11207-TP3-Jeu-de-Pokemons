using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Attaque : Binding
    {
        private string nom;
        private int degats;
        private OrigineType type;

        public OrigineType Type { get; private set; }

        public string Nom
        {
            get { return nom; }
            set
            {
                if (nom != value)
                {
                    nom = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Degats
        {
            get { return degats; }
            set
            {
                if (degats != value)
                {
                    degats = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
