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

namespace Test1
{

    public partial class MainformUser : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        public static string Usernamevalue = "";
        public static int Useridvalue;

        public MainformUser(String user)
        {
            InitializeComponent();
            label2.Text = (user);
            Usernamevalue = label2.Text;
            Useridvalue = gettingid(Usernamevalue);
        }
        public int gettingid(String user)
        {
            con.Open();
            String syntax = "SELECT UserID FROM UserTable where Name='" + Usernamevalue + "'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    int data = (int)rdr["UserID"];
                    return data;

                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            return 1;

        }
        

        private void MainformUser_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainformUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
               "Close the window?",
               "Are you sure?",
               MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
            if (window == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(Create.instance))
            {
                contentpanel.Controls.Add(Create.instance);
                Create.instance.Dock = DockStyle.Fill;
                Create.instance.BringToFront();
            }
            else
            {
                Create.instance.BringToFront();
            }
        }

        private void contentpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.DeleteOrder.instance))
            {
                contentpanel.Controls.Add(UserForms.DeleteOrder.instance);
                UserForms.DeleteOrder.instance.Dock = DockStyle.Fill;
                UserForms.DeleteOrder.instance.BringToFront();
                
            }
            else
            {
                UserForms.DeleteOrder.instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.ModifyOrder.instance))
            {
                contentpanel.Controls.Add(UserForms.ModifyOrder.instance);
                UserForms.ModifyOrder.instance.Dock = DockStyle.Fill;
                UserForms.ModifyOrder.instance.BringToFront();
            }
            else
            {
                UserForms.ModifyOrder.instance.BringToFront();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.ViewOrder.instance))
            {
                contentpanel.Controls.Add(UserForms.ViewOrder.instance);
                UserForms.ViewOrder.instance.Dock = DockStyle.Fill;
                UserForms.ViewOrder.instance.BringToFront();
            }
            else
            {
                UserForms.ViewOrder.instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.ViewStock.instance))
            {
                contentpanel.Controls.Add(UserForms.ViewStock.instance);
                UserForms.ViewStock.instance.Dock = DockStyle.Fill;
                UserForms.ViewStock.instance.BringToFront();
            }
            else
            {
                UserForms.ViewStock.instance.BringToFront();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
