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
    /// Logique d'interaction pour Creation_recette.xaml
    /// </summary>
    public partial class Creation_recette : Window
    {
        string produits;
        string quantite;
        public Creation_recette()
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

            #region Remplissage de la combobox avec tous les produits
            string requete = "Select * from cooking.produit";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader = command.ExecuteReader();

            string chaine = "";

            while (reader.Read())
            {
                chaine += reader["id_produit"] + " ";

            }

            string[] liste = chaine.Split(' ');

            for (int i = 0; i < liste.Length - 1; i++)
            {
                combobox_produits.Items.Add(liste[i]);
            }

            reader.Close();
            command.Dispose();

            #endregion

            maConnexion.Close();

            for (int i = 1; i < 200; i++) // Initialisation des combobox qui ne contiennent que des entiers
            {
                combobox_quantite.Items.Add(i); //quantités
            }

            for (int i = 1; i < 101; i++)
            {
                combobox_prix.Items.Add(i); //produits
            }
        }

        private void bouton_ajout_Click(object sender, RoutedEventArgs e) // Permet d'ajouter les produits avec leur quantité dans la listbox.
        {
            produits += combobox_produits.Text + " ";
            quantite += combobox_quantite.Text + " ";

            listbox_produits.Items.Add(combobox_produits.Text);
            listbox_quantite.Items.Add(combobox_quantite.Text);
        }

        private void bouton_finir_Click(object sender, RoutedEventArgs e)
        {
            string type = "";

            // Définition du type de la recette

            if((bool)rb_entree.IsChecked && !(bool)rb_plat.IsChecked && !(bool)rb_dessert.IsChecked)
            {
                type = "entrée";
            }
            else if(!(bool)rb_entree.IsChecked && (bool)rb_plat.IsChecked && !(bool)rb_dessert.IsChecked)
            {
                type = "plat";
            }
            else if(!(bool)rb_entree.IsChecked && !(bool)rb_plat.IsChecked && (bool)rb_dessert.IsChecked)
            {
                type = "dessert";
            }
            else//Par défaut ce sera un plat pour éviter les erreurs.
            {
                type = "plat";
            }

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

            #region Insetion de la recette dans la BDD
            string requete = "Insert into cooking.recette values('" + textbox_id_recette.Text + "','" + type + "','" + produits + "','" + quantite + "','" + textbox_descriptif.Text + "'," + 2 + "," + combobox_prix.Text + ",'" + textblock_recup_id.Text + "','" + textblock_recup_id.Text + "'," + 0 + ", False, False);";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            reader.Close();
            command1.Dispose();

            #endregion

            maConnexion.Close();

            MessageBox.Show("La recette à bien été créee! Merci de votre collaboration.");
        }
    }
}
