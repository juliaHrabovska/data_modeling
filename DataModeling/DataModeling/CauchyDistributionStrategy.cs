using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    class CauchyDistributionStrategy : DistributionStrategy
    {
        private String[] PARAMETERS = { "parameter1", "parameter2" };

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
