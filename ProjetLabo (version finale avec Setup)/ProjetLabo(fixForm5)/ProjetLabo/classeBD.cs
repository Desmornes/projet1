using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ProjetLabo
{
    class classeBD
    {    /// <summary>
         /// Connexion avec la base de donnée sur phpMyAdmin
         /// </summary>
        static string connString = "Server=127.0.0.1;Database=projetlabo;Uid=root;Password=; SslMode=none";
        static MySqlConnection conn = new MySqlConnection(connString);

        public static DateTime getDateCourante()
        {
            DateTime thisDay = DateTime.Today;
            return thisDay;
        }
        /// <summary>
        //Fonction pour vérifier si un utilisateur est dans la base de données
        ///Vérifie si les informations de connexion d'un utilisateur sont valides dans la base de données.
        /// <param name="unLogin">le login d'un utilisateur</param>
        /// <param name="unMdp"> le mot de passe de l'utilisateur </param>
        ///  </summary>

        public static int verifierLoginMdp(string unLogin, string unMdp)
        {
            conn.Open();
            int idSelected = 0;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id_personnel FROM personnel WHERE login=@login AND mot_de_passe=@mot_de_passe";
            cmd.Parameters.AddWithValue("@login", unLogin);
            cmd.Parameters.AddWithValue("@mot_de_passe", unMdp);
            idSelected = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            return idSelected;
        }

        ///<summary>
        /// Vérifie si l'utilisateur est bien un technicien.
        /// <param name = "idPersonnel" > L'ID de l'utilisateur à vérifier.</param>
        ///Retourne vrai si l'utilisateur est un technicien, sinon retourne faux.</returns>
        ///</summary>
        public static Boolean estTechnicien(int idPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM technicien WHERE id_personnel=@id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", idPersonnel);
            int technicien = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            if(technicien == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

         ///<summary>
         /// Vérifie si l'utilisateur est un responsable ou non.
         /// <param name = "idPersonnel" > L'ID de l'utilisateur à vérifier.</param>
         ///Retourne vrai si l'utilisateur est un technicien, sinon retourne faux.</returns>
         ///</summary>
       public static Boolean estResponsable(int idPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT est_responsable FROM personnel WHERE id_personnel=@id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", idPersonnel);
            int responsable = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            if(responsable == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        ///<summary>
        /// Fonction pour calculer les statistiques des incidents.
        ///<param name = "parametre" > Le paramètre pour filtrer les incidents(par exemple, l'état de prise en charge).</param>
        /// <returns>Le pourcentage des incidents correspondant au paramètre spécifié par rapport au nombre total d'incidents.</returns>
        ///</summary>
        public static double getStatsIncidents(string parametre)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            MySqlCommand cmd2 = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM demande_intervention WHERE etat_prise_en_charge=@parametre";
            cmd.Parameters.AddWithValue("@parametre", parametre);
            cmd2.CommandText = "SELECT COUNT(*) FROM demande_intervention";
            double total = Convert.ToDouble(cmd2.ExecuteScalar());
            double pourcentageCalcule = Convert.ToDouble(cmd.ExecuteScalar()) * 100 / total;
            conn.Close();
            return pourcentageCalcule;
        }
        /// <summary>
        ///Fonction pour calculer le total des incidents.
        ///<param name = "parametre" > Le paramètre pour filtrer les incidents(par exemple, l'état de prise en charge).</param>
        ///<returns>Le nombre total d'incidents correspondant au paramètre spécifié.</returns>
        /// </summary>
        public static double totalIncident(string parametre)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM demande_intervention WHERE etat_prise_en_charge=@parametre";
            cmd.Parameters.AddWithValue("@parametre", parametre);
            double total = Convert.ToDouble(cmd.ExecuteScalar());
            conn.Close();
            return total;

        }

        ///<summary>
        ///Fonction qui permet de modifier les informations d'un membre du personnel dans la base de données.
        /// <param name = "unId" > L'identifiant du membre du personnel à modifier.</param>
        ///<param name = "unLogin" > Le nouveau login à assigner au membre du personnel.</param>
        ///<param name = "unMotDePasse" > Le nouveau mot de passe à assigner au membre du personnel.</param>
        ///</summary
        public static void updatePersonnel(int unId, string unLogin, string unMotDePasse)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE personnel SET login=@login,mot_de_passe=@mot_de_passe WHERE id_personnel=@id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", unId);
            cmd.Parameters.AddWithValue("@login", unLogin);
            cmd.Parameters.AddWithValue("@mot_de_passe", unMotDePasse);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de modifier les informations d'un technicien dans la base de données.
        ///<param name="unId">L'identifiant du technicien à modifier.</param>
        ///<param name="uneFormation">La nouvelle formation à assigner au technicien.</param>
        ///<param name="unNiveauIntervention">Le nouveau niveau d'intervention à assigner au technicien.</param>
        ///</summary>
        public static void updateTechnicien(int unId, string uneFormation, string unNiveauIntervention)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE technicien SET id_personnel=@id_personnel,formation=@formation, niveau_intervention=@niveauInterv  WHERE id_personnel=@id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", unId);
            cmd.Parameters.AddWithValue("@formation", uneFormation);
            cmd.Parameters.AddWithValue("@niveauInterv", unNiveauIntervention);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de mettre à jour l'état de prise en charge d'un incident dans la base de données.
        ///<param name="unetatPriseEnCharge">Le nouvel état de prise en charge à assigner à l'incident.</param>
        ///<param name="unIdDemandeInterv">L'identifiant de la demande d'intervention correspondant à l'incident à mettre à jour.</param>
        ///</summary>
        public static void updateIncident(string unetatPriseEnCharge, int unIdDemandeInterv )
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Demande_intervention SET etat_prise_en_charge=@unetatPriseEnCharge WHERE id=@unIdDemandeInterv";
            cmd.Parameters.AddWithValue("@unetatPriseEnCharge", unetatPriseEnCharge);
            cmd.Parameters.AddWithValue("@unIdDemandeInterv",unIdDemandeInterv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une demande d'intervention à un membre du personnel dans la base de données.
        ///<param name="unIdDemandeInterv">L'identifiant de la demande d'intervention à lier.</param>
        ///<param name="unIdPersonnel">L'identifiant du membre du personnel à associer à la demande d'intervention.</param>
        ///</summary>
        public static void lierDemandePersonnel(int unIdDemandeInterv, int unIdPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO fait (id_personnel, id) VALUES (@unIdPersonnel, @unIdDemandeInterv)";
            cmd.Parameters.AddWithValue("@unIdPersonnel", unIdPersonnel);
            cmd.Parameters.AddWithValue("@unIdDemandeInterv", unIdDemandeInterv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une phase de travail à un incident dans la base de données.
        ///<param name="unIdDemandeInterv">L'identifiant de l'incident à lier à la phase de travail.</param>
        ///<param name="unIdPhaseTravail">L'identifiant de la phase de travail à associer à l'incident.</param>
        ///</summary>
        public static void lierPhaseTravailIncident(int unIdDemandeInterv,int unIdPhaseTravail)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO demande (id, id_1) VALUES (@unIdPhaseTravail, @unIdDemandeInterv)";
            cmd.Parameters.AddWithValue("@unIdPhaseTravail", unIdPhaseTravail);
            cmd.Parameters.AddWithValue("@unIdDemandeInterv", unIdDemandeInterv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier un matériel à un membre du personnel dans la base de données.
        ///<param name="unIdMateriel">L'identifiant du matériel à lier au membre du personnel.</param>
        ///<param name="unIdPersonnel">L'identifiant du membre du personnel auquel le matériel sera lié.</param>
        ///</summary>
        public static void lierMaterielPersonnel(int unIdMateriel, int unIdPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO est_affecte_a (id_materiel, id_personnel) VALUES (@unIdMateriel, @unIdPersonnel)";
            cmd.Parameters.AddWithValue("@unIdMateriel", unIdMateriel);
            cmd.Parameters.AddWithValue("@unIdPersonnel", unIdPersonnel);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter une phase de travail à la base de données.
        ///<param name="unePhaseTravail">L'objet PhaseTravail contenant les informations de la phase de travail à ajouter.</param>
        ///</summary>
        public static void ajoutPhaseTravail(PhaseTravail unePhaseTravail)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO phase_travail VAlUES (@id,@date_phase,@heure_debut,@heure_fin,@travail_realise)";
            cmd.Parameters.AddWithValue("@id", unePhaseTravail.getId());
            cmd.Parameters.AddWithValue("@date_phase", unePhaseTravail.getDate());
            cmd.Parameters.AddWithValue("@heure_debut", unePhaseTravail.getHeureDebut());
            cmd.Parameters.AddWithValue("@heure_fin", unePhaseTravail.getHeureFin());
            cmd.Parameters.AddWithValue("@travail_realise", unePhaseTravail.getTravailFait());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter un membre du personnel à la base de données.
        ///<param name="unpersonnel">L'objet Personnel contenant les informations du membre du personnel à ajouter.</param>
        ///</summary>
        public static void ajoutPersonel(Personnel unpersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO personnel VALUES (@id_personnel, @nom_complet, @matricule, @date_embauche, @login, @mot_de_passe, @est_responsable)";
            cmd.Parameters.AddWithValue("@id_personnel", unpersonnel.getid_perso());
            cmd.Parameters.AddWithValue("@nom_complet", unpersonnel.getNom());
            cmd.Parameters.AddWithValue("@matricule", unpersonnel.getnomatricule());
            cmd.Parameters.AddWithValue("@date_embauche", unpersonnel.getdatedembauche());
            cmd.Parameters.AddWithValue("@login", unpersonnel.getloging());
            cmd.Parameters.AddWithValue("@mot_de_passe", unpersonnel.getmotdepasse());
            cmd.Parameters.AddWithValue("@est_responsable", unpersonnel.getEstResponsable());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de supprimer un membre du personnel de la base de données.
        ///<param name="unPersonnel">L'objet Personnel à supprimer de la base de données.</param>
        ///</summary>
        public static void supprimerUtilisateur(Personnel unPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Personnel WHERE id_personnel = @id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", unPersonnel.getid_perso());
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        ///<summary>
        ///Fonction qui permet d'ajouter un matériel à la base de données.
        ///<param name="unmateriel">L'objet Materiel contenant les informations du matériel à ajouter.</param>
        ///</summary>
        public static void ajoutMateriel(Materiel unmateriel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO materiel VALUES (@id_materiel,@processeur,@memoire,@disque,@date_achat,@garantie)";
            cmd.Parameters.AddWithValue("@id_materiel", unmateriel.getId_materiel());
            cmd.Parameters.AddWithValue("@processeur", unmateriel.getProcesseur());
            cmd.Parameters.AddWithValue("@memoire", unmateriel.getMemoire());
            cmd.Parameters.AddWithValue("@disque", unmateriel.getDisque());
            cmd.Parameters.AddWithValue("@date_achat", unmateriel.getDateAchat());
            cmd.Parameters.AddWithValue("@garantie", unmateriel.getGarantie());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de consulter les matériels disponibles.
        ///<returns>Une liste d'objets Materiel représentant les matériels disponibles.</returns>
        ///</summary>
        public static List<Materiel> consulterMateriel()
        {
            List<Materiel> lesMateriels = new List<Materiel>();
            Materiel unMateriel;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM materiel JOIN est_affecte_a ON est_affecte_a.id_materiel=materiel.id_materiel";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                unMateriel = new Materiel(Convert.ToInt16(dataReader["id_materiel"]), Convert.ToString(dataReader["processeur"]), Convert.ToString(dataReader["memoire"]), Convert.ToString(dataReader["disque"]), Convert.ToDateTime(dataReader["date_achat"]), Convert.ToString(dataReader["garantie"]), Convert.ToInt16(dataReader["id_personnel"]));
                lesMateriels.Add(unMateriel);
            }
            conn.Close();
            return lesMateriels;
        }

        ///<summary>
        ///Fonction qui permet de supprimer un matériel de la base de données.
        ///<param name="unMateriel">L'objet Materiel à supprimer de la base de données.</param>
        ///</summary>
        public static void supprimerMateriel(Materiel unMateriel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM materiel WHERE id_materiel = @id_materiel";
            cmd.Parameters.AddWithValue("@id_materiel", unMateriel.getId_materiel());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter un technicien à la base de données.
        ///<param name="unTechnicien">L'objet Technicien contenant les informations du technicien à ajouter.</param>
        ///<param name="unIdPersonnel">L'identifiant du personnel associé au technicien.</param>
        ///</summary>
        public static void ajouterTechnicien(Technicien unTechnicien, int unIdPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO technicien VALUES (@id_personnel, @niveau_intervention,@formation)";
            cmd.Parameters.AddWithValue("@id_personnel", unIdPersonnel);
            cmd.Parameters.AddWithValue("@niveau_intervention", unTechnicien.getniveauIntervention());
            cmd.Parameters.AddWithValue("@formation", unTechnicien.getFormation());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter une compétence à la base de données.
        ///<param name="uneCompetence">L'objet Competence contenant les informations de la compétence à ajouter.</param>
        ///</summary>
        public static void ajouterCompetence(Competence uneCompetence)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO competence VALUES (@id_competence,@description_competence)";
            cmd.Parameters.AddWithValue("@id_competence", uneCompetence.getId());
            cmd.Parameters.AddWithValue("@description_competence", uneCompetence.getDescription());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter une région à la base de données.
        ///<param name="uneRegion">L'objet Region contenant les informations de la région à ajouter.</param>
        ///</summary>
        public static void ajouterRegion(Region uneRegion)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO region VALUES (@id,@nom_region)";
            cmd.Parameters.AddWithValue("@id", uneRegion.getId());
            cmd.Parameters.AddWithValue("@nom_region", uneRegion.getNom());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une compétence à un technicien dans la base de données.
        ///<param name="unIdPersonnel">L'identifiant du personnel (technicien).</param>
        ///<param name="unIdCompetence">L'identifiant de la compétence.</param>
        ///</summary>
        public static void lierCompetenceTechnicien(int unIdPersonnel, int unIdCompetence)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO a (id_personnel, id_competence) VALUES(@unIdPersonnel, @unIdCompetence)";
            cmd.Parameters.AddWithValue("@unIdPersonnel", unIdPersonnel);
            cmd.Parameters.AddWithValue("@unIdCompetence", unIdCompetence);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une région à un personnel dans la base de données.
        ///<param name="unIdPersonnel">L'identifiant du personnel.</param>
        ///<param name="unIdRegion">L'identifiant de la région.</param>
        ///</summary>
        public static void lierRegionPersonnel(int unIdPersonnel, int unIdRegion)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO passe (id_personnel, id) VALUES(@unIdPersonnel, @unIdRegion)";
            cmd.Parameters.AddWithValue("@unIdPersonnel", unIdPersonnel);
            cmd.Parameters.AddWithValue("@unIdRegion", unIdRegion);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une demande d'intervention à un technicien dans la base de données.
        ///<param name="unIdDemande">L'identifiant de la demande d'intervention.</param>
        ///<param name="unIdTechnicien">L'identifiant du technicien.</param>
        ///</summary>
        public static void lierDemandeTechnicien(int unIdDemande, int unIdTechnicien)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO intervient (id_personnel, id) VALUES(@unIdTechnicien, @unIdDemande)";
            cmd.Parameters.AddWithValue("@unIdTechnicien", unIdTechnicien);
            cmd.Parameters.AddWithValue("@unIdDemande", unIdDemande);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier une demande d'intervention à un matériel dans la base de données.
        ///<param name="unIdDemande">L'identifiant de la demande d'intervention.</param>
        ///<param name="unIdMateriel">L'identifiant du matériel.</param>
        ///</summary>
        public static void lierDemandeMateriel(int unIdDemande, int unIdMateriel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO concerne (id, id_materiel) VALUES(@unIdDemande, @unIdMateriel)";
            cmd.Parameters.AddWithValue("@unIdMateriel", unIdMateriel);
            cmd.Parameters.AddWithValue("@unIdDemande", unIdDemande);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de lier un logiciel à un matériel dans la base de données.
        ///<param name="unIdLogiciel">L'identifiant du logiciel.</param>
        ///<param name="unIdMateriel">L'identifiant du matériel.</param>
        ///</summary>
        public static void lierLogicielMateriel(int unIdLogiciel, int unIdMateriel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO possède (id_materiel, id_logiciel) VALUES(@unIdMateriel, @unIdLogiciel)";
            cmd.Parameters.AddWithValue("@unIdMateriel", unIdMateriel);
            cmd.Parameters.AddWithValue("@unIdLogiciel", unIdLogiciel);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter un logiciel à la base de données.
        ///<param name="unLogiciel">L'objet Logiciel contenant les informations du logiciel à ajouter.</param>
        ///</summary>
        public static void ajouterLogiciel(Logiciel unLogiciel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO logiciel VALUES (@id_logiciel,@nom_logiciel,@date_installation)";
            cmd.Parameters.AddWithValue("@id_logiciel", unLogiciel.getId());
            cmd.Parameters.AddWithValue("@nom_logiciel", unLogiciel.getNom());
            cmd.Parameters.AddWithValue("@date_installation", unLogiciel.getDateInstallation());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet d'ajouter une demande d'intervention à la base de données.
        ///<param name="uneDemandeIntervention">L'objet DemandeIntervention contenant les informations de la demande d'intervention à ajouter.</param>
        ///</summary>
        public static void ajouterincident(DemandeIntervention uneDemandeIntervention)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO demande_intervention VALUES (@id,@objet,@etat_prise_en_charge,@type_prise_en_charge,@niveau_urgence,@date_demande)";
            cmd.Parameters.AddWithValue("@id", uneDemandeIntervention.getId());
            cmd.Parameters.AddWithValue("@objet", uneDemandeIntervention.getobjet());
            cmd.Parameters.AddWithValue("@etat_prise_en_charge", uneDemandeIntervention.getEtat());
            cmd.Parameters.AddWithValue("@type_prise_en_charge", uneDemandeIntervention.GetType());
            cmd.Parameters.AddWithValue("@niveau_urgence", uneDemandeIntervention.getNiveauUrgence());
            cmd.Parameters.AddWithValue("@date_demande", uneDemandeIntervention.getDate());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de supprimer un technicien de la base de données.
        ///<param name="unIdPersonnel">L'objet Technicien à supprimer de la base de données.</param>
        ///</summary>
        public static void supprimerTechnicien(Technicien unIdPersonnel)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM technicien WHERE id_personnel = @id_personnel";
            cmd.Parameters.AddWithValue("@id_personnel", unIdPersonnel.getid_perso());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        ///<summary>
        ///Fonction qui permet de consulter les demandes d'intervention dans la base de données.
        ///<returns>Une liste d'objets DemandeIntervention représentant les demandes d'intervention.</returns>
        ///</summary>
        public static List<DemandeIntervention> consulterincident()
        {
            List<DemandeIntervention> lesDemandesInterventions = new List<DemandeIntervention>();
            DemandeIntervention uneDemandeIntervention;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM demande_intervention JOIN concerne ON concerne.id=demande_intervention.id JOIN fait ON fait.id=demande_intervention.id";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                uneDemandeIntervention = new DemandeIntervention(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["objet"]), Convert.ToString(dataReader["etat_prise_en_charge"]), Convert.ToString(dataReader["type_prise_en_charge"]), Convert.ToString(dataReader["niveau_urgence"]), Convert.ToDateTime(dataReader["date_demande"]), Convert.ToInt16(dataReader["id_personnel"]), Convert.ToInt16(dataReader["id_materiel"]));
                lesDemandesInterventions.Add(uneDemandeIntervention);
            }
            conn.Close();
            return lesDemandesInterventions;
        }

        ///<summary>
        ///Fonction qui permet de consulter les personnels enregistrés dans la base de données.
        ///<returns>Une liste d'objets Personnel représentant les personnels enregistrés.</returns>
        ///</summary>
        public static List<Personnel> consulterPersonnel()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            Personnel unPersonnel;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM personnel";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                unPersonnel = new Personnel(Convert.ToInt16(dataReader["id_personnel"]), Convert.ToString(dataReader["nom_complet"]), Convert.ToString(dataReader["matricule"]), Convert.ToDateTime(dataReader["date_embauche"]), Convert.ToString(dataReader["login"]), Convert.ToString(dataReader["mot_de_passe"]), Convert.ToInt16(dataReader["est_responsable"]));
                lesPersonnels.Add(unPersonnel);
            }
            conn.Close();
            return lesPersonnels;
        }

        ///<summary>
        ///Fonction qui permet de consulter les techniciens enregistrés dans la base de données.
        ///<returns>Une liste d'objets Technicien représentant les techniciens enregistrés.</returns>
        ///</summary>
        public static List<Technicien> consulterTechnicien()
        {
            List<Technicien> lesTechniciens = new List<Technicien>();
            Technicien unTechnicien;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM technicien LEFT JOIN personnel ON technicien.id_personnel=personnel.id_personnel";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                unTechnicien = new Technicien(Convert.ToInt16(dataReader["id_personnel"]), Convert.ToString(dataReader["nom_complet"]), Convert.ToString(dataReader["matricule"]), Convert.ToDateTime(dataReader["date_embauche"]), Convert.ToString(dataReader["login"]), Convert.ToString(dataReader["mot_de_passe"]), Convert.ToString(dataReader["niveau_intervention"]), Convert.ToString(dataReader["formation"]), Convert.ToInt16(dataReader["est_responsable"]));
                lesTechniciens.Add(unTechnicien);
            }
            conn.Close();
            return lesTechniciens;
        }

        ///<summary>
        ///Fonction qui permet de consulter les phases de travail enregistrées dans la base de données.
        ///<returns>Une liste d'objets PhaseTravail représentant les phases de travail enregistrées.</returns>
        ///</summary>
        public static List<PhaseTravail> consulterPhasesTravail()
        {
            List<PhaseTravail> lesPhases = new List<PhaseTravail>();
            PhaseTravail unePhase;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM phase_travail JOIN demande ON phase_travail.id=demande.id";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                unePhase = new PhaseTravail(Convert.ToInt16(dataReader["id"]), Convert.ToDateTime(dataReader["date_phase"]), Convert.ToString(dataReader["heure_debut"]), Convert.ToString(dataReader["heure_fin"]), Convert.ToString(dataReader["travail_realise"]), Convert.ToInt16(dataReader["id_1"]));
                lesPhases.Add(unePhase);
            }
            conn.Close();
            return lesPhases;
        }

        ///<summary>
        ///Fonction qui permet de consulter les logiciels enregistrés dans la base de données.
        ///<returns>Une liste d'objets Logiciel représentant les logiciels enregistrés.</returns>
        ///</summary>
        public static List<Logiciel> consulterLogiciels()
        {
            List<Logiciel> lesLogiciels = new List<Logiciel>();
            Logiciel unLogiciel;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM logiciel JOIN possède ON logiciel.id_logiciel=possède.id_logiciel";
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                unLogiciel = new Logiciel(Convert.ToInt16(dataReader["id_logiciel"]), Convert.ToString(dataReader["nom_logiciel"]), Convert.ToDateTime(dataReader["date_installation"]), Convert.ToInt16(dataReader["id_materiel"]));
                lesLogiciels.Add(unLogiciel);
            }
            conn.Close();
            return lesLogiciels;
        }


    }
}
