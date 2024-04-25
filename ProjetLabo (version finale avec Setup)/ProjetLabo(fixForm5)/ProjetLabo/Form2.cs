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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
      

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonLoginSubmit_Click(object sender, EventArgs e)
        {
            int id = classeBD.verifierLoginMdp(textBoxLoginId.Text, textBoxLoginPassword.Text);
            if(id != 0)
            {
                //redirection vers form5
                Form5 taPage = new Form5(id);
                Form3 uneAuterPage = new Form3(id);
                taPage.ShowDialog();
                this.Hide();
                this.Close();
            }
            else
            {
                //message d'erreur
                MessageBox.Show("Veuillez renseigner des identifiants valides");
            }
        }
    }
}
