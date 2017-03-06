using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class MazeGenerate : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

            Maze maze1 = new Maze(); //Intializes new Maze and Maze size

            //This portion adds a cell for each position in the mmaze

            //Row 1 cell

            
            maze1.addMazeCell(0, 0, true, true);
            maze1.addMazeCell(1, 0, false, true);
            maze1.addMazeCell(2, 0, false, true);
            maze1.addMazeCell(3, 0, false, true);
            maze1.addMazeCell(4, 0, true, true);


            //Row 2
            maze1.addMazeCell(0, 1, false, true);
            maze1.addMazeCell(1, 1, true, false);
            maze1.addMazeCell(2, 1, true, true);
            maze1.addMazeCell(3, 1, true, false);
            maze1.addMazeCell(4, 1, true, true);

            //Row 3
            maze1.addMazeCell(0, 2, true, true);
            maze1.addMazeCell(1, 2, true, true);
            //maze1.addMazeCell (2, 2, false, false);
            //maze1.addMazeCell (3, 2, false, false);
            maze1.addMazeCell(4, 2, true, true);

            //Row 4
            maze1.addMazeCell(0, 3, false, false);
            maze1.addMazeCell(1, 3, false, false);
            maze1.addMazeCell(2, 3, true, true);
            maze1.addMazeCell(3, 3, false, true);
            maze1.addMazeCell(4, 3, true, true);

            //Row 5
            maze1.addMazeCell(0, 4, true, true);
            maze1.addMazeCell(1, 4, true, true);
            maze1.addMazeCell(2, 4, true, true);
            maze1.addMazeCell(3, 4, true, false);
            maze1.addMazeCell(4, 4, true, true);

            //Addition Test Rows 
            maze1.addMazeCell(5, 5, true, true);

            maze1.addMazeCell(6, 6, true, true);
            

            //Generates Maze
            maze1.Draw();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}