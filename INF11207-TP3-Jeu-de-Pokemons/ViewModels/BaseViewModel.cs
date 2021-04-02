using INF11207_TP3_Jeu_de_Pokemons.Models;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public abstract class BaseViewModel : Binding
    {
        public WindowSize WindowSize { get; set; }

        public Dresseur Dresseur 
        { 
            get { return Game.Dresseur; }
            set { Game.Dresseur = value; }
        }

        public BaseViewModel()
        {
            WindowSize = new WindowSize(450, 800);
        }

        public BaseViewModel(WindowSize size)
        {
            WindowSize = size;
        }
    }
}
