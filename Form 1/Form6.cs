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
    public partial class Form6 : Form
    {

        private String name = "";
        private String Class = "";
        private String GrNo = "";
        private String F_Name = "";
        private String M_Name = "";
        private String Contact = "";
        private String DOB = "";
        private String Address = "";
        private String Attitude = "";
        private String Salary = "";










        public string selected = null;
        private string connectionString = null;
        SqlConnection cnn;
        SqlCommand command = null;
        

        public Form6()
        {

            InitializeComponent();
            DisableAll();
            textBox2.Enabled = false;
            
            AddDataToComboBox();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void AddDataToComboBox()
        {
            connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
            string Sql = "Select Name from Teachers";
            
            cnn.Open();
            command = new SqlCommand(Sql, cnn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0).ToString());
            }
            cnn.Close();
            
        }
        private void DisableAll()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox10.Enabled = false;
            textBox6.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
           
            button7.Enabled = false;
        }
        private void EnableAll()
        {
            textBox1.Enabled = true;
            //textBox2.Enabled = true;
            textBox10.Enabled = true;
            textBox6.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            
            button7.Enabled = true;
            comboBox1.Enabled = true;
            button1.Enabled = true;
        }
        private void EmptyAllTextBoxes()
        {
            textBox10.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";


        }

        public void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            
            if (comboBox1.SelectedItem != null)
            {
                string temp = comboBox1.SelectedItem.ToString();

                connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
                cnn = new SqlConnection(connectionString);
                string Sql = "Select * from Teachers where Name = '" + temp + "' "  ;
                cnn.Open();
                SqlCommand command = new SqlCommand(Sql, cnn);
                Console.WriteLine(Sql);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(0).ToString();
                    GrNo = textBox2.Text;
                    textBox6.Text = reader.GetValue(1).ToString();
                    name = textBox6.Text;
                    textBox10.Text = reader.GetValue(2).ToString();
                    Class = textBox10.Text;
                    textBox3.Text = reader.GetValue(3).ToString();
                    F_Name = textBox3.Text;
                    textBox4.Text = reader.GetValue(6).ToString();
                    M_Name = textBox4.Text;
                    textBox5.Text = reader.GetValue(4).ToString();
                    Contact = textBox5.Text;
                    textBox7.Text = reader.GetValue(5).ToString();
                    DOB = textBox7.Text;
                    textBox8.Text = reader.GetValue(8).ToString();
                    Address = textBox8.Text;
                    textBox9.Text = reader.GetValue(7).ToString();
                    Attitude = textBox9.Text;
                    textBox1.Text = reader.GetValue(9).ToString();
                    Salary = textBox1.Text;

                }

                cnn.Close();
            }
            
            else
            {
                MessageBox.Show("No Name Selected");
            }

        }
        private bool CheckIfChanged()
        {
            if (GrNo == textBox2.Text)
            {
                if (name == textBox6.Text)
                {
                    if (Class == textBox10.Text)
                    {
                        if (F_Name == textBox3.Text)
                        {
                            if (M_Name == textBox4.Text)
                            {
                                if (Contact == textBox5.Text)
                                {
                                    if (DOB == textBox7.Text)
                                    {
                                        if (Address == textBox8.Text)
                                        {
                                            if (Attitude == textBox9.Text)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
            }
            return true;
                
            
            
        }
     

        private void Button4_Click(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
            if (button5.ForeColor == Color.Red)
            {
                button5.ForeColor = Color.Black;
                DisableAll();
            }
            else if (button6.ForeColor == Color.Red)
            {
                button6.ForeColor = Color.Black;
                EmptyAllTextBoxes();
                DisableAll();
                
                
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button7.Text = "Update";
            button5.ForeColor = Color.Red;
            if(button4.ForeColor == Color.Red)
            {
                button4.ForeColor = Color.Black;
                EnableAll();
            }
            else if(button6.ForeColor == Color.Red)
            {
                button6.ForeColor = Color.Black;
                EnableAll();
                EmptyAllTextBoxes();
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int id;
            button7.Text = "Add";
            if(button7.Enabled == false ){ button7.Enabled = true;}
            button6.ForeColor = Color.Red;
            if (button4.ForeColor == Color.Red)
            {
                button4.ForeColor = Color.Black;
                EnableAll();
            }
            else if (button5.ForeColor == Color.Red)
            {
                button5.ForeColor = Color.Black;
            }
            comboBox1.Text = "";
            comboBox1.Enabled = false;
            button1.Enabled = false;
            EmptyAllTextBoxes();
            connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command2 = new SqlCommand("select top 1 ID from Teachers order by ID desc", cnn);

            SqlDataReader sq_reader = command2.ExecuteReader();
            textBox1.Text = "";
            if (sq_reader.Read())
            {
                id = Convert.ToInt32(sq_reader["ID"]);
                id = id + 1;
                textBox2.Text = id.ToString();
            }
            
            sq_reader.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int id;
            if (button6.ForeColor != Color.Red)
            {
                string updateQuery = "UPDATE Teachers Set Name ='" + textBox6.Text + "',FatherName ='" +
                    textBox10.Text + "', Contact ='" + textBox3.Text + "', DOB ='" +
                    textBox5.Text + "',DOJ ='" + textBox4.Text + "' ,Qualification ='" + textBox7.Text + "' ,  ClassTeacherOf='" +
                    textBox9.Text + "' ,Subject ='" + textBox8.Text + "' ,Salary ='" + textBox1.Text + "' WHERE Name = '" + comboBox1.Text + "'";
                MessageBox.Show(updateQuery);
                connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
                cnn = new SqlConnection(connectionString);

                cnn.Open();
                SqlCommand command = new SqlCommand(updateQuery, cnn);
                command.ExecuteNonQuery().ToString();
                cnn.Close();
            }
            else
            {
                if (textBox10.Text != "" && textBox6.Text != "")
                {
                    connectionString = "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    
                    SqlCommand command2 = new SqlCommand("select top 1 ID from Students order by ID desc", cnn);

                    SqlDataReader sq_reader = command2.ExecuteReader();

                    if (sq_reader.Read())
                    {
                       id = Convert.ToInt32(sq_reader["ID"]);
                       id = id + 1;
                       
                    }
/*  6 - name
10 father
id -2
contact -3
DOb -4
DOJ -5
Qualifi - 7
Subject - 8
classteacchr -9
salary -1*/

                    sq_reader.Close();
                    string addQuery = "Insert into Teacher (ID, Name, FatherName, Contact, DOB, Qualification,DOJ,ClassTeacherOf, Subject, Salary) " +
                       "values('" + textBox2.Text + "', '" + textBox6.Text + "', '" + textBox10.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '"
                       + textBox7.Text + "', '"+ textBox4.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "', '" + textBox1.Text + "')";
                     
                    MessageBox.Show(addQuery);
                    SqlCommand command = new SqlCommand(addQuery, cnn);
                    command.ExecuteNonQuery().ToString();
                    
                }
                else
                {
                    MessageBox.Show("The Name and Class field can not be left empty");
                }
            }
        }
        private bool m_isExiting;
        private void Button2_Click(object sender, EventArgs e)
        {
      
             
            this.Close();
            

        }


        private void Form4_Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (button4.ForeColor != Color.Red )
            {
                if (CheckIfChanged())
                {
                    DialogResult dialog = MessageBox.Show("Do you really want to close this, without saving?", "Warning", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (button5.ForeColor == Color.Red)
            {

                if (CheckIfChanged())
                {
                    if (button7.Enabled == false)
                    {
                        button7.Enabled = true;

                    }

                }
                else
                {
                    if (button7.Enabled == true)
                    {
                        button7.Enabled = false;

                    }
                }
            }
           
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            AddDataToComboBox();
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

