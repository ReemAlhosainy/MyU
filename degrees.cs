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
    public partial class degrees : Form
    {
        bool b = true;
        DataSet ds;
        public static int id;
        SqlDataAdapter da;
        SqlConnection con;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=student_db;Integrated Security=True";
        public degrees()
        {
            InitializeComponent();
        }

        private void degrees_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connection);
            con.Open();
            con.ChangeDatabase("Faculty");
            string query = "select distinct student_name,student_ID,grade from student  ";

            SqlCommandBuilder y = new SqlCommandBuilder(da);

            da = new SqlDataAdapter(query, con);
            //  MessageBox.Show(da.ToString());

            ds = new DataSet();
            da.Fill(ds, "degrees");
            dataGridView1.DataSource = ds.Tables["degrees"];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = int.Parse(textBox1. Text);
            con.Open();
            con.ChangeDatabase("Faculty");
            string query = "select degrees.course_id,course_name,degree from degrees,student,course_details where degrees.student_ID=student.student_ID and course_details.course_id=degrees.course_id and student.student_ID='" + id+"'";
            SqlCommandBuilder y = new SqlCommandBuilder(da);

            da = new SqlDataAdapter(query, con);
            //  MessageBox.Show(da.ToString());

            ds = new DataSet();
            da.Fill(ds, "degrees");
            dataGridView1.DataSource = ds.Tables["degrees"];
            SqlCommand s = new SqlCommand("select student_name from student where student_id ='" + id + "'", con);
            SqlCommandBuilder yy = new SqlCommandBuilder(da);

            //  MessageBox.Show(da.ToString());

            ds = new DataSet();
            da.Fill(ds, "student");
            SqlDataReader i = s.ExecuteReader();
            if (i.Read())
            {
                label3.Text = i[0].ToString();
            }
            con.Close();
            b = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            con.ChangeDatabase("Faculty");
            SqlCommand dc = new SqlCommand("delete from student where student_id ='" + int.Parse(textBox1.Text) + "'", con);
            dc.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds, "student");
            dataGridView1.DataSource = ds.Tables["student"];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            choises c = new choises();
            c.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(!b)
            {
                int count = dataGridView1.Rows.Count;
                int[] degre = new int[count]; con.Open(); con.ChangeDatabase("Faculty");

                for (int i = 0; i < count - 1; i++)
                {
                    degre[i] = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    try
                    {
                        int co_id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        //    int st_id = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());

                        SqlCommand c = new SqlCommand("update degrees set degree = '" + degre[i] + "'where student_ID='" + id + "'and course_id ='" + co_id + "'", con);
                        c.ExecuteNonQuery();
                    }
                    catch (Exception ee) { MessageBox.Show(ee.ToString()); }
                }

                con.Close();
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
              con.ChangeDatabase("Faculty");
            int count = dataGridView1.Rows.Count;
            int id22 =int.Parse( dataGridView1.Rows[count-2].Cells[1].Value.ToString()) ;
            string name22 = (dataGridView1.Rows[count-2].Cells[0].Value.ToString());
            int grade22 =int.Parse( dataGridView1.Rows[count-2].Cells[2].Value.ToString());

          
                SqlCommand cmd22 = new SqlCommand("insert into student(student_name , student_id , grade) values('" + name22 + "' , '" + id22 + "' , '" + grade22 + "')", con);
                  cmd22.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("insert into degrees(student_id) values('" + id22 +"')", con);
            cmd2.ExecuteNonQuery();
          

            con.Close();
        }
    }
}
