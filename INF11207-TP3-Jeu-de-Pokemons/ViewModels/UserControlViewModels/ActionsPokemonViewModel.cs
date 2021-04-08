using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels.UserControlViewModels
{
    public class ActionsPokemonViewModel : BaseViewModel
    {
        private EmplacementPokemon _pokemon;
        private RelayCommand _commandeEquiper;
        private RelayCommand _commandeDesequiper;

        public EmplacementPokemon Pokemon { get { return _pokemon; } }

        public string ContentButtonAction
        {
            get
            {
                if (Equipe)
                {
                    return "Déséquiper";
                }
                else
                {
                    return "Équiper";
                }
            }
        }

        public bool Equipe
        {
            get 
            { 
                if (_pokemon == null)
                {
                    return false;
                }
                return _pokemon.Equipe; 
            }
        }

        public ICommand CommandeEchanger { get; set; }

        public ICommand CommandeAction
        {
            get
            {
                if (Equipe)
                {
                    return _commandeDesequiper;
                }
                else
                {
                    return _commandeEquiper;
                }
            }
        }

        public ActionsPokemonViewModel(EmplacementPokemon pokemon)
        {
            _pokemon = pokemon;

            CommandeEchanger = new RelayCommand(
                o => Equipe,
                o => Echanger()
            );

            _commandeEquiper = new RelayCommand(
                o => true,
                o => Equiper()
            );

            _commandeDesequiper = new RelayCommand(
                o => true,
                o => Desequiper()
            );
        }

        private void Echanger()
        {

        }

        private void Equiper()
        {

        }

        private void Desequiper()
        {

        }
    }
}
