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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void boutton_termine_Click(object sender, RoutedEventArgs e) // Contient la vérification des id et mdp.
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

            #region Vérification du mot de passe et de l'identifiant
            string requete_verif = "Select id_client from client where id_client = '" + textbox_idClient.Text + "' And mdp = '" + passwordbox.Password + "';";
            MySqlCommand command_verif = maConnexion.CreateCommand();
            command_verif.CommandText = requete_verif;

            MySqlDataReader reader_verif = command_verif.ExecuteReader();

            string[] valueString = new string[reader_verif.FieldCount];
            string chaine = "";

            while (reader_verif.Read())
            {
                string id_client_trouve = (string)reader_verif["id_client"];
                chaine += id_client_trouve + " ";

                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //  valueString[i] = reader.GetValue(i).ToString();
                //Console.Write(valueString[i] + " , ");
                //}
                //Console.WriteLine();
            }

            reader_verif.Close();
            command_verif.Dispose();

            if(chaine == "") // Si on trouve rien la chaîne sera vide
            {
                MessageBox.Show("Identifiant ou mot de passe incorrects.\nVeuillez réessayer.");
            }
            else
            {
                string requete_cdr = "Select * from client where id_client = '" + textbox_idClient.Text +"';";
                MySqlCommand command_cdr = maConnexion.CreateCommand();
                command_cdr.CommandText = requete_cdr;

                MySqlDataReader reader_cdr = command_cdr.ExecuteReader();
                string[] valueString_cdr = new string[reader_cdr.FieldCount];

                string chaine_cdr = "";
                bool est_crea = false;

                while (reader_cdr.Read())
                {
                    est_crea = (bool)reader_cdr["est_createur"];
                    chaine_cdr += est_crea;
                }

                //Fenetre_Test fen = new Fenetre_Test();
                //fen.textblock_test.Text += est_crea;
                //fen.Show();

                reader_cdr.Close();
                command_cdr.Dispose();

                if (est_crea) // Condition pour appeler un type de fenêtre ou l'autre
                {
                    CdR_gestion fen1 = new CdR_gestion();
                    fen1.textblock_recup_id.Text = textbox_idClient.Text; //On recup l'id_client dans l'autre fenêtre
                    fen1.Show();
                    this.Hide();
                    MessageBox.Show("Bienvenue " + textbox_idClient.Text + "!");

                }
                else
                {
                    Client_normal_gestion fen2 = new Client_normal_gestion();
                    fen2.textblock_recup_id.Text = textbox_idClient.Text; //On recup l'id_client dans l'autre fenêtre
                    fen2.Show();
                    this.Hide(); 
                    MessageBox.Show("Bienvenue " + textbox_idClient.Text + "!");

                }
            }
            #endregion
            maConnexion.Close();
        }
    }
}
