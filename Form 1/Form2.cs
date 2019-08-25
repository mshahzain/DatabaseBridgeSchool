using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_1
{
    public partial class Form2 : Form
    {
        private String userName = "";
        private String password = "";
        public Form2()
        {
            InitializeComponent();
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == userName)
            {
                if(textBox2.Text == password)
                {
                    MessageBox.Show("Login Successful");

                    Form1 newForm = new Form1();
                   
                    newForm.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password, Login Unsuccessful");
                }
            }
            else
            {
                MessageBox.Show("Wrong username, Login Unsuccessful");
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
