using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetLabo
{
    public partial class Form4 : Form
    {
        public Form4(int idParam)
        {
            InitializeComponent();
            id = idParam;
        }
        
        int id;
        List<Technicien> lesTechniciens4;
        List<Personnel> lesPersonnels4;

        private void Form4_Load(object sender, EventArgs e)
        {
            Actualiser();
            labelIncidentsDeclares.Text = Convert.ToString(classeBD.getStatsIncidents("Déclarée"))+" %";
            labelIncidentsDeclaresUtilisateur.Text = Convert.ToString(classeBD.totalIncident("Déclarée"));
            labelIncidentsEnCharge.Text = Convert.ToString(classeBD.getStatsIncidents("En charge")) + " %";
            labelIncidentsEnChargeTechniciens.Text = Convert.ToString(classeBD.totalIncident("En charge"));
            labelIncidentsResolus.Text = Convert.ToString(classeBD.getStatsIncidents("Résolue")) + " %";
            labelIncidentsResolusTechnicien.Text = Convert.ToString(classeBD.totalIncident("Résolue"));
        }
        
        public void Actualiser()
        {
            lesPersonnels4 = classeBD.consulterPersonnel();
            foreach (Personnel unPersonnel in lesPersonnels4)
            {
                comboBoxDeleteUtilisateur.Items.Add(unPersonnel.getNom());
                comboBoxUpdateUtilisateur.Items.Add(unPersonnel.getNom());
                comboBoxAddRegion.Items.Add(unPersonnel.getNom());
            }
            lesTechniciens4 = classeBD.consulterTechnicien();
            foreach (Technicien unTechnicien in lesTechniciens4)
            {
                comboBoxUpdateTechnicien.Items.Add(unTechnicien.getNom());
                comboBoxDeleteTechnicien.Items.Add(unTechnicien.getNom());
                comboBoxAddCompetence.Items.Add((unTechnicien.getNom()));
            }
        }
        
        private void buttonAddUtilisateur_Click(object sender, EventArgs e)
        {
            //ajouter un personnel
            int EstResponsable =0;
            if (radioButtonEstResponsableTrue.Checked)
            {
                EstResponsable = 1;
            }
            else if (radioButtonEstResponsableFalse.Checked)
            {
                EstResponsable = 0;
            }
            Personnel lePersonnel = new Personnel(Convert.ToInt16(textBoxAddIdentiteUtilisateur.Text),Convert.ToString(textBoxAddNomUtilisateur.Text),Convert.ToString(textBoxAddMatriculeUtilisateur.Text),Convert.ToDateTime(textBoxAddEmbaucheUtilisateur.Text), Convert.ToString(textBoxAddLoginUtilisateur.Text),Convert.ToString(textBoxAddPasswordUtilisateur.Text),EstResponsable);
            classeBD.ajoutPersonel(lePersonnel);
            lesPersonnels4.Add(lePersonnel);
            Actualiser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rediriger vers la page utilisateurs
            Form5 taPage = new Form5(id);
            taPage.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rediriger vers la page utilisateurs
            Form5 taPage = new Form5(id);
            taPage.ShowDialog();
            this.Close();
        }

        private void buttonSetTechnicien_Click(object sender, EventArgs e)
        {
            //modifier un technicien
            int selectedTechnicien=comboBoxUpdateTechnicien.SelectedIndex;
            classeBD.updateTechnicien(lesTechniciens4[selectedTechnicien].getid_perso(), textBoxSetFormationTechnicien.Text, textBoxSetNiveauIntervTechnicien.Text) ;
            lesTechniciens4[selectedTechnicien].setFormation(textBoxSetFormationTechnicien.Text);
            lesTechniciens4[selectedTechnicien].setNiveauIntervention(textBoxSetNiveauIntervTechnicien.Text);
            Competence laCompetence = new Competence(Convert.ToInt16(textBoxAddIdCompetence.Text), textBoxAddCompetence.Text);
            lesTechniciens4[selectedTechnicien].addCompetence(laCompetence);
            classeBD.ajouterCompetence(laCompetence);
            classeBD.lierCompetenceTechnicien(lesTechniciens4[selectedTechnicien].getid_perso(), laCompetence.getId());
            Actualiser();
        }

        private void buttonAddTechnicien_Click(object sender, EventArgs e)
        {
            //ajouter un technicien
            Technicien leTechnicien = new Technicien(Convert.ToInt16(textBoxAddIdentiteTechnicien.Text), lesPersonnels4[Convert.ToInt16(textBoxAddIdentiteTechnicien.Text)].getNom(), lesPersonnels4[Convert.ToInt16(textBoxAddIdentiteTechnicien.Text)].getnomatricule(), lesPersonnels4[Convert.ToInt16(textBoxAddIdentiteTechnicien.Text)].getdatedembauche(), lesPersonnels4[Convert.ToInt16(textBoxAddIdentiteTechnicien.Text)].getloging(), lesPersonnels4[Convert.ToInt16(textBoxAddIdentiteTechnicien.Text)].getmotdepasse(), Convert.ToString(textBoxAddNiveauIntervTechnicien.Text), Convert.ToString(textBoxAddFormationTechnicien.Text), 0);
            classeBD.ajouterTechnicien(leTechnicien, Convert.ToInt16(textBoxAddIdentiteTechnicien.Text));
            lesTechniciens4.Add(leTechnicien);
            Actualiser();
        }

        private void buttonDeleteUtilisateur_Click(object sender, EventArgs e)
        {
            int rangSelectP = comboBoxDeleteUtilisateur.SelectedIndex;
            classeBD.supprimerUtilisateur(lesPersonnels4[rangSelectP]);
            lesPersonnels4.Remove(lesPersonnels4[rangSelectP]);
            labelDeleteUser.Text = (lesPersonnels4[rangSelectP].getNom()+" "+"a été supprimé");
            Actualiser();
        }

        private void buttonDeleteTechnicien_Click(object sender, EventArgs e)
        {
            int rangSelectT = comboBoxDeleteTechnicien.SelectedIndex;
            classeBD.supprimerTechnicien(lesTechniciens4[rangSelectT]);
            lesPersonnels4.Remove(lesTechniciens4[rangSelectT]);
            label1DeleteTechnicien.Text = (lesTechniciens4[rangSelectT].getNom() +" "+"a été supprimé");
            Actualiser();
        }

        private void buttonSetUtilisateur_Click(object sender, EventArgs e)
        {
            //modifier un personnel
            int selectedPersonnel = comboBoxUpdateUtilisateur.SelectedIndex;
            classeBD.updatePersonnel(lesPersonnels4[selectedPersonnel].getid_perso(), textBoxSetLoginUtilisateur.Text, textBoxSetPasswordUtilisateur.Text);
            lesPersonnels4[selectedPersonnel].setLogin(textBoxSetLoginUtilisateur.Text);
            lesPersonnels4[selectedPersonnel].setMotDePasse(textBoxSetPasswordUtilisateur.Text);
            Region laRegion = new Region(Convert.ToInt16(textBoxAddRegion.Text), textBox1.Text);
            classeBD.ajouterRegion(laRegion);
            lesPersonnels4[selectedPersonnel].addRegion(laRegion);
            classeBD.lierRegionPersonnel(lesTechniciens4[selectedPersonnel].getid_perso(), laRegion.getId());
            Actualiser();
        }
    }
}
