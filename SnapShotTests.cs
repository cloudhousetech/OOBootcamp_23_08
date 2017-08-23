using NUnit.Framework;

namespace OoBootCamp.Tests
{
    class SnapShotTests
    {
        private CompositeSnapShot _small_root;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _small_root = new CompositeSnapShot(
            new RegistrySnapShot(),
            new DirectorySnapShot(
                new DirectorySnapShot(
                    new FileSnapShot()),
                new DirectorySnapShot()));
        }

        [Test]
        public void Count()
        {
            Assert.AreEqual(6, _small_root.Count());
        }
    }
}
