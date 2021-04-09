using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class InventaireViewModel : BaseViewModel
    {
        private Pokemon _pokemon;
        private EmplacementPokemon _pokemonEquipe;
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

        public EmplacementPokemon PokemonSelectionne
        {
            get { return _pokemonEquipe; }
        }

        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set
            {
                _pokemon = value;
                _pokemonEquipe = new EmplacementPokemon(Emplacement.Emplacement1);
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

        public void Reinitialiser()
        {
            Recherche.Reinitialiser();
            Rechercher();
        }

        public void Rechercher()
        {
            Resultats = new ObservableCollection<Pokemon>(Recherche.Rechercher());
        }

        private void Acheter()
        {
            Pokemon pokemonAchete = Game.Dresseur.Acheter(Pokemon);
            if (!string.IsNullOrEmpty(pokemonAchete.Name))
            {
                Pokemon = pokemonAchete;
                Reinitialiser();
                MessageBox.Show($"{Pokemon.Name} a été acheté avec succès!", "Achat effectué", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show($"Vous n'avez pas les {Pokemon.Price}$ requis pour acheter ce pokémon.", "Incapable de payer", MessageBoxButton.OK);
            }
        }

        private void Equiper()
        {
            ChoixEmplacement choix = new ChoixEmplacement();
            choix.ShowDialog();

            int indexPokemon = Dresseur.Depot.ChercherIndexDePokemonAchete(Pokemon.IdPokemonAchete);

            Game.Dresseur.Equiper(indexPokemon, Game.Emplacement);
            MessageBox.Show($"{Pokemon.Name} a été équipé.", "Pokémon équipé", MessageBoxButton.OK);
        }
    }
}
