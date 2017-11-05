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

        public override double validateParametr(String name, object value, List<string> errors)
        {
            switch(name)
            {
                case "x0": return validateX0(value, errors);
                case "gamma": return validateGamma(value, errors);
                default: throw new ArgumentException("Unknown parameter " + name);
            }
        }

        private double validateX0(object value, List<string> errors)
        {
            double convertedValue = 0.0;
            try
            {
                convertedValue = Convert.ToInt32(value);                
            }
            catch (OverflowException)
            {
                errors.Add(value + " is outside the range of the Int32 type.");                
            }
            catch (FormatException)
            {
                errors.Add(value + " is not an integer.");                
            }
            return convertedValue;
        }

        private double validateGamma(object value, List<string> errors)
        {
            double convertedValue = 0.0;
            try
            {
                convertedValue = Convert.ToDouble(value);
                if (convertedValue <= 0)
                {
                    errors.Add("gamma must be bigger than 0.");
                }                
            }
            catch (OverflowException)
            {
                errors.Add(value + " is outside the range of the Double type.");
            }
            catch (FormatException)
            {
                errors.Add(value + " is not a double.");
            }
            return convertedValue;
        }
    }
}
