using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Statistiques
    {
        public int MontantAccumule { get; set; }
        public int MontantDepense { get; set; }
        public int PokemonsAchetes { get; set; }
        public int PokemonsDebloques { get; set; }
        public int CombatsTotal { get; set; }
        public int CombatsGagnes { get; set; }
        public int CombatsPerdus { get; set; }

        public string PrintMontantAccumule { get { return $"{MontantAccumule}$"; } }
        public string PrintMontantDepense { get { return $"{MontantDepense}$"; } }

        [JsonConstructor]
        public Statistiques() { }

        public Statistiques(int montantInitial, int nbPokemonsAchetes)
        {
            MontantAccumule = montantInitial;
            MontantDepense = 0;
            PokemonsAchetes = nbPokemonsAchetes;
            PokemonsDebloques = nbPokemonsAchetes;
            CombatsTotal = 0;
            CombatsGagnes = 0;
            CombatsPerdus = 0;
        }

        public void CombatTermine(ResultatCombat resultat)
        {
            MontantAccumule += resultat.Mise;
            CombatsTotal++;

            if (resultat.Victoire)
            {
                CombatsGagnes++;
            }
            else
            {
                CombatsPerdus++;
            }
        }
    }
}
