using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    public partial class Form1 : Form
    {
        private Module1 module1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(module1 == null)
            {
                module1 = new Module1();
                module1.Show();
            }
            else
            {
                module1.Focus();
            }
            
        }
    }
}
