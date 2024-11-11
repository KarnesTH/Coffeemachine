namespace Coffeemachine
{
    /// <summary>
    /// Represents a garbage container for the coffee machine.
    /// </summary>
    public class GarbageContainer : Container, IService
    {
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return MaxContains.ToString();
        }

        /// <summary>
        /// Performs the service operation to empty the garbage container.
        /// </summary>
        public void Service()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Ihr Abfallbehälter wird");
            Console.WriteLine("entleert...");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            MaxContains = 0;

            Thread.Sleep(3000);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Erfolgreich entleert.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
