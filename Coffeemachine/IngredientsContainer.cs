namespace Coffeemachine
{
    /// <summary>
    /// Represents a container for ingredients in the coffee machine.
    /// </summary>
    public class IngredientsContainer : Container, IService
    {
        /// <summary>
        /// Gets or sets the amount of water in the container.
        /// </summary>
        public double Water { get; set; }

        /// <summary>
        /// Gets or sets the amount of coffee in the container.
        /// </summary>
        public double Coffee { get; set; }

        /// <summary>
        /// Gets or sets the amount of cocoa in the container.
        /// </summary>
        public double Cocoa { get; set; }

        /// <summary>
        /// Gets or sets the amount of sugar in the container.
        /// </summary>
        public double Sugar { get; set; }

        /// <summary>
        /// Gets or sets the amount of milk in the container.
        /// </summary>
        public double Milk { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsContainer"/> class with the specified amounts of ingredients.
        /// </summary>
        /// <param name="water">The amount of water.</param>
        /// <param name="coffee">The amount of coffee.</param>
        /// <param name="cocoa">The amount of cocoa.</param>
        /// <param name="sugar">The amount of sugar.</param>
        /// <param name="milk">The amount of milk.</param>
        public IngredientsContainer(double water, double coffee, double cocoa, double sugar, double milk)
        {
            Water = water;
            Coffee = coffee;
            Cocoa = cocoa;
            Sugar = sugar;
            Milk = milk;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            MaxContains = Water + Coffee + Cocoa + Sugar + Milk;
            return MaxContains.ToString();
        }

        /// <summary>
        /// Performs the service operation to refill the ingredients container.
        /// </summary>
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
