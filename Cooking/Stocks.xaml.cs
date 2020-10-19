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
    /// Logique d'interaction pour Stocks.xaml
    /// </summary>
    public partial class Stocks : Window
    {
        public Stocks()
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

            #region Affichage du stock de chaque produit
            string requete = "Select * from cooking.produit";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader_produit = command.ExecuteReader();

            string chaine_produit = "";
            string chaine_stock = "";
            string chaine_unite = "";

            while (reader_produit.Read())
            {
                chaine_produit += reader_produit["id_produit"] + " ";

            }
            reader_produit.Close();

            MySqlDataReader reader_stock = command.ExecuteReader(); // On vient de se rendre compte qu'on a fait plusieurs reader inutilement mais par faute de temps on les laisse.

            while(reader_stock.Read())
            {
                chaine_stock += reader_stock["stock_actu"] + " ";

            }
            reader_stock.Close();

            MySqlDataReader reader_unite = command.ExecuteReader();

            while (reader_unite.Read())
            {
                chaine_unite += reader_unite["unite"] + " ";

            }
            reader_unite.Close();

            string[] liste_produit = chaine_produit.Split(' ');
            string[] liste_stock = chaine_stock.Split(' ');
            string[] liste_unite = chaine_unite.Split(' ');

            for(int i = 0; i < liste_produit.Length - 1; i++)
            {
                listbox_stocks.Items.Add(liste_produit[i] + " : " + liste_stock[i] + "" + liste_unite[i]);
            }


            command.Dispose();

            #endregion
            maConnexion.Close();
        }
    
    }
}
