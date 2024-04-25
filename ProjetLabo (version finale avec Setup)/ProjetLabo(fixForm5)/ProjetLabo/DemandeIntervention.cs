using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class DemandeIntervention
    {
        private int idDemandeInterv;
        private string objet;
        private string etatPriseEnCharge;
        private string typePriseEnCharge;
        private string niveauUrgence;
        private DateTime dateDemande;
        //clés étrangères
        private int idPersonnel;
        private int idMateriel;
        private List<PhaseTravail> lesPhasesDeTravail;
        //constructeur
        public DemandeIntervention(int idDemandeInterv, string objet, string etatPriseEnCharge, string typePriseEnCharge, string niveauUrgence, DateTime dateDemande, int idPersonnel, int idMateriel)
        {
            this.idDemandeInterv = idDemandeInterv;
            this.objet = objet;
            this.etatPriseEnCharge = etatPriseEnCharge;
            this.typePriseEnCharge = typePriseEnCharge;
            this.niveauUrgence = niveauUrgence;
            this.dateDemande = dateDemande;
            this.idPersonnel = idPersonnel;
            this.idMateriel = idMateriel;
            lesPhasesDeTravail = new List<PhaseTravail>();
        }

        //getters
        public int getId()
        {
            return idDemandeInterv;
        }
        public string getobjet()
        {
            return objet;
        }
        public string getEtat()
        {
            return etatPriseEnCharge;
        }
        public string getType()
        {
            return typePriseEnCharge;
        }
        public string getNiveauUrgence()
        {
            return niveauUrgence;
        }
        public DateTime getDate()
        {
            return dateDemande;
        }
        public int getIdPersonnel()
        {
            return idPersonnel;
        }
        public int getIdMateriel()
        {
            return idMateriel;
        }
        public List<PhaseTravail> getLesPhases()
        {
            return lesPhasesDeTravail;
        }
        //setters
        public void setId(int unId)
        {
            this.idDemandeInterv = unId;
        }
        public void setEtat(string unEtat)
        {
            this.etatPriseEnCharge = unEtat;
        }
        public void setType(string unType)
        {
            this.typePriseEnCharge = unType;
        }
        public void setNiveauUrgence(string unNiveau)
        {
            this.niveauUrgence = unNiveau;
        }
        public void setDate(DateTime uneDate)
        {
            this.dateDemande = uneDate;
        }
        public void setIdPersonnel(int unId)
        {
            this.idPersonnel = unId;
        }
        public void setIdMateriel(int unId)
        {
            this.idMateriel = unId;
        }
        public void addPhaseTravail(PhaseTravail unePhase)
        {
            lesPhasesDeTravail.Add(unePhase);
        }
    }
}
