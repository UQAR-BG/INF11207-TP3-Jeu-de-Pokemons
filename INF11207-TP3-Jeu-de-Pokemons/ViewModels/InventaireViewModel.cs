using INF11207_TP3_Jeu_de_Pokemons.Models;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class InventaireViewModel : BaseViewModel
    {
        public Recherche Recherche
        {
            get { return Game.Recherche; }
        }

        public InventaireViewModel(WindowSize size) : base(size) { }
    }
}
