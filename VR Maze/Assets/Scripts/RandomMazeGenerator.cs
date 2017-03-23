using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Randomly generates mazes
    /// </summary>
    public class RandomMazeGenerator : MazeGenerator
    {
        private int width;
        private int height;

        public RandomMazeGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override Maze Generate()
        {
            UndirectedGraph<Pair<int, int>> graph = CreateUnconnectedGridGraph(this.width, this.height);
            graph = BuildRandomGridSpanningTree(graph);
            RandomMaze maze = new RandomMaze(graph);
            return maze;
        }

        /// <summary>
        /// Creates an undirected graph of ints in the shape of a grid, where no nodes have connections
        /// </summary>
        /// <param name="width">Width of the grid</param>
        /// <param name="height">Height of the grid</param>
        /// <returns>The graph</returns>
        private UndirectedGraph<Pair<int, int>> CreateUnconnectedGridGraph(int width, int height)
        {
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

        /// <summary>
        /// Builds a random spanning tree out of an unconnected grid-shaped graph
        /// </summary>
        /// <param name="graph">The unconnected graph</param>
        /// <returns>The spanning tree</returns>
        private UndirectedGraph<Pair<int, int>> BuildRandomGridSpanningTree(UndirectedGraph<Pair<int, int>> graph)
        {
            var startCell = new Pair<int, int>(0, 0);
            List<Pair<int, int>> inMaze = new List<Pair<int, int>>();
            inMaze.Add(startCell);
            while (inMaze.Count < graph.Count)
            {
                List<GridEdge> candidateEdges = FindCandidateEdges(graph, inMaze);
                var random = new Random();
                int chosenIndex = random.Next(candidateEdges.Count);
                graph.AddEdge(candidateEdges[chosenIndex].Cell1, candidateEdges[chosenIndex].Cell2);
                inMaze.Add(candidateEdges[chosenIndex].Cell2);
            }
            return graph;
        }

        /// <summary>
        /// Finds candidate edges to be added in randomized prim's algorithm
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <param name="inMaze">Nodes in the graph that are already connected to the spanning tree</param>
        /// <returns>All edges that can be added such that the graph remains acyclic</returns>
        private List<GridEdge> FindCandidateEdges(UndirectedGraph<Pair<int, int>> graph, List<Pair<int, int>> inMaze)
        {
            List<GridEdge> candidates = new List<GridEdge>();
            foreach (var node in inMaze)
            {
                Pair<int, int> upNode = new Pair<int, int>(node.First - 1, node.Second);
                Pair<int, int> downNode = new Pair<int, int>(node.First + 1, node.Second);
                Pair<int, int> leftNode = new Pair<int, int>(node.First, node.Second - 1);
                Pair<int, int> rightNode = new Pair<int, int>(node.First, node.Second + 1);
                if (IsValidEdgeAddition(node, upNode, graph, inMaze))
                {
                    candidates.Add(new GridEdge(node, upNode));
                }
                if (IsValidEdgeAddition(node, downNode, graph, inMaze))
                {
                    candidates.Add(new GridEdge(node, downNode));
                }
                if (IsValidEdgeAddition(node, leftNode, graph, inMaze))
                {
                    candidates.Add(new GridEdge(node, leftNode));
                }
                if (IsValidEdgeAddition(node, rightNode, graph, inMaze))
                {
                    candidates.Add(new GridEdge(node, rightNode));
                }
            }
            return candidates;
        }

        /// <summary>
        /// Determines if an edge connection can be done in randomized prim's algorithm
        /// </summary>
        /// <param name="from">Node 1 of the connection</param>
        /// <param name="to">Node 2 of the connection</param>
        /// <param name="graph">The graph</param>
        /// <param name="inMaze">Nodes of the graph which are already part of the spanning tree</param>
        /// <returns></returns>
        private bool IsValidEdgeAddition(Pair<int, int> from, Pair<int, int> to, UndirectedGraph<Pair<int, int>> graph, List<Pair<int, int>> inMaze)
        {
            if (!graph.Contains(from) || !graph.Contains(to))
            {
                return false;
            }
            return inMaze.Contains(from) && !inMaze.Contains(to);
        }

        /// <summary>
        /// Locally represents an edge of a grid-shaped graph as a pair of pairs, for the purpose of shortening code in this class
        /// </summary>
        private class GridEdge
        {
            public GridEdge(Pair<int, int> cell1, Pair<int, int> cell2)
            {
                this.Cell1 = cell1;
                this.Cell2 = cell2; 
            }

            public Pair<int, int> Cell1{get; set;}
            public Pair<int, int> Cell2 { get; set; }
        }
    }
}
