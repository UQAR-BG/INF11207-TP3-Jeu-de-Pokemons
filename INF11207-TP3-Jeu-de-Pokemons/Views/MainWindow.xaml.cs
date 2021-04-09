using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Game.MainWindow;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (PeutSauvegarder())
            {
                MessageBoxResult reponse = MessageBox.Show("Souhaitez-vous sauvegarder avant de quitter?", "Quitter", MessageBoxButton.YesNo);
                if (reponse == MessageBoxResult.Yes)
                {
                    Game.Sauvegarder();
                }
            }
        }

        private bool PeutSauvegarder()
        {
            return Game.VueActuelle is not AccueilViewModel && Game.VueActuelle is not CreationJoueurViewModel;
        }
    }
}
