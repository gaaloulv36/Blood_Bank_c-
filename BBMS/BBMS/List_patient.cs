using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class List_patient : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        public List_patient()
        {
            InitializeComponent();
            Affiche2();

        }
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        }

        private void patie_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }

        private void list_op_Click(object sender, EventArgs e)
        {
            list_done log = new list_done();
            log.Show();
            this.Hide();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Affiche2()
        {
            conn.Open();
            String Tab = "select * from PatientDB";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            patientTB.DataSource = ds.Tables[0];
            conn.Close();
        }
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BnameTb.Text = patientTB.SelectedRows[0].Cells[1].Value.ToString();
            BprenomTb.Text = patientTB.SelectedRows[0].Cells[2].Value.ToString();
            BageTb.Text = patientTB.SelectedRows[0].Cells[3].Value.ToString();
            BsexeTb.SelectedItem = patientTB.SelectedRows[0].Cells[4].Value.ToString();
            BaddressTb.Text = patientTB.SelectedRows[0].Cells[5].Value.ToString();
            BteleTb.Text = patientTB.SelectedRows[0].Cells[6].Value.ToString();
            BtypeTb.SelectedItem = patientTB.SelectedRows[0].Cells[7].Value.ToString();
            if (BnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(patientTB.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    string tab = "Delete from PatientDB where id_pat='" + key + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Bien supprimer");
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (BnameTb.Text == "" || BprenomTb.Text == "" || BageTb.Text == "" || BteleTb.Text == "" || BsexeTb.SelectedIndex == -1 || BtypeTb.SelectedIndex == -1 || BaddressTb.Text == "")
            {
                MessageBox.Show("Manque des informations ");
            }
            else
                try
                {
                    string tab = "update PatientDB  set Bnom ='" + BnameTb.Text + "', Bprenom = '" + BprenomTb.Text + "', Bage='" + BageTb.Text + "', Bsexe='" + BsexeTb.SelectedItem.ToString() + "', Badress='" + BaddressTb.Text + "', Btele ='" + BteleTb.Text + "', Btype='" + BtypeTb.SelectedItem.ToString() + "'  where Id_pat = " + key + ";";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(tab, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Bien Modifée");
                    conn.Close();
                    Rest();
                    Affiche2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void BnameTb_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from PatientDB where Bnom like '%" + BnameTb.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            patientTB.DataSource = dt;
            ds.Fill(dt);
            conn.Close();
            if (BnameTb.Text == "")
            {
                Affiche2();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Rest();
        }
    }
}
