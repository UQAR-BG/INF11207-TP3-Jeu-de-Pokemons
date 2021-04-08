using INF11207_TP3_Jeu_de_Pokemons.Enums;
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

        public void EquiperPokemon(Emplacement emplacement, Pokemon pokemon)
        {
            PokemonEquipe pokemonEquipe = new PokemonEquipe(emplacement);
            pokemonEquipe.Pokemon = pokemon;
            pokemonEquipe.Pokemon.Emplacement = emplacement;
            PokemonsEquipes[(int)emplacement] = pokemonEquipe;
        }

        public void DesequiperPokemon(Emplacement emplacement)
        {
            int position = (int)emplacement;
            if (PokemonsEquipes[position].Pokemon != null)
            {
                PokemonsEquipes[position].Pokemon.Emplacement = Emplacement.Desequipe;
                PokemonsEquipes[position].Pokemon = null;
            }
        }

        public void RechargerEmplacements()
        {
            for (int i = 0; i < 3; i++)
            {
                if (PokemonsEquipes[i] == null || !PokemonsEquipes[i].Equipe)
                {
                    PokemonsEquipes[i] = new PokemonEquipe((Emplacement)i);
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
    }
}
