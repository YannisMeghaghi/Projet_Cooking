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
using System.Xml;

namespace Cooking
{
    /// <summary>
    /// Logique d'interaction pour passage_de_commande.xaml
    /// </summary>
    public partial class passage_de_commande : Window
    {
        int prix_total = 0;
        public passage_de_commande()
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

            #region Selection des recettes pour les combobox
            string requete = "Select * from recette";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader = command.ExecuteReader();

            string chaine = "";

            while (reader.Read())
            {
                chaine += reader["id_recette"] + " ";

            }

            string[] liste = chaine.Split(' ');

            for(int i = 0;i< liste.Length - 1; i++) 
            {
                combobox_recettes.Items.Add(liste[i]);
            }

            reader.Close();
            command.Dispose();

            #endregion

            #region Incrémentation du prix (ou non) d'une recette

            for (int i = 0; i < liste.Length - 1; i++)
            {
                string req = "Select nbr_fois_vendue from cooking.recette where id_recette = '" + liste[i] + "';";
                MySqlCommand com = maConnexion.CreateCommand();
                com.CommandText = req;
                MySqlDataReader red = com.ExecuteReader();
                int nbr_vendue2 = 0;

                while (red.Read())
                {
                    nbr_vendue2 = (int)red["nbr_fois_vendue"];
                }

                red.Close();
                com.Dispose();

                string re_up = "Select a_ete_up10 from cooking.recette where id_recette = '" + liste[i] + "';";
                MySqlCommand com_up = maConnexion.CreateCommand();
                com_up.CommandText = re_up;
                MySqlDataReader read_up = com_up.ExecuteReader();
                bool a_ete_up = false;

                while (read_up.Read())
                {
                    a_ete_up = (bool)read_up["a_ete_up10"];
                }

                read_up.Close();
                com_up.Dispose();

                if (a_ete_up)//Pour éviter d'augmenter le prix à chaque fois qu'il est commandé.
                {
                    string re_up5 = "Select a_ete_up50 from cooking.recette where id_recette = '" + liste[i] + "';";
                    MySqlCommand com_up5 = maConnexion.CreateCommand();
                    com_up5.CommandText = re_up5;
                    MySqlDataReader read_up5 = com_up5.ExecuteReader();
                    bool a_ete_up5 = false;

                    while (read_up5.Read())
                    {
                        a_ete_up5 = (bool)read_up5["a_ete_up50"];
                    }

                    read_up5.Close();
                    com_up5.Dispose();

                    if (a_ete_up5)
                    {

                    }
                    else
                    {
                        if ((nbr_vendue2) >= 50)
                        {
                            string re_up6 = "Update cooking.recette set a_ete_up50 = True where id_recette = '" + liste[i] + "';";
                            MySqlCommand com_up6 = maConnexion.CreateCommand();
                            com_up6.CommandText = re_up6;
                            MySqlDataReader read_up6 = com_up6.ExecuteReader();
                            read_up6.Close();
                            com_up6.Dispose();

                            string re3 = "Select prix_vente from cooking.recette where id_recette = '" + liste[i] + "';";
                            MySqlCommand co3 = maConnexion.CreateCommand();
                            co3.CommandText = re3;
                            MySqlDataReader ra3 = co3.ExecuteReader();
                            int prix_vente = 0;

                            while (ra3.Read())
                            {
                                prix_vente = (int)ra3["prix_vente"];
                            }

                            ra3.Close();
                            co3.Dispose();
                            prix_vente += 3;
                            string re4 = "Update cooking.recette set prix_vente =" + prix_vente + " where id_recette ='" + liste[i] + "';";
                            MySqlCommand co4 = maConnexion.CreateCommand();
                            co4.CommandText = re4;
                            MySqlDataReader ra4 = co4.ExecuteReader();

                            ra4.Close();
                            co4.Dispose();
                            string re5 = "Update cooking.recette set remuneration =" + 4 + " where id_recette ='" + liste[i] + "';";
                            MySqlCommand co5 = maConnexion.CreateCommand();
                            co5.CommandText = re5;
                            MySqlDataReader ra5 = co5.ExecuteReader();

                            ra5.Close();
                            co5.Dispose();
                        }
                    }
                }
                else
                {
                    

                    if ((nbr_vendue2) >= 10 && (nbr_vendue2) < 50)
                    {
                        string re_up2 = "Update cooking.recette set a_ete_up10 = True where id_recette = '" + liste[i] + "';";
                        MySqlCommand com_up2 = maConnexion.CreateCommand();
                        com_up2.CommandText = re_up2;
                        MySqlDataReader read_up2 = com_up2.ExecuteReader();
                        read_up2.Close();
                        com_up2.Dispose();

                        string re3 = "Select prix_vente from cooking.recette where id_recette = '" + liste[i] + "';";
                        MySqlCommand co3 = maConnexion.CreateCommand();
                        co3.CommandText = re3;
                        MySqlDataReader ra3 = co3.ExecuteReader();
                        int prix_vente = 0;

                        while (ra3.Read())
                        {
                            prix_vente = (int)ra3["prix_vente"];
                        }

                        ra3.Close();
                        co3.Dispose();
                        prix_vente += 2;
                        string re4 = "Update cooking.recette set prix_vente = " + prix_vente + " where id_recette ='" + liste[i] + "';";
                        MySqlCommand co4 = maConnexion.CreateCommand();
                        co4.CommandText = re4;
                        MySqlDataReader ra4 = co4.ExecuteReader();

                        ra4.Close();
                        co4.Dispose();
                    }

                }
                
            }

