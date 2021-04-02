using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {
        public Accueil()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }
    }
}
