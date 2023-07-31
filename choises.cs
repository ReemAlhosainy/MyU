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

namespace MyU_project
{
    public partial class choises : Form
    {
        private Form activeform;

        SqlConnection con;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=student_db;Integrated Security=True";
        public choises()
        {
            InitializeComponent();
        }
        private void openchildForm(Form childform, object btnsender)
        {

            if (activeform != null)
            {
                activeform.Close();
            }
            
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(childform);
            this.panel4.Tag = childform;
            childform.BringToFront();
            childform.Show();
            label2.Text = childform.Text;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Text = "Hello,Professor  " + Form1.username;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }



        private void button1_Click(object sender, EventArgs e)
        {
            /*Courses c = new Courses();
            c.Show();
            this.Hide();*/
            openchildForm(new Courses(), sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void choises_Load(object sender, EventArgs e)
        {
           // label2.Text = Form1.username;
            con = new SqlConnection(connection);
            con.Open();
            con.ChangeDatabase("Faculty");
            SqlCommand c1 = new SqlCommand("select professor_ID from professor where professor_password = '" + Form1.password + "' and professor_name ='" + Form1.username + "'", con);
            SqlDataReader i = c1.ExecuteReader();
            //label1.Text = i.Read().ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* degrees d = new degrees();
             d.Show();
             this.Hide();*/
            openchildForm(new degrees(), sender);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openchildForm(new Professor_Info(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
