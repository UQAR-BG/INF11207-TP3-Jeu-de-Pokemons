using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for Statistiques.xaml
    /// </summary>
    public partial class Statistiques : UserControl
    {
        public Statistiques()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }
    }
}
