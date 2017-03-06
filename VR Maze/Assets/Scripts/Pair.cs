using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Ordered pair of objects
    /// </summary>
    /// <typeparam name="T">Type of the first object in the pair</typeparam>
    /// <typeparam name="U">Type of the second object in the pair</typeparam>
    public class Pair<T, U>
    {
        /// <summary>
        /// Constructs a pair of the two objects
        /// </summary>
        /// <param name="first">First object</param>
        /// <param name="second">Second object</param>
        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }

        /// <summary>
        /// Equality comparison for Pairs
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>Whether this and obj are equal</returns>
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            Pair<T, U> instance = obj as Pair<T, U>;
            if (instance == null)
            {
                return false;
            }
            return this.First.Equals(instance.First) && this.Second.Equals(instance.Second);
        }

        /// <summary>
        /// Generic object hash code for Pair
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return this.First.GetHashCode() ^ this.Second.GetHashCode();
        }
    }
}
