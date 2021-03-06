﻿using System;
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
        private Module1 module1 = new Module1();
        private Module2 module2 = new Module2();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (module1.IsDisposed)
            {
                module1 = new Module1();
            }
            module1.Show();
            module1.BringToFront();
            module1.Activate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (module2.IsDisposed)
            {
                module2 = new Module2();
            }
            module2.Show();
            module2.BringToFront();
            module2.Activate(); 
        }
    }
}
