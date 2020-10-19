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
    /// Logique d'interaction pour Client_normal_gestion.xaml
    /// </summary>
    public partial class Client_normal_gestion : Window
    {
        
        public Client_normal_gestion()
        {
            
            InitializeComponent();
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

            #region Récupération du compte
            string requete_compte = "Select compte from client where id_client = '" + textblock_recup_id.Text + "';";
            MySqlCommand command_compte = maConnexion.CreateCommand();
            command_compte.CommandText = requete_compte;

            MySqlDataReader reader_compte = command_compte.ExecuteReader();

            string chaine_compte = "";

            while (reader_compte.Read())
            {
                chaine_compte+= reader_compte["compte"];
                
            }

            reader_compte.Close();
            command_compte.Dispose();

            #endregion

            maConnexion.Close();

            if(chaine_compte == "") // En sécurité
            {
                chaine_compte += "0";
            }

            Compte fen1 = new Compte();
            fen1.textblock_points_cooks.Text = chaine_compte + " cooks"; // Envoi de paramètres à la fenêtre suivante
            fen1.textblock_recup_id.Text = textblock_recup_id.Text;
            fen1.Show();
            
        }

        private void boutton_commande_Click(object sender, RoutedEventArgs e)
        {
            passage_de_commande fen1 = new passage_de_commande();
            fen1.textblock_recup_id.Text = textblock_recup_id.Text;
            fen1.Show();
            this.Hide();

        }

        private void boutton_deconnexion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bouton_classement_Click(object sender, RoutedEventArgs e)
        {
            Classement fenC = new Classement();
            fenC.Show();
        }
    }
}
