using Newtonsoft.Json;
using System.IO;

namespace INF11207_TP3_Jeu_de_Pokemons.Services
{
    public class Loader
    {
        public static bool PeutEtreCharge(string nomFichier)
        {
            return File.Exists(nomFichier);
        }

        public static bool Sauvegarder<T>(T objetASauvegarder, string nomFichier)
        {
            bool sauvegardeReussie = true;

            try
            {
                string objetSerialise = JsonConvert.SerializeObject(objetASauvegarder, Formatting.Indented);
                using (StreamWriter sauvegarde = File.CreateText(nomFichier))
                {
                    sauvegarde.Write(objetSerialise);
                }
            }
            catch (JsonSerializationException)
            {
                sauvegardeReussie = false;
            }

            return sauvegardeReussie;
        }

        public static bool Charger<T>(out T objetACharger, string nomFichier) where T : new()
        {
            bool chargementReussi = true;
            objetACharger = new();
            
            try
            {
                using (StreamReader contenuFichier = File.OpenText(nomFichier))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    objetACharger = (T)serializer.Deserialize(contenuFichier, typeof(T));
                }
            } catch (JsonSerializationException)
            {
                chargementReussi = false;
            }

            return chargementReussi;
        }
    }
}
