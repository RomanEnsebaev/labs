using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class clientred : Form
    {

        string con;
        public DataTable dt;
        public DataRow row;
        public bool vct;
        public string klold;
        public bool ed;

        public clientred()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void clientred_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            if (vct)
            {
                row = dt.NewRow();
                textBox1.Text = "";
                radioButton1.Checked = true;               
                dateTimePicker1.Value = DateTime.Today;
            }
            else
            {
               

                textBox1.Text = row[1].ToString();
                klold = row[3].ToString().Trim();             
                dateTimePicker1.Value = (DateTime)row[3];
                label4.Text = row[2].ToString();
                if (label4.Text=="М")
                {
                    radioButton1.Checked = true;
                }
                if(label4.Text=="Ж")
                {
                    radioButton2.Checked = true;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не задано ФИО");
                return;
            }
            

            row[1] = textBox1.Text;
            if (radioButton1.Checked)
            {
                row[2] = "М";
            }
            else { row[2] = "Ж"; }
            row[3] = dateTimePicker1.Value;

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
