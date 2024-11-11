namespace Coffeemachine
{
    /// <summary>
    /// Represents a recipe for a drink, including its name and required ingredients.
    /// </summary>
    public class Reciepes : IngredientsContainer
    {
        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reciepes"/> class with the specified name and ingredient amounts.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="water">The amount of water required.</param>
        /// <param name="coffee">The amount of coffee required.</param>
        /// <param name="cocoa">The amount of cocoa required.</param>
        /// <param name="sugar">The amount of sugar required.</param>
        /// <param name="milk">The amount of milk required.</param>
        public Reciepes(string name, double water, double coffee, double cocoa, double sugar, double milk)
            : base(water, coffee, cocoa, sugar, milk)
        {
            Name = name;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
