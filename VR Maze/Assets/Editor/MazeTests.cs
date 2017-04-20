using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts;
using System;

namespace Assets.Scripts.Tests {

    public class MazeTests {

        private class EmptyTestMaze : Maze
        {
        }

        private class EmptyTestMazeGenerator : MazeGenerator
        {
            public override Maze Generate()
            {
                return new EmptyTestMaze();
            }
        }

        [Test]
        public void MazeTests_NewMazeEmpty() {
            MazeGenerator generator = new EmptyTestMazeGenerator();
            Maze maze = generator.Generate();
            Assert.IsEmpty(maze.CellsInMaze);
        }

        private class HardcodedTestMaze : Maze
        {
            public HardcodedTestMaze()
            {
                addMazeCell(1, 1, false, true);
                addMazeCell(2, 1, true, true);
                addMazeCell(3, 1, false, false);
                addMazeCell(1, 2, false, true);
                addMazeCell(2, 2, true, true);
                addMazeCell(3, 2, false, true);
                addMazeCell(1, 3, true, false);
                addMazeCell(2, 3, false, false);
                addMazeCell(3, 3, false, false);
            }
        }

        public class HardcodedTestMazeGenerator : MazeGenerator
        {
            public override Maze Generate()
            {
                return new HardcodedTestMaze();
            }
        }

        [Test]
        public void MazeTests_AddCellsHardcodedMethodTest()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();         
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
            Maze maze = new RandomMaze(graph);
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
        public void MazeTests_StartCellTest()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            Assert.IsNull(maze.StartCell);
            maze.StartCell = new Pair<int, int>(1, 1);
            Assert.AreEqual(maze.StartCell, new Pair<int, int>(1, 1));
            maze.StartCell = new Pair<int, int>(2, 3);
            Assert.AreEqual(maze.StartCell, new Pair<int, int>(2, 3));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeTests_StartCellInMaze()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.StartCell = new Pair<int, int>(4, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeTests_FinishCellInMaze()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.FinishCell = new Pair<int, int>(4, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeTests_StartCellNotFinishCell()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.FinishCell = new Pair<int, int>(1, 1);
            maze.StartCell = new Pair<int, int>(1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeTests_FinishCellNotStartCell()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.StartCell = new Pair<int, int>(1, 1);
            maze.FinishCell = new Pair<int, int>(1, 1);
        }

        [Test]
        public void MazeTests_FinishCellTest()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            Assert.IsNull(maze.FinishCell);
            maze.FinishCell = new Pair<int, int>(1, 1);
            Assert.AreEqual(maze.FinishCell, new Pair<int, int>(1, 1));
            maze.FinishCell = new Pair<int, int>(2, 3);
            Assert.AreEqual(maze.FinishCell, new Pair<int, int>(2, 3));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MazeTests_MazeWithoutStartNotDrawable()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.FinishCell = new Pair<int, int>(1, 1);
            maze.Draw();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MazeTests_MazeWithoutFinishNotDrawable()
        {
            MazeGenerator generator = new HardcodedTestMazeGenerator();
            Maze maze = generator.Generate();
            maze.StartCell = new Pair<int, int>(1, 1);
            maze.Draw();
        }
    }
}
