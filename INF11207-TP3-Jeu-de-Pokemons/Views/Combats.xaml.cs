using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for Combats.xaml
    /// </summary>
    public partial class Combats : UserControl
    {
        public Combats()
        {
            InitializeComponent();
            DataContext = Game.VueActuelle;
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                try
                {
                    ((CombatsViewModel)DataContext).LancerCombat();
                }
                catch (Exception) { }
            }
        }
    }
}
