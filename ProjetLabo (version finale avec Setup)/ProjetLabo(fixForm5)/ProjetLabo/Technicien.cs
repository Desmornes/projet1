using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class Technicien : Personnel


    {
        private String niveauIntervention;
        private String formation;
        private List<Competence> lesCompetences;

       
        //constructeur
        public Technicien(int id_perso, String nom, String nomatricule, DateTime datedembauche, String login, String motdepasse, String niveauIntervention, String formation, int estResponsable)
            :base(id_perso,nom,nomatricule,datedembauche,login,motdepasse,estResponsable)
        {
            this.niveauIntervention = niveauIntervention;
            this.formation = formation;
            lesCompetences = new List<Competence>();
           
        }
        //getters
        public String getniveauIntervention()
        {
            return niveauIntervention;
        }
        public String getFormation()
        {
            return formation;
        }
        public void setFormation(string uneFormation)
        {
            this.formation = uneFormation;
        }
        public void setNiveauIntervention(string unNiveau)
        {
            this.niveauIntervention = unNiveau;
        }
        public void addCompetence(Competence uneCompetence)
        {
            lesCompetences.Add(uneCompetence);
        }
    }
}
