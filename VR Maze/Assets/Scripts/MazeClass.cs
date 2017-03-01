using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class Maze : MazeGenerate
    {

        List<MazeCell> mazeCellList = new List<MazeCell>();

        GameObject totalMaze;
        //private string mazeName;
        private int MazeSizeX;
        private int MazeSizeZ;


        //Constructor: 0 arguments
        public Maze()
        {
            MazeSizeX = 0; //Sets maze size x
            MazeSizeZ = 0; //Sets maze size z

        }

        //Maze Constructor: 2 arguments
        public Maze(int mazeSizeX, int mazeSizeZ)
        {
            MazeSizeX = mazeSizeX; //Set maze dimision x 
            MazeSizeZ = mazeSizeZ; //Set maze dimision z
            totalMaze = new GameObject("Maze");

        }

        //Creates and adds a maze cell to a list of mazeCells  
        public void addMazeCell(int x, int z, bool eastPath, bool southPath)
        {
            MazeCell currentCell = new MazeCell(x, z, southPath, eastPath);  //Creates new mazeCell
            mazeCellList.Add(currentCell);      //Adds mazeCell to list
        }

        //Generates the Maze: Generates Interior of Maze, then the remaining borders
        public void generateMaze()
        {
            generateInnerOfMaze(); //Method Call to generate the inside of a maze
            generateBorderOfMaze(); //Method Call to generate the border of a maze
        }

        //Generates the Interior of the maze
        private void generateInnerOfMaze()
        {
            //Intialize Empty Game Object cell
            GameObject cell;


            for (int count = 0; count < mazeCellList.Count; count++)
            {
                //Creates an empty parent game object cell which contains the path walls and cell floor for each cell
                cell = new GameObject("Maze Cell (" + mazeCellList[count].cellLocationX.ToString() + "," + mazeCellList[count].cellLocationZ.ToString() + ")");

                //Creates the position for the wall also passes the cell game object the walls are associated
                positionWall(mazeCellList[count].cellLocationX, mazeCellList[count].cellLocationZ, true, mazeCellList[count].EastPath, mazeCellList[count].SouthPath, true, cell);

                //Generates the Floor for the current cell and passes the cell game object the floor walls are associated with
                generateFloor((mazeCellList[count].cellLocationX * 10) - 25, 25 - (mazeCellList[count].cellLocationZ * 10), cell);
            }
        }

        private void generateBorderOfMaze()
        {
            GameObject border;
            border = new GameObject("Maze Border");

            //Generate North Borders
            foreach (MazeCell cell in mazeCellList)
            {

                //Generates North Borders in maze
                if (mazeCellList.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1)) == false)
                    positionWall(cell.cellLocationX, cell.cellLocationZ, false, true, true, true, border);

                //Generates East Borders in maze
                if (mazeCellList.Exists(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ)) == false)
                    positionWall(cell.cellLocationX, cell.cellLocationZ, true, false, true, true, border);

                //Generates South Borders in maze
                if (mazeCellList.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1)) == false)
                    positionWall(cell.cellLocationX, cell.cellLocationZ, true, true, false, true, border);

                //Generates West Borders in maze
                if (mazeCellList.Exists(x => (x.cellLocationX == cell.cellLocationX - 1) && (x.cellLocationZ == cell.cellLocationZ)) == false)
                    positionWall(cell.cellLocationX, cell.cellLocationZ, true, true, true, false, border);
            }


        }


        private void positionWall(float x, float z, bool northPath, bool eastPath, bool southPath, bool westPath, GameObject cell)
        {

            Vector3 scaleV = new Vector3(0, 0, 0);
            Vector3 posV = new Vector3(0, 0, 0);

            x = ((x * 10) - 25);//(gameObject.transform.lossyScale).x);
            z = (25 - (z * 10)); //(gameObject.transform.lossyScale).z);  

            //Creates a wall if a north path does not exist
            if (northPath == false)
            {
                scaleV = new Vector3(11f, 2, 1);
                posV = new Vector3(x + 5, 1, z);
                generateWall(posV, scaleV, cell, "North Wall");

            }

            //Creates a wall if a east path does not exist
            if (eastPath == false)
            {
                scaleV = new Vector3(1, 2, 11f);
                posV = new Vector3(x + 10f, 1, z - 5f);
                generateWall(posV, scaleV, cell, "East Wall");
            }

            //Creates a wall if a south path does not exist
            if (southPath == false)
            {
                scaleV = new Vector3(11f, 2, 1);
                posV = new Vector3(x + 5f, 1, z - 10);
                generateWall(posV, scaleV, cell, "South Wall");
            }

            //Creates a wall if a West path does not exist
            if (westPath == false)
            {
                scaleV = new Vector3(1, 2, 11f);
                posV = new Vector3(x, 1, z - 5);
                generateWall(posV, scaleV, cell, "West Wall");
            }


        }
        //Generates a wall given a Vector3 position and Vector3 scale
        //Also assigns the created wall game object to the pass cell and names the wall based on the passed string 
        public void generateWall(Vector3 position, Vector3 scale, GameObject cell, string wallName)
        {
			GameObject wall = GameObject.Instantiate((GameObject)Resources.Load("Wall-Prefab"));
			//GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.name = wallName;
            wall.SetActive(true);
            wall.transform.position = position;
            wall.transform.localScale = scale;
            wall.transform.parent = cell.transform;
            cell.transform.SetParent(totalMaze.transform);
        }

        //Creates a floor for a cell given a (x,z) coordinate
        //Assigns the created floor game abject to the passed cell
        public void generateFloor(float x, float z, GameObject cell)
        {
			GameObject mazeFloor = GameObject.Instantiate((GameObject)Resources.Load("Cell Floor-Prefab"));
            //GameObject mazeFloor = GameObject.CreatePrimitive(PrimitiveType.Plane);
            mazeFloor.name = "Cell Floor";
            mazeFloor.SetActive(true);
            mazeFloor.transform.position = new Vector3(x + 5, 0, z - 5);
            mazeFloor.transform.localScale = new Vector3(1, 1, 1);
            mazeFloor.transform.parent = cell.transform;
            cell.transform.SetParent(totalMaze.transform);
        }
    }
}
