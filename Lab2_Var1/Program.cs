using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_________task 1_________");
            Person first_person = new Person();
            Person second_person = new Person();
            Console.WriteLine("\nCall ReferenceEquals on two different Person objects:");
            Console.WriteLine(Object.ReferenceEquals(first_person, second_person));
            Console.WriteLine("Check is Person objects are data-equal:");
            Console.WriteLine(first_person.Equals(second_person));
            Console.WriteLine("Frist Person's hash code:");
            Console.WriteLine(first_person.GetHashCode());
            Console.WriteLine("Second Person's hash code:");
            Console.WriteLine(second_person.GetHashCode());
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 2_________");
            Student student = new Student();
            student.AddExams(new Exam("Algorithms", 4, new DateTime()));
            student.AddExams(new Exam("Combnatorics", 4, new DateTime()));
            Console.WriteLine("\nStudent data:\n");
            Console.WriteLine(student.ToString());
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 3_________");
            Console.WriteLine("Person field from Student object:");
            Console.WriteLine(student.Passport_Data.ToString());
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 4_________");
            Student lazy_student = (Student)((IDateAndCopy)student).DeepCopy();
            student.Name = "Ray";
            student.Last_Name = "Wilson";
            Console.WriteLine("Changed original Student object:\n");
            Console.WriteLine(student.ToString());
            Console.WriteLine("\nUnchanged copy of the original Student object:");
            Console.WriteLine(lazy_student.ToString());
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 5_________");
            try
            {
                student.Group_Number = 99;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 6_________");
            foreach (Object o in student.Session_Iterator())
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine("___________end___________");

            Console.WriteLine("_________task 6_________");
            foreach (Exam e in student.Exam_Iterator(3))
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("___________end___________");
            Console.ReadKey();
        }
    }
}
