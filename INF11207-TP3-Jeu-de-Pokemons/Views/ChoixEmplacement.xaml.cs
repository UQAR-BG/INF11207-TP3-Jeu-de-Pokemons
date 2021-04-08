using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for ChoixEmplacement.xaml
    /// </summary>
    public partial class ChoixEmplacement : Window
    {
        public ChoixEmplacement()
        {
            InitializeComponent();
            DataContext = new ChoixEmplacementViewModel(this);
        }
    }
}
