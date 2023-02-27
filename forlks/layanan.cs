using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace forlks
{
    public partial class layanan : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        pegawai formpegawai;
        menuutama formhome;
        login formlogin;
        paket formpaket;

        koneksi Konn = new koneksi();

        void formpegawai_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formpegawai = null;
        }

        void formhome_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formhome = null;
        }

        void formlogin_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        void formpaket_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        public layanan()
        {
            InitializeComponent();
        }

        void cari()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Layanan where id like '%" + txtCari.Text + "%' or nama like '%" + txtCari.Text + "%'  or hargaunit like '%" + txtCari.Text + "%'  or estimasidurasi like '%" + txtCari.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Layanan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Layanan";
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

        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Layanan", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Layanan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Layanan";
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

        private void layanan_Load(object sender, EventArgs e)
        {
            this.label11.Text = "Tanggal " + DateTime.Now.ToString();
            label10.Text = "Hi, " + login.recby;
            tampil();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Isi data terlebih dahulu");
            }

            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {               
                    switch (comboBox1.Text)
                    {
                        case "Laundry Kiloan":
                            comboBox1.Text = "1";
                            break;

                        case "Laundry Satuan":
                            comboBox1.Text = "2";
                            break;

                        case "Laundry Boneka":
                            comboBox1.Text = "3";
                            break;
                    }

                    switch (comboBox2.Text)
                    {
                        case "KG":
                            comboBox2.Text = "1";
                            break;

                        case "PCS":
                            comboBox2.Text = "2";
                            break;

                        case "SET":
                            comboBox2.Text = "3";
                            break;
                        case "M":
                            comboBox2.Text = "4";
                            break;
                    }
                    cmd = new SqlCommand("insert into Layanan (nama, id_kategori, id_unit, hargaunit, estimasidurasi) values('" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id"].Value.ToString();
                textBox2.Text = row.Cells["nama"].Value.ToString();
                comboBox1.Text = row.Cells["id_kategori"].Value.ToString();
                comboBox2.Text = row.Cells["id_unit"].Value.ToString();
                textBox3.Text = row.Cells["hargaunit"].Value.ToString();
                textBox4.Text = row.Cells["estimasidurasi"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Isi data terlebih dahulu");
            }

            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    switch (comboBox1.Text)
                    {
                        case "Laundry Kiloan":
                            comboBox1.Text = "1";
                            break;

                        case "Laundry Satuan":
                            comboBox1.Text = "2";
                            break;

                        case "Laundry Boneka":
                            comboBox1.Text = "3";
                            break;
                    }

                    switch (comboBox2.Text)
                    {
                        case "KG":
                            comboBox2.Text = "1";
                            break;

                        case "PCS":
                            comboBox2.Text = "2";
                            break;

                        case "SET":
                            comboBox2.Text = "3";
                            break;
                        case "M":
                            comboBox2.Text = "4";
                            break;
                    }
                    cmd = new SqlCommand("Update Layanan Set nama='" + textBox2.Text + "',id_kategori='" + comboBox1.Text.ToString() + "',id_unit='" + comboBox2.Text.ToString() + "',hargaunit='" + textBox3.Text + "',estimasidurasi='" + textBox4.Text + "' where id='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Berhasil");
                    tampil();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (formpegawai == null)
            {
                formpegawai = new pegawai();
                formpegawai.FormClosed += new FormClosedEventHandler(formpegawai_FormClosed);
                formpegawai.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formpegawai.Activate();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (formhome == null)
            {
                formhome = new menuutama();
                formhome.FormClosed += new FormClosedEventHandler(formhome_FormClosed);
                formhome.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formhome.Activate();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (formlogin == null)
            {
                formlogin = new login();
                formlogin.FormClosed += new FormClosedEventHandler(formlogin_FormClosed);
                formlogin.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formlogin.Activate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus Layanan " + textBox2.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("Delete Layanan where id='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Berhasil");
                    tampil();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id"].Value.ToString();
                textBox2.Text = row.Cells["nama"].Value.ToString();
                comboBox1.Text = row.Cells["id_kategori"].Value.ToString();
                comboBox2.Text = row.Cells["id_unit"].Value.ToString();
                textBox3.Text = row.Cells["hargaunit"].Value.ToString();
                textBox4.Text = row.Cells["estimasidurasi"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            cari();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (formpaket == null)
            {
                formpaket = new paket();
                formpaket.FormClosed += new FormClosedEventHandler(formpaket_FormClosed);
                formpaket.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formpaket.Activate();
            }
        }
    }
}
