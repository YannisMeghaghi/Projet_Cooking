using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class CdR : Client
    {
        private string id_Cdr;


        public CdR(string idClient, string nom, string prenom, string adresse, string ville, string tel, string mail, bool estCreateur, int compte, string mdp, string id_Cdr) : base(idClient, nom, prenom, adresse, ville, tel, mail, estCreateur, compte, mdp)
        {
            this.id_Cdr = id_Cdr;
        }

        public string Id_Cdr
        {
            get { return this.id_Cdr; }
            set { this.id_Cdr = value; }
        }
    }
}
