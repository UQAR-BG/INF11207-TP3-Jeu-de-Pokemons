using INF11207_TP3_Jeu_de_Pokemons.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class DepotPokemons
    {
        public List<Pokemon> PokemonsAchetes { get; set; }
        public PokemonEquipe[] PokemonsEquipes { get; set; } 

        [JsonConstructor]
        public DepotPokemons() { }

        public DepotPokemons(int niveauDresseur)
        {
            PokemonsAchetes = new List<Pokemon>();

            PokemonsEquipes = new PokemonEquipe[3];
            RechargerEmplacements();

            ChargerDepotParDefaut();
        }

        public PokemonEquipe Pokemon(int indexPokemon = 0)
        {
            if (indexPokemon >= 0 && indexPokemon < PokemonsEquipes.Length)
            {
                return PokemonsEquipes[indexPokemon];
            }
            return null;
        }

        public void EquiperPokemon(int position, Pokemon pokemon)
        {
            if (PositionValide(position))
            {
                PokemonEquipe pokemonEquipe = new PokemonEquipe(position);
                pokemonEquipe.Pokemon = pokemon;
                PokemonsEquipes[position] = pokemonEquipe;
            }
        }

        public void RechargerEmplacements()
        {
            for (int i = 0; i < 3; i++)
            {
                if (PokemonsEquipes[i] == null || !PokemonsEquipes[i].Equipe)
                {
                    PokemonsEquipes[i] = new PokemonEquipe(i);
                }
            }
        }

        private void ChargerDepotParDefaut()
        {
            List<Pokemon> pokemonsAchetes;

            if (!Loader.Charger(out pokemonsAchetes, "Resources/Data/PokemonAcheteParDefaut.json"))
            {
                MessageBox.Show("Le fichier PokemonAcheteParDefaut.json est manquant. Le jeu pourra donc rencontrer des comportements étranges.",
                    "Données manquantes", MessageBoxButton.OK);
            }
            PokemonsAchetes = pokemonsAchetes;
            EquiperPokemon(0, PokemonsAchetes[0]);
        }

        private bool PositionValide(int position)
        {
            return position >= 0 && position < 3;
        }
    }
}
