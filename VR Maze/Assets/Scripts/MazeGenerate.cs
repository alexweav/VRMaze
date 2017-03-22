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
            //DrawHardcodedMaze();
            DrawRandomMaze(15, 15);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Draws a randomly generated maze of the given size
        /// </summary>
        /// <param name="width">Width in cells</param>
        /// <param name="height">Height in cells</param>
        void DrawRandomMaze(int width, int height)
        {
            RandomMazeGenerator generator = new RandomMazeGenerator(width, height);
            Maze maze = generator.Generate();
            maze.Draw();
        }

        /// <summary>
        /// Draws a hardcoded test maze.
        /// </summary>
        /// <param name="maze1">The maze object to draw</param>
        void DrawHardcodedMaze()
        {
            Maze maze1 = new Maze("Maze 1"); //Intializes new Maze and Maze size
            maze1.SetXYZScale(.5f, 6, .5f);

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
            maze1.addMazeCell(2, 2, false, false);
            maze1.addMazeCell(3, 2, false, false);
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

            //Generates Maze
            maze1.Draw();
        }
    }
}