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

namespace WindowsFormsApp6
{
    public partial class apartment : Form
    {
        public apartment()
        {
            InitializeComponent();
        }
        bool v = true;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        private void apartment_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

            con.ConnectionString = Properties.Settings.Default.con;
            com.Connection = con;
            com.CommandText = "select * from apartment";
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("Нет соединения");
                Close();
                return;
            }
            SqlDataReader rd = com.ExecuteReader();

            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0], rd[1], rd[2], rd[3].ToString());
            }

            rd.Close();
            con.Close();

            if (dataGridView1.Rows.Count == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;
            dataGridView1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            v = false;
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sn = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult mess = MessageBox.Show("Вы действительно хотите удалить все данные о продутке " + sn + "?", " Подтвердите действие", MessageBoxButtons.YesNo);
            if (mess == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection();
                SqlCommand com = new SqlCommand();
                con.ConnectionString = Properties.Settings.Default.con;               
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "del_apartment";
                com.Parameters.Add("@a_id", SqlDbType.Int);
                com.Parameters.Add("@adress", SqlDbType.VarChar);
                com.Parameters.Add("@rooms", SqlDbType.VarChar);
                com.Parameters.Add("@r_space", SqlDbType.VarChar);

                com.Parameters["@a_id"].Value = dataGridView1.CurrentRow.Cells[0].Value;
                com.Parameters["@adress"].Value = dataGridView1.CurrentRow.Cells[1].Value;
                com.Parameters["@rooms"].Value = dataGridView1.CurrentRow.Cells[2].Value;
                com.Parameters["@r_space"].Value = dataGridView1.CurrentRow.Cells[3].Value;

                try { con.Open(); }
                catch
                {
                    MessageBox.Show("Нет соединения"); Close(); return;
                }
                try { com.ExecuteNonQuery(); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close(); con.Close(); return;
                }
                con.Close();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Введите aдресс");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Введите количество комнат");
                textBox1.Focus();
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Введите квадратуру");
                textBox1.Focus();
                return;
            }

            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con.ConnectionString = Properties.Settings.Default.con;
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "insert_apartment";
            com.Parameters.Add("@a_id", SqlDbType.Int);
            com.Parameters.Add("@adress", SqlDbType.VarChar);
            com.Parameters.Add("@rooms", SqlDbType.VarChar);
            com.Parameters.Add("@r_space", SqlDbType.VarChar);

            com.Parameters["@a_id"].Direction = ParameterDirection.Output;
            com.Parameters["@adress"].Value = textBox1.Text;
            com.Parameters["@rooms"].Value = textBox2.Text;
            com.Parameters["@r_space"].Value = textBox3.Text;
            try { con.Open(); }
            catch
            {
                MessageBox.Show("Нет соединения"); Close(); return;
            }
            try { com.ExecuteNonQuery(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close(); con.Close(); return;
            }
            con.Close();
            dataGridView1.Rows.Add(com.Parameters["@a_id"].Value.ToString(), textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.Enabled = true;
            panel1.Visible = false;
            panel3.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Введите aдресс");
                textBox1.Focus();
                return;
            }
            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Введите количество комнат");
                textBox1.Focus();
                return;
            }
            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Введите квадратуру");
                textBox1.Focus();
                return;
            }
            int index = dataGridView1.CurrentRow.Index;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.con;
            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "upd_apartment";
            com.Parameters.Add("@a_id", SqlDbType.Int);
            com.Parameters.Add("@adress", SqlDbType.VarChar);
            com.Parameters.Add("@rooms", SqlDbType.VarChar);
            com.Parameters.Add("@r_space", SqlDbType.VarChar);

            com.Parameters["@a_id"].Value = dataGridView1.CurrentRow.Cells[0].Value;
            com.Parameters["@adress"].Value = dataGridView1.CurrentRow.Cells[1].Value;
            com.Parameters["@rooms"].Value = dataGridView1.CurrentRow.Cells[2].Value;
            com.Parameters["@r_space"].Value = dataGridView1.CurrentRow.Cells[3].Value;

            try { con.Open(); }
            catch
            {
                MessageBox.Show("Нет соединения"); Close(); return;
            }
            try
            {
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close(); con.Close(); return;
            }
            dataGridView1.CurrentRow.Cells[1].Value = textBox4.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox5.Text;
            dataGridView1.CurrentRow.Cells[3].Value = textBox6.Text;

            panel2.Visible = false;
            panel3.Enabled = true;
            dataGridView1.Enabled = true;
            dataGridView1.CurrentCell = dataGridView1[0, index];
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            panel2.Visible = false;
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            dataGridView1.Enabled = true;
        }
    }
}
