using Newtonsoft.Json;
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
            Reinitialiser();
        }

        [JsonConstructor]
        public JaugeVie() { }

        public void Reinitialiser()
        {
            Value = MaxValue;
        }

        public void PerdreDeLaVie(int hp)
        {
            if (Value >= hp)
            {
                Value -= hp;
            }
            else
            {
                Value = 0;
            }
        }

        public override void AugmenterNiveau(Personnage personnage)
        {
            throw new NotImplementedException();
        }
    }
}
