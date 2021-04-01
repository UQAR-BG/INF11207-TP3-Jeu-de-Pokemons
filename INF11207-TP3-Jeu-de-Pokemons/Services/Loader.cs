using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace INF11207_TP3_Jeu_de_Pokemons.Services
{
    public class Loader
    {
        public static bool PeutEtreCharge(string nomFichier)
        {
            return File.Exists(nomFichier);
        }

        public static bool Sauvegarder<T>(T objetASauvegarder)
        {
            bool sauvegardeReussie = true;



            return sauvegardeReussie;
        }

        public static T Charger<T>(string nomFichier) where T : new()
        {
            T objetACharger;

            try
            {
                using (StreamReader contenuFichier = File.OpenText(nomFichier))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    objetACharger = (T)serializer.Deserialize(contenuFichier, typeof(T));
                }
            } catch (IOException)
            {
                objetACharger = new();
            }

            return objetACharger;
        }
    }
}
