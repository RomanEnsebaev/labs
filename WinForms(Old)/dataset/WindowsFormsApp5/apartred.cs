using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class apartred : Form
    {
        public apartred()
        {
            InitializeComponent();
        }
        string con;
        public DataTable dt;
        public DataRow row;
        public bool vct;
        public string klold;
        public bool ed;

        private void apartred_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            if (vct)
            {
                row = dt.NewRow();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {

                textBox1.Text = row[1].ToString();
                textBox2.Text = row[2].ToString();
                textBox3.Text = row[3].ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не задан адрес");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Не задано количество комнат");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Не задана квадратура");
                return;
            }

            row[1] = textBox1.Text;
            row[2] = textBox2.Text;
            row[3] = textBox3.Text;
            try
            {
                if (vct) dt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
