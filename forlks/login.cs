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
    public partial class login : Form
    {
        private SqlCommand cmd;
        private SqlDataReader rd;
        //menuutama formhome;
        koneksi Konn = new koneksi();

        public login()
        {
            InitializeComponent();
        }

        public static string username;
        public static string recby{ 
            get { return username; }
            set { username = value; }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("Select * from pegawai where nama='" + txtUsername.Text + "' and password='" + txtPassword.Text +"' ", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if(rd.HasRows)
            {
                recby = txtUsername.Text;
                this.Hide();
                conn.Close();
                menuutama formhome = new menuutama();
                formhome.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah");
            }
            //pegawai formpegawai = new pegawai();
            //formpegawai.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }


    }
}
