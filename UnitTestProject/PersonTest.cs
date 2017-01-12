using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Var1;

namespace UnitTestProject
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestEquals()
        {
            Person pe = new Person();
            Assert.AreEqual(false, pe.Equals(null));
            Person p_compare = new Person();
            Assert.AreEqual(pe, p_compare);
            Assert.AreEqual(true, pe.Equals(p_compare));
            Exam e = new Exam();
            Assert.AreEqual(false, pe.Equals(e));
            p_compare.Birth_Date = new DateTime();
            Assert.AreEqual(false, pe.Equals(p_compare));
            Assert.AreNotEqual(pe, p_compare);
        }

        //[TestMethod]
        //public void TestPersonEquals()
        //{
        //    Person p1 = new Person();
        //    Assert.AreEqual(false, p1.Equals((Person)null));
        //    Person p2 = new Person();
        //    Assert.AreEqual(true, p1.Equals(p2));
        //    p2.Name = "Douglas";
        //    Assert.AreNotEqual(p1, p2);
        //    Assert.AreEqual(false, p2.Equals(p1));
        //}

        [TestMethod]
        public void TestEqualityOperator()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Assert.AreEqual(true, p1 == p2);
            Assert.AreEqual(true, p1 == p1);
            p2.Last_Name = "Spaulding";
            Assert.AreEqual(false, p1 == p2);
            Assert.AreEqual(false, p2 == null);
        }

        [TestMethod]
        public void TestInequalityOperator()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            p2.Birth_Date = new DateTime(1916, 3, 16);
            Assert.AreEqual(true, p1 != p2);
            Assert.AreEqual(false, (p1 != p1));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod]
        public void TestDeepCopy()
        {
            IDateAndCopy p = new Person();
            Person p_copy = (Person)p.DeepCopy();
            Assert.AreEqual(p, p_copy);
            p_copy.Birth_Date = new DateTime();
            Assert.AreNotEqual(p, p_copy);
        }
    }
}
