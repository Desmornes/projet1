using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class Logiciel
    {
        private int idLogiciel;
        private string nomLogiciel;
        private DateTime dateInstallation;
        private int idMateriel;

        //constructeur
        public Logiciel(int unId, string unNom, DateTime uneDate, int unIdMateriel)
        {
            idLogiciel = unId; 
            nomLogiciel = unNom;
            dateInstallation = uneDate;
            idMateriel= unIdMateriel;
        }
        //getters
        public int getId()
        {
            return idLogiciel;
        }
        public string getNom()
        {
            return nomLogiciel;
        }
        public DateTime getDateInstallation()
        {
            return dateInstallation;
        }
        public int getIdMateriel()
        {
            return idMateriel;
        }

    }
}
