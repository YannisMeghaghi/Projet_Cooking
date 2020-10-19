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
    /// Logique d'interaction pour CdR_gestion.xaml
    /// </summary>
    public partial class CdR_gestion : Window
    {
        public CdR_gestion()
        {
            InitializeComponent();
        }

        private void boutton_compte_CdR_Click(object sender, RoutedEventArgs e)
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

            //On récupère le compte de l'utilisateur
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

            if (chaine_compte == "")
            {
                chaine_compte += "0";
            }


            //On récupère tout du créateur de recette
            string requete_recette = "Select * from createur_de_recette where id_client = '" + textblock_recup_id.Text + "';";
            MySqlCommand command_recette = maConnexion.CreateCommand();
            command_recette.CommandText = requete_recette;

            MySqlDataReader reader_recette = command_recette.ExecuteReader();

            string chaine_recette = "";

            while (reader_recette.Read())
            {
                chaine_recette += reader_recette["nbr_recette_vendue"];// Pour ne sélectionner que le nombre de recette vendues

            }

            reader_recette.Close();
            command_recette.Dispose();

            maConnexion.Close();

            Compte_cdr fen1 = new Compte_cdr();
            fen1.textblock_recup_id.Text = textblock_recup_id.Text; // On envoi différents paramètres aux fenêtres suivantes
            fen1.textblock_points_cooks.Text = chaine_compte + " cooks";
            fen1.textblock_nbr_recette.Text = chaine_recette;
            fen1.Show();
        }

        private void boutton_commande_CdR_Click(object sender, RoutedEventArgs e)
        {
            passage_de_commande fen1 = new passage_de_commande();
            fen1.textblock_recup_id.Text = textblock_recup_id.Text; // Envoi de paramètres
            fen1.Show();
            this.Hide();
        }

        private void boutton_nouvelle_recette_Click(object sender, RoutedEventArgs e)
        {
            Creation_recette fen = new Creation_recette();
            fen.textblock_recup_id.Text = textblock_recup_id.Text;
            fen.Show();
        }

        private void bouton_stock_Click(object sender, RoutedEventArgs e)
        {
            Stocks fen = new Stocks();
            fen.Show();
        }

        private void bouton_mes_recettes_Click(object sender, RoutedEventArgs e)
        {
            MesRecettes fen_mes = new MesRecettes();
            fen_mes.textblock_recup_id.Text = textblock_recup_id.Text;
            fen_mes.Tout();
            fen_mes.Show();
        }

        private void bouton_classement_Click(object sender, RoutedEventArgs e)
        {
            Classement fenC = new Classement();
            fenC.Show();
        }

        private void boutton_deconnexion4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
