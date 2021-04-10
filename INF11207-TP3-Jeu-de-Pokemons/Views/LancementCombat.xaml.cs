using INF11207_TP3_Jeu_de_Pokemons.Interfaces;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for LancementCombat.xaml
    /// </summary>
    public partial class LancementCombat : UserControl, INombreEnEntree
    {
        public LancementCombat()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }

        public void VerifierSiEntreeEstNombre(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserControl_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                ((LancementCombatViewModel)DataContext).RechercherInvitations();
            }
        }
    }
}
