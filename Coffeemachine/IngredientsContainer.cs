namespace Coffeemachine
{
    public class IngredientsContainer : Container, IService
    {
        public double Water { get; set; }
        public double Coffee { get; set; }
        public double Kakao { get; set; }
        public double Sugar { get; set; }
        public double Milk { get; set; }

        public IngredientsContainer(double water, double coffee, double kakao, double sugar, double milk) 
        { 
            Water = water;
            Coffee = coffee;
            Kakao = kakao;
            Sugar = sugar;
            Milk = milk;
        }

        public override string toString()
        {
            double maxContains = Water + Coffee + Kakao + Sugar + Milk;
            base.maxContains = maxContains;
            return Convert.ToString(base.maxContains);
        }

        public void service()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~     Ihr Zutatenbehälter wird               ~~~~~");
            Console.WriteLine("~~~~~     aufgefüllt...                          ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Water = 1.0;
            Coffee = 1.0;
            Kakao = 1.0;
            Sugar = 1.0;
            Milk = 1.0;

            Thread.Sleep(3000);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~    Erfolgreich aufgefüllt.                 ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
