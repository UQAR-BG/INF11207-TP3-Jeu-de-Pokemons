using INF11207_TP3_Jeu_de_Pokemons.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class DepotPokemons
    {
        public List<Pokemon> PokemonsAchetes { get; set; }
        public Pokemon[] PokemonsEquipes { get; set; } 

        [JsonConstructor]
        public DepotPokemons() { }

        public DepotPokemons(int niveauDresseur)
        {
            PokemonsAchetes = new List<Pokemon>();
            PokemonsEquipes = new Pokemon[3];

            ChargerDepotParDefaut();
        }

        public Pokemon Pokemon(int indexPokemon = 0)
        {
            if (indexPokemon >= 0 && indexPokemon < PokemonsEquipes.Length)
            {
                return PokemonsEquipes[indexPokemon];
            }
            return null;
        }

        private void ChargerDepotParDefaut()
        {
            PokemonsAchetes = Loader.Charger<List<Pokemon>>("Resources/Data/PokemonAcheteParDefaut.json");
            PokemonsEquipes[0] = PokemonsAchetes[0];
        }
    }
}
