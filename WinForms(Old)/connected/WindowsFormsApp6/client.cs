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
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        bool v = true;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private void client_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel2.Visible = false;
           
                con.ConnectionString = Properties.Settings.Default.con;
                com.Connection = con;
                com.CommandText = "select * from client";
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

                while (rd.Read()) {
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

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Enabled = true;
            dataGridView1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;
            dataGridView1.Enabled = false;

            //label4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label4.Text = "М";
            if (label4.Text == "М")
            {
                radioButton1.Checked = true;
            }
            if (label4.Text == "Ж")
            {
                radioButton2.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Введите ФИО");
                textBox1.Focus();
                return;
            }
            
            
                SqlConnection con = new SqlConnection();
                SqlCommand com = new SqlCommand();
                //строка соединения
                con.ConnectionString = Properties.Settings.Default.con;
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "insert_client";
                com.Parameters.Add("@c_id", SqlDbType.Int);
                com.Parameters["@c_id"].Direction = ParameterDirection.Output;
                com.Parameters.Add("@c_name", SqlDbType.VarChar);
                com.Parameters["@c_name"].Value = textBox1.Text;
                com.Parameters.Add("@c_gender", SqlDbType.VarChar);
            if (radioButton1.Checked)
            {
                label4.Text = "M";           
            }
            if(radioButton2.Checked)
            {
                label4.Text = "Ж";               
            }
            com.Parameters["@c_gender"].Value = label4.Text;
            com.Parameters.Add("@c_birthday", SqlDbType.Date);
            com.Parameters["@c_birthday"].Value = dateTimePicker1.Value.ToString();
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
            dataGridView1.Rows.Add(com.Parameters["@c_id"].Value.ToString(), textBox1.Text,label4.Text,dateTimePicker1.Value.ToString());          
            textBox1.Clear();

            dataGridView1.Enabled = true;
            panel1.Visible = false;
            panel3.Enabled = true;
                   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            v = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label5.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (label5.Text == "М")
            {
                radioButton4.Checked=true;
            }
            if (label5.Text == "Ж")
            {
                radioButton3.Checked = true;
            }
            string dd = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Value = DateTime.Parse(dd);
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Enabled = false;
            dataGridView1.Enabled = false;
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Введите ФИО");
                textBox2.Focus();
                return;
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.con;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            int index = dataGridView1.CurrentRow.Index;
            string sn = dataGridView1.CurrentRow.Cells[0].Value.ToString();
          
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "upd_client";
            com.Parameters.Add("@c_id", SqlDbType.Int);
            com.Parameters.Add("@c_name", SqlDbType.VarChar);
            com.Parameters.Add("@c_gender", SqlDbType.VarChar);
            com.Parameters.Add("@c_birthday", SqlDbType.Date);

            com.Parameters["@c_id"].Value = dataGridView1.CurrentRow.Cells[0].Value;
            com.Parameters["@c_name"].Value = textBox2.Text;
            if (radioButton4.Checked)
            {
                label5.Text = "М";

            }
            if (radioButton3.Checked)
            {
                label5.Text = "Ж";
            }
            com.Parameters["@c_gender"].Value = label5.Text;
            com.Parameters["@c_birthday"].Value = dateTimePicker2.Text.ToString();
            try { con.Open(); }
            catch
            {
                MessageBox.Show("Нет соединения"); Close(); return;
            }
            try { com.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                Close(); con.Close(); return;
            }
            dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[2].Value = label5.Text;
            dataGridView1.CurrentRow.Cells[3].Value = dateTimePicker2.Text.ToString();

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
            label5.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sn = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult mess = MessageBox.Show("Вы действительно хотите удалить все данные о продутке " + sn + "?", " Подтвердите действие", MessageBoxButtons.YesNo);
            if (mess == DialogResult.Yes)
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.con;
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "del_client";
                com.Parameters.Add("@c_id", SqlDbType.Int);
                com.Parameters.Add("@c_name", SqlDbType.VarChar);
                com.Parameters.Add("@c_gender", SqlDbType.VarChar);
                com.Parameters.Add("@c_birthday", SqlDbType.Date);

                com.Parameters["@c_id"].Value = dataGridView1.CurrentRow.Cells[0].Value;
                com.Parameters["@c_name"].Value = dataGridView1.CurrentRow.Cells[1].Value;
                com.Parameters["@c_gender"].Value = dataGridView1.CurrentRow.Cells[2].Value;
                com.Parameters["@c_birthday"].Value = dataGridView1.CurrentRow.Cells[3].Value;

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
    }
    }


