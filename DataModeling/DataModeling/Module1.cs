using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataModeling
{
    public partial class Module1 : Form
    {
        private Dictionary<String, DistributionStrategy> map = new Dictionary<String, DistributionStrategy>();
        private List<double> dots;

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
            parameterList.Add("Dots number");
            parameterList.Add("deviation");            
            parameterList.AddRange(strategy.getParameters());
            TableParameters tableParameters = new TableParameters(parameterList);
            DialogResult dialogResult = tableParameters.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                textBox1.Clear();
                tableParameters.getValueMap().Add("step", getStep(tableParameters.getValueMap()));
                dots = strategy.generateData(tableParameters.getValueMap());                
                for (int i = 0; i < dots.Count; i += 2)
                {
                    //Времменный вывод точек (Здесь должен быть вывод на график)
                    textBox1.Text += String.Format("{0:N5}  {1:N5}", dots[i], dots[i + 1]) + Environment.NewLine;
                }
                button2.Enabled = true;
            }
        }

        private double getStep(Dictionary<String, double> parameters)
        {
            double xBegin = parameters["xBegin"];
            double dots = parameters["Dots number"];
            double xEnd = parameters["xEnd"];

            return (xEnd - xBegin) / dots;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Запись данных в файл. Данные уже сохранeны в dots
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "*.txt";
            sfd.Filter = "txt files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.Write(textBox1.Text);

                sw.Close();
                fileStream.Close();
            }
             
        }
    }
}
