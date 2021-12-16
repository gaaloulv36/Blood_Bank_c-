using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BBMS
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }
        // Connection avec BD
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        // Function Rest pour initialization
        private void Rest()
        {
            Bnom.Text = "";
            Bprenom.Text = "";
            Baddress.Text = "";
            Bage.Text = "";
            Btele.Text = "";
            Bsexe.SelectedIndex = -1;
            Btype.SelectedIndex = -1;
        }
        // Partie ajpoute les donateurs dans la base des donneés
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Bnom.Text == "" || Bprenom.Text == "" || Bage.Text == "" || Bsexe.SelectedIndex == -1 || Btype.SelectedIndex == -1 || Baddress.Text == "")
            {
                MessageBox.Show("Champ invalide : merci de vérifier ");
            }
            else
            {
                try
                {
                 
                    string tab = "insert into PatientDB values ('" + Bnom.Text + "', '" + Bprenom.Text + "', '" + Bage.Text + "', '" + Bsexe.SelectedItem.ToString() + "', '" + Baddress.Text + "', '" + Btele.Text + "', '" + Btype.SelectedItem.ToString() + "')";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Bien Ajouté");
                    conn.Close();
                    Rest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // Event listener pour naviguée a l'interfae Login
        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae dashboard
        private void dash_Click(object sender, EventArgs e)
        {
            dashboard log = new dashboard();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae Stockage
        private void stock_Click(object sender, EventArgs e)
        {
            Stockage log = new Stockage();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae Transfer
        private void tra_sa_Click(object sender, EventArgs e)
        {
            Transfer log = new Transfer();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae liste des patients
        private void list_pa_Click(object sender, EventArgs e)
        {
            List_patient log = new List_patient();
            log.Show();
            this.Hide();
        }

        private void patie_Click(object sender, EventArgs e)
        {

        }
        // Event listener pour naviguée a l'interfae liste donnateur
        private void list_op_Click(object sender, EventArgs e)
        {
            list_done log = new list_done();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a operation
        private void oper_Click(object sender, EventArgs e)
        {
            operation log = new operation();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae donnateur
        private void Done_Click(object sender, EventArgs e)
        {
            donateur log = new donateur();
            log.Show();
            this.Hide();
        }
        // Event listener pour sorte de l'application
        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Event listener pour minimize l'in,terface
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // button pour Rest les valeur dans les chemins 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Rest();
        }
    }
}
