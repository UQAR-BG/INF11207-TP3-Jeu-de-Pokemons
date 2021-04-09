using INF11207_TP3_Jeu_de_Pokemons.Models;
using System;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class JoueurViewModel : BaseViewModel
    {
        public ICommand CommandeSauvegarder { get; private set; }
        public ICommand CommandeQuitter { get; private set; }

        public JoueurViewModel(WindowSize size) : base(size) 
        {
            CommandeSauvegarder = new RelayCommand(
                o => true,
                o => Sauvegarder()
            );

            CommandeQuitter = new RelayCommand(
                o => true,
                o => Quitter()
            );
        }

        private void Sauvegarder()
        {
            Game.Sauvegarder();
        }

        private void Quitter()
        {
            Environment.Exit(0);
        }
    }
}
