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
    public partial class Module1 : Form
    {
        private Dictionary<String, DistributionStrategy> map = new Dictionary<String, DistributionStrategy>();

        public Module1()
        {
            InitializeComponent();
            map.Add("Poisson", new PoissonDistributionStrategy());
            map.Add("Cauchy", new CauchyDistributionStrategy());

            foreach (string key in map.Keys)
            {
                comboBox1.Items.Add(key);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DistributionStrategy strategy = map[comboBox1.SelectedItem.ToString()];
            MessageBox.Show(strategy.getParameters()[0]);
        }
    }
}
