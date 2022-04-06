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
    public partial class zapr1 : Form
    {
        public zapr1()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter dakom, daadr;
        DataTable komnata= new DataTable();
        DataTable adres = new DataTable();
        BindingSource bskom = new BindingSource();
        BindingSource bsadr = new BindingSource();
        private void zapr1_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "SELECT DISTINCT(rooms) FROM apartment ";
            dakom= new SqlDataAdapter(com, con);
            com = "select adress,rooms from apartment  ";
            daadr = new SqlDataAdapter(com, con);
            daadr.Fill(adres);
            ds.Tables.Add(adres);
            dakom.Fill(komnata);
            ds.Tables.Add(komnata);

            DataRelation dr = new DataRelation("dr", komnata.Columns[0], adres.Columns[1]);

            ds.Relations.Add(dr);
            bskom.DataSource = komnata;
            bsadr.DataSource = bskom;
            bsadr.DataMember = "dr";

            comboBox1.DataSource = bskom;
            comboBox1.DisplayMember = "rooms";
            listBox1.DataSource = bsadr;
            listBox1.DisplayMember = "adress";

        }
        
    }
}
