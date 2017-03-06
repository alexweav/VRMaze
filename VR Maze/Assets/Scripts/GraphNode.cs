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
    public class GraphNode<T>
    {
        private T data;
        private List<GraphNode<T>> neighbors;

        /// <summary>
        /// Creates a graph node containing the given object
        /// </summary>
        /// <param name="data">The object</param>
        public GraphNode(T data)
        {
            this.data = data;
            neighbors = new List<GraphNode<T>>();
        }

        public void AddNeighbor(GraphNode<T> item)
        {
            neighbors.Add(item);
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

        public List<GraphNode<T>> Neighbors
        {
            get
            {
                return neighbors;
            }
        }
    }
}
