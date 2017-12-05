using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModeling
{
    class DistributionInfo
    {
        private long id;
        private List<Double> dots;
        private String autor;
        private String restoring;

        public DistributionInfo(long id, List<Double> dots, String autor, String restoring)
        {
            this.id = id;
            this.dots = dots;
            this.autor = autor;
            this.restoring = restoring;
        }

        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public List<Double> Dots
        {
            get
            {
                return dots;
            }
            set
            {
                dots = value;
            }
        }

        public String Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
            }
        }

        public String Restoring
        {
            get
            {
                return restoring;
            }
            set
            {
                restoring = value;
            }
        }
    }
}
