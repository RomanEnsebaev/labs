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
    public partial class pact : Form
    {
        public pact()
        {
            InitializeComponent();
        }
        string con, com;
        public ds ds1 = new ds();
        DataRow row;
        BindingSource bs = new BindingSource();
        public bool ed;
        public DataTable dt;

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pactred r = new pactred();
            r.dt = ds1.pact;
            r.vct = true;
            r.ed = ed;
            r.ShowDialog();
            ed = r.ed;
            int kol = dataGridView1.Rows.Count;
            dataGridView1.DataSource = ds1.pact;
            dataGridView1.CurrentCell = dataGridView1.Rows[kol - 1].Cells[1];
            //dataGridView1.Enabled = false;
            if (dataGridView1.RowCount > 0) { button2.Enabled = true; button3.Enabled = true; } else { button2.Enabled = false; button3.Enabled = false; }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pactred r = new pactred();
            row = ds1.pact.FindByp_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            r.row = row;
            r.dt = ds1.pact;
            r.vct = false;
            r.ShowDialog();
            ed = r.ed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == res)
            {
                row = ds1.pact.FindByp_id((int)dataGridView1.CurrentRow.Cells[0].Value);
                int kod = (int)row[0];
                row.Delete();
                ed = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pact_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            bs.DataSource = ds1.pact;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Дата выдачи";
            dataGridView1.Columns[2].HeaderText = "Стоимость";
            dataGridView1.Columns[4].HeaderText = "Квартира";           
            dataGridView1.Columns[3].HeaderText = "Клиент";
            dataGridView1.Columns[5].HeaderText = "Сотрудник";
            dataGridView1.AutoResizeColumns();
        }
    }
}
