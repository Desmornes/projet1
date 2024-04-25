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
    public partial class Form5 : Form
    {
        public Form5(int idParam)
        {
            InitializeComponent();
            id = idParam;
        }
        int id;
        List<Materiel> lesMateriels5;
        List<DemandeIntervention> lesIncidents5;

        private void Form5_Load(object sender, EventArgs e)
        {
            lesMateriels5 = new List<Materiel>();
            lesIncidents5 = new List<DemandeIntervention>();
            Actualiser();
        }
        public void Actualiser()
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            lesMateriels5 = classeBD.consulterMateriel();
            foreach (Materiel unMateriel in lesMateriels5)
            {
                comboBox1.Items.Add(unMateriel.getProcesseur());
            }
            lesIncidents5 = classeBD.consulterincident();
            foreach (DemandeIntervention unIncident in lesIncidents5)
            {
                comboBox3.Items.Add(unIncident.getobjet());
            }
        }
        private void buttonPageSuivante_Click(object sender, EventArgs e)
        {
            if (classeBD.estTechnicien(id) == true)
            {
                Form3 unePage = new Form3(id);
                unePage.ShowDialog();
                this.Hide();
            }
            else if(classeBD.estResponsable(id) == true)
            {
                Form4 unePage = new Form4(id);
                this.Hide();
                unePage.ShowDialog();
                this.Close();
            }
            else
            {
                buttonPageSuivante.Enabled = false;
                MessageBox.Show("Vous ne pouvez pas acceder a cette page.");
            }
        }
        private void button1_Click(object sender, EventArgs e) //Fonction pour ajouter incident
        {
            int selectedMaterielId = comboBox1.SelectedIndex;
            DemandeIntervention unIncident = new DemandeIntervention(Convert.ToInt16(textBoxId.Text), textBoxProbleme.Text, "Enregistrée", " ", "Sans risque particulier", classeBD.getDateCourante(), id, lesMateriels5[selectedMaterielId].getId_materiel());
            classeBD.ajouterincident(unIncident);
            lesIncidents5.Add(unIncident);
            classeBD.lierDemandePersonnel(Convert.ToInt16(textBoxId.Text),id);
            classeBD.lierDemandeMateriel(Convert.ToInt16(textBoxId.Text), lesMateriels5[selectedMaterielId].getId_materiel());
            Actualiser();
        }

        private void button2_Click(object sender, EventArgs e) //Fonction pour consulter un matériel selectionné
        {
            listBox1.Items.Clear();
            int selectedIncidentId = comboBox3.SelectedIndex;
            listBox1.Items.Add("Id : " + lesIncidents5[selectedIncidentId].getId());
            listBox1.Items.Add("Problème : " +lesIncidents5[selectedIncidentId].getobjet());
            listBox1.Items.Add("Etat de prise en charge : " +lesIncidents5[selectedIncidentId].getEtat());
            listBox1.Items.Add("Type de prise en charge :"+lesIncidents5[selectedIncidentId].getType());
            listBox1.Items.Add("Niveau d'urgence : "+ lesIncidents5[selectedIncidentId].getNiveauUrgence());
            listBox1.Items.Add("Date de la demande : "+lesIncidents5[selectedIncidentId].getDate());
            listBox1.Items.Add("Demandé par : "+lesIncidents5[selectedIncidentId].getIdPersonnel());
            listBox1.Items.Add("Demandé pour : "+lesIncidents5[selectedIncidentId].getIdMateriel());
            Actualiser();
        }
    }
}
