using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Combat
    {
        private readonly int experience = 20;

        private int mise;
        private Dresseur joueur;
        private Dresseur adversaire;
        private Dresseur joueurActuel;
        private List<Dresseur> participants;

        private ResultatCombat gagnant;
        private ResultatCombat perdant;

        public Dresseur Joueur
        {
            get { return joueur; }
        }

        public Pokemon PokemonEquipeJoueur
        {
            get { return Joueur.PremierPokemonValide(); }
        }

        public string NomJoueur
        {
            get 
            { 
                if (joueur != null)
                {
                    return $"{joueur.FirstName} {joueur.Name}";
                }
                return "";
            }
        }

        public Dresseur Adversaire
        {
            get { return adversaire; }
        }

        public Pokemon PokemonEquipeAdversaire
        {
            get { return Adversaire.PremierPokemonValide(); }
        }

        public string NomAdversaire
        {
            get
            {
                if (adversaire != null)
                {
                    return $"{adversaire.FirstName} {adversaire.Name}";
                }
                return "";
            }
        }


        public int Mise
        {
            get { return mise; }
        }

        public bool TourDuJoueur
        {
            get { return joueurActuel == joueur; }
        }

        public Combat(Dresseur joueur, Dresseur adversaire, int mise)
        {
            this.joueur = joueur;
            this.adversaire = adversaire;
            this.mise = mise;

            AttribuerParticipants();
        }

        public void MettreFin()
        {
            gagnant = new ResultatCombat(true, mise, experience);
            perdant = new ResultatCombat(false, 0, experience / 2);

            DeterminerGagnant();
        }

        private void DeterminerGagnant()
        {
            if (joueur.EncorePokemonsValides())
            {
                AttribuerResultats(gagnant);
            }
            else
            {
                AttribuerResultats(perdant);
            }
        }

        private void AttribuerParticipants()
        {
            participants = new List<Dresseur>();
            participants.Add(joueur);
            participants.Add(adversaire);

            joueurActuel = participants[0];
        }

        private void AttribuerResultats(ResultatCombat resultats)
        {
            joueur.TerminerUnCombat(resultats);
        }
    }
}
