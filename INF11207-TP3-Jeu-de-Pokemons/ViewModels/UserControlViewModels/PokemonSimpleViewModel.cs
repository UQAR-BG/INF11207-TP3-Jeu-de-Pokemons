using INF11207_TP3_Jeu_de_Pokemons.Models;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels.UserControlViewModels
{
    public class PokemonSimpleViewModel : BaseViewModel
    {
        private EmplacementPokemon _pokemon;

        public EmplacementPokemon Pokemon { get { return _pokemon; } }

        public PokemonSimpleViewModel(EmplacementPokemon pokemon)
        {
            _pokemon = pokemon;
        }
    }
}
