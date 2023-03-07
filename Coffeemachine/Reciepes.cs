namespace Coffeemachine
{
    public class Reciepes : IngredientsContainer
    {
        public string Name { get; set; }
        public Reciepes(string name, double water, double coffee, double kakao, double sugar, double milk) : base(water, coffee, kakao, sugar, milk)
        {
            Name = name;
        }
        
        public String toString()
        {
            return Name;
        }
    }
}
