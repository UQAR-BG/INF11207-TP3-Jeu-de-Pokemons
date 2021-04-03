using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Recherche : Binding
    {
        private FiltreRecherche _filtre;
        private string _nom;
        private List<Pokemon> _resultats;

        public FiltreRecherche Filtre
        {
            get { return _filtre; }
            set
            {
                if (_filtre != value)
                {
                    _filtre = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (!_nom.Equals(value))
                {
                    _nom = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool RechercheTous
        {
            get { return _filtre == FiltreRecherche.Tous; }
        }

        public Recherche(FiltreRecherche filtre = FiltreRecherche.Tous, string nom = "")
        {
            _filtre = filtre;
            _nom = nom;
            _resultats = new List<Pokemon>();
        }

        public void Reinitialiser()
        {
            _filtre = FiltreRecherche.Tous;
            _nom = "";
            _resultats = new List<Pokemon>();
        }

        public List<Pokemon> Rechercher()
        {
            return _resultats;
        }
    }
}
