using System;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class JaugeXp : Jauge
    {
        public JaugeXp(int valeurMax) : base(valeurMax) { }

        public override void AugmenterNiveau(Personnage personnage)
        {
            throw new NotImplementedException();
        }
    }
}
