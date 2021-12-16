using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Transfer : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");
        public Transfer()
        {
            InitializeComponent();
            Affiche();
            SangStock();
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

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Reçu Pour Transfer de Sang", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 100));
        }

        private void DoneurTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nametxt.Text = patienttb.SelectedRows[0].Cells[1].Value.ToString();
            typetxt.SelectedItem = patienttb.SelectedRows[0].Cells[7].Value.ToString();
        }
        // recuperation des donnees des patients et les affichees dans le tableau 
        private void Affiche()
        {
            conn.Open();
            String Tab = "select * from PatientDB";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            patienttb.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from PatientDB where Bnom like '%" + nametxt.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            ds.Fill(dt);
            patienttb.DataSource = dt;
            conn.Close();
            if (nametxt.Text == "")
            {
                Affiche();
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }
        // 
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


        // étiquettes vides après exécution

        private void rest()
        {
            nametxt.Text = "";
            typetxt.SelectedIndex = -1;
            Bqunat.Text = "";
        }

        // Affichage le quantite de Sang dans la partie stockage
        private void SangStock()
        {
            conn.Open();
            String tab = "select * from SangDB";
            SqlDataAdapter sq = new SqlDataAdapter(tab, conn);
            SqlCommandBuilder sb = new SqlCommandBuilder(sq);
            var ds = new DataSet();
            sq.Fill(ds);
            quantb.DataSource = ds.Tables[0];
            conn.Close();
        }
        // fi partie adhy lezmna nchoufo kifeh n3mlou transer ma3a el dem ali fi diponiblite bech nbdlo m3ah kime : 
        // O- - O- ; O+ - O- we O+ ; B- : O- et B- ; B+ : O- O+ B- B+ ; A- : O- A- ; A+ : O- O+ A- A+ ; AB- : O- B- A- AB- ; AB+ tous les type
        // creation event pour faire le transfert de sang 
        private void insertTrans()
        {
            

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "" || typetxt.SelectedIndex == -1 || Bqunat.Text == "")
            {
                MessageBox.Show("Verifer les informations");
            }

            else
            {

                try
                {
                
                    
            /*        String stockkAB = typetxt.SelectedItem.ToString();
                    if(stockkAB == "AB+")
                    {
                        int Stock = Convert.ToInt32(Bqunat.Text);
                        conn.Open();
                        SqlDataAdapter sda3 = new SqlDataAdapter("select Bquant from SangDB where Btype='"+"AB+"+ " ou Btype='" + "A+" + "'", conn);
                        DataTable dt11 = new DataTable();
                        sda3.Fill(dt11);
                        int qte = Convert.ToInt32(dt11.Rows[0][0].ToString());
                        if (Stock <= qte)
                        {
                            SqlCommand cmd2 = new SqlCommand("insert into DBtrans values('" + nametxt.Text + "', '" + typetxt.SelectedItem.ToString() + "', '" + Bqunat.Text + "')", conn);
                            cmd2.ExecuteNonQuery();
                            String tab = "update SangDB set Bquant -= '"+Stock+"' where Btype='" +"AB+"+ "' OR Btype='" +"A+" +"'";
                            SqlCommand cmd = new SqlCommand(tab, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Transfert a ete effectuer ");
                        }
                    } */


                    // Dans cette partie nous avons Crée la partie Transfer de Quantite de Sang 
                    // test la quantite disponible par rapport le quantite saisier
                    int Stock = Convert.ToInt32(Bqunat.Text);
                    conn.Open();
                    SqlDataAdapter sda3 = new SqlDataAdapter("select Bquant from SangDB where Btype='" +typetxt.SelectedItem.ToString()+"'", conn);
                    DataTable dt11 = new DataTable();
                    sda3.Fill(dt11);
                    int qte = Convert.ToInt32(dt11.Rows[0][0].ToString());



                    if (Stock <= qte)
                    {
                        SqlCommand cmd2 = new SqlCommand("insert into DBtrans values('" + nametxt.Text + "', '" + typetxt.SelectedItem.ToString() + "', '" + Bqunat.Text + "')", conn);
                        cmd2.ExecuteNonQuery();
                        String tab = "update SangDB set Bquant -= '" +Stock+ "' where Btype='" + typetxt.SelectedItem.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(tab, conn);
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Transfert a ete effectuer ");


                    }
                    else
                    {
                        MessageBox.Show("stockage invalide !");
                    }
                    conn.Close();
                    rest();
                    Affiche();
                    SangStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void quantb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
