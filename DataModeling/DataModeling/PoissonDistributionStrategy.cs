using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    class PoissonDistributionStrategy : DistributionStrategy
    {
        private String[] PARAMETERS = { "a", "b" };

        public List<double> generateData(List<double> parameters)
        {
            throw new NotImplementedException();
        }

        public string[] getParameters()
        {
            return PARAMETERS;
        }
    }
}
