using INF11207_TP3_Jeu_de_Pokemons.Models;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class Game
    {
        private static MainWindowViewModel _mainViewModel = new MainWindowViewModel();

        public static MainWindowViewModel MainWindow
        {
            get { return _mainViewModel; }
        }

        public static Dresseur Dresseur { get; set; }

        public static void Naviguer(string destination)
        {
            _mainViewModel.Navigation(destination);
        }
    }
}
