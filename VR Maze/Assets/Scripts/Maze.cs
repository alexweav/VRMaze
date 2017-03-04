using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Maze
    {
        private UndirectedGraph<Pair<int, int>> graph;
        private List<MazeCell> cellsInMaze = new List<MazeCell>();
        private MazeDrawer Drawer;

        public Maze()
        {
            
        }

        /// <summary>
        /// Constructs a maze from a grid-shaped graph. Passageways between cells are connections in the graph.
        /// </summary>
        /// <param name="graph">The grid-shaped graph</param>
        public Maze(UndirectedGraph<Pair<int, int>> graph)
        {
            this.graph = graph;
            foreach(var node in graph)
            {
                Pair<int, int> southNode = new Pair<int, int>(node.First + 1, node.Second);
                Pair<int, int> eastNode = new Pair<int, int>(node.First, node.Second + 1);
                bool southPath = graph.Contains(southNode) && graph.AreConnected(node, southNode);
                bool eastPath = graph.Contains(eastNode) && graph.AreConnected(node, eastNode);
                addMazeCell(node.Second, node.First, eastPath, southPath);
            }
        }

        /// <summary>
        /// adds a maze cell to a list to of maze cells to form a maze mazecells called DrawbleFormat to form a maze  
        /// </summary>
        /// <param name="x"> x cell position </param>
        /// <param name="z"> z cell position </param>
        /// <param name="eastPath"> bool value if an east path exist to another cell  </param>
        /// <param name="southPath"> bool value if a south path exist to another cell </param>
        public void addMazeCell(int x, int z, bool eastPath, bool southPath)
        {
            MazeCell currentCell = new MazeCell(x, z, southPath, eastPath);  //Creates new mazeCell
            cellsInMaze.Add(currentCell);      //Adds mazeCell to list
        }

        public List<MazeCell> CellsInMaze
        {

            get
            {
                return CellsInMaze;
            }

        }

        /// <summary>
        /// Draws maze using the Maze Drawer class
        /// </summary>
        public void Draw()
        {
            Drawer = new MazeDrawer(this);
            Drawer.drawMaze();
        }
    }
}