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
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    /// 

    public partial class Inscription : Window
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void boutton_fini_inscription_Click(object sender, RoutedEventArgs e)
        {
            Client client1 = new Client(textbox_idClient.Text, textbox_nom.Text, textbox_prenom.Text, textbox_adresse.Text, textbox_ville.Text, textbox_tel.Text, textbox_mail.Text, (bool)(checkbox_estCreateur_inscription.IsChecked), 0, textbox_mdp.Text);

            verif_id_client(client1);
        }

        private void verif_id_client(Client client1)
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

            #region Vérification d'un identifiant bien unique + insertion dans les différentes tables fonciton de créateur ou non
            string requete_verif = "Select * from client";// where id_client = '" + textbox_idClient + "';";
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

            if (chaine.Contains(client1.IdClient))
            {
                MessageBox.Show("Cet identifiant est déjà utilisé!\nVeuillez en entrer un autre.");

            }
            else
            {
                if (!client1.EstCreateur)
                {
                    //créer le client en ajoutant tous les attributs
                    //en fonction de CdR ou non, l'envoyer sur une page ou une autre



                    string requete = "Insert into cooking.client values('" + client1.IdClient + "','" + client1.Nom + "','" + client1.Prenom + "','" + client1.Adresse + "','" + client1.Ville + "','" + client1.Tel + "','" + client1.Mail + "'," + client1.EstCreateur + "," + client1.Compte + ",'" + client1.Mdp + "');";
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = requete;

                    MySqlDataReader reader = command1.ExecuteReader();
                    reader.Close();
                    command1.Dispose();

                    Client_normal_gestion fen2 = new Client_normal_gestion();
                    fen2.textblock_recup_id.Text = textbox_idClient.Text;
                    fen2.Show();
                    this.Hide();
                }
                else
                {
                    CdR cdr1 = new CdR(textbox_idClient.Text, textbox_nom.Text, textbox_prenom.Text, textbox_adresse.Text, textbox_ville.Text, textbox_tel.Text, textbox_mail.Text, (bool)(checkbox_estCreateur_inscription.IsChecked), 0, textbox_mdp.Text, textbox_idClient.Text);



                    string requete = ("Insert into cooking.client values('" + client1.IdClient + "','" + client1.Nom + "','" + client1.Prenom + "','" + client1.Adresse + "','" + client1.Ville + "','" + client1.Tel + "','" + client1.Mail + "'," + client1.EstCreateur + ",'" + client1.Compte + "','" + client1.Mdp + "');");
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = requete;

                    MySqlDataReader reader = command1.ExecuteReader();
                    reader.Close();
                    command1.Dispose();

                    string requete2 = "Insert into cooking.createur_de_recette values('" + client1.IdClient + "','" + client1.IdClient + "','" + 0 + "');";
                    MySqlCommand command2 = maConnexion.CreateCommand();
                    command2.CommandText = requete2;

                    MySqlDataReader reader2 = command2.ExecuteReader();

                    reader.Close();
                    command2.Dispose();


                    CdR_gestion fen2 = new CdR_gestion();
                    fen2.textblock_recup_id.Text = textbox_idClient.Text;
                    fen2.Show();
                    this.Hide();
                }

                #endregion


                maConnexion.Close();
            }

        }

    }
}
