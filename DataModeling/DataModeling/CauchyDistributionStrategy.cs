using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    class CauchyDistributionStrategy : DistributionStrategy
    {
        private String[] PARAMETERS = { "x0", "gamma" };

        public override List<double> generateData(Dictionary<String, double> parameters)
        {
            double xBegin = parameters["xBegin"];
            double step = parameters["step"];
            double xEnd = parameters["xEnd"];
            double x0 = parameters["x0"];
            double gamma = parameters["gamma"];
            double deviation = parameters["deviation"];

            List<double> dots = new List<double>();

            for (double x = xBegin; x <= xEnd; x += step)
            {
                dots.Add(x);
                dots.Add(cauchyFunction(x, x0, gamma) + getRandomDeviation(deviation));
            }

            return dots;
        }

        private double cauchyFunction(double x, double x0, double gamma)
        {
            return ((1 / Math.PI) * Math.Atan((x - x0) / gamma)) + 0.5;
        }

        public override string[] getParameters()
        {
            return PARAMETERS;
        }
    }
}
