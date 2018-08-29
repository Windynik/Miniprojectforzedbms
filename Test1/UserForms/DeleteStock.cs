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
    public partial class DeleteStock : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        private static DeleteStock _instance;
        public static DeleteStock instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeleteStock();

                }
                return _instance;
            }

        }
        public DeleteStock()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();

        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            try
            {
                String del = comboBox1.SelectedItem.ToString();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from ProdInfo where Name='" + del+ "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from Stock where Stockname='" + del + "'";
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
    }
}
