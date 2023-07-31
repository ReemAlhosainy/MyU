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
    public partial class Courses : Form

    {
        public int id;
        public string name;
        public int grad;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=student_db;Integrated Security=True";
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        public Courses()
        {
            InitializeComponent();
        }
        public void shownow()
        {
            SqlCommand c = new SqlCommand("select * from course_details", con);
            c.ExecuteNonQuery();
            da = new SqlDataAdapter(c);
            SqlCommandBuilder sb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void Courses_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connection);
            con.Open();

            try
            {

                con.ChangeDatabase("Faculty");
                SqlCommand cm1 = new SqlCommand("create table course_details([course_id][int ]primary key,[course_name][varchar](50),[grade][int])", con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("course_details table is created successfully .");
            }
            catch (SqlException ex)
            {
               // MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            int grad = int.Parse(comboBox1.SelectedItem.ToString());

            try
            {
                con.Open();
                con.ChangeDatabase("Faculty");
                SqlCommand c = new SqlCommand("insert into course_details(course_id,course_name,grade) values ('" + id + "','" + name + "','" + grad + "')", con);
                c.ExecuteNonQuery();

                MessageBox.Show("new course is added successfully .");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("no course  added .....\n" + ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)//editt
        {
           
            if (textBox1.Text != "")
            {
                id = int.Parse(textBox1.Text);
                name = textBox2.Text;
                grad = int.Parse(comboBox1.SelectedItem.ToString());
            }
            else
            {

                id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                grad = (int)dataGridView1.SelectedRows[0].Cells[2].Value;


            }


            try
            {

                con.Open();
                con.ChangeDatabase("Faculty");


                SqlCommand sq = new SqlCommand("UPDATE course_details set course_name ='" + name + "',grade ='" + grad + "' where course_id =" + id, con);
                sq.ExecuteNonQuery();


                MessageBox.Show("successfully updated .");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("updation failed....\n" + ex.Message);
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);


            try
            {
                con.Open();
                con.ChangeDatabase("Faculty");
                SqlCommand c = new SqlCommand("delete from course_details where course_id= " + id, con);
                c.ExecuteNonQuery();
                shownow();
                MessageBox.Show("course is deleted successfully .");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("no course is  deleted .....\n" + ex.Message);
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                con.ChangeDatabase("Faculty");
                SqlCommand c = new SqlCommand("select * from course_details", con);
                c.ExecuteNonQuery();
                da = new SqlDataAdapter(c);
                if (da != null)
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    ds = new DataSet();
                    da.Fill(ds, "course_details");
                }

            }
            catch
            {
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            choises formm = new choises();
            formm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
