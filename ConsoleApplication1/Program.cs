using FizBuz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var configs = new FizBuzConfig[] 
            {
                new FizBuzConfig(3, "fiz"),
                new FizBuzConfig(5, "buz"),
                new FizBuzConfig(10, "baz")
                
            };
            var fizBuz = new FizBuz.FizBuz(1, 100, configs);
            fizBuz.OnOutput += (sender, output, value) =>
                {
                    Console.WriteLine(output);
                };


            fizBuz.Run();
            Console.Read();
        }
    }
}
