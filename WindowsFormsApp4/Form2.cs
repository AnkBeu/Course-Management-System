using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UName.Font = new Font("Arial", 12, FontStyle.Regular); // Change the font name and size as needed
            Password.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UName.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("MISSING INFORMATION!");
            }
            else if (UName.Text == "Admin" && Password.Text == "Password")
            {
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter the correct information!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            UName.Text = " ";
            Password.Text = " ";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
