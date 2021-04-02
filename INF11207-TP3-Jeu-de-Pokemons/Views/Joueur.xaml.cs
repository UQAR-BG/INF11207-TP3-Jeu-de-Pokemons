using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for Joueur.xaml
    /// </summary>
    public partial class Joueur : UserControl
    {
        public Joueur()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }
    }
}
