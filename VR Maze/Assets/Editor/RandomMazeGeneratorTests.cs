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
            RandomMazeGenerator generator = new RandomMazeGenerator();
            Maze maze = generator.generate(5, 6);
            Assert.AreEqual(maze.Graph.Count, 30);
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    Assert.IsTrue(maze.Graph.Contains(new Pair<int, int>(j, i)), i + ", " + j);
                }
            }
        }

        [Test]
        public void RandomMazeGeneratorTests_AllNodesHaveCorrectConnectionCount()
        {
            RandomMazeGenerator generator = new RandomMazeGenerator();
            Maze maze = generator.generate(5, 6);
            foreach(var node in maze.Graph)
            {
                Assert.IsTrue(maze.Graph.Neighbors(node).Count > 0);
                Assert.IsTrue(maze.Graph.Neighbors(node).Count < 5);
            }
        }
    }
}
