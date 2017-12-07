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
using System.Windows.Forms.DataVisualization.Charting;

namespace DataModeling
{
    public partial class Module2 : Form
    {

        private List<double> dots = new List<double>();
        private String seriesNameMethod1 = "Interpolate Lagrange";
        private String seriesNameMethod2 = "Interpolate Newton";
        double[] xValues, yValues;
        List<double> lagrangeDots = new List<double>();
        List<double> newtonDots = new List<double>();

        private void initValues()
        {
            int n = dots.Count / 2;
            xValues = new double[n];
            yValues = new double[n];
            int k = 0;
            for (int i = 0; i < dots.Count; i += 2)
            {
                xValues[k] = dots[i];
                yValues[k++] = dots[i + 1];
            }
        }


        private void restoresPolynomialMethods()
        {
            List<double> lagrangeDots = new List<double>();
            List<double> newtonDots = new List<double>();
            InterpolationInfo lagrangeInfo = new InterpolationInfo();
            InterpolationInfo newtonInfo = new InterpolationInfo();

            for (double x = xValues[0]; x <= xValues[xValues.Count() - 1]; x += 0.1)
            {
                double lagrangeY = interpolateLagrangePolynomial(x);
                lagrangeDots.Add(x);
                lagrangeDots.Add(lagrangeY);

                double newtonY = interpolateNewtonPolynomial(x);
                newtonDots.Add(x);
                newtonDots.Add(newtonY);

                //Console.WriteLine("*** " + x + "; " + lagrangeY);
                //Console.WriteLine("^^^ " + x + "; " + newtonY);

            }

            chartInterpolation.Series.Clear();
            drawLagrangeInterpolation(lagrangeDots);
            lagrangeInfo.check(lagrangeDots);
            showLagrangeInfo(lagrangeInfo);

            drawNewtonInterpolation(newtonDots);
            newtonInfo.check(newtonDots);
            showNewtonInfo(newtonInfo);
        }

        private void showLagrangeInfo(InterpolationInfo lagrangeInfo)
        {
            labelInfoLagrange.Text = lagrangeInfo.getMinimum() + lagrangeInfo.getDecrease() + lagrangeInfo.getMaximum() + lagrangeInfo.getIncrease() + lagrangeInfo.getRoot();
        }

        private void showNewtonInfo(InterpolationInfo newtonInfo)
        {
            labelInfoNewton.Text = newtonInfo.getMinimum() + newtonInfo.getDecrease() + newtonInfo.getMaximum() + newtonInfo.getIncrease() + newtonInfo.getRoot();
        }



        public Module2()
        {
            InitializeComponent();
            checkBoxInterpolationMethod1.Enabled = false;
            checkBoxInterpolationMethod2.Enabled = false;

            //button1.Visible = false;
            //comboBox1.Visible = false;
            buttonSaveInDB.Enabled = false;

            //dots.Add(0);
            //dots.Add(0.0000453);
            //dots.Add(2);
            //dots.Add(0.0027);
            //dots.Add(4);
            //dots.Add(0.0292);
            //dots.Add(6);
            //dots.Add(0.1301);
            //dots.Add(8);
            //dots.Add(0.3328);
            //dots.Add(10);
            //dots.Add(0.583);
            //dots.Add(12);
            //dots.Add(0.7915);
            //dots.Add(14);
            //dots.Add(1);
            //dots.Add(16);
            //dots.Add(1);
            //dots.Add(18);
            //dots.Add(1);
            //dots.Add(20);
            //dots.Add(1);

            //initValues();
            //restoresPolynomialMethods();       
        }

        public void drawLagrangeInterpolation(List<double> lagrangeDots)
        {
            List<double> chartDots = lagrangeDots;
            ChartDraw.showChart(chartDots, seriesNameMethod1, SeriesChartType.Spline, Color.Green, chartInterpolation);
            checkBoxInterpolationMethod1.Enabled = true;
            checkBoxInterpolationMethod1.Checked = true;
        }

        public void drawNewtonInterpolation(List<double> newtonDots)
        {
            List<double> chartDots = newtonDots;
            ChartDraw.showChart(chartDots, seriesNameMethod2, SeriesChartType.Spline, Color.Red, chartInterpolation);
            checkBoxInterpolationMethod2.Enabled = true;
            checkBoxInterpolationMethod2.Checked = true;
        }

        private void checkBoxInterpolationMethod1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInterpolationMethod1.Checked)
            {
                chartInterpolation.Series[seriesNameMethod1].Enabled = true;
            }
            else
            {
                chartInterpolation.Series[seriesNameMethod1].Enabled = false;
            }
        }

        private void checkBoxInterpolationMethod2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInterpolationMethod2.Checked)
            {
                chartInterpolation.Series[seriesNameMethod2].Enabled = true;
            }
            else
            {
                chartInterpolation.Series[seriesNameMethod2].Enabled = false;
            }
        }


        private double interpolateLagrangePolynomial(double x)
        {
            double lagrangePol = 0;

            for (int i = 0; i < xValues.Count(); i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < xValues.Count(); j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                lagrangePol += basicsPol * yValues[i];
            }
            return lagrangePol;
        }


        private double step;

        private double interpolateNewtonPolynomial(double x)
        {
            step = xValues[1] - xValues[0];
            int n = xValues.Count();
            double result = Cj(0);
            for (int j = 1; j < n; j++)
            {
                double tmp = Cj(j);
                for (int k = 0; k < j; k++)
                    tmp *= x - xValues[k];
                result += tmp;
            }
            return result;

        }

        private double Cj(int j)
        {
            if (j == 0)
                return yValues[0];
            double delta = getDelta(j, j);
            return delta / (factorial(j) * Math.Pow(step, j));
        }

        private double getDelta(int p, int i)
        {
            if (p == 1)
                return yValues[i] - yValues[i - 1];
            return getDelta(p - 1, i) - getDelta(p - 1, i - 1);
        }

        private double factorial(double value)
        {
            if (value == 0)
                return 1;
            return value * factorial(value - 1);
        }

        private void buttonSaveInDB_Click(object sender, EventArgs e)
        { 
            DistributionInfo distributionInfoLagrange = new DistributionInfo(1, lagrangeDots, "Autor", "Lagrange");
            DistributionInfo distributionInfoNewton = new DistributionInfo(2, newtonDots, "Autor", "Newton");
            DBManager.insert(distributionInfoLagrange);
            DBManager.insert(distributionInfoNewton);
            buttonSaveInDB.Enabled = false;
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSaveInDB.Enabled = true;
            dots.Clear();
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
            if (dots.Count > 0)
            {
                initValues();
                restoresPolynomialMethods();
            }
        }

    }
}
