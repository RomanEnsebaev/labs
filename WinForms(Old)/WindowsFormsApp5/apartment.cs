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
    public partial class apartment : Form
    {
        public apartment()
        {
            InitializeComponent();
        }
        string con;
        public ds ds1 = new ds();
        DataRow row;
        BindingSource bs = new BindingSource();
        public bool ed;

        private void apartment_Load(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.con;
            bs.DataSource = ds1.apartment;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Адрес";
            dataGridView1.Columns[2].HeaderText = "Кол. комнат";
            dataGridView1.Columns[3].HeaderText = "Квадратура";
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            apartred r = new apartred();
            r.dt = ds1.apartment;
            r.vct = true;
            r.ed = ed;
            r.ShowDialog();
            ed = r.ed;
            int kol = dataGridView1.Rows.Count;
            dataGridView1.DataSource = ds1.apartment;
            dataGridView1.CurrentCell = dataGridView1.Rows[kol - 1].Cells[1];
            // dataGridView1.Enabled = false;
            if (dataGridView1.RowCount > 0) { button2.Enabled = true; button3.Enabled = true; } else { button2.Enabled = false; button3.Enabled = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            apartred r = new apartred();
            row = ds1.apartment.FindBya_id((int)dataGridView1.CurrentRow.Cells[0].Value);
            r.row = row;
            r.dt = ds1.apartment;
            r.vct = false;
            r.ShowDialog();
            ed = r.ed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == res)
            {
                row = ds1.apartment.FindBya_id((int)dataGridView1.CurrentRow.Cells[0].Value);
                int kod = (int)row[0];
                if (ds1.pact.Select("a_id=" + kod).Count() == 0)
                {
                    row.Delete();
                    ed = true;
                }
                else
                {
                    MessageBox.Show("Квартира еще учавствует в сделке");
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
