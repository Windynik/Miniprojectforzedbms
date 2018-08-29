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
    public partial class SupplierLogin : Form
    {
        public SupplierLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader Lognrdr;

        private String getUserName(String User)
        {
            //Gonna fetch that sweet arse
            con.Open();
            String syntax = "SELECT Name FROM SellerTable";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            Lognrdr = cmd.ExecuteReader();
            try
            {
                while (Lognrdr.Read())
                {
                    String data = Lognrdr["Name"].ToString();

                    if (data.Equals(User))
                    {
                        con.Close();
                        return ("True");
                    }
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

            return ("False");
        }
        private String getPassWord(String pass)
        {
            //Gonna fetch that sweet arse
            con.Open();
            String syntax = "SELECT Password FROM SellerTable";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            Lognrdr = cmd.ExecuteReader();
            try
            {
                while (Lognrdr.Read())
                {
                    String data = Lognrdr["Password"].ToString();

                    if (data.Equals(pass))
                    {
                        con.Close();
                        return ("True");
                    }
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

            return ("False");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = Userent.Text;
            pass = Passent.Text;
            if (getUserName(user).Equals("True") && getPassWord(pass).Equals("True"))
            {
                SupplierMainform main = new SupplierMainform(user);
                main.Show();
                this.Hide();
            }
            else
            {
                label4.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Userent_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Passent_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lol = new Form1();
            lol.Show();
            this.Hide();
        }

        private void SupplierLogin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {
            SupplierSignup lol = new SupplierSignup();
            lol.Show();
            this.Hide();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            UserSignup lol = new UserSignup();
            lol.Show();
            this.Hide();

        }
    }
}
