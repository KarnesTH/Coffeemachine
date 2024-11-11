namespace Coffeemachine
{
    public class Coffeemachine
    {
        private readonly IngredientsContainer _ingredientsContainer = new(1.0, 1.0, 1.0, 1.0, 1.0);
        private double _currentWater;
        private double _currentCoffee;
        private double _currentCocoa;
        private double _currentSugar;
        private double _currentMilk;

        private readonly Reciepes[] _recipes =
        {
            new Reciepes("Kaffee schwarz", 0.2, 0.02, 0, 0, 0),
            new Reciepes("Kaffee Zucker", 0.2, 0.02, 0, 0.02, 0),
            new Reciepes("Kaffee Milch", 0.2, 0.02, 0, 0, 0.02),
            new Reciepes("Kaffee Milch/Zucker", 0.2, 0.02, 0, 0.02, 0.02),
            new Reciepes("Kakao", 0.2, 0, 0.02, 0.02, 0.02)
        };

        private readonly GarbageContainer _garbageContainer = new();

        public Coffeemachine()
        {
            _currentWater = _ingredientsContainer.Water;
            _currentCoffee = _ingredientsContainer.Coffee;
            _currentCocoa = _ingredientsContainer.Cocoa;
            _currentSugar = _ingredientsContainer.Sugar;
            _currentMilk = _ingredientsContainer.Milk;
        }

        private static void Main(string[] args)
        {
            var coffeemachine = new Coffeemachine();
            coffeemachine.Start();
        }

        public void Start()
        {
            DisplayMessage("Ihr Gerät startet...", 5000);
            DisplayMessage("Ihr Gerät ist einsatzbereit");

            while (true)
            {
                if (_garbageContainer.MaxContains >= 1.0)
                {
                    Console.WriteLine("Bitte entleeren Sie den Abfallbehälter.");
                    Thread.Sleep(3000);
                    Service();
                }

                DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                    continue;
                }

                switch (userInput)
                {
                    case 8:
                        Status();
                        break;
                    case 9:
                        Shutdown();
                        break;
                    case 10:
                        Service();
                        break;
                    default:
                        if (userInput >= 0 && userInput < _recipes.Length)
                        {
                            CreateDrink(_recipes[userInput]);
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        }
                        break;
                }
            }
        }

        private void CreateDrink(Reciepes recipe)
        {
            if (_currentWater < recipe.Water)
            {
                Console.WriteLine("Nicht genügend Wasser vorhanden.");
                return;
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{recipe.Name} wird zubereitet.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            DeductIngredient(ref _currentWater, recipe.Water, _ingredientsContainer);
            DeductIngredient(ref _currentCoffee, recipe.Coffee, _ingredientsContainer);
            DeductIngredient(ref _currentCocoa, recipe.Cocoa, _ingredientsContainer);
            DeductIngredient(ref _currentSugar, recipe.Sugar, _ingredientsContainer);
            DeductIngredient(ref _currentMilk, recipe.Milk, _ingredientsContainer);

            Thread.Sleep(3000);

            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{recipe.Name} ist fertig.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Thread.Sleep(3000);

            if (recipe.Coffee > 0)
            {
                _garbageContainer.MaxContains += 0.2;
            }
        }

        private void DeductIngredient(ref double currentAmount, double amountToDeduct, IngredientsContainer container)
        {
            if (amountToDeduct > 0)
            {
                currentAmount -= amountToDeduct;

                if (container.Water == currentAmount + amountToDeduct)
                {
                    container.Water = currentAmount;
                }
                else if (container.Coffee == currentAmount + amountToDeduct)
                {
                    container.Coffee = currentAmount;
                }
                else if (container.Cocoa == currentAmount + amountToDeduct)
                {
                    container.Cocoa = currentAmount;
                }
                else if (container.Sugar == currentAmount + amountToDeduct)
                {
                    container.Sugar = currentAmount;
                }
                else if (container.Milk == currentAmount + amountToDeduct)
                {
                    container.Milk = currentAmount;
                }
            }
        }

        private void Status()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Status:");
            Console.WriteLine($"Wasser: \t\t\t{Math.Round(_ingredientsContainer.Water, 2)}l");
            Console.WriteLine($"Kaffee: \t\t\t{Math.Round(_ingredientsContainer.Coffee, 2)}l");
            Console.WriteLine($"Kakao:  \t\t\t{Math.Round(_ingredientsContainer.Cocoa, 2)}l");
            Console.WriteLine($"Zucker: \t\t\t{Math.Round(_ingredientsContainer.Sugar, 2)}l");
            Console.WriteLine($"Milch:  \t\t\t{Math.Round(_ingredientsContainer.Milk, 2)}l");
            Console.WriteLine($"Gesamt im Zutatenbehälter: \t{Math.Round(_ingredientsContainer.Water + _ingredientsContainer.Coffee + _ingredientsContainer.Cocoa + _ingredientsContainer.Sugar + _ingredientsContainer.Milk, 2)}l");
            Console.WriteLine($"Gesamt im Abfallbehälter: \t{_garbageContainer.MaxContains}l");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        private void Shutdown()
        {
            DisplayMessage("Abschaltung...", 3000);
            Environment.Exit(0);
        }

        private void Service()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Wartungs Auswahl:");
            Console.WriteLine("1. Abfallbehälter entleeren.");
            Console.WriteLine("2. Zutatenbehälter auffüllen.");

            if (!int.TryParse(Console.ReadLine(), out int userInput))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                return;
            }

            switch (userInput)
            {
                case 1:
                    _garbageContainer.Service();
                    break;
                case 2:
                    _ingredientsContainer.Service();
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                    break;
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        private void DisplayMessage(string message, int delay = 0)
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{message}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            if (delay > 0)
            {
                Thread.Sleep(delay);
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Auswahl:");
            for (int i = 0; i < _recipes.Length; i++)
            {
                Console.WriteLine($"      {i}      {_recipes[i].Name}");
            }

            Console.WriteLine("      8      Status");
            Console.WriteLine("      9      Ende");
            Console.WriteLine("      10     Wartung");
            Console.WriteLine("Drücken Sie eine Nummer:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
