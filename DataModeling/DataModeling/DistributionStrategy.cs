using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    interface DistributionStrategy
    {

        List<double> generateData(Dictionary<String, double> parameters); 

        String[] getParameters();
    }
}
