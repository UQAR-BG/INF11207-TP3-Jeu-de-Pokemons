using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using Newtonsoft.Json;
using System;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Invitation : Binding
    {
        [JsonIgnore]
        private bool isValid;

        private StatutType statut;
        private string nomAdversaire;
        private string nomCreateur;
        private int miseCreateur;
        private int miseAdversaire;
        private int niveau;

        private DateTime dateCreation;
        private Dresseur createur;

        public StatutType Statut
        {
            get { return statut; }
            set
            {
                if (statut != value)
                {
                    statut = value;
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

        public string NomAdversaire
        {
            get { return nomAdversaire; }
            set
            {
                if (nomAdversaire != value)
                {
                    nomAdversaire = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NomCreateur
        {
            get { return nomCreateur; }
            set
            {
                if (nomCreateur != value)
                {
                    nomCreateur = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MiseCreateur
        {
            get { return miseCreateur; }
            set
            {
                if (miseCreateur != value)
                {
                    miseCreateur = value;
                    SetIsValid();
                }
            }
        }

        public int MiseAdversaire
        {
            get { return miseAdversaire; }
            set
            {
                if (miseAdversaire != value)
                {
                    miseAdversaire = value;
                    SetIsValid();
                }
            }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set
            {
                if (dateCreation != value)
                {
                    dateCreation = value;
                    OnPropertyChanged();
                }
            }
        }

        public Dresseur Createur
        {
            get { return createur; }
            set
            {
                if (createur != value)
                {
                    createur = value;
                    SetIsValid();
                }
            }
        }

        [JsonIgnore]
        public bool IsValid
        {
            get { return isValid; }
            set
            {
                if (isValid != value)
                {
                    isValid = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonConstructor]
        public Invitation() { }

        public Invitation(Dresseur createur)
        {
            statut = StatutType.Attente;

            this.createur = createur;
            NomCreateur = $"{createur.FirstName} {createur.Name}";
            Niveau = createur.Level;
            DateCreation = DateTime.Now;
        }

        public bool ShouldSerializeCreateur()
        {
            return false;
        }

        public void Confirmer()
        {

        }

        public void Refuser()
        {

        }

        private void SetIsValid()
        {
            IsValid = createur != null && MiseCreateur >= 100 && createur.Money >= MiseCreateur;
        }
    }
}
