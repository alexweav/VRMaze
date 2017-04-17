using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// The developer test maze
    /// </summary>
    public class TestMaze : Maze
    {
        /// <summary>
        /// Construct the test maze
        /// </summary>
        public TestMaze()
        {
            addMazeCell(0, 0, true, true);
            addMazeCell(1, 0, false, true);
            addMazeCell(2, 0, false, true);
            addMazeCell(3, 0, false, true);
            addMazeCell(4, 0, true, true);

            //Row 2
            addMazeCell(0, 1, false, true);
            addMazeCell(1, 1, true, false);
            addMazeCell(2, 1, true, true);
            addMazeCell(3, 1, true, false);
            addMazeCell(4, 1, true, true);

            //Row 3
            addMazeCell(0, 2, true, true);
            addMazeCell(1, 2, true, true);
            addMazeCell(2, 2, false, false);
            addMazeCell(3, 2, false, false);
            addMazeCell(4, 2, true, true);

            //Row 4
            addMazeCell(0, 3, false, false);
            addMazeCell(1, 3, false, false);
            addMazeCell(2, 3, true, true);
            addMazeCell(3, 3, false, true);
            addMazeCell(4, 3, true, true);

            //Row 5
            addMazeCell(0, 4, true, true);
            addMazeCell(1, 4, true, true);
            addMazeCell(2, 4, true, true);
            addMazeCell(3, 4, true, false);
            addMazeCell(4, 4, true, true);

            this.StartCell = new Pair<int, int>(0, 0);
            this.FinishCell = new Pair<int, int>(4, 4);
        }
    }

    /// <summary>
    /// Generates the test maze
    /// </summary>
    public class TestMazeGenerator : MazeGenerator
    {
        /// <inheritdoc/>
        public override Maze Generate()
        {
            return new TestMaze();
        }
    }
}
