using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class SupplierMainform : Form
    {
        public static String Suppname = "";
        public SupplierMainform(String user)
        {
            InitializeComponent();
            label2.Text = (user);
            Suppname = label2.Text;
        }

        private void MainformUser_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainformUser_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.CreateStock.instance))
            {
                contentpanel.Controls.Add(UserForms.CreateStock.instance);
                UserForms.CreateStock.instance.Dock = DockStyle.Fill;
                UserForms.CreateStock.instance.BringToFront();
            }
            else
            {
                UserForms.CreateStock.instance.BringToFront();
            }
        }

        private void contentpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!contentpanel.Controls.Contains(UserForms.DeleteStock.instance))
            {
                contentpanel.Controls.Add(UserForms.DeleteStock.instance);
                UserForms.DeleteStock.instance.Dock = DockStyle.Fill;
                UserForms.DeleteStock.instance.BringToFront();
            }
            else
            {
                UserForms.DeleteStock.instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)

        {
            if (!contentpanel.Controls.Contains(UserForms.ModifyStock.instance))
            {
                contentpanel.Controls.Add(UserForms.ModifyStock.instance);
                UserForms.ModifyStock.instance.Dock = DockStyle.Fill;
                UserForms.ModifyStock.instance.BringToFront();
            }
            else
            {
                UserForms.ModifyStock.instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!contentpanel.Controls.Contains(UserForms.ViewOrder.instance))
            {
                contentpanel.Controls.Add(UserForms.ViewOrder.instance);
                UserForms.ViewOrder.instance.Dock = DockStyle.Fill;
                UserForms.ViewOrder.instance.BringToFront();
            }
            else
            {
                UserForms.ViewOrder.instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (!contentpanel.Controls.Contains(UserForms.ViewStock.instance))
            {
                contentpanel.Controls.Add(UserForms.ViewStock.instance);
                UserForms.ViewStock.instance.Dock = DockStyle.Fill;
                UserForms.ViewStock.instance.BringToFront();
            }
            else
            {
                UserForms.ViewStock.instance.BringToFront();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
