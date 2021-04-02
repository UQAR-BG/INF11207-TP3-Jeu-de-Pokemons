using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class JoueurViewModel : BaseViewModel
    {
        public ICommand CommandeSauvegarder { get; private set; }

        public JoueurViewModel(WindowSize size) : base(size) 
        {
            CommandeSauvegarder = new RelayCommand(
                o => true,
                o => Sauvegarder()
            );
        }

        private void Sauvegarder()
        {
            Game.Sauvegarder();
        }
    }
}
