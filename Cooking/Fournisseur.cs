using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class Fournisseur
    {
        private string nom;
        private string tel;

        public Fournisseur(string nom, string tel)
        {
            this.nom = nom;
            this.tel = tel;
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }
    }
}
