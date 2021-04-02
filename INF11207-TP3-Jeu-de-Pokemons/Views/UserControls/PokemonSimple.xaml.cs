using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels.UserControlViewModels;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PokemonSimple.xaml
    /// </summary>
    public partial class PokemonSimple : UserControl
    {
        public PokemonSimple()
        {
            InitializeComponent();
            PokemonEquipe pokemon = (PokemonEquipe)DataContext;
            DataContext = new PokemonSimpleViewModel(pokemon);
        }
    }
}
