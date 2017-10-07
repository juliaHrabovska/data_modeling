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
            List<String> parameterList = new List<String>();
            parameterList.Add("xBegin");
            parameterList.Add("xEnd");
            parameterList.Add("step");
            parameterList.AddRange(strategy.getParameters());
            TableParameters tableParameters = new TableParameters(parameterList);
            DialogResult dialogResult = tableParameters.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                textBox1.Clear();
                List<double> dots = strategy.generateData(tableParameters.getValueMap());                
                for (int i = 0; i < dots.Count; i += 2)
                {
                    textBox1.Text += String.Format("{0:N2}  {1:N2}", dots[i], dots[i + 1]) + Environment.NewLine;

                }
                
            }
        }
    }
}
