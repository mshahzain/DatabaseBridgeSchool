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
        
        SqlConnection cnn;
        private String TypeOfExpense;
        private String connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
        public Form7(String Sno)
        {
            InitializeComponent();
            if( Sno != "INSERT")
            {
                comboBox4.Enabled = false;

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand command2 = new SqlCommand("select * from CashBookDaily where SerialNumber = '" + Sno + "'", cnn);
                SqlDataReader reader = command2.ExecuteReader();
               


            }
            else { }
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
            if (comboBox4.Text == "Groceries") { TypeOfExpense = "Grocery"; }
            else if (comboBox4.Text == "Salary") { TypeOfExpense = "Salary"; }
            else if (comboBox4.Text == "Stationary") { TypeOfExpense = "Staionary"; }
            else if (comboBox4.Text == "Miscellaneous") { TypeOfExpense = " MiscellaneousExpenses"; }
            else if (comboBox4.Text == "Received Cash") { TypeOfExpense = "MoneyReceived"; }
            

            string addQuery = "Insert into CashBookDaily (" + TypeOfExpense+ ", Date, CurrentTrackingMonth,Year,Description, Recipient ) " + "values('" + textBox2.Text + "', '" + comboBox2.Text + "', '" + comboBox1.Text + "', '" + comboBox3.Text + "', '" + richTextBox1.Text + "', '"
              + textBox1.Text + "')";
            SqlCommand com = new SqlCommand(addQuery, cnn);
            MessageBox.Show(com.ExecuteNonQuery().ToString());
            MessageBox.Show("Successfully added.");
            

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

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
