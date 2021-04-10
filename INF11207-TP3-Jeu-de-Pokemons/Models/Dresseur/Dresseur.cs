using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Dresseur : Personnage, ICombattant
    {
        private string firstName;
        private int age;
        private int money;

        public GuidePourDebloquerPokemons Guide { get; set; }

        public DepotPokemons Depot { get; set; }

        public Statistiques Statistiques { get; set; }

        public List<Invitation> Invitations { get; set; }

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
        public Dresseur()
        {
            Depot = new DepotPokemons();
            Invitations = new List<Invitation>();
        }

        public Dresseur(int level, string name = "", string firstName = "", int age = 18, int experience = 100, int money = 5000) : base(name, level, experience)
        {
            FirstName = firstName;
            Age = age;
            Money = money;
            Guide = new GuidePourDebloquerPokemons(level);
            Depot = new DepotPokemons(level);
            Statistiques = new Statistiques(money, 1);
            Invitations = new List<Invitation>();
        }

        public bool EncorePokemonsValides()
        {
            bool pokemonsValides = false;
            foreach (EmplacementPokemon emplacement in Depot.Emplacements)
            {
                if (Depot.Equipe(emplacement.Ordre) && emplacement.Pokemon.EncoreValide())
                {
                    pokemonsValides = true;
                }
            }
            return pokemonsValides;
        }

        public void TerminerUnCombat(ResultatCombat resultats)
        {
            Level += XpGauge.AjouterExperience(resultats.Experience);
            Money += resultats.Mise;

            Guide.AppliquerCorrespondance(Level);

            foreach (EmplacementPokemon emplacement in Depot.Emplacements)
            {
                if (emplacement.Equipe)
                {
                    int indexPokemon = Depot.IndexPokemonsEquipes[(int)emplacement.Ordre];

                    emplacement.Pokemon.TerminerUnCombat(resultats);
                    Pokemon evolution = emplacement.Pokemon.Evolution.EvoluerSiAtteintLeNiveau(emplacement.Pokemon);
                    MessageBox.Show($"{emplacement.Pokemon.Name} va évoluer!", "Évolution", MessageBoxButton.OK);

                    if (evolution != null)
                    {
                        emplacement.Pokemon = evolution;
                        Depot.Evolution(indexPokemon, evolution);
                    }
                }
            }
        }

        public Pokemon Acheter(Pokemon pokemon)
        {
            Pokemon pokemonAchete = new Pokemon();
            int prix = pokemon.Price;

            if (Money >= prix && !pokemon.Achete)
            {
                Money -= prix;
                pokemonAchete = (Pokemon)pokemon.Clone();
                pokemonAchete.Acheter();
                Depot.PokemonsAchetes.Add(pokemonAchete);
            }

            return pokemonAchete;
        }

        public void Equiper(int indexPokemon, Emplacement emplacement)
        {
            Pokemon pokemon = Depot.PokemonsAchetes[indexPokemon];

            if (pokemon.Equipe)
            {
                Echanger(pokemon.Emplacement, emplacement);
            }
            else
            {
                Desequiper(emplacement);
                Depot.EquiperPokemon(emplacement, indexPokemon);
            }
        }

        public void Echanger(Emplacement emplacement1, Emplacement emplacement2)
        {
            Depot.Echanger(emplacement1, emplacement2);
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
