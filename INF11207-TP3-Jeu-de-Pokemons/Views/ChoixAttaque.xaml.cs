using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for ChoixAttaque.xaml
    /// </summary>
    public partial class ChoixAttaque : Window
    {
        public ChoixAttaque(List<Attaque> attaques)
        {
            InitializeComponent();
            DataContext = new ChoixAttaqueViewModel(this, attaques);
        }
    }
}
