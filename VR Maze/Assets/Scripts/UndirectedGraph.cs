﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Represents an undirected graph with nodes containing a generic type
    /// </summary>
    /// <typeparam name="T">The type of object that the nodes contain</typeparam>
    public class UndirectedGraph<T> : IEnumerable<T>
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
            fromNode.AddNeighbor(toNode);
            toNode.AddNeighbor(fromNode);
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
            return fromNode.Neighbors.Contains(toNode) || toNode.Neighbors.Contains(fromNode);
        }

        /// <summary>
        /// Returns whether or not an item is in graph
        /// </summary>
        /// <param name="item">The item to test</param>
        /// <returns>True if item is in the graph</returns>
        public bool Contains(T item)
        {
            foreach (GraphNode<T> node in nodes)
            {
                if (node.Data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns all items directly connected to the given item in the graph
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>A list of all items connected to item</returns>
        public List<T> Neighbors(T item)
        {
            List<T> items = new List<T>();
            GraphNode<T> itemNode = getNode(item);
            foreach (var node in itemNode.Neighbors)
            {
                items.Add(node.Data);
            }
            return items;
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

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (GraphNode<T> node in nodes)
            {
                if (node == null)
                {
                    break;
                }
                yield return node.Data;
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
