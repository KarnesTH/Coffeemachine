namespace Coffeemachine
{
    public class Coffeemachine
    {
        IngredientsContainer zb = new(1.0, 1.0, 1.0, 1.0, 1.0);
        double currWater;
        double currCoffee;
        double currKakao;
        double currSugar;
        double currMilk;

        public Coffeemachine()
        {
            currWater = zb.Water;
            currCoffee = zb.Coffee;
            currKakao = zb.Kakao;
            currSugar = zb.Sugar;
            currMilk = zb.Milk;
        }

        Reciepes[] reciepes =
        {
            new Reciepes("Kaffee schwarz", 0.2, 0.02, 0, 0, 0),
            new Reciepes("Kaffee Zucker", 0.2, 0.02, 0, 0.02, 0),
            new Reciepes("Kaffee Milch", 0.2, 0.02, 0, 0, 0.02),
            new Reciepes("Kaffee Milch/Zucker", 0.2, 0.02, 0, 0.02, 0.02),
            new Reciepes("Kakao", 0.2, 0, 0.02, 0.02, 0.02)
        };

        GarbageContainer gc = new();

        private static void Main(string[] args)
        {
            Coffeemachine cm = new();
            cm.Start();
        }

        public void Start()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~        Ihr Gerät startet...                ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Thread.Sleep(5000);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~        Ihr Gerät ist einsatzbereit         ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            while (true)
            {
                if (gc.MaxContains >= 1.0)
                {
                    Console.WriteLine("Bitte entleeren Sie den Abfallbehälter.");

                    Thread.Sleep(3000);

                    Service();
                }

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~                                            ~~~~~");
                Console.WriteLine("~~~~~        Auswahl:                            ~~~~~");
                Console.WriteLine("~~~~~                                            ~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                for (int i = 0; i < reciepes.Length; i++)
                {
                    Console.WriteLine("      " + i + "      " + reciepes[i].Name);
                }

                Console.WriteLine("      8      Status");
                Console.WriteLine("      9      Ende");
                Console.WriteLine("      10     Wartung");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~                                            ~~~~~");
                Console.WriteLine("~~~~~ Drücken Sie eine Nummer:                   ~~~~~");

                int userInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                if (userInput == 8)
                {
                    Status();
                }
                else if(userInput == 9)
                {
                    Shutdown();
                }
                else if (userInput == 10)
                {
                    Service();
                }
                else
                {
                    CreateDrink(reciepes[userInput]);
                }
            }
        }

        void CreateDrink(Reciepes r)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(r.Name + " wird zubereitet.");

            if (r.Water == +0.2)
            {
                currWater = zb.Water - r.Water;
                zb.Water = currWater;
            }

            if (r.Coffee == +0.02)
            {
                currCoffee = zb.Coffee - r.Coffee;
                zb.Coffee = currCoffee;
            }

            if (r.Kakao == +0.02)
            {
                currKakao = zb.Kakao - r.Kakao;
                zb.Kakao = currKakao;
            }

            if (r.Sugar == +0.02)
            {
                currSugar = zb.Sugar - r.Sugar;
                zb.Sugar = currSugar;
            }

            if (r.Milk == +0.02)
            {
                currMilk = zb.Milk - r.Milk;
                zb.Milk = currMilk;
            }

            Thread.Sleep(3000);

            Console.WriteLine(r.Name + " ist fertig.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            if (r.Coffee == +0.02)
            {
                double garbage = 0.2;
                double fill = gc.MaxContains + garbage;
                gc.MaxContains = fill;
            }
        }

        void Status()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~        Status:                             ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Wasser: \t\t\t" + Math.Round(zb.Water) + "l");
            Console.WriteLine("Kaffee: \t\t\t" + Math.Round(zb.Coffee) + "l");
            Console.WriteLine("Kakao:  \t\t\t" + Math.Round(zb.Kakao) + "l");
            Console.WriteLine("Zucker: \t\t\t" + Math.Round(zb.Sugar) + "l");
            Console.WriteLine("Milch:  \t\t\t" + Math.Round(zb.Milk) + "l");
            Console.WriteLine("Gesamt im Zutatenbehälter: \t" + (Math.Round(zb.Water + zb.Coffee + zb.Kakao + zb.Sugar + zb.Milk)) + "l");
            Console.WriteLine("Gesamt im Abfallbehälter: \t" + gc.MaxContains + "l");
        }

        void Shutdown()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~        Abschaltung...                      ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Thread.Sleep(3000);

            Environment.Exit(0);
        }

        void Service()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~        Wartungs Auswahl:                   ~~~~~");
            Console.WriteLine("~~~~~                                            ~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("      1     Abfallbehälter entleeren.");
            Console.WriteLine("      2     Zutatenbehälter auffüllen.");

            int userInput2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            if (userInput2 == 1)
            {
                gc.service();
            }
            else if (userInput2 == 2)
            {
                zb.service();
            }
        }
    }
}