namespace Coffeemachine
{
    public abstract class Container
    {
        public double CurrentFillLevel { get; set; }
        public double MaxContains { get; set; }

        public abstract override String ToString();
    }
}
