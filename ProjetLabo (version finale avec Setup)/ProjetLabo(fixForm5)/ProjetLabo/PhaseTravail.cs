using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class PhaseTravail
    {
        private int idPhase;
        private DateTime datePhase;
        private String heureDebut;
        private String heureFin;
        private string travailFait;
        private int idDemande;

        //constructeur
        public PhaseTravail(int unId, DateTime uneDate, String uneHeureDebut, String uneHeureFin, string unTravail, int unIdDemande)
        {
            this.idPhase = unId;
            this.datePhase = uneDate;
            this.heureDebut = uneHeureDebut;
            this.heureFin = uneHeureFin;
            this.travailFait = unTravail;
            this.idDemande = unIdDemande;
        }
        //getters
        public int getId()
        {
            return idPhase;
        }
        public DateTime getDate()
        {
            return datePhase;
        }
        public String getHeureDebut()
        {
            return heureDebut;
        }
        public String getHeureFin()
        {
            return heureFin;
        }
        public string getTravailFait()
        {
            return travailFait;
        }
        public int getIdDemande()
        {
            return idDemande;
        }
    }
}
