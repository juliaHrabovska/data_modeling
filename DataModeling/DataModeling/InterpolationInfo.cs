using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    class InterpolationInfo
    {
        List<double> root = new List<double>();
        List<double> decrease = new List<double>();
        List<double> increase = new List<double>();
        List<double> minimum = new List<double>();
        List<double> maximum = new List<double>();

        public void check(List<double> dots)
        {
            int n = dots.Count / 2;
            double[] xValues = new double[n];
            double[] yValues = new double[n];
            int k = 0;
            for (int i = 0; i < dots.Count; i += 2)
            {
                xValues[k] = dots[i];
                yValues[k++] = dots[i + 1];
            }
            isRoot(xValues, yValues);
            isDecrease(xValues, yValues);
            isIncrease(xValues, yValues);
        }

        public void isRoot(double[] xValues, double[] yValues)
        {
            for (int i = 0; i < xValues.Count(); i++)
            {
                if (xValues[i] == 0)
                {
                    root.Add(xValues[i]);
                    root.Add(yValues[i]);
                }
            }
        }

        public void isDecrease(double[] xValues, double[] yValues)
        {
            double tmpY = yValues[0];
            bool isStartDot = false;
            for (int i = 1; i < xValues.Count(); i++)
            {
                if (yValues[i] < tmpY)
                {
                    if (isStartDot == false)
                    {
                        decrease.Add(xValues[i - 1]);
                    }
                    isStartDot = true;
                    continue;
                }

                if (yValues[i] > tmpY)
                {
                    if (isStartDot)
                    {
                        decrease.Add(xValues[i - 1]);
                        minimum.Add(xValues[i - 1]);
                        minimum.Add(yValues[i - 1]);
                        isStartDot = false;
                    }
                    tmpY = yValues[i];
                }
            }
            if (isStartDot)
            {
                decrease.Add(xValues[xValues.Count() - 1]);
                minimum.Add(xValues[xValues.Count() - 1]);
                minimum.Add(yValues[yValues.Count() - 1]);
            }
        }

        public void isIncrease(double[] xValues, double[] yValues)
        {
            double tmpY = yValues[0];
            bool isStartDot = false;
            for (int i = 1; i < xValues.Count(); i++)
            {
                if (yValues[i] > tmpY)
                {
                    if (isStartDot == false)
                    {
                        increase.Add(xValues[i - 1]);
                    }
                    isStartDot = true;
                    continue;
                }

                if (yValues[i] < tmpY)
                {
                    if (isStartDot)
                    {
                        increase.Add(xValues[i - 1]);
                        maximum.Add(xValues[i - 1]);
                        maximum.Add(yValues[i - 1]);
                        isStartDot = false;
                    }
                    tmpY = yValues[i];
                }
            }
            if (isStartDot)
            {
                increase.Add(xValues[xValues.Count() - 1]);
                maximum.Add(xValues[xValues.Count() - 1]);
                maximum.Add(yValues[yValues.Count() - 1]);
            }
        }


        public String getMinimum()
        {
            StringBuilder sb = new StringBuilder("Minimum:" + Environment.NewLine);
            for (int i = 0; i < minimum.Count() - 1; i += 2)
            {
                sb.Append("(").Append(Math.Round(minimum[i], 3)).Append("; ").Append(Math.Round(minimum[i + 1], 3)).Append(")").Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public String getMaximum()
        {
            StringBuilder sb = new StringBuilder("Maximum:" + Environment.NewLine);
            for (int i = 0; i < maximum.Count() - 1; i += 2)
            {
                sb.Append("(").Append(Math.Round(maximum[i], 3)).Append("; ").Append(Math.Round(maximum[i + 1], 3)).Append(")").Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public String getRoot()
        {
            StringBuilder sb = new StringBuilder("Root:" + Environment.NewLine);
            for (int i = 0; i < root.Count() - 1; i += 2)
            {
                sb.Append("(").Append(Math.Round(root[i], 3)).Append("; ").Append(Math.Round(root[i + 1], 3)).Append(")").Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public String getDecrease()
        {
            StringBuilder sb = new StringBuilder("Decrease:" + Environment.NewLine);
            for (int i = 0; i < decrease.Count() - 1; i += 2)
            {
                sb.Append("(").Append(Math.Round(decrease[i], 3)).Append("; ").Append(Math.Round(decrease[i + 1], 3)).Append(")").Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public String getIncrease()
        {
            StringBuilder sb = new StringBuilder("Increase:" + Environment.NewLine);
            for (int i = 0; i < increase.Count() - 1; i += 2)
            {
                sb.Append("(").Append(Math.Round(increase[i], 3)).Append("; ").Append(Math.Round(increase[i + 1], 3)).Append(")").Append(Environment.NewLine);
            }
            return sb.ToString();
        }



    }
}
