using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class PokemonsViewModel : BaseViewModel
    {
        private UserControl control;

        public ICommand CommandeEchangerEmplacement1 { get; set; }
        public ICommand CommandeEchangerEmplacement2 { get; set; }
        public ICommand CommandeEchangerEmplacement3 { get; set; }

        public ICommand CommandeActon { get; set; }

        public PokemonsViewModel(WindowSize size) : base(size)
        {
            CreerCommandes();
        }

        public PokemonsViewModel(UserControl window) : base(new WindowSize(900, 1000))
        {
            control = window;
            CreerCommandes();
        }

        public bool EmplacementEstEquipe(Emplacement emplacement)
        {
            return Dresseur.Depot.PokemonsEquipes[(int)emplacement].Equipe;
        }

        private void CreerCommandes()
        {
            CommandeEchangerEmplacement1 = new RelayCommand(
                o => EmplacementEstEquipe(Emplacement.Emplacement1),
                o => Echanger(Emplacement.Emplacement1)
            );

            CommandeEchangerEmplacement2 = new RelayCommand(
                o => EmplacementEstEquipe(Emplacement.Emplacement2),
                o => Echanger(Emplacement.Emplacement2)
            );

            CommandeEchangerEmplacement3 = new RelayCommand(
                o => EmplacementEstEquipe(Emplacement.Emplacement3),
                o => Echanger(Emplacement.Emplacement3)
            );

            CommandeActon = new RelayCommandWithParam<string>(Action);
        }

        private void Action(string parametre)
        {
            int position = int.Parse(parametre);
            Emplacement emplacement = (Emplacement)position;
            if (EmplacementEstEquipe(emplacement))
            {
                Desequiper(emplacement);
            }
            else
            {
                Equiper(emplacement);
            }
        }

        private void Echanger(Emplacement emplacement)
        {
            ChoixEmplacement choix = new ChoixEmplacement();
            choix.ShowDialog();

            Dresseur.Echanger(emplacement, Game.Emplacement);
            Game.Naviguer("refresh");
        }

        private void Equiper(Emplacement emplacement)
        {
            Game.Recherche.Filtre = FiltreRecherche.Achetes;
            Game.Naviguer("inventaire");
        }

        private void Desequiper(Emplacement emplacement)
        {
            Dresseur.Desequiper(emplacement);
            Game.Naviguer("refresh");
        }
    }
}
