using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace forlks
{
    public partial class paket : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi Konn = new koneksi();
        public paket()
        {
            InitializeComponent();
        }

        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Paket", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Paket");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Paket";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void paket_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id"].Value.ToString();
                comboBox1.Text = row.Cells["id_layanan"].Value.ToString();
                numericUpDown1.Text = row.Cells["totalunit"].Value.ToString();
                numericUpDown2.Text = row.Cells["harga"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "" || numericUpDown1.Text.Trim() == "" || numericUpDown2.Text.Trim() == "")
            {
                MessageBox.Show("Isi data terlebih dahulu");
            }

            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("insert into Paket (id_layanan, totalunit, harga) values('" + comboBox1.Text + "','" + numericUpDown1.Text + "','" + numericUpDown1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Berhasil");
                    tampil();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
