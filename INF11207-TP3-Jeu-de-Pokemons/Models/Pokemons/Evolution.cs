using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Evolution
    {
        public int Level { get; set; }
        public string To { get; set; }

        [JsonConstructor]
        public Evolution()
        {
            Level = 1;
            To = "";
        }

        public Pokemon EvoluerSiAtteintLeNiveau(Pokemon pokemon)
        {
            if (pokemon.Evolue && pokemon.Level >= Level && !pokemon.Name.Equals(To))
            {
                Pokemon evolution = (Pokemon)Game.PokemonsDeBase
                    .Find(p => p.Name.Equals(To))
                    .Clone();

                evolution.Acheter();
                evolution.ATK = pokemon.ATK;
                evolution.DEF = pokemon.DEF;
                evolution.Emplacement = pokemon.Emplacement;
                evolution.Level = pokemon.Level;
                evolution.XpGauge = pokemon.XpGauge;

                return evolution;
            }
            return null;
        }
    }
}
