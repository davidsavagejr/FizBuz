using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizBuz
{
    public sealed class FizBuzConfig
    {
        public FizBuzConfig(int divisor, string message)
        {
            if (divisor <= 0)
                throw new ArgumentOutOfRangeException("divisor", new Exception("divisor must be greater than zero"));
            divisorVal = divisor;
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");
            messageVal = message;
        }

        public static IEnumerable<FizBuzConfig> Default
        {
            get
            {
                return new List<FizBuzConfig>()
                {
                    new FizBuzConfig(3, "fiz"),
                    new FizBuzConfig(5, "buz")
                };
            }
        }

        private int divisorVal;
        public int Divisor { get { return divisorVal; } }

        private string messageVal;
        public string Message { get { return messageVal; } }
    }
}
