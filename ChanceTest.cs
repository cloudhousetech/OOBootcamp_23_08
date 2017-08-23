/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Probability operates correctly
    [TestFixture]
    public class ChanceTest
    {
        [Test]
        public void Valid()
        {
            Assert.Throws<ArgumentException>(() => new Probability(-0.1));
            Assert.Throws<ArgumentException>(() => new Probability(1.1));
        }

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Probability(0.75), new Probability(0.75));
            Assert.AreNotEqual(new Probability(0.75), new object());
            Assert.AreNotEqual(new Probability(0.75), null);
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Probability(0.75).GetHashCode(), new Probability(0.75).GetHashCode());
        }

        [Test]
        public void Not()
        {
            Assert.AreEqual(new Probability(0.75), new Probability(0.25).Not());
        }

        [Test]
        public void And()
        {
            Assert.AreEqual(new Probability(0.2), new Probability(0.25).And(new Probability(0.8)));
            Assert.AreEqual(new Probability(1), new Probability(1).And(new Probability(1)));
            Assert.AreEqual(new Probability(0), new Probability(0).And(new Probability(0)));
        }

        [Test]
        public void Or()
        {
            Assert.AreEqual(new Probability(0.75), new Probability(0.5).Or(new Probability(0.5)));
            Assert.AreEqual(new Probability(0.875), new Probability(0.5).Or(new Probability(0.5).Or(new Probability(0.5))));
            Assert.AreEqual(new Probability(1.0), new Probability(0.5).Or(new Probability(1.0)));
            Assert.AreEqual(new Probability(1.0), new Probability(1.0).Or(new Probability(0.5)));
            Assert.AreEqual(new Probability(0.5), new Probability(0.0).Or(new Probability(0.5)));
        }
    }
}