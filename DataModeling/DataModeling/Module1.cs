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
using System.Windows.Forms.DataVisualization.Charting;

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
            parameterList.AddRange(strategy.getParameters());
            TableParameters tableParameters = new TableParameters(parameterList, strategy);
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
                showChartPoints();
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
            sfd.FileName = "*.csv";
            sfd.Filter = "csv files (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.Write(buidOutputText());

                sw.Close();
                fileStream.Close();
            }
             
        }

        private string buidOutputText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(comboBox1.SelectedItem.ToString()).Append(";");
            sb.Append(DateTime.Today).Append(";");
            sb.Append(Environment.UserName).Append(Environment.NewLine);
            bool flag = false;
            foreach (double d in dots)
            {
                sb.Append(d);
                if (flag)
                {
                    sb.Append(Environment.NewLine);
                } else
                {
                    sb.Append(";");
                }
                flag = !flag;
            }

            return sb.ToString();
        }


        public void showChartPoints()
        {
            chartPoints.Series.Clear();
            ChartDraw.showChart(dots, "Points", SeriesChartType.Point, Color.Red, chartPoints);
        }

    }
}
