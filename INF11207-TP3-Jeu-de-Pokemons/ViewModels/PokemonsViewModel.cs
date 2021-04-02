using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class PokemonsViewModel : BaseViewModel
    {
        public ICommand CommandeEchangerEmplacement1 { get; set; }
        public ICommand CommandeEchangerEmplacement2 { get; set; }
        public ICommand CommandeEchangerEmplacement3 { get; set; }

        public ICommand CommandeActon { get; set; }

        public PokemonsViewModel(WindowSize size) : base(size)
        {
            CommandeEchangerEmplacement1 = new RelayCommand(
                o => EmplacementEstEquipe(0),
                o => Equiper(0)
            );

            CommandeEchangerEmplacement2 = new RelayCommand(
                o => EmplacementEstEquipe(1),
                o => Equiper(1)
            );

            CommandeEchangerEmplacement3 = new RelayCommand(
                o => EmplacementEstEquipe(2),
                o => Equiper(2)
            );

            CommandeActon = new RelayCommandWithParam<string>(Action);
        }

        public bool EmplacementEstEquipe(int emplacement)
        {
            if (EmplacementValide(emplacement))
            {
                return Dresseur.Depot.PokemonsEquipes[emplacement].Equipe;
            }
            return false;
        }

        private void Action(string indexEmplacement)
        {
            int emplacement = int.Parse(indexEmplacement);
            if (EmplacementValide(emplacement))
            {
                if (EmplacementEstEquipe(emplacement))
                {
                    Desequiper(emplacement);
                }
                else
                {
                    Equiper(emplacement);
                }
            }
        }

        private void Echanger(int emplacement)
        {

        }

        private void Equiper(int emplacement)
        {

        }

        private void Desequiper(int emplacement)
        {

        }

        private bool EmplacementValide(int emplacement)
        {
            return emplacement >= 0 && emplacement < 3;
        }
    }
}
