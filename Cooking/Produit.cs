using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class Produit
    {
        private string nom;
        private string categorie;
        private string unite;
        private double stock_actu;
        private double stock_mini; //(stock_mini prévédent)/2 + 3*quantite pour cette recette
        private string nom_fournisseur;
        private string ref_fournisseur;

        public Produit(string nom, string categorie, string unite, double stock_actu, double stock_mini, string nom_fournisseur, string ref_fournisseur)
        {
            this.nom = nom;
            this.categorie = categorie;
            this.unite = unite;
            this.stock_actu = stock_actu;
            this.stock_mini = stock_mini;
            this.nom_fournisseur = nom_fournisseur;
            this.ref_fournisseur = ref_fournisseur;

        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public string Categorie
        {
            get { return this.categorie; }
            set { this.categorie = value; }
        }
        public string Unite
        {
            get { return this.unite; }
            set { this.unite = value; }
        }
        public double Stock_actu
        {
            get { return this.stock_actu; }
            set { this.stock_actu = value; }
        }
        public double Stock_mini
        {
            get { return this.stock_mini; }
            set { this.stock_mini = value; }
        }
        public string Nom_fournisseur
        {
            get { return this.nom_fournisseur; }
            set { this.nom_fournisseur = value; }
        }
        public string Ref_fournisseur
        {
            get { return this.ref_fournisseur; }
            set { this.ref_fournisseur = value; }
        }
    }
}
