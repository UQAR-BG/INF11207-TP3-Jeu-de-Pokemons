using INF11207_TP3_Jeu_de_Pokemons.Enums;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Pokemon : Personnage
    {
        private string description;
        private int atk;
        private int def;
        private int health;
        private JaugeVie hpGauge;
        private string image;

        private List<Attaque> attacks;

        public int Id { get; set; }
        public List<OrigineType> Types { get; set; }
        public Evolution Evolution { get; set; }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ATK
        {
            get { return atk; }
            set
            {
                if (atk != value)
                {
                    atk = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DEF
        {
            get { return def; }
            set
            {
                if (def != value)
                {
                    def = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (health != value)
                {
                    health = value;
                    hpGauge = new JaugeVie(health);
                    OnPropertyChanged();
                }
            }
        }

        public JaugeVie HpGauge
        {
            get { return hpGauge; }
            set
            {
                if (hpGauge != value)
                {
                    hpGauge = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Attaque> Attacks
        {
            get { return attacks; }
            set
            {
                if (attacks != value)
                {
                    attacks = value;
                    OnPropertyChanged();
                }
            }
        }

        public Pokemon(int id, string nom, string description, int atk, int def, Evolution evolution,
            List<OrigineType> types, int health, string image, int niveau, int experiencePerLevel, List<Attaque> attaques) 
            : base(nom, niveau, experiencePerLevel)
        {
            Id = id;
            Description = description;
            Evolution = evolution;
            ATK = atk;
            DEF = def;
            Types = types;
            Health = health;
            Image = image;
            Attacks = attaques;
        }
    }
}
