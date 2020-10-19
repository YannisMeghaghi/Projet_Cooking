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
    /// Logique d'interaction pour Compte_cdr.xaml
    /// </summary>
    public partial class Compte_cdr : Window
    {
        public Compte_cdr()
        {
            InitializeComponent();
            combobox_crediter.Items.Add(5); //Initialisationde la combobox
            combobox_crediter.Items.Add(10);
            combobox_crediter.Items.Add(20);
            combobox_crediter.Items.Add(50);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Suppresion du compte Créateur de recette, vous resterez tout de même un client", "Supprimer mon compte");

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

            #region On récupère les recettes crée par l'utilisateur connecté
            string requete = "Select id_recette from recette where id_cdr = '" + textblock_recup_id.Text + "'";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string chaine = "";

            while (reader.Read())
            {
                chaine += reader["id_recette"] + " ";
            }

            string[] liste = chaine.Split(' ');

            reader.Close();
            command.Dispose();
            #endregion

            for (int i = 0; i < liste.Length - 1; i++)// On boucle sur la liste des recettes fin de supprimer toutes les recettes du créateur
            {                                         // Car on le compte est en cours de suppression.
                string requete1 = "Delete from recette where id_recette = '" + liste[i] + "';";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete1;
                MySqlDataReader reader1 = command1.ExecuteReader();

                reader1.Close();
                command1.Dispose();
            }
            
            //Enfin on Delete le compte du créateur de recette connecté.

            string requete2 = "Delete from createur_de_recette where id_cdr = '" + textblock_recup_id.Text + "';";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete2;
            MySqlDataReader reader2 = command2.ExecuteReader();

            reader2.Close();
            command2.Dispose();
            maConnexion.Close();
        }

        private void combobox_crediter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bouton_crediter_Click(object sender, RoutedEventArgs e)
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

            #region Récupération du compte de l'utilisateur
            string requete_compte = "Select compte from client where id_client = '" + textblock_recup_id.Text + "';";
            MySqlCommand command_compte = maConnexion.CreateCommand();
            command_compte.CommandText = requete_compte;

            MySqlDataReader reader_compte = command_compte.ExecuteReader();

            string chaine_compte = "";

            while (reader_compte.Read())
            {
                chaine_compte += reader_compte["compte"];

            }

            reader_compte.Close();
            command_compte.Dispose();

            #endregion

            if (chaine_compte == "") { chaine_compte = "0"; }
            int resultat = Convert.ToInt32(chaine_compte) + Convert.ToInt32(combobox_crediter.SelectedItem);

            #region Update du compte de l'utilisateur après créditation
            string requete = "Update client set compte = " + resultat + " where id_client = '" + textblock_recup_id.Text + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader = command.ExecuteReader();

            reader.Close();
            command.Dispose();

            #endregion

            maConnexion.Close();

            MessageBox.Show("Votre compte à bien été créditer. Quittez puis accédez à votre compte pour voir votre solde actualisé");

        }
    }
}
