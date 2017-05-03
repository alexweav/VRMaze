using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Assets.Scripts.Tests
{
    public class RandomMazeGeneratorTests
    {
        [Test]
        public void RandomMazeGeneratorTests_GraphHasCorrectNodes()
        {
            RandomMazeGenerator generator = new RandomMazeGenerator(5, 6);
            RandomMaze maze = generator.Generate() as RandomMaze;
            Assert.AreEqual(maze.Graph.Count, 30);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Assert.IsTrue(maze.Graph.Contains(new Pair<int, int>(j, i)), i + ", " + j);
                }
            }
        }

        [Test]
        public void RandomMazeGeneratorTests_AllNodesHaveCorrectConnectionCount()
        {
            RandomMazeGenerator generator = new RandomMazeGenerator(5, 6);
            RandomMaze maze = generator.Generate() as RandomMaze;
            foreach (var node in maze.Graph)
            {
                Assert.IsTrue(maze.Graph.Neighbors(node).Count > 0, "Actual count: "+ maze.Graph.Neighbors(node).Count);
                Assert.IsTrue(maze.Graph.Neighbors(node).Count < 5, "Actual count: "+ maze.Graph.Neighbors(node).Count);
            }
        }

        [Test]
        public void RandomMazeGeneratorTests_StartCellUpperLeft()
        {
            RandomMazeGenerator generator = new RandomMazeGenerator(5, 6);
            Maze maze = generator.Generate();
            Assert.AreEqual(maze.StartCell, new Pair<int, int>(0, 0));
        }

        [Test]
        public void RandomMazeGeneratorTests_FinishCellBottomRight()
        {
            RandomMazeGenerator generator = new RandomMazeGenerator(5, 6);
            Maze maze = generator.Generate();
            Assert.AreEqual(maze.FinishCell, new Pair<int, int>(4, 5));
        }
    }
}
