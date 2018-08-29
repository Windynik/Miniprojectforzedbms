using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test1
{
    public partial class Create : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        public static int ilikeprices;
        private static Create _instance;
        public static int whydoidothis;
        public static int omfg;
        public static Create instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new Create();

                }
                return _instance;
            }

        }
        public Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ProdInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private String availabilitycheck()
        {
            
            int Stockused;
            Stockused = (int)numericUpDown1.Value;
            con.Open();
            String syntax = "SELECT Stockavail FROM Stock where Stockname='"+comboBox1.SelectedItem.ToString()+"'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    int data = (int)rdr["Stockavail"];
                    
                    if (data>Stockused)
                    {
                        con.Close();
                        whydoidothis = data;
                        
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

            return("False");
        }

        private void Subbut_Click(object sender, EventArgs e)
        {
           
            submission();
            //int remaining = data - Stockused;
           // return (remaining);
        }
        private void submission()
        {
            String Itemname = comboBox1.SelectedItem.ToString();
            int units = (int)numericUpDown1.Value;
            int total = omfg;
            String reply = availabilitycheck();
            int remaining=0;
            if (reply == "True")
            {
                remaining = remainingstock();
              
            }
            else if(reply=="False")
            {
                MessageBox.Show("There is not enough stock!");
                return;
            }
            if (check(Itemname) == "True")
            {
                MessageBox.Show("Order Already made! If you need to change amount , go to modify!");
            }
            else if (check(Itemname) == "False")
            {
                SqlCommand cmd = new SqlCommand("Createorderproc", con); //insert code here
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pname", Itemname);
                cmd.Parameters.AddWithValue("@Noofitems", units);
                cmd.Parameters.AddWithValue("@Totamt", total);
                cmd.Parameters.AddWithValue("@UserId", MainformUser.Useridvalue);       //Find user id.
                cmd.Parameters.AddWithValue("@Stockavail", remainingstock());


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Inserted");

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
            }
        }
        public int remainingstock()
        {
            
            int Stockused;
            Stockused=(int)numericUpDown1.Value;
            return (whydoidothis - Stockused);
        }
        private String check(String User)
        {
            //Gonna fetch that sweet arse
            con.Open();
            String syntax = "SELECT Pname FROM OrderId";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    String data = rdr["Pname"].ToString();

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
        public void refreshprice()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Price FROM ProdInfo where Name='"+comboBox1.SelectedItem.ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ilikeprices=(int)(dr["Price"]);
            }
            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        public void refreshstocjk()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Stockavail FROM Stock where Stockname='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                label1.Text = dr["Stockavail"].ToString();

            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //ugh
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pricechange();
        }
        private void pricechange()
        {
            int stockvalue=(int)numericUpDown1.Value;
            int pricevalue = ilikeprices;
                                                   //Proper!!
            int total= stockvalue * pricevalue;
            omfg = total;
            Price.Text = total.ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshstocjk();
            refreshprice();
            pricechange();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ProdInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            con.Close();
        }
    }
}
