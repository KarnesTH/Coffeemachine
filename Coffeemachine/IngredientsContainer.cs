namespace Coffeemachine
{
    public class IngredientsContainer : Container, IService
    {
        public double Water { get; set; }
        public double Coffee { get; set; }
        public double Cocoa { get; set; }
        public double Sugar { get; set; }
        public double Milk { get; set; }

        public IngredientsContainer(double water, double coffee, double cocoa, double sugar, double milk)
        {
            Water = water;
            Coffee = coffee;
            Cocoa = cocoa;
            Sugar = sugar;
            Milk = milk;
        }

        public override string ToString()
        {
            MaxContains = Water + Coffee + Cocoa + Sugar + Milk;
            return MaxContains.ToString();
        }

        public void Service()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Ihr Zutatenbehälter wird");
            Console.WriteLine("aufgefüllt...");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Water = 1.0;
            Coffee = 1.0;
            Cocoa = 1.0;
            Sugar = 1.0;
            Milk = 1.0;

            Thread.Sleep(3000);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Erfolgreich aufgefüllt.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
