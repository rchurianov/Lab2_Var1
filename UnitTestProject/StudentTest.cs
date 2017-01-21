using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Var1;
using System.Collections;

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

        [TestMethod]
        public void Test_Session_Iterator()
        {
            Student s = new Student();
            foreach (Object o in s.Session_Iterator())
            {
                Console.WriteLine(o.ToString());
            }
        }

        [TestMethod]
        public void Test_Exam_Iterator()
        {
            Student s = new Student();
            s.AddExams(new Exam("Mathematical Statistics", 2, new DateTime()));
            s.AddExams(new Exam("Probability Theory", 3, new DateTime()));
            s.AddExams(new Exam("Physics", 4, new DateTime()));
            Console.WriteLine("\nFull session list:\n");
            foreach (Object o in s.Session_Iterator())
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine("\nExams with grade higher than 3:\n");
            foreach (Exam e in s.Exam_Iterator(3))
            {
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void Test_StudentEnumerator()
        {
            IEnumerable student = new Student();
            ((Student)student).Credit_List.Add(new Credit("Compilators", true));
            ((Student)student).AddExams(new Exam("Compilators", 4, new DateTime()));

            ((Student)student).Credit_List.Add(new Credit("Compilators", true));
            ((Student)student).AddExams(new Exam("Compilators", 4, new DateTime()));

            ((Student)student).Credit_List.Add(new Credit("Compilators", true));
            ((Student)student).AddExams(new Exam("Compilators", 4, new DateTime()));

            foreach (Object obj in student)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
