using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizBuz.Tests
{
    [TestClass]
    public class FizBuzConfigests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FizBuzConfigShouldThrowExceptForZeroDivisor()
        {
            var config = new FizBuzConfig(0, "baz");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FizBuzConfigShouldThrowExceptionForEmptyString()
        {
            var config = new FizBuzConfig(3, string.Empty);
        }

        [TestMethod]
        public void FizBuzConfigCtorShouldAssignValueToDivsor()
        {
            var config = new FizBuzConfig(3, "baz");
            Assert.AreEqual(3, config.Divisor);
        }

        [TestMethod]
        public void FizBuzConfigCtorShouldAssignValueToMessage()
        {
            var config = new FizBuzConfig(3, "baz");
            Assert.AreEqual("baz", config.Message);
        }

        [TestMethod]
        public void FizBuzConfigDefaultShouldReturnExpectedConfig()
        {
            var expected3 = new FizBuzConfig(3, "fiz");
            var expected5 = new FizBuzConfig(5, "buz");
            var actual = FizBuzConfig.Default;
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count());
            Assert.IsTrue(actual.Any(c => c.Message == expected3.Message && c.Message == expected3.Message), "Default config should contain divisor of 3 with message \"fiz\"");
            Assert.IsTrue(actual.Any(c => c.Message == expected5.Message && c.Message == expected5.Message), "Default config should contain divisor of 5 with message \"fiz\"");

        }
    }
}
