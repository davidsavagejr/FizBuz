using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizBuz.Tests
{
    [TestClass]
    public class FizBuzTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FizBuzCtorShouldThrowExceptionWhenStartIsGreaterThanEnd()
        {
            var target = new FizBuz(5, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FizBuzCtorShouldThrowExceptionWhenStartIsGreaterThanEndWhenConfigurationProvided()
        {
            var target = new FizBuz(5, 4, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FizBuzCtorShouldThrowExceptionWhenConfigurationsAreNull()
        {
            var target = new FizBuz(1, 10, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FizBuzCtorShouldThrowExceptionWhenConfigurationsAreEmpty()
        {
            var target = new FizBuz(1, 10, new FizBuzConfig[] { });
        }

        [TestMethod]
        public void FizBuzShouldRunWithoutEventHandlerWhenSet()
        {
            var target = new FizBuz(1, 100);
            target.Run();
        }

        [TestMethod]
        public void FizBuzShouldCallEventHandlerWhenSet()
        {
            bool called = false;
            var target = new FizBuz(1, 100);
            target.OnOutput += (sender, output, value) => called = true;
            target.Run();
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void FizBuzShouldOutputForEachItemFromStartToEnd()
        {
            int start = 1;
            int stop = 100;
            int calls = 0;
            var target = new FizBuz(start, stop);
            target.OnOutput += (sender, output, value) => calls++;
            target.Run();
            Assert.AreEqual((start - 1) + stop, calls);
        }

        [TestMethod]
        public void FizBuzShouldMatchConfiguredValues()
        {
            var configs = new FizBuzConfig[]
            {
                new FizBuzConfig(3, "fiz"),
                new FizBuzConfig(5, "buz"),
                new FizBuzConfig(10, "baz"),
                
            };
            var target = new FizBuz(1, 100, configs);
            target.OnOutput += (sender, output, value) =>
                {
                    configs.Where(c => output.Contains(c.Message)).ToList()
                        .ForEach(c => Assert.IsTrue(value % c.Divisor == 0, "FizBuz should not have output {1} as {0} is not divisible by {2} ({3})", value, output, c.Divisor, c.Message));
                };
            target.Run();
        }
    }
}
