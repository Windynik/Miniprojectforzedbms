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
    public partial class ViewStock : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        
        
        private static ViewStock _instance;
        public static ViewStock instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewStock();

                }
                return _instance;
            }

        }
        public ViewStock()
        {
            InitializeComponent();
        }
        public void disp_Stock()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select s.Stockavail,P.Pid,P.Price,P.Name from ProdInfo P,Stock s where P.Name=s.Stockname order by P.Pid";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {
            disp_Stock();
        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            disp_Stock();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
