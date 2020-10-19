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

namespace Cooking
{
    /// <summary>
    /// Logique d'interaction pour Payement_refuse.xaml
    /// </summary>
    public partial class Payement_refuse : Window
    {
        public Payement_refuse()
        {
            InitializeComponent();
        }

        private void boutton_revenir_commande_Click(object sender, RoutedEventArgs e)
        {
            passage_de_commande fen1 = new passage_de_commande();
            fen1.Show();
            this.Close();
        }

        private void boutton_deconnexion_2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
