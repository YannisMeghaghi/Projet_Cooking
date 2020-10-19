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
    /// Logique d'interaction pour Demo2.xaml
    /// </summary>
    public partial class Demo2 : Window
    {
        public Demo2()
        {
            InitializeComponent();
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

            #region Selection des produit tel que stock_actu <= 2*stock_mini
            string requete = "Select * from produit where stock_actu <= 2*stock_mini;";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();

            string chaine = "";

            while (reader.Read())
            {
                chaine += reader["id_produit"] + " ";
            }

            string[] liste_produit = chaine.Split(' ');

            for (int i = 0; i < liste_produit.Length - 1; i++)
            {
                textblock_produit.Text += liste_produit[i] + "\n";
            }

            reader.Close();
            command.Dispose();

            #endregion

            maConnexion.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            #region Recherche des recettes contenant le produit recherché
            string requete = "Select * from recette where liste_produit like '%" + textbox_recherche.Text + "%';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();

            string chaine_recette = "";
            string chaine_produit = "";
            string chaine_qte = "";

            while (reader.Read())
            {
                chaine_recette += reader["id_recette"] + " ";
                chaine_produit += reader["liste_produit"] + "/";
                chaine_qte += reader["liste_quantite"] + "/";
            }

            string[] liste_recette = chaine_recette.Split(' ');
            string[] liste_produit = chaine_produit.Split('/');
            string[] liste_qte = chaine_qte.Split('/');

            

            for (int i = 0; i < liste_recette.Length - 1; i++)
            {
                for (int j = 0; j< liste_produit.Length - 1; j++)
                {
                    string[] liste_finie_p = liste_produit[j].Split(' ');
                    string[] liste_finie_q = liste_qte[j].Split(' ');

                    int index = 0;

                    for (int k = 0; k < liste_finie_q.Length - 1; k++)
                    {
                        if (liste_finie_p[k] == textbox_recherche.Text)
                        {
                            index = i;
                        }
                    }

                    textblock_qte.Text += liste_finie_q[index] + "\n";
                }


                textblock_recette.Text += liste_recette[i] + "\n";
            }

            reader.Close();
            command.Dispose();

            #endregion

            maConnexion.Close();
        }
    }
}
