using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public bool IsValid { get; private set; }
        public ICommand CommandeChargerSauvegarde { get; private set; }
        public ICommand CommandeCommencerUnePartie { get; private set; }

        public AccueilViewModel(WindowSize size) : base(size) 
        {
            VerifierSiSauvegardeExiste();

            CommandeCommencerUnePartie = new RelayCommand(
                o => true,
                o => CommencerUnePartie()
            );

            CommandeChargerSauvegarde = new RelayCommand(
                o => IsValid,
                o => ChargerSauvegarde()
            );
        }

        private void VerifierSiSauvegardeExiste()
        {
            IsValid = File.Exists(Game.CheminVersSauvegarde);
        }

        private void CommencerUnePartie()
        {
            Game.Naviguer("creationjoueur");
        }

        private void ChargerSauvegarde()
        {
            Dresseur sauvegarde;
            if (Loader.Charger(out sauvegarde, Game.CheminVersSauvegarde))
            {
                Game.Dresseur = sauvegarde;
                Game.Dresseur.Depot.RechargerEmplacements();
                MessageBox.Show("Sauvegarde chargée avec succès.", "Sauvegarde chargée", MessageBoxButton.OK);
                Game.Naviguer("joueur");
            }
            else
            {
                MessageBox.Show("La sauvegarde a été corrompue. Il est impossible de la lire. " +
                    "Veuillez débuter une nouvelle partie.", "Sauvegarde corrompue", MessageBoxButton.OK);
            }
        }
    }
}
