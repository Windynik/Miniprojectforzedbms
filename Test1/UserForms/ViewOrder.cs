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
    public partial class ViewOrder : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");

        private static ViewOrder _instance;
        public static ViewOrder instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewOrder();

                }
                return _instance;
            }

        }
        public void disp_Stock()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
           
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select o.Oid,o.UserId,u.Name,o.Noofitems,o.Totamt,p.Price,o.Pname from ProdInfo p,OrderId o,UserTable u where p.Name=o.Pname and u.UserID=o.UserId  Order by o.Oid";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public ViewOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {
            disp_Stock();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            disp_Stock();
        }
    }
    
}
