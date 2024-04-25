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
    public partial class Form3 : Form
    {
        public Form3(int idParam)
        {
            InitializeComponent();
            id = idParam;
        }
        
        int idPhaseDeTravailAjoute;
        int id;
        List<Materiel> lesMateriels3;
        List<DemandeIntervention> lesIncidents3;
        List<PhaseTravail> lesPhases3;
        List<Logiciel> lesLogiciels3;
        PhaseTravail unePhaseDeTravail;

        public void Actualiser()
        {
            comboBoxDeleteMateriel.Items.Clear();
            comboBoxLogiciel.Items.Clear();
            comboBoxShowIncident.Items.Clear();
            comboBoxShowIncidentPriseEnCharge.Items.Clear();
            comboBoxShowMateriel.Items.Clear();
            lesMateriels3 = classeBD.consulterMateriel();
            foreach (Materiel unMateriel in lesMateriels3)
            {
                comboBoxShowMateriel.Items.Add(unMateriel.getProcesseur());
                comboBoxDeleteMateriel.Items.Add(unMateriel.getProcesseur());
                comboBoxLogiciel.Items.Add(unMateriel.getProcesseur());
            }
            lesIncidents3 = classeBD.consulterincident();
            foreach (DemandeIntervention uneDemandeIntervention in lesIncidents3)
            {
                comboBoxShowIncident.Items.Add(uneDemandeIntervention.getobjet());
                comboBoxShowIncidentPriseEnCharge.Items.Add(uneDemandeIntervention.getobjet());
            }
            lesPhases3 = classeBD.consulterPhasesTravail();
            lesLogiciels3 = classeBD.consulterLogiciels();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materiel leMateriel = new Materiel(Convert.ToInt16(textBoxAddId.Text),Convert.ToString(textBoxAddProc.Text),Convert.ToString(textBoxAddMemoire.Text),Convert.ToString(textBoxAddDisque.Text),Convert.ToDateTime(textBoxAddDateAchat.Text),Convert.ToString(textBoxAddGarantie.Text), Convert.ToInt16(textBoxAddMaterielIdPersonnel.Text));
            classeBD.ajoutMateriel(leMateriel);
            lesMateriels3.Add(leMateriel);
            classeBD.lierMaterielPersonnel(leMateriel.getId_materiel(), Convert.ToInt16(textBoxAddMaterielIdPersonnel.Text));
            Actualiser();
        }

        private void buttonShowMateriel_Click(object sender, EventArgs e)
        {
            listBoxShowMateriel.Items.Clear();
            listBoxShowMateriel.Items.Add("Id : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getId_materiel());
            listBoxShowMateriel.Items.Add("Processeur : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getProcesseur());
            listBoxShowMateriel.Items.Add("Mémoire : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getMemoire());
            listBoxShowMateriel.Items.Add("Disque : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getDisque());
            listBoxShowMateriel.Items.Add("Date d'achat : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getDateAchat());
            listBoxShowMateriel.Items.Add("Garantie : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getGarantie());
            listBoxShowMateriel.Items.Add("Affecté à (id) : " + lesMateriels3[comboBoxShowMateriel.SelectedIndex].getIdPersonnel());
            listBoxShowMateriel.Items.Add("Logiciels : ");
            foreach (Logiciel unLogiciel in lesLogiciels3)
            {
                if (unLogiciel.getIdMateriel() == lesMateriels3[comboBoxShowMateriel.SelectedIndex].getId_materiel())
                {
                    listBoxShowMateriel.Items.Add("     - " + unLogiciel.getNom());
                }
            }
            Actualiser();
        }

        private void buttonShowIncident_Click(object sender, EventArgs e)
        {
            listBoxShowIncident.Items.Clear();
            listBoxShowIncident.Items.Add("Id : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getId());
            listBoxShowIncident.Items.Add("Objet : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getobjet());
            listBoxShowIncident.Items.Add("Etat de prise en charge : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getEtat());
            listBoxShowIncident.Items.Add("Type de prise en charge : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getType());
            listBoxShowIncident.Items.Add("Niveau d'urgence : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getNiveauUrgence());
            listBoxShowIncident.Items.Add("Date de la demande : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getDate());
            listBoxShowIncident.Items.Add("Demandé par (id) : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getIdPersonnel());
            listBoxShowIncident.Items.Add("Demandé pour (id) : " + lesIncidents3[comboBoxShowIncident.SelectedIndex].getIdMateriel());
            listBoxShowIncident.Items.Add("Phases de travail : ");
            foreach(PhaseTravail unePhase in lesPhases3)
            {
                if(unePhase.getIdDemande()==lesIncidents3[comboBoxShowIncident.SelectedIndex].getId())
                {
                    listBoxShowIncident.Items.Add("     - " + unePhase.getTravailFait());
                }
            }
            Actualiser();
        }

        private void buttonDeleteMateriel_Click(object sender, EventArgs e)
        {
            int rangSelect = comboBoxDeleteMateriel.SelectedIndex;
            classeBD.supprimerMateriel(lesMateriels3[rangSelect]);
            lesMateriels3.Remove(lesMateriels3[rangSelect]);
            labelDeletedMateriel.Text ="Le matériel d'id"+ lesMateriels3[rangSelect].getId_materiel()+ "a été supprimé";
            Actualiser();
        }

        private void buttonAjouterPhase_Click(object sender, EventArgs e)
        {
            unePhaseDeTravail = new PhaseTravail(Convert.ToInt16(textBoxIdPhase.Text), classeBD.getDateCourante(), textBoxHeureDebut.Text, Convert.ToString(textBoxHeureFinPhase.Text), Convert.ToString(textBoxTravailPhase.Text), Convert.ToInt16(lesIncidents3[comboBoxShowIncidentPriseEnCharge.SelectedIndex].getId()));
            idPhaseDeTravailAjoute = unePhaseDeTravail.getId();
            classeBD.ajoutPhaseTravail(unePhaseDeTravail);
            Actualiser();
        }
        private void buttonUpdateIncident_Click(object sender, EventArgs e)
        {
            int selectedIncident = comboBoxShowIncidentPriseEnCharge.SelectedIndex;
            string etat="";
            if (radioButtonCloturee.Checked)
            {
                etat = "Clôturée";
            }
            else if (radioButtonResolue.Checked)
            {
                etat = "Résolue";
            }
            classeBD.updateIncident(etat ,lesIncidents3[selectedIncident].getId());
            lesIncidents3[selectedIncident].setEtat(etat);
            lesIncidents3[selectedIncident].addPhaseTravail(unePhaseDeTravail);
            classeBD.lierPhaseTravailIncident(lesIncidents3[selectedIncident].getId(), idPhaseDeTravailAjoute);
            classeBD.lierDemandeTechnicien(lesIncidents3[selectedIncident].getId(),id);
            Actualiser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 taPage = new Form5(id);
            taPage.ShowDialog();
            this.Close();
        }

        private void buttonAjoutLogiciel_Click(object sender, EventArgs e)
        {
            Logiciel leLogiciel = new Logiciel(Convert.ToInt16(textBoxIdLogiciel.Text),textBoxNomLogiciel.Text,Convert.ToDateTime(textBoxDateLogiciel.Text), lesMateriels3[comboBoxLogiciel.SelectedIndex].getId_materiel());
            lesMateriels3[comboBoxLogiciel.SelectedIndex].addLogiciel(leLogiciel);
            classeBD.ajouterLogiciel(leLogiciel);
            classeBD.lierLogicielMateriel(leLogiciel.getId(), lesMateriels3[comboBoxLogiciel.SelectedIndex].getId_materiel());
            Actualiser();
        }
    }
}
