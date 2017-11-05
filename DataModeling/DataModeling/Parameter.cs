using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    class Parameter
    {
        private String name { get; }
        private Double rangeBegin { get; }
        private Double rangeEnd { get; }

        public Parameter(String name, double rangeBegin, double rangeEnd)
        {
            this.name = name;
            this.rangeBegin = rangeBegin;
            this.rangeEnd = rangeEnd;
        }        
    }
}
