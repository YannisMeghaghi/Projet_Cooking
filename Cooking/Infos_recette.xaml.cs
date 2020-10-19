using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Cooking
{
    /// <summary>
    /// Logique d'interaction pour Infos_recette.xaml
    /// </summary>
    public partial class Infos_recette : Window
    {
        public Infos_recette()
        {
            InitializeComponent();
        }

        public void Tout() // Créer car si tout cela était dans le constructeur ca ne marcherait pas (expliqué dans le rapport)
        {
            #region Connexion
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=cooking;" +
                                         "UID=root;PASSWORD=Jessyann1808*";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e1)
            {
                Console.WriteLine(" ErreurConnexion : " + e1.ToString());
                return;
            }
            #endregion

            #region Selection de différentes colonnes permettant de décrire une recette
            string requete = "Select * from cooking.recette where id_recette = '" + textblock_recup__recette.Text + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string chaine = "";

            while (reader.Read())
            {
                chaine += reader["id_recette"] + "_";
                chaine += "Liste des produits : " + reader["liste_produit"] + "_";
                chaine += "Quantités respectives de ces produits : " + reader["liste_quantite"] + "_";
                chaine += "Crée par : " + reader["id_cdr"];
            }

            string[] liste = chaine.Split('_');

            for(int i = 0; i < liste.Length - 1; i++)
            {
                textblock_infos.Text += liste[i] + "\n\n";
            }

            reader.Close();
            command.Dispose();

            #endregion

            maConnexion.Close();
        }
    }
}
