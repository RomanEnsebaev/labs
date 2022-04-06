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
    public partial class zapr6 : Form
    {
        public zapr6()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter dapact;
        DataTable pact = new DataTable();
        BindingSource bspact = new BindingSource();

        private void zapr6_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "select client.c_name from client join pact on client.c_id=pact.c_id group by c_name";
            dapact = new SqlDataAdapter(com, con);
            dapact.Fill(pact);
            ds.Tables.Add(pact);
            bspact.DataSource = pact;

            dataGridView1.DataSource = bspact;
            dataGridView1.Columns[0].HeaderText = "ФИО клиента";
            dataGridView1.Columns[0].Width = 300;
        }
    }
}
