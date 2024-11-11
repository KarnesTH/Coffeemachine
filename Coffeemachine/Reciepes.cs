namespace Coffeemachine
{
    public class Reciepes : IngredientsContainer
    {
        public string Name { get; set; }

        public Reciepes(string name, double water, double coffee, double cocoa, double sugar, double milk)
            : base(water, coffee, cocoa, sugar, milk)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
