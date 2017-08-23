using System;
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures graph algorithms operate correctly
    [TestFixture]
    public class GraphTest
    {
        private static readonly Node A = new Node();
        private static readonly Node B = new Node();
        private static readonly Node C = new Node();
        private static readonly Node D = new Node();
        private static readonly Node E = new Node();
        private static readonly Node F = new Node();
        private static readonly Node G = new Node();

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            B.To(A, 6);
            B.To(C, 7).To(D, 1).To(E, 2).To(B, 3).To(F, 4);
            C.To(D, 5);
            C.To(E, 8);
        }

        [Test]
        public void CanReach()
        {
            Assert.IsTrue(A.CanReach(A));
            Assert.IsTrue(B.CanReach(A));
            Assert.IsFalse(A.CanReach(B));
            Assert.IsTrue(B.CanReach(F));
            Assert.IsTrue(C.CanReach(F));
            Assert.IsFalse(G.CanReach(B));
            Assert.IsFalse(B.CanReach(G));
        }

        [Test]
        public void HopCount()
        {
            Assert.AreEqual(0, A.HopCount(A));
            Assert.AreEqual(1, B.HopCount(A));
            Assert.AreEqual(1, B.HopCount(F));
            Assert.AreEqual(3, C.HopCount(F));
            Assert.Throws<InvalidOperationException>(delegate { A.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.HopCount(G); });
        }

        [Test]
        public void Cost()
        {
            Assert.AreEqual(0, A.Cost(A));
            Assert.AreEqual(6, B.Cost(A));
            Assert.AreEqual(4, B.Cost(F));
            Assert.AreEqual(10, C.Cost(F));
            Assert.Throws<InvalidOperationException>(delegate { A.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.Cost(G); });
        }

        
        [Test]
        public void Path()
        {
            Assert.AreEqual(6, B.Path(A).Cost());
            Assert.AreEqual(1, B.Path(A).HopCount());
            Assert.AreEqual(10, C.Path(F).Cost());
            Assert.AreEqual(4, C.Path(F).HopCount());
        }

        [Test]
        public void Paths()
        {
            Assert.AreEqual(1, G.Paths(G).Count);
            Assert.AreEqual(1, B.Paths(A).Count);
            Assert.AreEqual(1, B.Paths(C).Count);
            Assert.AreEqual(2, B.Paths(D).Count);
            Assert.AreEqual(3, B.Paths(E).Count);
            Assert.AreEqual(1, B.Paths(F).Count);
            Assert.AreEqual(0, B.Paths(G).Count);
        }
    }
}
