using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizBuz
{
    public delegate void FizBuzOutputHandler(object sender, string output, int value);

    public class FizBuz
    {
        public FizBuz(int start, int end)
        {
            if (start > end)
                throw new ArgumentException("The value for parameter \"start\" must be greater than the value for \"end\"");

            this.Start = start;
            this.End = end;
        }

        public FizBuz(int start, int end, params FizBuzConfig[] configurations)
            : this(start, end)
        {
            if (null == configurations)
                throw new ArgumentNullException("configurations");
            if (!configurations.Any())
                throw new ArgumentException("configurations must contain at least one configuration");
            this.Configurations = configurations;
        }

        private int Start { get; set; }
        private int End { get; set; }
        private FizBuzConfig[] Configurations;

        public event FizBuzOutputHandler OnOutput;

        public void Run()
        {
            if (null == this.Configurations)
                this.Configurations = FizBuzConfig.Default.ToArray();

            StringBuilder output = new StringBuilder();
            for (int i = this.Start; i <= this.End; i++)
            {
                output.Clear();
                var matches = this.Configurations.Where(c => c != null && i % c.Divisor == 0).OrderBy(c => c.Divisor).ToList();
                if (!matches.Any())
                    output.Append(i.ToString());
                else
                    matches.ForEach(m => output.Append(m.Message));
                Write(output.ToString(), i);
            }
        }

        private void Write(string output, int value)
        {
            if(this.OnOutput != null)
                this.OnOutput(this, output, value);
        }

    }
}
