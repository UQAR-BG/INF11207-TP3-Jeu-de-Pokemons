using INF11207_TP3_Jeu_de_Pokemons.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Pokemon : Personnage, ICloneable
    {
        private string description;
        private int atk;
        private int def;
        private int price;
        private int health;
        private Emplacement emplacement;
        private JaugeVie hpGauge;
        private string image;
        private bool achete;
        private bool equipe;

        private List<Attaque> attacks;

        public int Id { get; set; }
        public List<OrigineType> Types { get; set; }

        public string PrintTypes
        {
            get
            {
                string types = "";
                for (int i = 0; i < Types.Count; i++)
                {
                    types += Types[i].ToString() + (i < Types.Count - 1 ? ", " : "");
                }
                return types;
            }
        }

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

        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PrintPrice
        {
            get { return $"{price}$"; }
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

        public bool Achete
        {
            get { return achete; }
            set
            {
                if (achete != value)
                {
                    achete = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Equipe
        {
            get { return equipe; }
            set
            {
                if (equipe != value)
                {
                    equipe = value;
                    OnPropertyChanged();
                }
            }
        }

        public Emplacement Emplacement
        {
            get { return emplacement; }
            set
            {
                if (emplacement != value)
                {
                    if (value == Emplacement.Desequipe)
                    {
                        Equipe = false;
                    }
                    else
                    {
                        Equipe = true;
                    }
                    emplacement = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonConstructor]
        public Pokemon() : base("", 1, 100) { }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
