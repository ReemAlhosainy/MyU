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
    public partial class student : Form
    {


        DataSet ds;
        SqlDataAdapter da2;
        SqlDataAdapter da;
        SqlConnection con;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=student_db;Integrated Security=True";

        public student()
        {
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connection);
            con.Open();
            con.ChangeDatabase("Faculty");
            string query = "select student_name , student_id , grade from student where student_password= '" + Form1.password + "'";
            SqlCommandBuilder yy = new SqlCommandBuilder(da);
            da = new SqlDataAdapter(query, con);
            label4.Text = "Hello " + Form1.username;
            label5.Text = "Student Info";
           

            ds = new DataSet();
            da.Fill(ds, "student");
            SqlDataReader i = new SqlCommand(query,con).ExecuteReader();
            if (i.Read())
            {
                Id.Text = i[1].ToString();
                grade.Text = i[2].ToString();
                name.Text = i[0].ToString();
            }
            con.Close();
            con.Open();
            con.ChangeDatabase("Faculty");
            string query2 = "select degrees.course_id,course_name,degree from degrees,student,course_details where degrees.student_ID=student.student_ID and course_details.course_id=degrees.course_id and student.student_ID='" + int.Parse(Id.Text) + "'";
            SqlCommandBuilder y = new SqlCommandBuilder(da2);

            da2 = new SqlDataAdapter(query2, con);
            //  MessageBox.Show(da.ToString());

           // ds = new DataSet();
            da2.Fill(ds, "degrees");
            dataGridView1.DataSource = ds.Tables["degrees"];

            con.Close();
        
        }

        private void Id_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
