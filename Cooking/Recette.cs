using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class Recette
    {
        private string nomRecette;
        private string typeRecette;
        private Produit[] liste_produits;
        private int[] liste_quantite;
        private string descriptif;
        private double prix_vente;
        private double remuneration;

        public Recette(string nom, string type, Produit[] liste_produits, int[] liste_quantite, string descriptif, double prix_vente, double remuneration)
        {
            this.nomRecette = nom;
            this.typeRecette = type;
            this.liste_produits = liste_produits;
            this.liste_quantite = liste_quantite;
            this.descriptif = descriptif;
            this.prix_vente = prix_vente;
            this.remuneration = remuneration;

        }

        public string NomRecette
        {
            get { return this.nomRecette; }
            set { this.nomRecette = value; }
        }

        public string TypeRecette
        {
            get { return this.typeRecette; }
            set { this.typeRecette = value; }
        }

        public Produit[] Liste_produits
        {
            get { return this.liste_produits; }
            set { this.liste_produits = value; }
        }

        public int[] Liste_quantite
        {
            get { return this.liste_quantite; }
            set { this.liste_quantite = value; }
        }

        public string Descriptif
        {
            get { return this.descriptif; }
            set { this.descriptif = value; }
        }

        public double Prix_vente
        {
            get { return this.prix_vente; }
            set { this.prix_vente = value; }
        }

        public double Remuneration
        {
            get { return this.remuneration; }
            set { this.remuneration = value; }
        }
    }  
}
