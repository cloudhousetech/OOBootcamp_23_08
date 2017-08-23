/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */
 
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Rectangle works correctly
    [TestFixture]
    public class RectangleTest
    {
        Rectangle[] rectangles = {
            new Rectangle(10, 10),
            new Rectangle(11, 11),
            new Rectangle(1, 1)
        };

        [Test]
        public void Area()
        {
            Assert.AreEqual(24.0, new Rectangle(4.0, 6.0).Area());
        }

        [Test]
        public void Perimeter()
        {
            Assert.AreEqual(20.0, new Rectangle(4.0, 6.0).Perimeter());
        }

        [Test]
        public void InvalidRectangles()
        {
            Assert.That(() => new Rectangle(0, 1), Throws.ArgumentException);
            Assert.That(() => new Rectangle(1, 0), Throws.ArgumentException);
        }

        [Test]
        public void Square()
        {
            Assert.AreEqual(100, new Rectangle(10,10).Area());
            Assert.IsTrue(new Rectangle(10,10).IsSquare());
        }

        [Test]
        public void LargestArea()
        {
            //Assert.That(new Rectangle(10,10).Area() > new Rectangle(2,2).Area());
            //Assert.That( Rectangle.Largest(rectangles) , Is.EqualTo( new Rectangle(11,11).Area()));
        }
    }
}
