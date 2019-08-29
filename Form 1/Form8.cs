using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form_1
{
    public partial class Form8 : Form
    {
        SqlConnection con = new SqlConnection( "Data Source = DESKTOP-VEVG9RB; Initial Catalog = Khidmat; Integrated Security = True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public Form8()
        {
            InitializeComponent();
            con.Open();

            adpt = new SqlDataAdapter("select * from CashBookDaily order by SerialNumber", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form7 newform = new Form7("INSERT");
            newform.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                

                string a = Convert.ToString(selectedRow.Cells["SerialNumber"].Value);
                MessageBox.Show(a);
                
                cmd = new SqlCommand("Delete From CashBookDaily where SerialNumber = '" + a +"'", con);
               
                DialogResult dialog = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {

                    cmd.ExecuteNonQuery();
                    dataGridView1.DataSource = null;
                    adpt = new SqlDataAdapter("select * from CashBookDaily order by SerialNumber", con);
                    dt = new DataTable();
                    adpt.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {

                }
               
            }

        }
    }
}
