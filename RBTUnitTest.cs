using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBTree;

namespace RBTreeUnitTests
{
    [TestClass]
    public class RBTUnitTest
    {
        [TestMethod]
        public void CheckCleansingTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 5; i++)
                tree.Insert(i);
            Assert.AreEqual(false, tree.IsEmpty());
            tree.Clear();
            Assert.AreEqual(true, tree.IsEmpty());
        }

        [TestMethod]
        public void CheckInsertString()
        {
            RedBlackTree<string> tree = new RedBlackTree<string>();
            tree.Insert("a");
            tree.Insert("b");
            tree.Insert("c");
            tree.Insert("d");
            Assert.AreEqual("a", tree.Find("a").Key);
            Assert.AreEqual("d", tree.Find("d").Key);
        }

        [TestMethod]
        public void CheckDeleteString()
        {
            RedBlackTree<string> tree = new RedBlackTree<string>();
            tree.Insert("a");
            tree.Insert("b");
            tree.Insert("c");
            tree.Insert("d");
            tree.Delete("d");
            Assert.AreEqual(null, tree.Find("d"));
        }
		
	[TestMethod]
        public void CheckInsertInteger()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 5; i++)
                tree.Insert(i);
            Assert.AreEqual(0, tree.Find(0).Key);
            Assert.AreEqual(4, tree.Find(4).Key);
        }

        [TestMethod]
        public void CheckDeleteInteger()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 5; i++)
                tree.Insert(i);
            tree.Delete(4);
            Assert.AreEqual(null, tree.Find(4));
        }
		
	[TestMethod]
	public void CheckColoring()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 3; i++)
                tree.Insert(i);
            Assert.AreEqual("B", tree.Root.Color);
            Assert.AreEqual("R", tree.Root.LeftChild.Color);
            Assert.AreEqual("R", tree.Root.RightChild.Color);
        }

	[TestMethod]
	public void CheckInserting()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 3; i++)
                tree.Insert(i);
            Assert.AreEqual(1, tree.Root.Key);
            Assert.AreEqual(0, tree.Root.LeftChild.Key);
            Assert.AreEqual(2, tree.Root.RightChild.Key);
        }
		
        [TestMethod]
        public void CheckSearching()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            for (int i = 0; i < 10; i++)
                tree.Insert(i);
            Assert.AreEqual(7, tree.FindNext(6).Key);
            Assert.AreEqual(5, tree.FindPrevious(6).Key);
            Assert.AreEqual(null, tree.FindNext(9));
            Assert.AreEqual(0, tree.FindPrevious(0).Key);
        }	
    }
}
