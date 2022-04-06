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
    public partial class menu : Form
    {
        string con, com;
        public bool ed;

        public menu()
        {
            InitializeComponent();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            clientt v1 = new clientt();
            v1.ds1 = ds1;
            v1.ShowDialog();
            ed = v1.ed;
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                DialogResult res = MessageBox.Show("Сохранить изменения?", "Внимание", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == res)
                {
                    try
                    {                         // записываем  удаленные записи в дочерней таблице в базу 
                        int kol = ds1.pact.Count;
                        DataRow[] rows = new DataRow[kol];
                        int kt = 0;
                        foreach (DataRow r in ds1.pact)
                        {
                            if (r.RowState == DataRowState.Deleted)
                            {
                                rows[kt] = r;
                                kt += 1;
                            }
                        }
                        for (int k = 0; k <= kt; k++)
                        {
                            pactTableAdapter.Update(rows[k]);
                        }                         //записываем в базу изменения любых типов  в родительских таблицах                        
                        clientTableAdapter.Update(ds1.client);
                        employeeTableAdapter.Update(ds1.employee);                         //  записываем добавленные  и измененные записи в дочерней таблице                         
                        apartmentTableAdapter.Update(ds1.apartment);
                        pactTableAdapter.Update(ds1.pact);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else
                {
                    ds1.RejectChanges();
                    ed = false;
                }
                res = MessageBox.Show("Выйти?", "Внимание", MessageBoxButtons.YesNo);
                if (DialogResult.No == res)
                { e.Cancel = true; ed = false; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee v2 = new employee();
            v2.ds1 = ds1;
            v2.ShowDialog();
            ed = v2.ed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            apartment v3 = new apartment();
            v3.ds1 = ds1;
            v3.ShowDialog();
            ed = v3.ed;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pact v4 = new pact();
            v4.ds1 = ds1;
            v4.ShowDialog();
            ed = v4.ed;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zapr1 v5 = new zapr1();
            v5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            zapr2 v6 = new zapr2();
            v6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            zapr3 v7 = new zapr3();
            v7.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            zapr4 v8 = new zapr4();
            v8.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            zapr5 v9 = new zapr5();
            v9.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            zapr6 v9 = new zapr6();
            v9.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {                     
            employeeTableAdapter.Fill(ds1.employee);           
            clientTableAdapter.Fill(ds1.client);        
            apartmentTableAdapter.Fill(ds1.apartment);
            pactTableAdapter.Fill(ds1.pact);
        }


    }
}
