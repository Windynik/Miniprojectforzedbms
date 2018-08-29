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
    public partial class ModifyStock : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
  
        private static ModifyStock _instance;
        public static ModifyStock instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModifyStock();

                }
                return _instance;
            }

        }
        public ModifyStock()
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
        private void refresh()
        {
            comboBox1.Items.Clear();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshprice();
            refreshstock();
        }
        private void refreshstock()
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
                Stock.Text = dr["Stockavail"].ToString();
                
            }
            con.Close();
        }
        private void refreshprice()
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
                Price.Text = dr["Price"].ToString();
                
            }
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();

        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            int price = (int)Price.Value;
            int stock = (int)Stock.Value;
            try {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Stock set Stockavail='" + stock + "'where Stockname='" + comboBox1.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Update ProdInfo set Price='" + price + "'where Name='" + comboBox1.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information Updated!");

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                con.Close();
            }
                
        }
    }
}
