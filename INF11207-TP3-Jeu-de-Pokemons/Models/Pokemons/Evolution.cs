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
    }
}
