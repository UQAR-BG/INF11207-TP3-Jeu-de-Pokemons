using INF11207_TP3_Jeu_de_Pokemons.Enums;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Dresseur : Personnage
    {
        private string firstName;
        private int age;
        private int money;

        private DepotPokemons depot;

        public GuidePourDebloquerPokemons Guide { get; set; }
        public DepotPokemons Depot { get; set; }
        public Statistiques Statistiques { get; set; }

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

        public string PrintMoney
        {
            get { return $"{Money}$"; }
        }

        public bool IsValid
        {
            get { return isValid; }
        }

        [JsonConstructor]
        public Dresseur() { }

        public Dresseur(int level, string name = "", string firstName = "", int age = 18, int experience = 100, int money = 5000) : base(name, level, experience)
        {
            FirstName = firstName;
            Age = age;
            Money = money;
            Guide = new GuidePourDebloquerPokemons(level);
            Depot = new DepotPokemons(level);
            Statistiques = new Statistiques(money, 1);
        }

        public bool Acheter(Pokemon pokemon)
        {
            bool pokemonAcheteAvecSucces = true;
            int prix = pokemon.Price;

            if (Money >= prix)
            {
                Money -= prix;
                Pokemon pokemonAchete = (Pokemon)pokemon.Clone();
                pokemonAchete.Achete = true;
                Depot.PokemonsAchetes.Add(pokemonAchete);
            }
            else
            {
                pokemonAcheteAvecSucces = false;
            }

            return pokemonAcheteAvecSucces;
        }

        public void Equiper(Pokemon pokemon, Emplacement emplacement)
        {
            if (pokemon.Equipe)
            {
                Echanger(pokemon.Emplacement, emplacement);
            }
            else
            {
                Depot.EquiperPokemon(emplacement, pokemon);
            }
        }

        public void Echanger(Emplacement emplacement1, Emplacement emplacement2)
        {
            int position1 = (int)emplacement1;
            int position2 = (int)emplacement2;

            if (emplacement1 != emplacement2)
            {
                PokemonEquipe pokemon1 = Depot.PokemonsEquipes[position1];
                pokemon1.Ordre = emplacement2;

                Depot.PokemonsEquipes[position1] = Depot.PokemonsEquipes[position2];
                Depot.PokemonsEquipes[position1].Ordre = emplacement1;

                Depot.PokemonsEquipes[position2] = pokemon1;

                if (Depot.PokemonsEquipes[position1].Equipe)
                {
                    Depot.PokemonsEquipes[position1].Pokemon.Emplacement = emplacement1;
                }

                if (Depot.PokemonsEquipes[position2].Equipe)
                {
                    Depot.PokemonsEquipes[position2].Pokemon.Emplacement = emplacement2;
                }
            }
        }

        public void Desequiper(Emplacement emplacement)
        {
            Depot.DesequiperPokemon(emplacement);
        }

        protected override void SetIsValid()
        {
            isValid = !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(FirstName) && Age > 0;
        }
    }
}
