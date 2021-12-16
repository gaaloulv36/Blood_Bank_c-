using System;
using System.Windows.Forms;

namespace BBMS
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (BpassLB.Text == "") // configuration admin mot de pass
            {
                MessageBox.Show("Entre le password !");
            }
            else if (BpassLB.Text == "admin")

            {
                adminadd log = new adminadd();
                log.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("mot de passe inccorect !");
                BpassLB.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // Event listener pour naviguée a l'interfae login
        private void label2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        // Event listener pour quitter l'interface
        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Event listener pour minimize interface
        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
