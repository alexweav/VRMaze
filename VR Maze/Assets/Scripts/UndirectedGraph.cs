using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Represents an undirected graph with nodes containing a generic type
    /// </summary>
    /// <typeparam name="T">The type of object that the nodes contain</typeparam>
    class UndirectedGraph<T>
    {
        private List<GraphNode<T>> nodes;

        /// <summary>
        /// Creates an empty graph
        /// </summary>
        public UndirectedGraph()
        {
            nodes = new List<GraphNode<T>>();
        }

        /// <summary>
        /// Adds a node to the graph
        /// </summary>
        /// <param name="value">The object contained by the node</param>
        public void AddNode(T value)
        {
            nodes.Add(new GraphNode<T>(value));
        }

        /// <summary>
        /// Adds an edge between two items in a graph
        /// </summary>
        /// <param name="from">Item 1</param>
        /// <param name="to">Item 2</param>
        public void AddEdge(T from, T to)
        {
            GraphNode<T> fromNode = getNode(from);
            GraphNode<T> toNode = getNode(to);
            fromNode.Neighbors.Add(toNode);
            toNode.Neighbors.Add(fromNode);
        }

        /// <summary>
        /// Returns true if two items in a graph are directly connected
        /// </summary>
        /// <param name="from">Item 1</param>
        /// <param name="to">Item 2</param>
        /// <returns>Indication if from and to are connected</returns>
        public bool AreConnected(T from, T to)
        {
            GraphNode<T> fromNode = getNode(from);
            GraphNode<T> toNode = getNode(to);
            return fromNode.Neighbors.Contains(toNode);
        }

        /// <summary>
        /// The number of nodes in the graph
        /// </summary>
        public int Count
        {
            get
            {
                return nodes.Count;
            }
        }

        /// <summary>
        /// Finds a node that contains the given item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The node containing item</returns>
        private GraphNode<T> getNode(T item)
        {
            foreach (GraphNode<T> node in nodes)
            {
                if (node.Data.Equals(item))
                {
                    return node;
                }
            }
            throw new ArgumentException("Item " + item + " not available in graph.");
        }
    }
}
