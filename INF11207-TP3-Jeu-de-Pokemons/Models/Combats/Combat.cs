using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using INF11207_TP3_Jeu_de_Pokemons.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Combat
    {
        private readonly int experience = 50;
        private Random random;

        private int indexParticipant;
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
            get { return Joueur.PokemonEquipe; }
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
            get { return Adversaire.PokemonEquipe; }
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
            random = new Random();

            AttribuerParticipants();
        }

        public void Attaquer()
        {
            if (joueurActuel == joueur)
            {
                AttaquerAdversaire();
            }
            else
            {
                AttaquerJoueur();
            }

            ProchainTour();
        }

        private void AttaquerAdversaire()
        {
            Pokemon pokemonJoueur = PokemonEquipeJoueur;

            ChoixAttaque choix = new ChoixAttaque(pokemonJoueur.Attacks);
            choix.ShowDialog();

            Attaque attaque = Game.Attaque;
            if (pokemonJoueur.Attaquer(PokemonEquipeAdversaire, attaque))
            {
                adversaire.MettreAJourPokemonEquipe();
                Game.Naviguer("refresh");
            }
        }

        private void AttaquerJoueur()
        {
            Pokemon pokemonJoueur = PokemonEquipeAdversaire;
            int indexAttaque = random.Next(pokemonJoueur.Attacks.Count);

            Attaque attaque = pokemonJoueur.Attacks[indexAttaque];

            MessageBox.Show($"{pokemonJoueur.Name} a utilisé {attaque.Name} sur {PokemonEquipeJoueur.Name}.", 
                "Attaque de l'adversaire", MessageBoxButton.OK);
            if (pokemonJoueur.Attaquer(PokemonEquipeJoueur, attaque))
            {
                joueur.MettreAJourPokemonEquipe();
                Game.Naviguer("refresh");
            }
        }

        private void ProchainTour()
        {
            indexParticipant = ++indexParticipant % 2;
            joueurActuel = participants[indexParticipant];

            if (joueurActuel.EncorePokemonsValides())
            {
                if (joueurActuel == adversaire)
                {
                    Attaquer();
                }
            }
            else
            {
                MettreFin();
            }
        }

        private void MettreFin()
        {
            gagnant = new ResultatCombat(true, mise, experience);
            perdant = new ResultatCombat(false, 0, experience / 2);

            DeterminerGagnant();
            Game.Naviguer("lancercombat");
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

            indexParticipant = 0;
            joueurActuel = participants[indexParticipant];
        }

        private void AttribuerResultats(ResultatCombat resultats)
        {
            joueur.TerminerUnCombat(resultats);
        }
    }
}
