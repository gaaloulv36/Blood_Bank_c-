using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class adminadd : Form
    {
        public adminadd()
        {
            InitializeComponent();
            Affiche2();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // mode exit
        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Rest() // clair les interfaces aprés ajoute
        {
            Buser.Text = "";
            Bpassword.Text = "";
            key = 0;
        }
        // connexion base de donnée
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        // ajoute les username et le mot de passe de chaque emploiee 
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Buser.Text == "" || Bpassword.Text == "")  // verification de chaque label 
            {
                MessageBox.Show("Champ invalide : merci de vérifier ");
            }
            else
            {
                try // insertion les valeur dans les deux label user et password
                {

                    string tab = "insert into AEMP  values ('" + Buser.Text + "', '" + Bpassword.Text + "')";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employeé Bien Ajouté");
                    conn.Close();
                    Rest();
                    Affiche2();
                }
                catch (Exception ex) // verification d'error dans le systeme
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Affiche2() // affichage le tableau de employee
        {
            conn.Open();
            String Tab = "select * from AEMP";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            EMPTB.DataSource = ds.Tables[0];
            conn.Close();
        }
        // Dans cette partie on create event click sur le tableau pour afficher les données dans les labels 
        int key = 0;
        private void EMPTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Buser.Text = EMPTB.SelectedRows[0].Cells[1].Value.ToString();
            Bpassword.Text = EMPTB.SelectedRows[0].Cells[2].Value.ToString();
            if (Buser.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EMPTB.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        // Dans cette partie nous avons creat event de la button supprimer pour effacer les donnees dans le tableau
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Selectioner la Collum pour supprimer !");
            }
            else
            {
                try
                {

                    string tab = "Delete from AEMP where id_emp='" + key + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employée Bien supprimer");
                    conn.Close();
                    Rest();
                    Affiche2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        // dans cette partie nous avons creat event pour le button modfier pour faire le modification au niveau des donneé de tableau
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (Buser.Text == "" || Bpassword.Text == "")
            {
                MessageBox.Show("Manque des informations ");
            }
            else
                try
                {
                    string tab = "update AEMP  set Buser ='" + Buser.Text + "', Bpassword = '" + Bpassword.Text + "' where Id_emp = " + key + ";";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employeé Bien Modifée");
                    conn.Close();
                    Rest();
                    Affiche2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
