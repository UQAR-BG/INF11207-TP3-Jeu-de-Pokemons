using INF11207_TP3_Jeu_de_Pokemons.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class GuidePourDebloquerPokemons
    {
        public Dictionary<int, List<int>> CorrespondanceNiveauPokemon { get; private set; }
        public List<int> IdPokemonsDebloques { get; set; }

        [JsonConstructor]
        public GuidePourDebloquerPokemons()
        {
            LireCorrespondances();
        }

        public GuidePourDebloquerPokemons(int niveauDresseur)
        {
            IdPokemonsDebloques = new List<int>();

            LireCorrespondances();
            AppliquerCorrespondance(niveauDresseur);
        }

        private void LireCorrespondances()
        {
            string nomFichier = "Resources/Data/CorrespondanceNiveauPokemons.json";
            CorrespondanceNiveauPokemon = Loader.Charger<Dictionary<int, List<int>>>(nomFichier);
        }

        private void AppliquerCorrespondance(int niveauDresseur)
        {
            if (niveauDresseur > 0)
            {
                while (niveauDresseur > 0)
                {
                    AppliquerCorrespondanceParNiveau(niveauDresseur);
                    niveauDresseur--;
                }
            }
        }

        private void AppliquerCorrespondanceParNiveau(int niveauDresseur)
        {
            if (CorrespondanceNiveauPokemon.ContainsKey(niveauDresseur))
            {
                IdPokemonsDebloques.InsertRange(0, CorrespondanceNiveauPokemon[niveauDresseur]);
            }
        }
    }
}
