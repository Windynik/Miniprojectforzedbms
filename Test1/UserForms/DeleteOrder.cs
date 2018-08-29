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
    public partial class DeleteOrder : UserControl
    {
        public static int kek;
        public static int kek2;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader rdr;

        private static DeleteOrder _instance;
        public static DeleteOrder instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeleteOrder();

                }
                return _instance;
            }

        }
        public DeleteOrder()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void refresh()
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();
        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            String del = comboBox1.SelectedItem.ToString();
            addition(del);
            deletion(del);

        }
        private void deletion(string del)
        {
            try
            {
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from OrderId where Pname='" + del + "'";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                refresh();
                MessageBox.Show("Deleted Successfully");
            }
        }
        private void addition(string dele)
        {
            con.Open();
            String syntax = "SELECT Noofitems FROM OrderId where Pname='"+dele+"'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    kek = (int)rdr["Noofitems"];
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                
                con.Close();
            }

            con.Open();
            String syntaxs = "SELECT Stockavail FROM Stock where Stockname='" + dele + "'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntaxs, con);
            rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    kek2 = (int)rdr["Stockavail"];
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {

                con.Close();
            }
            int lel = kek + kek2;
            
            try
            { 
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Stock set Stockavail='" + lel + "' where Stockname='" + dele + "'";   //This is where we use the SQL commands.
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {

                con.Close();
            }
        }
    }
}
