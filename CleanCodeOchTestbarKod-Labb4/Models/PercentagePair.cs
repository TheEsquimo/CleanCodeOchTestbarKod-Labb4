using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4
{
    public class PercentagePair
    {
        public PercentagePair(double percentageA, double percentageB)
        {
            this.percentageA = percentageA;
            this.percentageB = percentageB;
        }

        public string PercentageA
        {
            get { return DoubleToPercentageString(percentageA); }
            set
            {
                try
                {
                    percentageA = double.Parse(value);
                }
                catch
                {
                    throw new InvalidCastException();
                }
            }
        }

        public string PercentageB
        {
            get { return DoubleToPercentageString(percentageB); }
            set
            {
                try
                {
                    percentageB = double.Parse(value);
                }
                catch
                {
                    throw new InvalidCastException();
                }
            }
        }

        private double percentageA;
        private double percentageB;


        private string DoubleToPercentageString(double value)
        {
            return value.ToString() + "%";
        }
    }
}
