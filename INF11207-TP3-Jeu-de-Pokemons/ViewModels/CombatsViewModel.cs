using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class CombatsViewModel : BaseViewModel
    {
        private Combat _combat; 

        public string Titre
        {
            get
            {
                return $"{_combat.NomJoueur} VS {_combat.NomAdversaire}";
            }
        }

        public Dresseur Joueur
        {
            get { return _combat.Joueur; }
        }

        public Pokemon PokemonEquipeJoueur
        {
            get { return _combat.PokemonEquipeJoueur; }
        }

        public Dresseur Adversaire
        {
            get { return _combat.Adversaire; }
        }

        public Pokemon PokemonEquipeAdversaire
        {
            get { return _combat.PokemonEquipeAdversaire; }
        }

        public ICommand CommandeAttaquer { get; set; }

        public CombatsViewModel(WindowSize size) : base(size) 
        {
            _combat = Game.Combat;

            CommandeAttaquer = new RelayCommand(
                o => _combat.TourDuJoueur,
                o => Attaquer()
            );
        }

        public void LancerCombat()
        {
            _combat = Game.Combat;
            Joueur.MettreAJourPokemonEquipe();
            Adversaire.MettreAJourPokemonEquipe();
        }

        private void Attaquer()
        {
            _combat.Attaquer();
        }
    }
}
