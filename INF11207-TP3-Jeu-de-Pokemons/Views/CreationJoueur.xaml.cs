using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for CreationJoueur.xaml
    /// </summary>
    public partial class CreationJoueur : Window
    {
        public CreationJoueur()
        {
            InitializeComponent();
        }

        private void VerifierSiEntreeEstNombre(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
