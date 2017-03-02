using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Scripts;

namespace Assets.Scripts.Tests
{
    public class UndirectedGraphTests
    {

        [Test]
        public void UndirectedGraphTests_EmptyConstructorTest()
        {
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            Assert.AreEqual(graph.Count, 0);
        }

        [Test]
        public void UndirectedGraphTests_AddNodeTest()
        {
            int item1 = 5;
            int item2 = 10;
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            Assert.IsFalse(graph.Contains(item1));
            Assert.IsFalse(graph.Contains(item2));
            graph.AddNode(item1);
            Assert.IsTrue(graph.Contains(item1));
            Assert.IsFalse(graph.Contains(item2));
            graph.AddNode(item2);
            Assert.IsTrue(graph.Contains(item1));
            Assert.IsTrue(graph.Contains(item2));
        }

        [Test]
        public void UndirectedGraphTests_AddEdgeTest()
        {
            int item1 = 5;
            int item2 = 10;
            int item3 = -2;
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            graph.AddNode(item1);
            graph.AddNode(item2);
            graph.AddNode(item3);
            Assert.AreEqual(graph.Count, 3);
            Assert.IsFalse(graph.AreConnected(item1, item2));
            Assert.IsFalse(graph.AreConnected(item1, item3));
            Assert.IsFalse(graph.AreConnected(item2, item3));
            graph.AddEdge(item1, item2);
            Assert.IsTrue(graph.AreConnected(item1, item2));
            Assert.IsFalse(graph.AreConnected(item1, item3));
            Assert.IsFalse(graph.AreConnected(item2, item3));
            graph.AddEdge(item1, item3);
            Assert.IsTrue(graph.AreConnected(item1, item2));
            Assert.IsTrue(graph.AreConnected(item1, item3));
            Assert.IsFalse(graph.AreConnected(item2, item3));
            graph.AddEdge(item2, item3);
            Assert.IsTrue(graph.AreConnected(item1, item2));
            Assert.IsTrue(graph.AreConnected(item1, item3));
            Assert.IsTrue(graph.AreConnected(item2, item3));
            Assert.IsFalse(graph.AreConnected(item1, item1));
            graph.AddEdge(item1, item1);
            Assert.IsTrue(graph.AreConnected(item1, item1));
        }
    }
}
