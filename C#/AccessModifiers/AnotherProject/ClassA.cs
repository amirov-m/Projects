using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherProject
{
    public class ClassA
    {
        public int field;
        protected int protectedField;


        public ClassA(int field)
        {
            this.field = field;
        }
    }

    public class ClassC
    {
        protected internal int protectedInternaField;

        public int GetProtectedInternalField()
        {
            return protectedInternaField;
        }
    }
}
