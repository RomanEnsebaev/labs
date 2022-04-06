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
    public partial class zapr2 : Form
    {
        public zapr2()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter daclient;      
        DataTable client = new DataTable();
        BindingSource bsclient = new BindingSource();

        private void zapr2_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "select c_name from client join pact on client.c_id=pact.c_id join apartment on apartment.a_id=pact.a_id where rooms=3";
            daclient = new SqlDataAdapter(com, con);
            daclient.Fill(client);
            ds.Tables.Add(client);

            bsclient.DataSource = client;

            dataGridView1.DataSource = bsclient;
            dataGridView1.Columns[0].HeaderText = "ФИО клиента";
            dataGridView1.Columns[0].Width = 200;
        }
    }
}