            #endregion

            maConnexion.Close();
        }

        private void boutton_payer_Click(object sender, RoutedEventArgs e) // bouton ajouter '+'
        {
            listbox_panier.Items.Add(combobox_recettes.Text); // Initialisation de la listbox

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

            int prix = 0;

            // Incrémentation du prix du panier
            string requete = "Select prix_vente from cooking.recette where id_recette = '" + combobox_recettes.Text + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                prix = (int)reader["prix_vente"];
            }
            reader.Close();
            command.Dispose();

            prix_total += prix;
            textblock_prix_total.Text = "" + prix_total;

            
            maConnexion.Close();

        }

        private void boutton_payer_final_Click(object sender, RoutedEventArgs e)
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

            //Nombreuses conséquences de l'achat du contenu du panier final.
            string requete_compte = "Select compte from cooking.client where id_client = '" + textblock_recup_id.Text + "';";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete_compte;
            MySqlDataReader reader2 = command2.ExecuteReader();

            int compte = 0;

            while (reader2.Read())
            {
                compte = (int)reader2["compte"];
            }
            command2.Dispose();
            reader2.Close();

            int resultat = compte - prix_total;

            if (resultat< 0) //Si pas assez d'argent
            {
                MessageBox.Show("Payement refusé", "Erreur");
            }
            else
            {
                string requete_update = "Update client set compte = " + resultat + " where id_client = '" + textblock_recup_id.Text + "';";
                MySqlCommand command_update = maConnexion.CreateCommand();
                command_update.CommandText = requete_update;
                MySqlDataReader reader_update = command_update.ExecuteReader();

                command_update.Dispose();
                reader_update.Close();

                //A partir de la on crédite le créateur de la recette
                string chaine_panier = "";

                foreach (string recette in listbox_panier.Items)
                {
                    chaine_panier += recette + " ";
                }

                string[] liste_panier = chaine_panier.Split(' ');
                string id_recherche = "";

                for (int i = 0; i < liste_panier.Length - 1; i++)
                {

                    //On vérifie le nombre de ventes de chaque recettes et on augmente son prix si nécéssaire.
                    string req1 = "Select nbr_fois_vendue from cooking.recette where id_recette = '" + liste_panier[i] + "';";
                    MySqlCommand com1 = maConnexion.CreateCommand();
                    com1.CommandText = req1;
                    MySqlDataReader red1 = com1.ExecuteReader();

                    int nbr_vendue2 = 0;

                    while (red1.Read())
                    {
                        nbr_vendue2 = (int)red1["nbr_fois_vendue"];
                    }

                    red1.Close();
                    com1.Dispose();

                    string requeteX = "Insert into cooking.commande values('" + i + "','" + liste_panier[i] + "');";
                    MySqlCommand commandX = maConnexion.CreateCommand();
                    commandX.CommandText = requeteX;
                    MySqlDataReader readerX = commandX.ExecuteReader();
                    readerX.Close();
                    commandX.Dispose();


                    #region XML



                    XmlDocument docXml = new XmlDocument();
                    //création élément racine en l'ajoutant au doc
                    XmlElement racine = docXml.CreateElement("Commande");
                    docXml.AppendChild(racine);

                    //création de l'en-tête XML 
                    XmlDeclaration xmldecl = docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");
                    docXml.InsertBefore(xmldecl, racine);

                    string idcommande = i.ToString();
                    XmlElement xmlNumeroCommande = docXml.CreateElement("Numéro_de_la_commande");
                    xmlNumeroCommande.InnerText = idcommande;
                    racine.AppendChild(xmlNumeroCommande);



                    /*foreach (object o in liste_panier.)
                    {
                        XmlElement recette = docXml.CreateElement("Recette");
                        recette.InnerText = ((Recette)o).Nom_R;
                        racine.AppendChild(recette);
                    }*/

                    string aujdhui1 = DateTime.Now.ToString();
                    string aujdhui2 = Convert.ToString(aujdhui1);
                    XmlElement date = docXml.CreateElement("Date");
                    date.InnerText = aujdhui2;
                    racine.AppendChild(date);

                    //enregistrement du doc XML, à retrouver dans le dossier bin\debug de Visual Studio
                    docXml.Save("test.xml");
                    MessageBox.Show("Le dossier XML a été créé.");





                    #endregion

                    string re2 = "Update cooking.recette set nbr_fois_vendue = " + (nbr_vendue2 +1) + " where id_recette ='" + liste_panier[i] + "';";
                    MySqlCommand co2 = maConnexion.CreateCommand();
                    co2.CommandText = re2;
                    MySqlDataReader ra2 = co2.ExecuteReader();

                    ra2.Close();
                    co2.Dispose();
                    
                    
                    

                    //On réduit les stocks d'ingrédients
                    ////D'abord on récupère la liste de produit de chaque recette
                    string chaine_produit = "";
                    string chaine_quantite = "";
                    string req = "Select * from cooking.recette where id_recette = '" + liste_panier[i] + "';";
                    MySqlCommand com = maConnexion.CreateCommand();
                    com.CommandText = req;
                    MySqlDataReader rea = com.ExecuteReader();

                    while (rea.Read())
                    {
                        chaine_produit += (string)rea["liste_produit"];
                    }
                    string[] liste_produit = chaine_produit.Split(' ');

                    rea.Close();
                    MySqlDataReader rea2 = com.ExecuteReader();

                    while (rea2.Read())
                    {
                        chaine_quantite += (string)rea2["liste_quantite"];
                    }
                    rea2.Close();
                    com.Dispose();

                    string[] liste_quantite = chaine_quantite.Split(' ');
                    

                    for (int j = 0; j < liste_produit.Length - 1; j++)
                    {
                        string reqt = "Select * from cooking.produit where id_produit = '" + liste_produit[j] + "';";
                        MySqlCommand comd = maConnexion.CreateCommand();
                        comd.CommandText = reqt;
                        MySqlDataReader readr = comd.ExecuteReader();
                        int stock_actu = 0;
                        while (readr.Read())
                        {
                            stock_actu = (int)readr["stock_actu"];
                        }
                        readr.Close();
                        comd.Dispose();

                        int stock_final = stock_actu - Convert.ToInt32(liste_quantite[j]);

                        string reque = "Update cooking.produit set stock_actu = " + stock_final + " where id_produit = '" + liste_produit[j] + "';";
                        MySqlCommand commd = maConnexion.CreateCommand();
                        commd.CommandText = reque;
                        MySqlDataReader redr = commd.ExecuteReader();
                        redr.Close();
                        commd.Dispose();

                        
                    }
                    //Qui a crée cette recette?
                    string requete3 = "Select id_cdr from cooking.recette where id_recette = '" + liste_panier[i] + "';";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = requete3;
                    MySqlDataReader reader3 = command3.ExecuteReader();

                    while (reader3.Read())
                    {
                        id_recherche = (string)reader3["id_cdr"];
                    }

                    command3.Dispose();
                    reader3.Close();
                    //Quelle rémunération associée à cette recette ?
                    int remuneration = 0;

                    string requete = "Select remuneration from cooking.recette where id_recette = '" + liste_panier[i] + "';";
                    MySqlCommand command = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        remuneration = (int)reader["remuneration"];
                    }

                    reader.Close();
                    command.Dispose();
                    //Combien sur le compte du créateur
                    string requete_cdr = "Select compte from cooking.client where id_client = '" + id_recherche + "';";
                    MySqlCommand command_cdr = maConnexion.CreateCommand();
                    command_cdr.CommandText = requete_cdr;
                    MySqlDataReader reader_cdr = command_cdr.ExecuteReader();

                    int compte_cdr = 0;

                    while (reader_cdr.Read())
                    {
                        compte_cdr = (int)reader_cdr["compte"];
                    }

                    reader_cdr.Close();
                    command_cdr.Dispose();

                    //Update de son compte
                    int resultat_cdr = compte_cdr + remuneration;

                    string requete4 = "Update client set compte = " + resultat_cdr + " where id_client = '" + id_recherche + "';";
                    MySqlCommand command4 = maConnexion.CreateCommand();
                    command4.CommandText = requete4;
                    MySqlDataReader reader4 = command4.ExecuteReader();

                    command4.Dispose();
                    reader4.Close();

                    //On récupère le nombre de recette vendue par ce créateur de recette

                    string requete_nbr = "Select nbr_recette_vendue from cooking.createur_de_recette where id_client = '" + id_recherche + "';";
                    MySqlCommand command_nbr = maConnexion.CreateCommand();
                    command_nbr.CommandText = requete_nbr;
                    MySqlDataReader reader_nbr = command_nbr.ExecuteReader();

                    int nbr_vendue = 0;

                    while (reader_nbr.Read())
                    {
                        nbr_vendue = (int)reader_nbr["nbr_recette_vendue"];
                    }

                    reader_nbr.Close();
                    command_nbr.Dispose();
                    //On incrémente le nombre de recettes vendues par ce créateur

                    string requete6 = "Update cooking.createur_de_recette set nbr_recette_vendue = " + (nbr_vendue + 1) + " where id_client = '" + id_recherche + "';";
                    MySqlCommand command6 = maConnexion.CreateCommand();
                    command6.CommandText = requete6;
                    MySqlDataReader reader6 = command6.ExecuteReader();

                    command6.Dispose();
                    reader6.Close();

                }


                

                string requetes = "Select compte from cooking.client where id_client = '" + textblock_recup_id.Text + "';";
                MySqlCommand commandes = maConnexion.CreateCommand();
                commandes.CommandText = requetes;
                MySqlDataReader readers = commandes.ExecuteReader();

                int comptes = 0;

                while (readers.Read())
                {
                    comptes += Convert.ToInt32(readers["compte"]);
                }


                readers.Close();
                commandes.Dispose();

                
                maConnexion.Close();

                Payement_accpete fen = new Payement_accpete();
                fen.textbock_recup_id.Text = textblock_recup_id.Text;
                fen.textblock_compte.Text = "" + comptes;
                fen.Show();
                this.Hide();
            }
        }
    }
}
