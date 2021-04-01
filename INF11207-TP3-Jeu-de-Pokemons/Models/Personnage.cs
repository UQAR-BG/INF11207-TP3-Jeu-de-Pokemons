using INF11207_TP3_Jeu_de_Pokemons.ViewModels;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public abstract class Personnage : Binding
    {
        protected bool isValid;

        private string name;
        private int niveau;
        private JaugeXp xpGauge;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    SetIsValid();
                }
            }
        }

        public int Niveau
        {
            get { return niveau; }
            set
            {
                if (niveau != value)
                {
                    niveau = value;
                    OnPropertyChanged();
                }
            }
        }

        public JaugeXp XpGauge
        {
            get { return xpGauge; }
            set
            {
                if (xpGauge != value)
                {
                    xpGauge = value;
                    OnPropertyChanged();
                }
            }
        }

        public Personnage(string name = "", int niveau = 1, int experiencePerLevel = 100)
        {
            Name = name;
            Niveau = niveau;
            XpGauge = new JaugeXp(experiencePerLevel);
        }

        protected virtual void SetIsValid()
        {
            isValid = !string.IsNullOrEmpty(Name);
        }
    }
}
