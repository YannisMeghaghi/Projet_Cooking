using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class Client
    {
        private string idClient;
        private string nom;
        private string prenom;
        private string adresse;
        private string ville;
        private string tel;
        private string mail;
        private bool estCreateur;
        private int compte;
        private string mdp;

        public Client()
        {
            this.idClient = "";
            this.nom = null;
            this.prenom = null;
            this.adresse = null;
            this.ville = null;
            this.tel = "";
            this.mail = null;
            this.estCreateur = false;
            this.compte = 0;
            this.mdp = null;
        }


        public Client(string idClient, string nom, string prenom, string adresse, string ville, string tel, string mail, bool estCreateur, int compte, string mdp)
        {
            this.idClient = idClient;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.ville = ville;
            this.tel = tel;
            this.mail = mail;
            this.estCreateur = estCreateur;
            this.compte = compte;
            this.mdp = mdp;
        }

        public string IdClient
        {
            get { return this.idClient; }
            set { this.idClient = value; }
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string Ville
        {
            get { return this.ville; }
            set { this.ville = value; }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        public bool EstCreateur
        {
            get { return this.estCreateur; }
            set { this.estCreateur = value; }
        }

        public int Compte
        {
            get { return this.compte; }
            set { this.compte = value; }
        }

        public string Mdp
        {
            get { return this.mdp; }
            set { this.mdp = value; }
        }

        public override string ToString()
        {
            string ch = "Non";
            if (this.estCreateur)
            {
                ch = "Oui";
            }

            return ("Identifiant : " + this.IdClient + "\nNom : " + this.Nom + "\nPrénom : " + this.Prenom + "\nCréateur de recette : " + ch);
        }
    }
}
