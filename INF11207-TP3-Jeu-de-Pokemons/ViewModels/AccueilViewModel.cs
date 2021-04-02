using INF11207_TP3_Jeu_de_Pokemons.Models;
using System.IO;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public bool IsValid { get; private set; }
        public ICommand CommandeChargerSauvegarde { get; private set; }

        public AccueilViewModel(WindowSize size) : base(size) 
        {
            VerifierSiSauvegardeExiste();

            CommandeChargerSauvegarde = new RelayCommand(
                o => IsValid,
                o => ChargerSauvegarde()
            );
        }

        private void VerifierSiSauvegardeExiste()
        {
            IsValid = File.Exists("Resources/Save/Sauvegarde.json");
        }

        private void ChargerSauvegarde()
        {

        }
    }
}
