using System.Diagnostics.Metrics;

namespace Coffeemachine
{
    public class GarbageContainer : Container, IService
    {
        public double MaxContains { get; set; }

        public override string toString()
        {
            return Convert.ToString(MaxContains);
        }

        public void service()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~     Ihr Abfallbehälter wird                ~~~~~");
            Console.WriteLine("~~~~~     entleert...                            ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            MaxContains = 0;

            Thread.Sleep(3000);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~    Erfolgreich entleert.                   ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
