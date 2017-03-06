using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts;

namespace Assets.Scripts.Tests {

    public class MazeTests {

        [Test]
        public void MazeTests_NewMazeEmpty() {
            Maze maze = new Maze("Maze");
            Assert.IsEmpty(maze.CellsInMaze);
        }

        [Test]
        public void MazeTests_AddCellsHardcodedMethodTest()
        {
            Maze maze = new Maze("Maze");
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

        [Test]
        public void MazeTests_AddCellsGraphMethodTest()
        {
            UndirectedGraph<Pair<int, int>> graph = new UndirectedGraph<Pair<int, int>>();
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    graph.AddNode(new Pair<int, int>(i, j));
                }
            }
            graph.AddEdge(new Pair<int, int>(1, 1), new Pair<int, int>(2, 1));
            graph.AddEdge(new Pair<int, int>(2, 1), new Pair<int, int>(3, 1));
            graph.AddEdge(new Pair<int, int>(3, 1), new Pair<int, int>(3, 2));
            graph.AddEdge(new Pair<int, int>(3, 2), new Pair<int, int>(2, 2));
            graph.AddEdge(new Pair<int, int>(2, 2), new Pair<int, int>(1, 2));
            graph.AddEdge(new Pair<int, int>(1, 2), new Pair<int, int>(1, 3));
            graph.AddEdge(new Pair<int, int>(2, 2), new Pair<int, int>(2, 3));
            graph.AddEdge(new Pair<int, int>(2, 3), new Pair<int, int>(3, 3));
            Maze maze = new Maze(graph);
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
