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
    public partial class pactred : Form
    {
        public pactred()
        {
            InitializeComponent();
        }
        string con, com;
        public DataTable dt;
        public DataRow row;
        public bool vct;
        public string vdold;
        public bool ed;

        private void apartmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.apartmentBindingSource.EndEdit();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не задана стоимость");
                return;
            }
            row[1] = dateTimePicker1.Value.ToString();
            row[2] = textBox1.Text;
            row[4] = comboBox1.SelectedValue;
            row[3] = comboBox2.SelectedValue;
            row[5] = comboBox3.SelectedValue;
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

        private void pactred_Load(object sender, EventArgs e)
        {
           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds1.employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.ds1.employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds1.client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.ds1.client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds1.apartment". При необходимости она может быть перемещена или удалена.
            this.apartmentTableAdapter.Fill(this.ds1.apartment);
            if (vct)
            {
                row = dt.NewRow();
                textBox1.Text = "";
                comboBox1.SelectedIndex = 0;   //  установка на первую строку  
                comboBox2.SelectedIndex = 0;   //  установка на первую строку 
                comboBox3.SelectedIndex = 0;

                

                dateTimePicker1.Value = DateTime.Today;
            }
            else
            {
                dateTimePicker1.Value = (DateTime)row[1];
                textBox1.Text = row[2].ToString();
                vdold = row[0].ToString().Trim();
                comboBox1.Text = row[4].ToString();
                comboBox2.Text = row[3].ToString();              
                comboBox3.Text = row[5].ToString();
            }
        }
    }
}
