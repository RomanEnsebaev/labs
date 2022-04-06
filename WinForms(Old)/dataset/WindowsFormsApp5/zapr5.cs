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
    public partial class zapr5 : Form
    {
        public zapr5()
        {
            InitializeComponent();
        }
        string con, com;
        DataSet ds = new DataSet();
        SqlDataAdapter dapact, daklient;
        DataTable pact= new DataTable();
        DataTable klient = new DataTable();
        BindingSource bspact = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        BindingSource bsklient = new BindingSource();

        private void zapr5_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            com = "select distinct e_name from employee";
            dapact = new SqlDataAdapter(com, con);
            com = "select employee.e_name, pact.p_id, amount, deal_date, adress from employee join pact on pact.e_id=employee.e_id join apartment on apartment.a_id=pact.a_id group by employee.e_name, pact.p_id, amount, deal_date, adress ";

            daklient = new SqlDataAdapter(com, con);//Заполнение таблиц и добавление их в набор данных      
            dapact.Fill(pact);
            ds.Tables.Add(pact);
            daklient.Fill(klient);
            ds.Tables.Add(klient); //Установка связи между таблицами    
            DataRelation dr = new DataRelation("dr", pact.Columns[0], klient.Columns[0]);  //Добавление связей в набор данных             
            ds.Relations.Add(dr); // Привязка таблиц к элементам управления             
            bspact.DataSource = pact;
            bsklient.DataSource = bspact;
            bsklient.DataMember = "dr";

            comboBox1.DataSource = bspact;
            comboBox1.DisplayMember = "e_name";
            dataGridView1.DataSource = bsklient;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Код договора";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Стоимость";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].HeaderText = "Дата договора";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "Адресс";
            dataGridView1.Columns[4].Width = 150;
        }
    }
}
