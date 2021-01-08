namespace CleanCodeOchTestbarKod_Labb4
{
    public class PercentagePair
    {
        public PercentagePair(double percentageA, double percentageB)
        {
            PercentageA = percentageA;
            PercentageB = percentageB;
        }

        public string PercentageAWithPercentageSymbol
        {
            get { return DoubleToPercentageString(PercentageA); }
        }

        public string PercentageBWithPercentageSymbol
        {
            get { return DoubleToPercentageString(PercentageB); }
        }

        public double PercentageA { get; set; }
        public double PercentageB { get; set; }


        private string DoubleToPercentageString(double value)
        {
            return value.ToString() + "%";
        }
    }
}
