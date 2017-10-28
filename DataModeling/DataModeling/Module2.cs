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

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Read from file",
            "Read from DB"});
            this.comboBox1.Location = new System.Drawing.Point(33, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Module2
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Module2";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "(*.csv, *.txt)|*.csv;*.txt";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var lines = File.ReadAllLines(openFileDialog1.FileName);

                    for (int i = 0; i < lines.Length; i++)
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
