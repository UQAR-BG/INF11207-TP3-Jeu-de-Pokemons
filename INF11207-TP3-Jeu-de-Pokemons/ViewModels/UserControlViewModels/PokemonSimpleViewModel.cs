using INF11207_TP3_Jeu_de_Pokemons.Models;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels.UserControlViewModels
{
    public class PokemonSimpleViewModel : BaseViewModel
    {
        private PokemonEquipe _pokemon;

        public PokemonEquipe Pokemon { get { return _pokemon; } }

        public PokemonSimpleViewModel(PokemonEquipe pokemon)
        {
            _pokemon = pokemon;
        }
    }
}
