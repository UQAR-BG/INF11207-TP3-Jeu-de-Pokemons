using INF11207_TP3_Jeu_de_Pokemons.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class GuidePourDebloquerPokemons
    {
        [JsonIgnore]
        public Dictionary<int, List<int>> CorrespondanceNiveauPokemon { get; set; }

        public List<int> IdPokemonsDebloques { get; set; }

        [JsonConstructor]
        public GuidePourDebloquerPokemons()
        {
            LireCorrespondances();
        }

        public GuidePourDebloquerPokemons(int niveauDresseur)
        {
            LireCorrespondances();
            AppliquerCorrespondance(niveauDresseur);
        }

        public void AppliquerCorrespondance(int niveauDresseur)
        {
            if (niveauDresseur > 0)
            {
                IdPokemonsDebloques = new List<int>();

                while (niveauDresseur > 0)
                {
                    AppliquerCorrespondanceParNiveau(niveauDresseur);
                    niveauDresseur--;
                }
            }
        }

        private void LireCorrespondances()
        {
            Dictionary<int, List<int>> correspondance;

            if (!Loader.Charger(out correspondance, "Resources/Data/CorrespondanceNiveauPokemons.json"))
            {
                MessageBox.Show("Le fichier CorrespondanceNiveauPokemons.json est manquant. Le jeu pourra donc rencontrer des comportements étranges.",
                    "Données manquantes", MessageBoxButton.OK);
            }
            CorrespondanceNiveauPokemon = correspondance;
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
