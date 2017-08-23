using System;
using System.Web.UI.WebControls;
using NUnit.Framework;
using static OoBootCamp.Unit;
using static OoBootCamp.QuantityUnit;

namespace OoBootCamp.Tests
{
    [TestFixture]
    public class VolumeTest
    {
        [Test]
        public void Equality()
        {
            Assert.AreEqual(3.0.Teaspoon(), 3.0.Teaspoon());
            Assert.AreEqual(1.0.Tablespoon(), 3.0.Teaspoon());
            Assert.AreEqual(1.0.Ounce(), 6.0.Teaspoon());
            Assert.AreEqual(1.0.Ounce(), 2.0.Tablespoon());
            Assert.AreEqual(2.0.Tablespoon(), 1.0.Ounce());
            Assert.AreEqual((-2.0).Tablespoon(), (-1.0).Ounce());
            Assert.AreEqual(0.5.Ounce(), 1.0.Tablespoon());
            Assert.AreEqual(6.0.Tablespoon(), 6.0.Tablespoon());
            Assert.AreEqual(1.0.Ounce(), 2.0.Tablespoon());
            Assert.AreEqual(Tablespoon.S(6), 6.0.Tablespoon());
            Assert.AreEqual(Tablespoon.S(6), 6.Tablespoon());
             Assert.AreEqual(Celsius.S(10), 10.Celsius());

            Assert.AreEqual(0.5.Ounce().GetHashCode(), 1.0.Tablespoon().GetHashCode());

            Assert.AreEqual(1.0.Foot(), 12.0.Inch());
            Assert.AreEqual(1.0.Yard(), 3.0.Foot());
            Assert.AreEqual(1.0.Furlong(), 220.0.Yard());
            Assert.AreEqual(1.0.Mile(), 8.0.Furlong());
            Assert.AreEqual(1.Foot(), 1.Foot());

            Assert.AreEqual(0.Celsius(), 32.Fahrenheit());
            Assert.AreEqual(10.Celsius(), 50.Fahrenheit());
            Assert.AreEqual(100.Celsius(), 212.Fahrenheit());
            Assert.AreEqual((-40).Celsius(), (-40).Fahrenheit());
            Assert.AreEqual((100).Fahrenheit(), (100).Fahrenheit());
            Assert.AreNotEqual((100).Fahrenheit(), (100).Celsius());

            Assert.AreEqual(32.Fahrenheit(), 0.Celsius());
            Assert.AreEqual(50.Fahrenheit(), 10.Celsius());
            Assert.AreEqual(212.Fahrenheit(), 100.Celsius());
            Assert.AreEqual(208.4.Fahrenheit(), 98.Celsius());
        }

        [Test]
        public void Addition()
        {
            Assert.AreEqual(1.0.Tablespoon() + 3.0.Teaspoon(), 1.0.Ounce());
            Assert.AreEqual(Tablespoon.S(1) + Tablespoon.S(1), 1.0.Ounce());
        }

        [Test]
        public void Subtraction()
        {
            //Assert.AreEqual(200.0.Celsius() - 10.0.Celsius(), 190.0.Celsius());
            Assert.AreEqual(1.0.Tablespoon() - 6.0.Teaspoon(), (-0.5).Ounce());
        }

        [Test]
        public void IncompatibleUnits()
        {
            Assert.AreNotEqual(1.Foot(), 1.Tablespoon());
            Assert.AreNotEqual(1.Inch(), 1.Teaspoon());
        }
    }
}
