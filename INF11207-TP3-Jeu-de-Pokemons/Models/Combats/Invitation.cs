using INF11207_TP3_Jeu_de_Pokemons.Enums;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models.Combats
{
    public class Invitation
    {
        private StatutType statut;
        private string nomDestinataire;
        private string nomCreateur;

        [JsonIgnore]
        private Dresseur createur;

        public StatutType Statut
        {
            get { return statut; }
        }

        public string NomDestinataire
        {
            get { return nomDestinataire; }
        }

        public string NomCreateur
        {
            get { return nomCreateur; }
        }

        [JsonConstructor]
        public Invitation() { }

        public Invitation(Dresseur createur)
        {
            statut = StatutType.Attente;

            this.createur = createur;
            nomCreateur = createur.Name;
        }

        public void Confirmer()
        {

        }

        public void Refuser()
        {

        }
    }
}
