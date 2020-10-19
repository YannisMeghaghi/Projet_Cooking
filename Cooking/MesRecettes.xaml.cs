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
    /// Logique d'interaction pour MesRecettes.xaml
    /// </summary>
    public partial class MesRecettes : Window
    {
        public MesRecettes()
        {
            //MessageBox.Show(textblock_recup_id.Text);
            InitializeComponent();
        }

        public void Tout()
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

            #region Récupération de toutes les recettes créées par l'utilisateur + nombre de vente de chacune
            //MessageBox.Show(textblock_recup_id.Text);
            string requete = "Select * from recette where id_cdr = '" + this.textblock_recup_id.Text + "';";
            //MessageBox.Show(textblock_recup_id.Text);
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            string chaine_recette = "";
            while (reader.Read())
            {
                chaine_recette += reader["id_recette"] + " ";
            }

            string[] liste_recette = chaine_recette.Split(' ');

            command.Dispose();
            reader.Close();

            string req = "Select * from recette where id_cdr = '" + this.textblock_recup_id.Text + "';";
            MySqlCommand com = maConnexion.CreateCommand();
            com.CommandText = req;
            MySqlDataReader rea = com.ExecuteReader();
            string chaine_vente = "";
            while (rea.Read())
            {
                chaine_vente += rea["nbr_fois_vendue"] + " ";
            }

            string[] liste_vente = chaine_vente.Split(' ');

            com.Dispose();
            rea.Close();

           

            for (int i = 0; i < liste_recette.Length - 1; i++)
            {
                listbox_recette.Items.Add("" + liste_recette[i] + " : " + liste_vente[i] + " ventes");
            }

            #endregion


            maConnexion.Close();
        }

        private void bouton_infos_recette_Click(object sender, RoutedEventArgs e)
        {
            Infos_recette fen = new Infos_recette();
            string[] chaine = listbox_recette.SelectedItem.ToString().Split(' ');
            fen.textblock_recup__recette.Text = chaine[0];
            fen.Tout();
            fen.Show();
        }

        private void bouton_suppr_recette_Click(object sender, RoutedEventArgs e)
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

            #region Suppression d'une recette
            string[] chaine = listbox_recette.SelectedItem.ToString().Split(' ');
            string requete = "Delete from recette where id_recette = '" + chaine[0] + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();

            #endregion

            MessageBox.Show(chaine[0] + " à bien été supprimé.","Recette supprimée");
        }
    }
}
