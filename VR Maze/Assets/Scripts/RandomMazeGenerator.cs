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
        private UndirectedGraph<Pair<int, int>> CreateUnconnectedGridGraph(int width, int height)
        {
            int numNodes = width * height;
            UndirectedGraph<Pair<int, int>> graph = new UndirectedGraph<Pair<int, int>>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    graph.AddNode(new Pair<int, int>(j, i));
                }
            }
            return graph;
        }

        private UndirectedGraph<Pair<int, int>> BuildRandomGridSpanningTree(UndirectedGraph<Pair<int, int>> graph)
        {
            var startCell = new Pair<int, int>(0, 0);
            List<Pair<int, int>> inMaze = new List<Pair<int, int>>();
            inMaze.Add(startCell);
            while (inMaze.Count < graph.Count)
            {
                throw new NotImplementedException();
            }
            return graph;
        }
    }
}
