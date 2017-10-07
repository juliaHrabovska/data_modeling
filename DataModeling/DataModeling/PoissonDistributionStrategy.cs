﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    class PoissonDistributionStrategy : DistributionStrategy
    {
        private String[] PARAMETERS = { "lambda" };        

        public List<double> generateData(Dictionary<String, double> parameters)
        {            
            double xBegin = parameters["xBegin"];
            double step = parameters["step"];
            double xEnd = parameters["xEnd"];            
            double lambda = parameters["lambda"];

            List<double> dots = new List<double>();

            for(double x = xBegin; x <= xEnd; x += step)
            {
                dots.Add(x);
                dots.Add(poissonFunction(x, lambda));
            }

            return dots;
        }

        private double poissonFunction(double x, double lambda)
        {
            return Math.Exp(-1 * lambda) * poissonSum(x, lambda);
        }

        private double poissonSum(double x, double lambda)
        {
            int floorX = Convert.ToInt32(Math.Floor(x));
            double sum = 0.0;
            for(int i=0; i <= floorX; i++)
            {
                sum += Math.Pow(lambda, i) / factorial(i);
            }

            return sum;
        }
                

        private int factorial(int x)
        {
            if(x == 0)
            {
                return 1;
            }
            int fact = x;
            for (int counter = x - 1; counter >= 1; counter--)
            {
                fact = fact * counter;                
            }
            return fact;
        }

        public string[] getParameters()
        {
            return PARAMETERS;
        }
    }
}
