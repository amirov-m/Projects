using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherProject;

namespace AccessModifiers
{
    class ClassB : ClassA
    {
        public ClassB(int d) : base(5)
        {
//            protectedField = 10;
        }

        internal int GetProtectedField()
        {
            return protectedField;
        }
    }

    class ClassD : ClassC
    {
        public ClassD()
        {
            protectedInternaField = 13;
        }

        public int GetField()
        {
            return protectedInternaField;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new ClassA(9);
            var b = new ClassB(10);

            Console.WriteLine(b.GetProtectedField());

            var c = new ClassC();
            var d = new ClassD();
            
            Console.WriteLine(d.GetProtectedInternalField());
        }
    }
}
