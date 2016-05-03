using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Counter
    {
        public Counter(int maxNumber)
        {
            this.MaxNumber = maxNumber;
        }

        public int MaxNumber { get; private set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter(10);
            for (int i = 0; i < counter.MaxNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
