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

namespace Form_1
{
    public partial class Form7 : Form
    {
        public String connectionString;
        SqlConnection cnn;
        public Form7()
        {
            InitializeComponent();
            comboBox1.Text = "January";
            comboBox2.Text = "1";
            comboBox3.Text = "2019";
            comboBox4.Text = "Groceries";

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int id;
            connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command2 = new SqlCommand("select top 1 SerialNumber from CashBookDaily order by SerialNumber desc", cnn);

            SqlDataReader sq_reader = command2.ExecuteReader();

            if (sq_reader.Read())
            {
                id = Convert.ToInt32(sq_reader["SerialNumber"]);
                id = id + 1;

            }


            sq_reader.Close();
            string addQuery = "Insert into CashBookDaily (SerialNumber, Date, CurrentTrackingMonth,Year,Description, Recipient ) " +
               "values('" id.ToString() + "', '" +comboBox2.Text + "', '" + comboBox1.Text + "', '" +comboBox3.Text + "', '" + richTextBox1.Text + "', '"
               + textBox1 + "', '" + textBox4.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "', '" + textBox1.Text + "')";

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
