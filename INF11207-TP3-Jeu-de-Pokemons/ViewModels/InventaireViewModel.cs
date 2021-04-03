using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class InventaireViewModel : BaseViewModel
    {
        private Pokemon _pokemon;
        private PokemonEquipe _pokemonEquipe;
        private ObservableCollection<Pokemon> _resultats;

        public ICommand CommandeReinitialiser { get; set; }
        public ICommand CommandeRechercher { get; set; }

        private RelayCommand _commandeAcheter;
        private RelayCommand _commandeEquiper;

        public string TexteBoutonAction
        {
            get 
            {
                if (Pokemon != null && Pokemon.Achete)
                {
                    return "Équiper";
                }
                else
                {
                    return "Acheter";
                }
            }
        }

        public ICommand Action
        {
            get 
            {
                if (Pokemon != null && Pokemon.Achete)
                {
                    return _commandeEquiper;
                }
                else
                {
                    return _commandeAcheter;
                }
            }
        }

        public PokemonEquipe PokemonSelectionne
        {
            get { return _pokemonEquipe; }
        }

        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set
            {
                _pokemon = value;
                _pokemonEquipe = new PokemonEquipe(0);
                _pokemonEquipe.Pokemon = _pokemon;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Pokemon> Resultats
        {
            get { return _resultats; }
            set
            {
                if (_resultats != value)
                {
                    _resultats = value;
                    OnPropertyChanged();
                }
            }
        }

        public Recherche Recherche
        {
            get { return Game.Recherche; }
        }

        public InventaireViewModel(WindowSize size) : base(size) 
        {
            CommandeReinitialiser = new RelayCommand(
                o => true,
                o => Reinitialiser()
            );

            CommandeRechercher = new RelayCommand(
                o => true,
                o => Rechercher()
            );

            _commandeAcheter = new RelayCommand(
                o => Pokemon != null && !Pokemon.Achete,
                o => Acheter()
            );

            _commandeEquiper = new RelayCommand(
                o => Pokemon != null && Pokemon.Achete,
                o => Equiper()
            );
        }

        private void Reinitialiser()
        {
            Recherche.Reinitialiser();
            Resultats.Clear();
        }

        private void Rechercher()
        {
            Resultats = new ObservableCollection<Pokemon>(Recherche.Rechercher());
        }

        private void Acheter()
        {

        }

        private void Equiper()
        {

        }
    }
}
