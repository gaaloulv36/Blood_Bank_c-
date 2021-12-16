using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BBMS
{
    public partial class list_done : Form

    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        public list_done()
        {
            InitializeComponent();
            Affiche();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void dash_Click(object sender, EventArgs e)
        {
            dashboard log = new dashboard();
            log.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            Stockage log = new Stockage();
            log.Show();
            this.Hide();
        }

        private void tra_sa_Click(object sender, EventArgs e)
        {
            Transfer log = new Transfer();
            log.Show();
            this.Hide();
        }

        private void list_pa_Click(object sender, EventArgs e)
        {
            List_patient log = new List_patient();
            log.Show();
            this.Hide();
        }

        private void patie_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }

        private void list_op_Click(object sender, EventArgs e)
        {

        }

        private void oper_Click(object sender, EventArgs e)
        {
            operation log = new operation();
            log.Show();
            this.Hide();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            donateur log = new donateur();
            log.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void BteleTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtypeTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void BaddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void BageTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BsexeTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void BprenomTb_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from DonateurDBD where Bprenom like '%" + BprenomTb.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            DoneurTB.DataSource = dt;
            ds.Fill(dt);
            conn.Close();
            if (BprenomTb.Text == "")
            {
                Affiche();
            }

        }

        private void BnameTb_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from DonateurDBD where Bnom like '%" + BnameTb.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            DoneurTB.DataSource = dt;
            ds.Fill(dt);
            conn.Close();
            if (BnameTb.Text == "")
            {
                Affiche();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //pour vider label après l'exécution
        private void Rest()
        {
            BnameTb.Text = "";
            BprenomTb.Text = "";
            BaddressTb.Text = "";
            BageTb.Text = "";
            BteleTb.Text = "";
            BsexeTb.SelectedIndex = -1;
            BtypeTb.SelectedIndex = -1;
            key = 0;
        }
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
        // dans cette partie nous avons creé le partie modification des donneés de donateur 
        int key = 0;
        private void Bmodif_Click(object sender, EventArgs e)
        {


            if (BnameTb.Text == "" || BprenomTb.Text == "" || BageTb.Text == "" || BteleTb.Text == "" || BsexeTb.SelectedIndex == -1 || BtypeTb.SelectedIndex == -1 || BaddressTb.Text == "")
            {
                MessageBox.Show("Manque des informations ");
            }
            else
                try
                {
                    string tab = "update DonateurDBD  set Bnom ='" + BnameTb.Text + "', " +
                        "Bprenom = '" + BprenomTb.Text + "', Bage='" + BageTb.Text + "', " +
                        "Bsexe='" + BsexeTb.SelectedItem.ToString() + "', Baddress='" + BaddressTb.Text + "'," +
                        " Btele ='" + BteleTb.Text + "', Btype='" + BtypeTb.SelectedItem.ToString() + "'  where Id_don = " + key + ";";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donnateur Bien Modifée");
                    conn.Close();
                    Rest();
                    Affiche();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }


        // creat event click sur le tableau list donnateur 
        private void DoneurTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BnameTb.Text = DoneurTB.SelectedRows[0].Cells[1].Value.ToString();
            BprenomTb.Text = DoneurTB.SelectedRows[0].Cells[2].Value.ToString();
            BageTb.Text = DoneurTB.SelectedRows[0].Cells[3].Value.ToString();
            BsexeTb.SelectedItem = DoneurTB.SelectedRows[0].Cells[4].Value.ToString();
            BaddressTb.Text = DoneurTB.SelectedRows[0].Cells[5].Value.ToString();
            BteleTb.Text = DoneurTB.SelectedRows[0].Cells[6].Value.ToString();
            BtypeTb.SelectedItem = DoneurTB.SelectedRows[0].Cells[7].Value.ToString();
            if (BnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DoneurTB.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Selection le Collum pour supprimer !");
            }
            else
            {
                try
                {

                    string tab = "Delete from DonateurDBD where id_don='" + key + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donnateur Bien supprimer");
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Rest();
        }
    }
}
