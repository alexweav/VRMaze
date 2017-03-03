using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Maze : MonoBehaviour
    {
        private List<MazeCell> cellsInMaze = new List<MazeCell>();
        private MazeDrawer Drawer;
        private Vector3 ScaleVectorMultiplier;
        private string mazeName;

        public Maze()
        {
            ScaleVectorMultiplier = new Vector3(1f, 1f, 1f);
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

        /// <summary>
        /// Returns a list of CellsInMaze.  Needs to be Type Cast as List of Maze Cells when assigning to another variable
        /// </summary>
        public object CellInMaze
        {

            get
            {
                return cellsInMaze;
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
        public void SetXYZMazeScale(int x, int y, int z)
        {
           ScaleVectorMultiplier = new Vector3(x, y, z);
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