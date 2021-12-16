using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            admin log = new admin();
            log.Show();
            this.Hide();
        }
        // button connexion pour la login des employee : 
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from AEMP where Buser = '" + UempLB.Text + "' and Bpassword = '" + PempLB.Text + "'", conn);
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            if (Dt.Rows[0][0].ToString() == "1")
            {
                MainForm Main = new MainForm();
                Main.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Utulisatuer ou Mot de Pass inccorect !");
            }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
            this.Hide();
        }
    }
}
