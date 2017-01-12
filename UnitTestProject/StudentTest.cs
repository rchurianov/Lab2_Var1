using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Var1;

namespace UnitTestProject
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestEquals()
        {
            Student s1 = new Student();
            Student s2 = new Student();
            Assert.AreNotEqual(null, s1);
            Assert.AreEqual(false, s2.Equals(null));
            Assert.AreEqual(s1, s2);
            Assert.AreEqual(true, s2.Equals(s1));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Student s1 = new Student();
            Student s2 = new Student();
            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());
        }

        [TestMethod]
        public void Test_DeepCopy()
        {
            IDateAndCopy s = new Student();
            Student s_copy = (Student)s.DeepCopy();
            Assert.AreEqual(s, s_copy);
            s_copy.Credit_List.Add(new Credit());
            s_copy.AddExams(new Exam());
            Assert.AreNotEqual(true, s_copy.Equals(s));
            Assert.AreNotEqual(s, s_copy);
        }

    }
}
