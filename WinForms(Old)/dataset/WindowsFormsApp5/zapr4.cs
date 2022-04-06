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
    public partial class zapr4 : Form
    {
        public zapr4()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter daapartment;
        DataTable apartment = new DataTable();
        BindingSource bsapart = new BindingSource();

        private void zapr4_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "select top 1 count(pact.a_id), r_space from apartment join pact on apartment.a_id=pact.a_id group by pact.a_id,r_space";
            daapartment = new SqlDataAdapter(com, con);
            daapartment.Fill(apartment);
            ds.Tables.Add(apartment);

            bsapart.DataSource = apartment;

            dataGridView1.DataSource = bsapart;
            dataGridView1.Columns[1].HeaderText = "Space";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].HeaderText = "apart id";
            //  dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

     
    }
}
