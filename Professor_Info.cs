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

namespace MyU_project
{
    public partial class Professor_Info : Form
    {
        SqlConnection con;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=Faculty;Integrated Security=True";

        public Professor_Info()
        {
            InitializeComponent();
        }
       

        private void Professor_Info_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connection);
            con.Open();
            try
            {

                con.ChangeDatabase("Faculty");
                SqlCommand sq = new SqlCommand("select professor_ID, professor_name, professor_password from professor where professor_name=@professor_name ", con);
                sq.Parameters.AddWithValue("professor_name", Form1.username);
                SqlDataReader re = sq.ExecuteReader();
                if (re.Read())
                {

                    label1.Text = re["professor_ID"].ToString();
                    label2.Text = re["professor_name"].ToString();
                    label3.Text = re["professor_password"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
