using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class Materiel
    {
        private int id_materiel;
        private String processeur;
        private String memoire;
        private String disque;
        private DateTime dateAchat;
        private String garantie;
        private int idPersonnel;
        private List<Logiciel> lesLogiciels;

        //constructeur
        public Materiel (int id_materiel, String processeur, String memoire, String disque, DateTime uneDate, string uneGarantie, int unIdPersonnel)
        {
            this.id_materiel = id_materiel;
            this.processeur = processeur;
            this.memoire = memoire;
            this.disque = disque;
            this.dateAchat = uneDate;
            this.garantie = uneGarantie;
            this.idPersonnel = unIdPersonnel;
            lesLogiciels = new List<Logiciel>();
        }
        //getters
        public int getId_materiel()
        {
            return id_materiel;
        }
        public String getProcesseur()
        {
            return processeur;
        }
        public String getMemoire()
        {
            return memoire;
        }
        public String getDisque()

        {
            return disque;
        }
        public DateTime getDateAchat()
        {
            return dateAchat;
        }
        public string getGarantie()
        {
            return garantie;
        }
        public int getIdPersonnel()
        {
            return idPersonnel;
        }
        //setters
        public void setId_materiel(int unId_materiel)
        {
            this.id_materiel = unId_materiel;
        }
        public void setProcesseur(string unProcesseur)
        {
            this.processeur = unProcesseur;
        }
        public void setMemoire(string uneMemoire)
        {
            this.memoire = uneMemoire;
        }
        public void setDisque(string unDisque)
        {
            this.disque = unDisque;
        }
        public void setDateAchat(DateTime uneDate)
        {
            this.dateAchat = uneDate;
        }
        public void setGarantie(string uneGarantie)
        {
            this.garantie = uneGarantie;
        }
        public void setIdPersonnel(int unId)
        {
            this.idPersonnel = unId;
        }
        public void addLogiciel(Logiciel unLogiciel)
        {
            this.lesLogiciels.Add(unLogiciel);
        }
    }
}
