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
    /// Logique d'interaction pour Demo1.xaml
    /// </summary>
    public partial class Demo1 : Window
    {
        public Demo1()
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

            #region Nombre total de client
            string requete = "Select count(*) from client";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            textblock_nombre_client.Text = reader[0].ToString();

            reader.Close();
            command.Dispose();
            #endregion


            #region Affichage de tous les créateurs de recette
            string requet = "Select * from createur_de_recette";
            MySqlCommand comman = maConnexion.CreateCommand();
            comman.CommandText = requet;

            MySqlDataReader reade = comman.ExecuteReader();
            string chaine = "";
            while (reade.Read())
            {
                chaine += (string)reade["id_client"] + " ";
            }

            string[] liste = chaine.Split(' ');

            reade.Close();
            comman.Dispose();
            #endregion

            string nbr_rec = "";
            #region Récupération du nomre de recette vendues par le créateur de recette
            for (int i = 0; i< liste.Length - 1; i++) 
            {
                string reque = "Select * from createur_de_recette where id_client = '" + liste[i] + "';";
                MySqlCommand comma = maConnexion.CreateCommand();
                comma.CommandText = reque;
                MySqlDataReader rea = comma.ExecuteReader();

                string nombre = "";

                while (rea.Read())
                {
                    nombre += rea["nbr_recette_vendue"];
                }

                nbr_rec += nombre + " ";

                rea.Close();
                comma.Dispose();
            }
            #endregion

            string[] liste_nbr = nbr_rec.Split(' ');

            for (int i = 0; i < liste.Length - 1; i++) // Affichage dans des textblocks
            {
                textblock_cdr.Text += liste[i] + "\n";
                textblock_recette.Text += liste_nbr[i] + "\n";
            }

            #region Nombre total de recette

            string requete1 = "Select count(*) from recette";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete1;
            MySqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            string total = reader1[0].ToString();

            textblock_total.Text = total;

            reader1.Close();
            command1.Dispose();
            #endregion

            maConnexion.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Demo2 fen = new Demo2();
            fen.Show();
            this.Close();
        }
    }
}
