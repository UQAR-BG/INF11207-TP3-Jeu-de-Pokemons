using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for Pokemons.xaml
    /// </summary>
    public partial class Pokemons : UserControl
    {
        public Pokemons()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }
    }
}
