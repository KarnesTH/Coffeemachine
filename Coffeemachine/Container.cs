namespace Coffeemachine
{
    /// <summary>
    /// Represents an abstract container with a current fill level and a maximum capacity.
    /// </summary>
    public abstract class Container
    {
        /// <summary>
        /// Gets or sets the current fill level of the container.
        /// </summary>
        public double CurrentFillLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum capacity of the container.
        /// </summary>
        public double MaxContains { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public abstract override String ToString();
    }
}
