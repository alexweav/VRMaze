using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Maze : MonoBehaviour
    {
        private List<MazeCell> CellsInMaze = new List<MazeCell>();
        private MazeDrawer Drawer;

        public Maze()
        {
            
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

        public object cellinMaze
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