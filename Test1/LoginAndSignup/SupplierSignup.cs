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
    public partial class SupplierSignup : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader Lognrdr;
        public SupplierSignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 88, 44, 55);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SupplierSignup_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Subbut_Click(object sender, EventArgs e)
        {
            String user = Userent.Text.ToString();
            String password = Passent.Text.ToString();
            String Add = Address.Text.ToString();
            String phno = Phoneno.Text.ToString();
            if (usernamepasschecker(user, password))
            {


                SqlCommand cmd = new SqlCommand("Suppreg", con); //insert code here
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Address", Add);
                cmd.Parameters.AddWithValue("@PhoneNumber", phno);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {

                    MessageBox.Show("There is an error : " + ex);
                    this.Controls.Clear();
                }
                finally
                {
                    con.Close();
                }

                var window = MessageBox.Show(
                "Registration complete! Go to login?",
               "Congratulations!",
               MessageBoxButtons.YesNo);
                if (window == DialogResult.Yes)
                {
                    Form1 lol = new Form1();
                    lol.Show();
                    this.Hide();

                }
                else if (window == DialogResult.No)
                {
                    System.Environment.Exit(1);
                }
            }

        }
        private bool usernamepasschecker(String user, String pass)
        {

            if (String.IsNullOrWhiteSpace(user))
            {
                MessageBox.Show("Enter a user name!");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Enter a Password!");
                return false;
            }
            else if (checkuser(user) == "True")
            {
                MessageBox.Show("Username Exists! Please change it.");
                return false;

            }
            return true;
        }



        private String checkuser(String User)
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

        private void Backbutton_Click(object sender, EventArgs e)
        {
            SupplierLogin lol = new SupplierLogin();
            lol.Show();
            this.Hide();


        }
    }
}
