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
    public partial class Form1 : Form
    {
        public static string username = "";
        public static string password = "";

        SqlConnection con;
        string connection = "Data Source=REEM-AHMAD;Initial Catalog=student_db;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            con.ChangeDatabase("Faculty");
            username = textBox1.Text;
            password = textBox2.Text;
            string option = comboBox1.SelectedItem.ToString();
            if (option == "Professor")
            {
                SqlCommand cmd2 = new SqlCommand("select* from professor where professor_name ='" + username + "'and professor_password='" + password + "'", con);
                SqlDataReader r = cmd2.ExecuteReader();
                if (r.Read())
                {
                    choises f = new choises();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sorry The username or password is invalid");
                }
            }
            else if (option == "Student")
            {
                SqlCommand cmd2 = new SqlCommand("select* from student where student_name ='" + username + "'and student_password='" + password + "'", con);
                SqlDataReader r = cmd2.ExecuteReader();
                if (r.Read())
                {
                    student form3 = new student();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sorry The username or password is invalid");
                }
            }

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connection);
            con.Open();

            try
            {
                SqlCommand cmd1 = new SqlCommand("Create database Faculty", con);
                cmd1.ExecuteNonQuery();
            }
            catch { }
            con.ChangeDatabase("Faculty");
            try
            {
                SqlCommand cmd1 = new SqlCommand("create table student([student_ID][int ]primary key,[student_name][varchar](50),[student_password][varchar](100))", con);
                cmd1.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SqlCommand cmd1 = new SqlCommand("create table professor([professor_ID][int ] primary key,[professor_name][varchar](50),[professor_password][varchar](100))", con);
                cmd1.ExecuteNonQuery();
            }
            catch { }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
