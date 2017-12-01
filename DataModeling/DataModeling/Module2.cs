using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    public partial class Module2 : Form
    {

        private List<double> dots = new List<double>();

        public Module2()
        {
            InitializeComponent();
        }

       
        /**
         * Reading from file. Double values should be separated by ","(comma)
         */
        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "(*.csv, *.txt)|*.csv;*.txt";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var lines = File.ReadAllLines(openFileDialog1.FileName);

                    for (int i = 1; i < lines.Length; i++)
                    {
                        var values = lines[i].Split(';');

                        for (int j = 0; j < values.Length; j++)
                        {
                            dots.Add(double.Parse(values[j]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
