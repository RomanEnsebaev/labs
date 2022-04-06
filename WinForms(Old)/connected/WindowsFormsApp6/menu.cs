using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            client v1 = new client();
            v1.ShowDialog();
        }

        private void menu_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee v2 = new employee();
            v2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            apartment v3 = new apartment();
            v3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pact v4 = new Pact();
            v4.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            zapr1 v5 = new zapr1();
            v5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }
        private void button7_Click(object sender, EventArgs e)
        {
           
        }
        private void button8_Click(object sender, EventArgs e)
        {
          
        }
        private void button9_Click(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {
            
        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            zapr2 v6 = new zapr2();
            v6.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            zapr3cs v7 = new zapr3cs();
            v7.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            zapr4 v8 = new zapr4();
            v8.ShowDialog();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
                zapr5 v9 = new zapr5();
                v9.ShowDialog();
            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            zapr6 v9 = new zapr6();
            v9.ShowDialog();
        }
    }
}
