using System;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class JaugeVie : Jauge
    {
        public JaugeVie(int value, int maxValue) : base(maxValue)
        {
            Value = value;
        }

        public JaugeVie(int maxValue) : base(maxValue) 
        {
            Value = maxValue;
        }

        public override void AugmenterNiveau(Personnage personnage)
        {
            throw new NotImplementedException();
        }
    }
}
