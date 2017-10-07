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
        private String[] PARAMETERS = { "parameter1", "parameter2" };

        public List<double> generateData(Dictionary<String, double> parameters)
        {
            MessageBox.Show("CauchyDistributionStrategy");
            return null;
        }

        public string[] getParameters()
        {
            return PARAMETERS;
        }
    }
}
