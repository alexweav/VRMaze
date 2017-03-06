using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Randomly generates mazes
    /// </summary>
    class RandomMazeGenerator : IMazeGenerator
    {
        public Maze generate(int width, int height)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an undirected graph of ints in the shape of a grid, where no nodes have connections
        /// </summary>
        /// <param name="width">Width of the grid</param>
        /// <param name="height">Height of the grid</param>
        /// <returns>The graph</returns>
        private UndirectedGraph<int> CreateUnconnectedGridGraph(int width, int height)
        {
            int numNodes = width * height;
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            for (int i = 0; i < numNodes; i++)
            {
                graph.AddNode(i);
            }
            return graph;
        }
    }
}
