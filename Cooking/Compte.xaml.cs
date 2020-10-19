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
    /// Logique d'interaction pour Compte.xaml
    /// </summary>
    public partial class Compte : Window
    {
        public Compte()
        {
            InitializeComponent();
            combobox_crediter.Items.Add(5); // Initialisation de la combobox
            combobox_crediter.Items.Add(10);
            combobox_crediter.Items.Add(20);
            combobox_crediter.Items.Add(50);
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

            #region Récupération du compte
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

            if(chaine_compte == "") { chaine_compte = "0"; }
            int resultat = Convert.ToInt32(chaine_compte) + Convert.ToInt32(combobox_crediter.SelectedItem);

            #region Update du compte du client
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
