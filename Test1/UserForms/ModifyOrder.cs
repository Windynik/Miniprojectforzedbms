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

namespace Test1.UserForms
{
    public partial class ModifyOrder : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        public static int ilikeprices;
        public static int total;
        public static int whydoidothis;

        private static ModifyOrder _instance;
        public static ModifyOrder instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModifyOrder();

                }
                return _instance;
            }

        }
        
        public ModifyOrder()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {

            refresh();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            refreshprice();
            changetotprice();
        }

       
        private void refresh()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM OrderId";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Pname"].ToString());
            }
            con.Close();
        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            string result = availabilitycheck();
            if(result=="True")
            {
                submit();
            }
            else if(result=="False")
            {
                MessageBox.Show("There is no stock!!");
            }

        }
        private void submit()
        {
            int units = (int)Stocknew.Value;
        string Itemname = comboBox1.SelectedItem.ToString();
        SqlCommand cmd = new SqlCommand("Modifyorderproc", con); //insert code here
        cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Pname", Itemname);
            cmd.Parameters.AddWithValue("@Noofitems", units);
            cmd.Parameters.AddWithValue("@Totamt", total);
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

        private void Stocknew_ValueChanged(object sender, EventArgs e)
        {
            refreshprice();
            changetotprice();

        }
        public void refreshprice()
        {
             con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Price FROM ProdInfo where Name='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ilikeprices = (int)(dr["Price"]);
                
            }
            con.Close();
        }

        public void changetotprice()
        {
            
            total = ilikeprices * (int)Stocknew.Value;
            
            
            Price.Text = total.ToString();
        }
        public int remainingstock()
        {

            int Stockused;
            Stockused = (int)Stocknew.Value;
            return (whydoidothis - Stockused);
        }
        private String availabilitycheck()
        {

            int Stockused;
            Stockused = (int)Stocknew.Value;
            con.Open();
            String syntax = "SELECT Stockavail FROM Stock where Stockname='" + comboBox1.SelectedItem.ToString() + "'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    int data = (int)rdr["Stockavail"];

                    if (data > Stockused)
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

            return ("False");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
