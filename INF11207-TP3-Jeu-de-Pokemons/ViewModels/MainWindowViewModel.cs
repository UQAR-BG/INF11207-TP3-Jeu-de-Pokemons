using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Visibility _peutAfficherMenu = Visibility.Visible;

        private BaseViewModel _vueActuelle;
        private AccueilViewModel accueilViewModel = new AccueilViewModel(new WindowSize(450, 800));
        private CreationJoueurViewModel creationJoueurViewModel = new CreationJoueurViewModel(new WindowSize(450, 600));
        private JoueurViewModel joueurViewModel = new JoueurViewModel(new WindowSize(450, 800));
        private PokemonsViewModel pokemonsViewModel = new PokemonsViewModel(new WindowSize(900, 1000));
        private InventaireViewModel inventaireViewModel = new InventaireViewModel(new WindowSize(900, 800));
        private StatsViewModel statsViewModel = new StatsViewModel(new WindowSize(500, 800));
        private LancementCombatViewModel lancementCombatViewModel = new LancementCombatViewModel(new WindowSize(350, 600));

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
            VueActuelle = accueilViewModel;
            CommandeNavigation = new RelayCommandWithParam<string>(Navigation);

            Game.ChargerPokemonsBase();
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
            Visibility visibiliteMenu = VueActuelle is not AccueilViewModel && VueActuelle is not CreationJoueurViewModel ? Visibility.Visible : Visibility.Hidden;
            PeutAfficherMenu = visibiliteMenu;
        }
    }
}
