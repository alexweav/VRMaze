using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Scripts;

namespace Assets.Scripts.Tests
{
    public class GraphNodeTests
    {
        [Test]
        public void GraphNodeTests_ConstructorTest()
        {
            int item = 5;
            GraphNode<int> node = new GraphNode<int>(item);
            Assert.AreEqual(node.Data, item);
            Assert.IsEmpty(node.Neighbors);
        }

        [Test]
        public void GraphNodeTests_ChangeDataTest()
        {
            int item1 = 5;
            int item2 = 10;
            GraphNode<int> node = new GraphNode<int>(item1);
            Assert.AreEqual(node.Data, item1);
            node.Data = item2;
            Assert.AreEqual(node.Data, item2);
        }

        [Test]
        public void GraphNodeTests_NeighborsTest()
        {
            int item1 = 5;
            int item2 = 10;
            GraphNode<int> node1 = new GraphNode<int>(item1);
            GraphNode<int> node2 = new GraphNode<int>(item2);
            Assert.IsEmpty(node1.Neighbors);
            Assert.IsEmpty(node2.Neighbors);
            node1.AddNeighbor(node2);
            Assert.AreEqual(node1.Neighbors.Count, 1);
            Assert.IsEmpty(node2.Neighbors);
            Assert.AreEqual(node1.Neighbors[0], node2);
            node2.AddNeighbor(node1);
            Assert.AreEqual(node1.Neighbors.Count, 1);
            Assert.AreEqual(node2.Neighbors.Count, 1);
            Assert.AreEqual(node1.Neighbors[0], node2);
            Assert.AreEqual(node2.Neighbors[0], node1);
            //Ensure that object references are properly set
            Assert.AreEqual(node1.Neighbors[0].Neighbors[0], node1);
            Assert.AreEqual(node2.Neighbors[0].Neighbors[0], node2);
        }
    }
}
