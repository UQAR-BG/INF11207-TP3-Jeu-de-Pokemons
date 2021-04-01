using INF11207_TP3_Jeu_de_Pokemons.Enums;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Pokemon : Personnage
    {
        private int id;
        private string description;
        private int pointsAttaque;
        private int pointsDefense;
        private int health;
        private JaugeVie hpGauge;
        private string image;

        private List<Attaque> attacks;

        public int Id { get; set; }

        public List<OrigineType> Types { get; set; }

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

        public int PointsAttaque
        {
            get { return pointsAttaque; }
            set
            {
                if (pointsAttaque != value)
                {
                    pointsAttaque = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PointsDefense
        {
            get { return pointsDefense; }
            set
            {
                if (pointsDefense != value)
                {
                    pointsDefense = value;
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

        public Pokemon(int id, string nom, string description, int pointsAttaque, int pointsDefense, 
            List<OrigineType> types, int health, string image, int niveau, int experiencePerLevel, List<Attaque> attaques) 
            : base(nom, niveau, experiencePerLevel)
        {
            Id = id;
            Description = description;
            PointsAttaque = pointsAttaque;
            PointsDefense = pointsDefense;
            Types = types;
            Health = health;
            Image = image;
            Attacks = attaques;
        }
    }
}
