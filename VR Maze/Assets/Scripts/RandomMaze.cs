using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RandomMaze : Maze
    {
        private UndirectedGraph<Pair<int, int>> graph;

        /// <summary>
        /// Constructs a maze from a grid-shaped graph. Passageways between cells are connections in the graph.
        /// </summary>
        /// <param name="graph">The grid-shaped graph</param>
        public RandomMaze(UndirectedGraph<Pair<int, int>> graph)
        {
            base.IntializeMaze("Maze");
            this.graph = graph;
            foreach (var node in graph)
            {
                Pair<int, int> southNode = new Pair<int, int>(node.First + 1, node.Second);
                Pair<int, int> eastNode = new Pair<int, int>(node.First, node.Second + 1);
                bool southPath = graph.Contains(southNode) && graph.AreConnected(node, southNode);
                bool eastPath = graph.Contains(eastNode) && graph.AreConnected(node, eastNode);
                addMazeCell(node.Second, node.First, eastPath, southPath);
            }
        }

        public UndirectedGraph<Pair<int, int>> Graph
        {
            get
            {
                return this.graph;
            }
        }
    }
}
