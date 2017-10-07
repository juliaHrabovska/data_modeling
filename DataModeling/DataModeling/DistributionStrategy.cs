using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    interface DistributionStrategy
    {

        List<double> generateData(List<double> parameters); 

        String[] getParameters();
    }
}
