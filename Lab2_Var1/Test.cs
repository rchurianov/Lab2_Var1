using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    public class Test
    {
        public Test(string name, bool passed)
        {
            this.Test_Name = name;
            this.Test_Passed = passed;
        }

        public Test()
        {
            this.Test_Name = "Linear Algebra";
            this.Test_Passed = true;
        }

        public string Test_Name
        { get; set; }

        public bool Test_Passed
        { get; set; }

        public override string ToString()
        {
            return Test_Name + " passed: " + Test_Passed.ToString();
        }
    }
}
