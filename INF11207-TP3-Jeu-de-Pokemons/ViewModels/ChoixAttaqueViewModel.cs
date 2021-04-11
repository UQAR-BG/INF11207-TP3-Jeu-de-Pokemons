using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class ChoixAttaqueViewModel : BaseViewModel
    {
        private List<Attaque> _attacks;
        private Window _window;

        public List<Attaque> Attacks
        {
            get { return _attacks; }
            set
            {
                if (_attacks != value)
                {
                    _attacks = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CommandeChoisirAttaque { get; set; }

        public ChoixAttaqueViewModel(Window window, List<Attaque> attacks)
        {
            _window = window;
            _attacks = attacks;

            CommandeChoisirAttaque = new RelayCommandWithParam<string>(ChoisirAttaque);
        }

        private void ChoisirAttaque(string indexAttaque)
        {
            int index = int.Parse(indexAttaque);

            Game.Attaque = Attacks[index];
            _window.Close();
        }
    }
}
