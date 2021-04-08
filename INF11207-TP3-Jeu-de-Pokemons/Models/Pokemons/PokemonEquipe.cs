using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class PokemonEquipe : Binding
    {
        private Emplacement _ordre;
        private Pokemon _pokemon;

        public Pokemon Pokemon
        { 
            get { return _pokemon; }
            set { EquiperPokemon(value); }
        }
        public bool Equipe { get { return _pokemon != null; } }
        public Emplacement Ordre { get; set; }
        public string PrintOrdre 
        { 
            get 
            {
                int ordrePourAfficher = (int)_ordre + 1;
                return $"{ordrePourAfficher}:"; 
            } 
        }

        [JsonConstructor]
        public PokemonEquipe() { }

        public PokemonEquipe(Emplacement ordre)
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
