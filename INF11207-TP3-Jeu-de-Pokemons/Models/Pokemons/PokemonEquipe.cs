using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class PokemonEquipe : Binding
    {
        private int _ordre;
        private Pokemon _pokemon;

        public Pokemon Pokemon
        { 
            get { return _pokemon; }
            set { EquiperPokemon(value); }
        }
        public bool Equipe { get { return _pokemon != null; } }
        public int Ordre { get { return _ordre; } }
        public string PrintOrdre 
        { 
            get 
            {
                int ordrePourAfficher = _ordre + 1;
                return $"{ordrePourAfficher}:"; 
            } 
        }

        [JsonConstructor]
        public PokemonEquipe() { }

        public PokemonEquipe(int ordre)
        {
            _ordre = ordre;
        }

        public void EquiperPokemon(Pokemon pokemon)
        {
            _pokemon = pokemon;
        }

        public void DesequiperPokemon()
        {
            _pokemon = null;
        }
    }
}
