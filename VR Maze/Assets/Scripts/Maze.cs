using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Maze
    {
        GameObject ThisMaze;
        private Vector3 ThisMazeScale;
        private Vector3 ThisMazePosition;
        private List<MazeCell> CellsInMaze = new List<MazeCell>();
        private UndirectedGraph<Pair<int, int>> graph;
        private MazeDrawer Drawer;
        private string mazeName;


        public Maze(string MazeName)
        {
            mazeName = MazeName;
            ThisMaze = new GameObject(mazeName);
            ThisMazeScale = new Vector3(.5f, 10f, .5f);
            ThisMazePosition = new Vector3(0f, 0f, 0f);
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
            CellsInMaze.Add(currentCell);      //Adds mazeCell to list
        }

        /// <summary>
        /// Returns a list of CellsInMaze.  Needs to be Type Cast as List of Maze Cells when assigning to another variable
        /// </summary>
        public object CellInMaze
        {

            get
            {
                return CellsInMaze;
            }

        }

        /// <summary>
        /// MazeName(Set; Get;) method  
        /// </summary>
        public string MazeName
        {
            get
            {
                return mazeName;
            }

            set
            {
                mazeName = value;
            }
        }

        /// <summary>
        /// Allows Maze Scale to be change in the X,Y, and Z directions
        /// </summary>
        /// <param name="x"> x scale multiplier</param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetXYZScale(float x, float y, float z)
        {
            ThisMazeScale = new Vector3(x, y, z);
        }

        public bool ContainsCell(MazeCell cell)
        {
            foreach (var currentCell in CellsInMaze)
            {
                if (currentCell.Equals(cell))
                {
                    return true;
                }
            }
            return false;
        }
        public void SetXYZPosition(float x, float y, float z)
        {
            ThisMazePosition = new Vector3(x, y, z);
        }

        /// <summary>
        /// Draws maze using the Maze Drawer class
        /// </summary>
        public void Draw()
        {
            Drawer = new MazeDrawer(this);
            Drawer.drawMaze();
            ThisMaze.transform.localScale = ThisMazeScale;
            ThisMaze.transform.position = ThisMazePosition;
        }
    }
}