using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// A node in a graph
    /// </summary>
    /// <typeparam name="T">The data type that the graph node contains</typeparam>
    class GraphNode<T>
    {
        private T data;
        private List<T> neighbors;

        /// <summary>
        /// Empty constructor. Use this to create an arbitrary dataless node
        /// </summary>
        public GraphNode()
        {
        }

        /// <summary>
        /// Creates a graph node containing the given object
        /// </summary>
        /// <param name="data">The object</param>
        public GraphNode(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public List<T> Neighbors
        {
            get
            {
                if (neighbors == null)
                {
                    return new List<T>();
                }
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
}
