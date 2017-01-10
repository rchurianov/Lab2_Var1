using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    public class Credit
    {
        public Credit(string name, bool passed)
        {
            this.Credit_Name = name;
            this.Credit_Passed = passed;
        }

        public Credit()
        {
            this.Credit_Name = "Linear Algebra";
            this.Credit_Passed = true;
        }

        public string Credit_Name
        { get; set; }

        public bool Credit_Passed
        { get; set; }

        public override string ToString()
        {
            return Credit_Name + " passed: " + Credit_Passed.ToString();
        }
    }
}
