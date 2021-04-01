﻿using INF11207_TP3_Jeu_de_Pokemons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class CreationJoueurViewModel : BaseViewModel
    {
        public Dresseur Dresseur { get; set; }

        public ICommand CommandeCreerJoueur { get; private set; }

        public CreationJoueurViewModel()
        {
            Dresseur = new Dresseur();

            CommandeCreerJoueur = new RelayCommand(
                o => Dresseur.IsValid,
                o => CreerJoueur()
            );
        }

        private void CreerJoueur()
        {
            MessageBox.Show($"Le joueur {Dresseur.FirstName} {Dresseur.Name}", "Joueur créé", MessageBoxButton.OK);

            string serializedDresseur = JsonConvert.SerializeObject(Dresseur, Formatting.Indented);
            using (StreamWriter sauvegarde = File.CreateText("joueur.json"))
            {
                sauvegarde.Write(serializedDresseur);
            }
        }
    }
}