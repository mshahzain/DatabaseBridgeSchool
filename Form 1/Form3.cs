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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 newform = new Form4();
            newform.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form6 newform = new Form6();
            newform.Show();
        }
    }
}
