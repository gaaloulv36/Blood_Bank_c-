using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class operation : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");

        public operation()
        {
            InitializeComponent();
            Affiche();
            SangSTOCk();
        }
        private void Rest()
        {
            Bnomtb.Text = "";
            btypetb.SelectedIndex = -1;
            bstocktb.Text = "";
            key = 0;
        }
        // Event listener pour naviguée a l'interface login
        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interface dashboard 
        private void dash_Click(object sender, EventArgs e)
        {
            dashboard log = new dashboard();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interface stockage
        private void stock_Click(object sender, EventArgs e)
        {
            Stockage log = new Stockage();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interface transfert
        private void tra_sa_Click(object sender, EventArgs e)
        {
            Transfer log = new Transfer();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interface list patient
        private void list_pa_Click(object sender, EventArgs e)
        {
            List_patient log = new List_patient();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae patient
        private void patie_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }
        // Event listener pour naviguée a l'interfae lsite donateur
        private void list_op_Click(object sender, EventArgs e)
        {
            list_done log = new list_done();
            log.Show();
            this.Hide();
        }

        private void oper_Click(object sender, EventArgs e)
        {

        }
        // Event listener pour naviguée a l'interfae donateur
        private void Done_Click(object sender, EventArgs e)
        {
            donateur log = new donateur();
            log.Show();
            this.Hide();
        }
        // Event listener pour sorite de l'application
        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Initialisation des label apres l'execution de l'event
        public void rest()
        {
            bstocktb.Text = "";
            btypetb.SelectedIndex = -1;
            Bnomtb.Text = "";
        }
        // events recherch sur le label 
        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from DonateurDBD where Bnom like '%" + Bnomtb.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            ds.Fill(dt);
            DoneurTB.DataSource = dt;
            conn.Close();
            if (Bnomtb.Text == "")
            {
                Affiche();
                rest();
            }



        }
        // affichage les donneés de donateurs dans un tabelaux
        private void Affiche()
        {
            conn.Open();
            String Tab = "select * from DonateurDBD";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            DoneurTB.DataSource = ds.Tables[0];
            conn.Close();


        }
        // int PreStcok;
        /*  // aide à obtenir le stock actuel de sang en fonction d'un groupe sanguin particulier
          private void getStock(string bquan)
          {
              var Stock = Convert.ToInt32(bstocktb.Text);
              conn.Open();
              string querry = "select * from SangDB where bquan = '" + btypetb + "'";
              SqlCommand cmd = new SqlCommand(querry, conn);
              DataTable dt = new DataTable();
              SqlDataAdapter sda = new SqlDataAdapter(cmd);
              sda.Fill(dt);
              foreach (DataRow dr in dt.Rows)
              {
                  PreStcok = Convert.ToInt32(dr["Bstock"].ToString());
              }

              conn.Close();*/
        // } 
        int key = 0;
        // event click sur le tableau pour transfert les information de colonne vers les labeles 
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Bnomtb.Text = DoneurTB.SelectedRows[0].Cells[1].Value.ToString();
            btypetb.SelectedItem = DoneurTB.SelectedRows[0].Cells[7].Value.ToString();


            if (Bnomtb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DoneurTB.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        // dans le partie suivant nous avons crée une l'event sur la button supprimer pour effacier les information dans le tableaux  
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Selection le Collum pour supprimer !");
            }
            else
            {
                try
                {
                    string tab = "Delete from  DonateurDBD where id_don='" + key + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Bien supprimer");
                    conn.Close();
                    Rest();
                    Affiche();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

     
        // validation de l'ajoute du quantite de sang
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (Bnomtb.Text == "" || btypetb.SelectedIndex == -1 || bstocktb.Text == "")
            {
                MessageBox.Show("Verifer les informations");
            }

            else
            {
                try
                {

                    var Stock = Convert.ToInt32(bstocktb.Text);
                    if (Stock <= 0 )
                    {
                        MessageBox.Show("Verfier le valeur de Quantite");
                    }
                    else
                    {
                        String tab = "update SangDB set Bquant += " + Stock + " where Btype='" + btypetb.SelectedItem.ToString() + "'";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(tab, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Stockage de sang a ete modifier");
                        conn.Close();
                        rest();
                        Affiche();
                        SangSTOCk();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // affichage de blood stock 
        private void SangSTOCk()
        {
            conn.Open();
            String Tab = "select * from SangDB";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            SangTB.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bnomtb_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
    }
}
