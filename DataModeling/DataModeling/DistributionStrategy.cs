using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    abstract class DistributionStrategy
    {
        private static Random random = new Random();

        public abstract List<double> generateData(Dictionary<String, double> parameters);

        public abstract String[] getParameters();

        protected double getRandomDeviation(double deviation)
        {
            return random.NextDouble() * deviation * getPlusOrMinus();
        }

        protected double getPlusOrMinus()
        {
            return random.NextDouble() > 0.5 ? 1 : -1;
        }
    }
}
