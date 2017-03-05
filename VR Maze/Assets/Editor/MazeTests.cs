using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace Assets.Scripts.Tests {

    public class MazeTests {

        [Test]
        public void MazeTests_NewMazeEmpty() {
            Maze maze = new Maze();
            Assert.IsEmpty(maze.CellsInMaze);
        }

        [Test]
        public void MazeTests_AddCellsHardcodedMethodTest()
        {
            Maze maze = new Maze();
            Assert.IsEmpty(maze.CellsInMaze);
            maze.addMazeCell(1, 1, false, true);
            maze.addMazeCell(2, 1, true, true);
            maze.addMazeCell(3, 1, false, false);
            maze.addMazeCell(1, 2, false, true);
            maze.addMazeCell(2, 2, true, true);
            maze.addMazeCell(3, 2, false, true);
            maze.addMazeCell(1, 3, true, false);
            maze.addMazeCell(2, 3, false, false);
            maze.addMazeCell(3, 3, false, false);
            Assert.AreEqual(maze.CellsInMaze.Count, 9);
            Assert.IsTrue(maze.ContainsCell(new MazeCell(1, 1, false, true)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(2, 1, true, true)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(3, 1, false, false)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(1, 2, false, true)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(2, 2, true, true)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(3, 2, false, true)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(1, 3, true, false)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(2, 3, false, false)));
            Assert.IsTrue(maze.ContainsCell(new MazeCell(3, 3, false, false)));
        }
    }
}
