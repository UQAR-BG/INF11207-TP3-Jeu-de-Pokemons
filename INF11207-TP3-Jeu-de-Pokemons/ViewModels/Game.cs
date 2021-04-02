using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class Game
    {
        private static readonly string _cheminVersSauvegarde = "Resources/Save/Sauvegarde.json";
        private static MainWindowViewModel _mainViewModel = new MainWindowViewModel();
        private static Dresseur _dresseur = new Dresseur(1);
        private static bool _sauvegardeChargee = false;

        public static string CheminVersSauvegarde
        {
            get { return _cheminVersSauvegarde; }
        }

        public static MainWindowViewModel MainWindow
        {
            get { return _mainViewModel; }
        }

        public static BaseViewModel VueActuelle
        {
            get { return _mainViewModel.VueActuelle; }
        }

        public static Dresseur Dresseur
        {
            get { return _dresseur; }
            set
            {
                _dresseur = value;
                _sauvegardeChargee = true;
            }
        }

        public static bool SauvegardeChargee
        {
            get { return _sauvegardeChargee; }
        }

        public static void Naviguer(string destination)
        {
            _mainViewModel.Navigation(destination);
        }

        public static void Sauvegarder()
        {
            if (Loader.Sauvegarder(Dresseur, CheminVersSauvegarde))
            {
                MessageBox.Show("Sauvegarde effectuée avec succès.", "Sauvegarde effectuée", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Une erreur s'est produite lors de la sauvegarde.", "Erreur", MessageBoxButton.OK);
            }
        }
    }
}
