using System;

namespace ParseTree
{
    /// <summary>
    /// The class that represents the operand.
    /// </summary>
    public class Operand : Node
    {
        /// <summary>
        /// Initializes an object of the operand class.
        /// </summary>
        public Operand(int item) => Value = item;

        /// <summary>
        /// Returns the value of the operand.
        /// </summary>
        public override int Value { get; }

        /// <returns>a string that represents the current object.</returns>
        public override string ToString()
        {
            string output = "";

            output += Value.ToString();

            return output; 
        }

        /// <summary>
        /// Prints a string that represents the current object.
        /// </summary>
        public override void Print() => Console.Write(ToString());
    }
}
