﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public abstract class Maze  
    {
        private MazeSpawnGOManager MSPM;
        public List<MazeCell> CellsInMaze = new List<MazeCell>();
        public GameObject MazeGO;
        private Pair<int, int> mazeSize;
        private Vector3 ThisMazeScale,ThisMazePosition;
        private MazeDrawer Drawer;
        private string mazeName;
        
        private MazeCell startCell;
        private MazeCell finishCell;
       

        

        /// <summary>
        /// adds a maze cell to a list to of maze cells to form a maze mazecells called DrawbleFormat to form a maze  
        /// </summary>
        /// <param name="x"> x cell position </param>
        /// <param name="z"> z cell position </param>
        /// <param name="eastPath"> bool value if an east path exist to another cell  </param>
        /// <param name="southPath"> bool value if a south path exist to another cell </param>
        public void addMazeCell(int x, int z, bool eastPath, bool southPath)  
        {
            //GameObject mazeCellGO = (GameObject)GameObject.Instantiate(Resources.Load("Maze Cell Templet"));
            MazeCell currentCell = new MazeCell(x, z, eastPath, southPath);  //Creates new mazeCell
            CellsInMaze.Add(currentCell);      //Adds mazeCell to list

            MazeSize = new Pair<int, int>(x , z );
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
        /// Gets and sets the start cell of the maze, in the form of a pair of ints representing the X and Z coordinates of the cell.
        /// </summary>
        public Pair<int, int> StartCell
        {
            get
            {
                if (startCell == null)
                {
                    return null;
                }
                return new Pair<int, int>(startCell.cellLocationX, startCell.cellLocationZ);
            }
            set
            {
                MazeCell cell = FindCellByCoordinates(value.First, value.Second);
                if (cell == null)
                {
                    throw new ArgumentException("The given cell is not in the maze.");
                }
                if (cell.Equals(finishCell))
                {
                    throw new ArgumentException("The start cell cannot be the same as the finish cell.");
                }
                startCell = cell;
                cell.StartCell = true;
            }
        }

        /// <summary>
        /// Gets and sets the finish cell of the maze, in the form of a pair of ints representing the X and Z coordinates of the cell.
        /// </summary>
        public Pair<int, int> FinishCell
        {
            get
            {
                if(finishCell == null)
                {
                    return null;
                }
                return new Pair<int, int>(finishCell.cellLocationX, finishCell.cellLocationZ);
            }
            set
            {
                MazeCell cell = FindCellByCoordinates(value.First, value.Second);
                if (cell == null)
                {
                    throw new ArgumentException("The given cell is not in the maze.");
                }
                if (cell.Equals(startCell))
                {
                    throw new ArgumentException("The finish cell cannot be the same as the start cell.");
                }
                finishCell = cell;
                cell.FinishCell = true;
            }
        }

        public Pair<int, int> MazeSize
        {
            get
            {
                return mazeSize;
            }

            set
            {
                mazeSize = new Pair<int,int>(value.First ,value.Second );
                //Debug.Log(mazeSize.First + " " + mazeSize.Second);
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

        /// <summary>
        /// Given coordinates, finds the corresponding MazeCell object if it exists.
        /// </summary>
        /// <param name="x">The x coordinate of the cell</param>
        /// <param name="z">The z coordinate of the cell</param>
        /// <returns>The cell, if it exists, or null otherwise</returns>
        private MazeCell FindCellByCoordinates(int x, int z)
        {
            foreach(var cell in CellsInMaze)
            {
                if (cell.cellLocationX == x && cell.cellLocationZ == z)
                {
                    return cell;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets XYZ Position of the maze
        /// </summary>
        /// <param name="x"> x position</param>
        /// <param name="y"> y position</param>
        /// <param name="z"> z position</param>
        public void SetXYZPosition(float x, float y, float z)
        {
            ThisMazePosition = new Vector3(x, y, z);
        }

        /// <summary>
        /// Draws maze using the Maze Drawer class
        /// </summary>
        public void Draw()
        {
            if (startCell == null)
            {
                throw new InvalidOperationException("The maze has no defined start cell.");
            }
            if (finishCell == null)
            {
                throw new InvalidOperationException("The maze has no defined finish cell.");
            }

            setStartandFinishCells();

            MazeGO = new GameObject(mazeName);
            Drawer = new MazeDrawer(this);

           

            Drawer.drawMaze();
            updateMazeGOProperties();
            SpawnAllGO();

        }

        

        /// <summary>
        /// Update Scale and Position of a maze
        /// </summary>
        public void updateMazeGOProperties()
        {
            MazeSize = new Pair<int, int>(CellsInMaze[CellsInMaze.Count - 1].cellLocationX + 1, CellsInMaze[CellsInMaze.Count - 1].cellLocationZ + 1);
            MazeGO.transform.localScale = ThisMazeScale;
            MazeGO.transform.position = ThisMazePosition;
            MazeGO.name = mazeName;
            
            
        }

        /// <summary>
        /// Spawns Player in designatecell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name ="objectToSpawn"></param>
      
        public void setStartandFinishCells()
        {
            this.StartCell = new Pair<int, int>(0, 0);
            this.FinishCell = new Pair<int, int>(this.MazeSize.First, this.MazeSize.Second);
           // Debug.Log(this.StartCell);
            //Debug.Log(this.finishCell);
        }
        public void UpdateMainPlayerIconPOS()
        {
            MSPM.UpdateMainPlayerIconPOS();
        }
        public void SpawnAllGO()
        {
            this.MSPM.SpawnAllGO();
        }

        public void hideAllCellsParts()
        {
            foreach (Transform MazeCellChild in this.MazeGO.transform)
            {
                foreach (Transform MazeCellPartChild in MazeCellChild.transform)
                {
                    MazeCellPartChild.gameObject.SetActive(false);
                }

                MazeCellChild.gameObject.SetActive(false);
            }

        }

        /// <summary>
        /// Method for Intializing a maze.  Sets the hieght, scale, and name for the maze.
        /// </summary>
        /// <param name="MazeName">Name of the maze</param>
        protected void IntializeMaze(string MazeName)
        {
            mazeName = MazeName;
     
            ThisMazeScale = new Vector3(.5f, 10f, .5f);
            ThisMazePosition = new Vector3(0f, 0f, 0f);
            this.MSPM = new MazeSpawnGOManager(this);

        }

       
    }
}


