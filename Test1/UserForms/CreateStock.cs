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
    public partial class CreateStock : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|\\App_data\\Database1.mdf\";Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        SqlDataReader Lognrdr;
        private static CreateStock _instance;
        public static CreateStock instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CreateStock();

                }
                return _instance;
            }

        }
        public CreateStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void Subbut_Click(object sender, EventArgs e)
        {
            String name;
            int stock,price;
            name = nament.Text;
            price = (int)Pricent.Value;
            stock = (int)stockent.Value;
            if(stockchecker(name))
            {
                insertstock(name, price, stock);
            }
            
        }
        private bool stockchecker(String name)
        {

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter a Price!");
                return false;
            }
           
            else if (check(name) == "True")
            {
                MessageBox.Show("Item Already Exists! Please change it.");
                return false;

            }
            return true;
        }
        private dynamic getsellerID()
        {
            con.Open();
            String syntax = "SELECT Sid FROM SellerTable where Name='"+SupplierMainform.Suppname+"'";   //This is where we use the SQL commands.
            cmd = new SqlCommand(syntax, con);
            Lognrdr = cmd.ExecuteReader();
            try
            {
                while (Lognrdr.Read())
                {
                    int data = (int)Lognrdr["Sid"];
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
        private String check(String User)
        {
            //Gonna fetch that sweet arse
            con.Open();
            String syntax = "SELECT Name FROM ProdInfo";   //This is where we use the SQL commands.
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
        private void insertstock(String name,int price,int stock)
        {
            String name1 = name;
            int id = getsellerID();
            SqlCommand cmd = new SqlCommand("Createstockproc", con); //insert code here
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Stockavail", stock);
            cmd.Parameters.AddWithValue("@Stockname", name1);
            cmd.Parameters.AddWithValue("@SellerId", id);


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
}
