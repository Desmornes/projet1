using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class Competence
    {
        private int idCompetence;
        private string description;

        //constructeur
        public Competence(int idCompetence, string description)
        {
            this.idCompetence = idCompetence;
            this.description = description;
        }

        //getters
        public int getId()
        {
            return idCompetence;
        }
        public string getDescription()
        {
            return description;
        }
    }
}
