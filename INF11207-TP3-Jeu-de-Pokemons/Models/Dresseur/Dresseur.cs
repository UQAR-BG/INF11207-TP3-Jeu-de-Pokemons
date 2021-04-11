using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Dresseur : Personnage, ICombattant
    {
        private string firstName;
        private int age;
        private int money;

        [JsonIgnore]
        private Pokemon pokemonEquipe;

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

        [JsonIgnore]
        public Pokemon PokemonEquipe
        {
            get 
            { 
                if (pokemonEquipe != null)
                {
                    return pokemonEquipe;
                }
                return new Pokemon(); 
            }
            set
            {
                if (pokemonEquipe != value)
                {
                    pokemonEquipe = value;
                    OnPropertyChanged();
                }
            }
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
            if (PokemonsValides().Count > 0)
            {
                pokemonsValides = true;
            }
            return pokemonsValides;
        }

        public Pokemon PremierPokemonValide()
        {
            List<Pokemon> pokemonsValides = PokemonsValides();
            Pokemon premierPokemon = new Pokemon();

            if (pokemonsValides.Count > 0)
            {
                premierPokemon = pokemonsValides[0];
            }
            return premierPokemon;
        }

        public void MettreAJourPokemonEquipe()
        {
            PokemonEquipe = PremierPokemonValide();
        }

        public void TerminerUnCombat(ResultatCombat resultats)
        {
            Level += XpGauge.AjouterExperience(resultats.Experience);
            ModifierArgent(resultats.Mise);

            Guide.AppliquerCorrespondance(Level);
            Statistiques.PokemonsDebloques = Guide.IdPokemonsDebloques.Count;
            Statistiques.CombatsTotal++;
            if (resultats.Victoire)
            {
                Statistiques.CombatsGagnes++;
            }
            else
            {
                Statistiques.CombatsPerdus++;
            }

            foreach (EmplacementPokemon emplacement in Depot.Emplacements)
            {
                if (emplacement.Equipe)
                {
                    int indexPokemon = Depot.IndexPokemonsEquipes[(int)emplacement.Ordre];

                    emplacement.Pokemon.TerminerUnCombat(resultats);
                    Pokemon evolution = emplacement.Pokemon.Evolution.EvoluerSiAtteintLeNiveau(emplacement.Pokemon);

                    if (evolution != null)
                    {
                        emplacement.Pokemon = evolution;
                        Depot.Evolution(indexPokemon, evolution);
                    }
                }
            }
        }

        public void ModifierArgent(int montant)
        {
            if (montant >= 0)
            {
                Statistiques.MontantAccumule += montant;
                Money += montant;
            }
            else
            {
                Statistiques.MontantDepense -= montant;
                Money += montant;
            }
        }

        public Pokemon Acheter(Pokemon pokemon)
        {
            Pokemon pokemonAchete = new Pokemon();
            int prix = pokemon.Price;

            if (Money >= prix && !pokemon.Achete)
            {
                ModifierArgent(-prix);
                pokemonAchete = (Pokemon)pokemon.Clone();
                pokemonAchete.Acheter();
                Depot.PokemonsAchetes.Add(pokemonAchete);
                Statistiques.PokemonsAchetes++;
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

        private List<Pokemon> PokemonsValides()
        {
            List<Pokemon> pokemonValides = new List<Pokemon>();

            foreach (EmplacementPokemon emplacement in Depot.Emplacements)
            {
                if (Depot.Equipe(emplacement.Ordre) && emplacement.Pokemon.EncoreValide())
                {
                    pokemonValides.Add(emplacement.Pokemon);
                }
            }
            return pokemonValides;
        }
    }
}
