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

namespace forlks
{
    public partial class pegawai : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        layanan formlayanan;
        login formlogin;
        menuutama formhome;

        void formlayanan_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlayanan = null;
        }

        void formlogin_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        void formhome_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formhome = null;
        }

        koneksi Konn = new koneksi();

        public pegawai()
        {
            InitializeComponent();
        }

        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Pegawai", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pegawai");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pegawai";
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

        void cari()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Pegawai where id like '%"+ textBox6.Text +"%' or nama like '%"+ textBox6.Text + "%' or password like '%"+ textBox6.Text + "%' or email like '%"+ textBox6.Text + "%' or alamat like '%"+ textBox6.Text +"%' or notelp like '%" + textBox6.Text +"%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pegawai");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pegawai";
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

        private void pegawai_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || comboBox1.Text.Trim() == "")
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
                        case "Owner":
                            comboBox1.Text = "1";
                            break;

                        case "Kasir":
                            comboBox1.Text = "2";
                            break;

                        case "Pencuci":
                            comboBox1.Text = "3";
                            break;
                    }
                    cmd = new SqlCommand("insert into Pegawai (password, nama, email, alamat, notelp, tgllahir, id_jabatan) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "')", conn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Isi data terlebih dahulu");
            }

            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    switch(comboBox1.Text)
                    {
                        case "Owner":
                            comboBox1.Text = "1";
                            break;

                        case "Kasir":
                            comboBox1.Text = "2";
                            break;

                        case "Pencuci":
                            comboBox1.Text = "3";
                            break;
                    }
                    cmd = new SqlCommand("Update Pegawai Set password='" + textBox2.Text + "',nama='" + textBox3.Text + "',email='" + textBox4.Text + "',alamat='" + textBox5.Text + "',notelp='" + textBox7.Text + "',tgllahir='" + dateTimePicker1.Text + "',id_jabatan='" + comboBox1.Text.ToString() + "' where id='" + textBox1.Text +"'", conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id"].Value.ToString();
                textBox2.Text = row.Cells["password"].Value.ToString();
                textBox3.Text = row.Cells["nama"].Value.ToString();
                textBox4.Text = row.Cells["email"].Value.ToString();
                textBox5.Text = row.Cells["alamat"].Value.ToString();
                textBox7.Text = row.Cells["notelp"].Value.ToString();
                dateTimePicker1.Text = row.Cells["tgllahir"].Value.ToString();
                comboBox1.Text = row.Cells["id_jabatan"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus pengguna " + textBox3.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("Delete Pegawai where id='"+textBox1.Text+"'", conn);
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (formlayanan == null)
            {
                formlayanan = new layanan();
                formlayanan.FormClosed += new FormClosedEventHandler(formlayanan_FormClosed);
                formlayanan.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formlayanan.Activate();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            cari();
        }
    }
}
