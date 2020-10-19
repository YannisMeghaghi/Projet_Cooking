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
    /// Logique d'interaction pour Classement.xaml
    /// </summary>
    public partial class Classement : Window
    {
        public Classement()
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

            //Classement des CdR
            //On classe les créateurs en fonction d nombre de recette qu'ils ont vendus
            string requeteC = "Select * from cooking.createur_de_recette order by nbr_recette_vendue DESC;";
            MySqlCommand commandC = maConnexion.CreateCommand();
            commandC.CommandText = requeteC;
            MySqlDataReader readerC = commandC.ExecuteReader();
            string chaine_classement = "";
            while (readerC.Read())
            {
                chaine_classement += readerC["id_cdr"] + " "; // On rajoute un espace afin de pouvoir ensuite split(' ') cette chaîne de caractères
            }

            string[] liste_classement = chaine_classement.Split(' ');

            for (int i = 0; i < liste_classement.Length - 1; i++)
            {
                listbox_classement_cdr.Items.Add(liste_classement[i]); // On les ajoute à la listbox.
            }

            readerC.Close();
            commandC.Dispose();

            //Classement des recettes
            //Idem mais avec les recettes en fonction du nombre de fois qu'ils ont été vendues

            string requeteR = "Select * from cooking.recette order by nbr_fois_vendue DESC;";
            MySqlCommand commandR = maConnexion.CreateCommand();
            commandR.CommandText = requeteR;
            MySqlDataReader readerR = commandR.ExecuteReader();
            string chaine_classementR = "";
            while (readerR.Read())
            {
                chaine_classementR += readerR["id_recette"] + " "; // Même technique avec le split(' ')
            }

            string[] liste_classementR = chaine_classementR.Split(' ');

            readerR.Close();
            commandR.Dispose();

            string chaine_nbr_vente = "";
            for (int i = 0; i < liste_classementR.Length - 1; i++) //On boucle sur la liste des recettes
            {
                string req = "Select * from cooking.recette where id_recette = '" + liste_classementR[i] + "';";
                MySqlCommand comV = maConnexion.CreateCommand();
                comV.CommandText = req;
                MySqlDataReader readerV = comV.ExecuteReader();

                while (readerV.Read())
                {
                    chaine_nbr_vente += readerV["nbr_fois_vendue"] + " "; // On récupère ensuite le nombre de ventes pour les afficher à côté des noms
                }

                readerV.Close();
                comV.Dispose();
            }

            string[] liste_nbr_vente = chaine_nbr_vente.Split(' ');

            for (int i = 0; i < liste_classementR.Length - 1; i++)
            {
                listbox_classement_recette.Items.Add(liste_classementR[i] + " : " + liste_nbr_vente[i] + " ventes"); // Affichage final
            }

            
            maConnexion.Close();

        }

        private void bouton_infos_recette_Click(object sender, RoutedEventArgs e)
        {
            Infos_recette fen = new Infos_recette();
            string[] chaine = listbox_classement_recette.SelectedItem.ToString().Split(' ');// Permet d'avoir des infos supplémentaires sur chaque recettes
            fen.textblock_recup__recette.Text = chaine[0];
            fen.Tout();
            fen.Show();
        }
    }
}
