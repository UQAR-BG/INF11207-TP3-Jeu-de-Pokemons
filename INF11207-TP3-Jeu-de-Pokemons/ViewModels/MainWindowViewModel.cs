using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Visibility _peutAfficherMenu = Visibility.Visible;

        private BaseViewModel _vueActuelle;
        private AccueilViewModel accueilViewModel;
        private CreationJoueurViewModel creationJoueurViewModel;
        private JoueurViewModel joueurViewModel;
        private PokemonsViewModel pokemonsViewModel;
        private InventaireViewModel inventaireViewModel;
        private StatsViewModel statsViewModel;
        private LancementCombatViewModel lancementCombatViewModel;
        private CombatsViewModel combatsViewModel;

        public Visibility PeutAfficherMenu
        {
            get { return _peutAfficherMenu; }
            set { SetProperty(ref _peutAfficherMenu, value); }
        }

        public BaseViewModel VueActuelle
        {
            get { return _vueActuelle; }
            set 
            { 
                SetProperty(ref _vueActuelle, value);
                VerifierSiPeutAfficherMenu();
            }
        }

        public RelayCommandWithParam<string> CommandeNavigation { get; private set; }

        public MainWindowViewModel()
        {
            Game.Initialiser();
            InitializeViewModels();

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
                case "combats":
                    VueActuelle = combatsViewModel;
                    break;
                case "refresh":
                    BaseViewModel buffer = VueActuelle;
                    VueActuelle = this;
                    VueActuelle = buffer;
                    break;
                default:
                    VueActuelle = VueActuelle;
                    break;
            }
        }

        private void VerifierSiPeutAfficherMenu()
        {
            Visibility visibiliteMenu = VueActuelle is not AccueilViewModel && VueActuelle is not CreationJoueurViewModel 
                && VueActuelle is not CombatsViewModel ? Visibility.Visible : Visibility.Hidden;
            PeutAfficherMenu = visibiliteMenu;
        }

        private void InitializeViewModels()
        {
            accueilViewModel = new AccueilViewModel(new WindowSize(450, 800));
            creationJoueurViewModel = new CreationJoueurViewModel(new WindowSize(450, 600));
            joueurViewModel = new JoueurViewModel(new WindowSize(450, 800));
            pokemonsViewModel = new PokemonsViewModel(new WindowSize(900, 1000));
            inventaireViewModel = new InventaireViewModel(new WindowSize(900, 800));
            statsViewModel = new StatsViewModel(new WindowSize(500, 800));
            lancementCombatViewModel = new LancementCombatViewModel(new WindowSize(500, 800));
            combatsViewModel = new CombatsViewModel(new WindowSize(800, 700));
        }
    }
}
