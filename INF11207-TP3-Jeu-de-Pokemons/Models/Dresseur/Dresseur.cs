using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Dresseur : Personnage
    {
        private string firstName;
        private int age;
        private int money;

        public GuidePourDebloquerPokemons Guide { get; set; }
        public DepotPokemons Depot { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    SetIsValid();
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    SetIsValid();
                }
            }
        }

        public int Money
        {
            get { return money; }
            set
            {
                if (money != value)
                {
                    money = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValid
        {
            get { return isValid; }
        }

        public Dresseur(string name = "", string firstName = "", int age = 18, int level = 1, int experience = 100, int money = 5000) : base(name, level, experience)
        {
            FirstName = firstName;
            Age = age;
            Money = money;
            Guide = new GuidePourDebloquerPokemons(level);
            Depot = new DepotPokemons(level);
        }

        protected override void SetIsValid()
        {
            isValid = !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(FirstName) && Age > 0;
        }
    }
}
