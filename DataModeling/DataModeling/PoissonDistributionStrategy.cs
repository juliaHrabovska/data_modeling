using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    class PoissonDistributionStrategy : DistributionStrategy
    {
        private String[] PARAMETERS = { "lambda" };
        private double step = 0.01;

        public List<double> generateData(Dictionary<String, double> parameters)
        {            
            double xBegin = parameters["xBegin"];
            double step = parameters["step"];
            double xEnd = parameters["xEnd"] - step;            
            double lambda = parameters["lambda"];

            List<double> dots = new List<double>();

            for(double x = xBegin; x <= xEnd; x += step)
            {
                dots.Add(x);
                dots.Add(poissonFunction(x, lambda));
            }

            return dots;
        }

        private double poissonFunction(double x, double lambda)
        {
            return Math.Pow(lambda, x) * Math.Exp(-1 * lambda) / factorial(x);
        }

        private double factorial(double x)
        {
            return Math.Log(Math.Floor(x)) + x * Math.Log(Math.Floor(x) + 1);
        }

        public string[] getParameters()
        {
            return PARAMETERS;
        }
    }
}
