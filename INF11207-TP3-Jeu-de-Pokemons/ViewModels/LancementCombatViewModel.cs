using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class LancementCombatViewModel : BaseViewModel
    {
        private Invitation _invitation;
        private Invitation _invitationSelectionnee;
        private ObservableCollection<Invitation> _resultats;

        public ICommand CommandeCreer { get; set; }

        public ICommand CommandeLancer { get; set; }

        public Invitation Invitation
        {
            get { return _invitation; }
            set { _invitation = value; }
        }

        public Invitation InvitationSelectionne
        {
            get { return _invitationSelectionnee; }
            set
            {
                _invitationSelectionnee = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Invitation> Resultats
        {
            get { return _resultats; }
            set
            {
                if (_resultats != value)
                {
                    _resultats = value;
                    OnPropertyChanged();
                }
            }
        }

        public LancementCombatViewModel(WindowSize size) : base(size) 
        {
            CommandeCreer = new RelayCommand(
                o => Invitation.IsValid,
                o => CreerInvitation()
            );

            CommandeLancer = new RelayCommand(
                o => _invitationSelectionnee != null && Invitation.IsValid,
                o => LancerUnCombat()
            );
        }

        public void RechercherInvitations()
        {
            Invitation = new Invitation(Dresseur);
            Invitation.MiseCreateur = 100;

            List<Invitation> invitations = ChargerInvitations();
            invitations.AddRange(Dresseur.Invitations.FindAll(i => i.Statut == StatutType.Attente));

            Resultats = new ObservableCollection<Invitation>(invitations);
            InvitationSelectionne = Resultats[0];
        }

        private void CreerInvitation()
        {
            Invitation.Statut = StatutType.Accepte;
            Dresseur.Invitations.Add(Invitation);

            MessageBox.Show($" Le dresseur {Resultats[0].NomCreateur} a accepté votre invitation.\nLancement du combat en cours...", 
                "Nouveau combat", MessageBoxButton.OK);

            LancerUnCombat();
        }

        private void LancerUnCombat()
        {
            Dresseur.ModifierArgent(-Invitation.MiseCreateur);

            int mise = Invitation.MiseCreateur + InvitationSelectionne.MiseCreateur;
            Dresseur adversaire = Resultats[0].Createur;
            adversaire.Depot.RechargerEmplacements();
            Game.Combat = new Combat(Dresseur, adversaire, mise);

            Game.Naviguer("combats");
        }

        private List<Invitation> ChargerInvitations()
        {
            List<Invitation> invitations = new List<Invitation>();
            if (!Loader.Charger(out invitations, "Resources/Data/InvitationsParDefaut.json"))
            {
                MessageBox.Show("Le fichier InvitationsParDefaut.json est manquant. Le jeu pourra donc rencontrer des comportements étranges.",
                    "Données manquantes", MessageBoxButton.OK);
            }
            return invitations;
        }
    }
}
