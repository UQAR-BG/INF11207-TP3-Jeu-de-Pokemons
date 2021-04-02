using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.ComponentModel;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _vueActuelle;
        private AccueilViewModel accueilViewModel = new AccueilViewModel(new WindowSize(450, 800));
        private CreationJoueurViewModel creationJoueurViewModel = new CreationJoueurViewModel(new WindowSize(450, 600));
        private JoueurViewModel joueurViewModel = new JoueurViewModel(new WindowSize(450, 800));
        private PokemonsViewModel pokemonsViewModel = new PokemonsViewModel(new WindowSize(850, 850));
        private InventaireViewModel inventaireViewModel = new InventaireViewModel(new WindowSize(900, 800));
        private StatsViewModel statsViewModel = new StatsViewModel(new WindowSize(500, 800));
        private LancementCombatViewModel lancementCombatViewModel = new LancementCombatViewModel(new WindowSize(350, 600));

        public BaseViewModel VueActuelle
        {
            get { return _vueActuelle; }
            set { SetProperty(ref _vueActuelle, value); }
        }

        public RelayCommandWithParam<string> CommandeNavigation { get; private set; }

        public MainWindowViewModel()
        {
            VueActuelle = accueilViewModel;
            CommandeNavigation = new RelayCommandWithParam<string>(Navigation);
        }

        public void Navigation(string destination)
        {
            switch (destination)
            {
                case "accueil":
                    VueActuelle = accueilViewModel;
                    break;
                case "creationjoueur":
                    VueActuelle = creationJoueurViewModel;
                    break;
                case "joueur":
                    VueActuelle = joueurViewModel;
                    break;
                case "pokemons":
                    VueActuelle = pokemonsViewModel;
                    break;
                case "inventaire":
                    VueActuelle = inventaireViewModel;
                    break;
                case "statistiques":
                    VueActuelle = statsViewModel;
                    break;
                case "lancercombat":
                    VueActuelle = lancementCombatViewModel;
                    break;
                default:
                    VueActuelle = VueActuelle;
                    break;
            }
        }
    }
}
