using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
     class Personnel
    {

        private int idPerso;
        private String nom;
        private String matricule;
        private DateTime dateEmbauche;
        private String login;
        private String motDePasse;
        private int estResponsable;
        private List<Region> lesRegions;

        //constructeur
        public Personnel(int id_perso, String nom, String nomatricule, DateTime datedembauche, String login, String motdepasse, int estResponsable)
        {
            this.idPerso = id_perso;
            this.nom = nom;
            this.matricule = nomatricule;
            this.dateEmbauche = datedembauche;
            this.login = login;
            this.motDePasse = motdepasse;
            lesRegions = new List<Region>();
            this.estResponsable = estResponsable;   
        }
        //getters
        public virtual int getid_perso()
        {
            return idPerso;
        }
        public virtual String getNom()
        {
            return nom;
        }
        public virtual String getnomatricule()
        {
            return matricule;
        }
        public virtual DateTime getdatedembauche()
        {
            return dateEmbauche;
        }
        public virtual String getloging()
        {
            return login;
        }
        public virtual String getmotdepasse()
        {
            return motDePasse;
        }
        public virtual int getEstResponsable()
        {
            return estResponsable;
        }
        public virtual List<Region> getLesRegions()
        {
            return lesRegions;
        }
        //setters
        public void setId(int unId)
        {
            this.idPerso = unId;
        }
        public void setNom( String unnom)
        {
            this.nom = unnom;
        }
        public void setMatricule(string unnomatricule )
        {
            this.matricule= unnomatricule;    
        }
        public void setDateEembauche(DateTime unedatedembauche)
        {
            dateEmbauche = unedatedembauche;
        }
        public void setLogin(string unLogin)
        {
            this.login= unLogin;
        }
        public void setMotDePasse(string unMotDePasse)
        {
            this.motDePasse = unMotDePasse;
        }
        public void addRegion(Region uneRegion)
        {
            lesRegions.Add(uneRegion);
        }
    }
}
