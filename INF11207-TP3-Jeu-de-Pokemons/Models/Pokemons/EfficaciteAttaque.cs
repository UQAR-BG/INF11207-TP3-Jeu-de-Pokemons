using INF11207_TP3_Jeu_de_Pokemons.Enums;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class EfficaciteAttaque
    {
        public OrigineType Attack { get; set; }
        public OrigineType Defend { get; set; }
        public double Effectiveness { get; set; }
    }
}
