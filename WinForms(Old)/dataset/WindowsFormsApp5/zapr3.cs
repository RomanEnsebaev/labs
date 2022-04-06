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
    public partial class zapr3 : Form
    {
        public zapr3()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter daklient;
        DataTable klient = new DataTable();
        BindingSource bsklient = new BindingSource();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value) button1.Enabled = false; else button1.Enabled = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value) button1.Enabled = false; else button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bsklient.Filter = "deal_date>="  + dateTimePicker1.Value.ToString();
            //bsklient.Filter = "deal_date<="  + dateTimePicker1.Value.ToString();
            bsklient.Filter = "deal_date>=" + "\'" + dateTimePicker1.Value.ToString()+"\'";
            bsklient.Filter = "deal_date<=" + "\'" + dateTimePicker2.Value.ToString() + "\'";
            dataGridView1.Refresh();
        }

        private void zapr3_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "select deal_date,client.c_name from pact join client on client.c_id=pact.c_id order by client.c_name,deal_date";
            daklient = new SqlDataAdapter(com, con);//Заполнение таблиц и добавление их в набор данных      
            daklient.Fill(klient);
            ds.Tables.Add(klient);
            bsklient.DataSource = klient;            
            dataGridView1.DataSource = bsklient;
            dataGridView1.Columns[1].HeaderText = "ФИО клиента";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
