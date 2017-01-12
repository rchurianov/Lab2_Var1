using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    public class Student : Person, IDateAndCopy
    {
        private Education degree;
        private int group_number;
        private ArrayList credit_list;
        private ArrayList exam_list;

        public Student(Person p, Education e, int i) : base(p.Name, p.Last_Name, p.Birth_Date)
        {
            degree = e;
            group_number = i;

            credit_list = new ArrayList();
            credit_list.Add(new Credit("Analysis", true));
            credit_list.Add(new Credit("Differential equations", true));

            exam_list = new ArrayList();
            exam_list.Add(new Exam("History", 5, new DateTime(2000, 10, 10)));
            exam_list.Add(new Exam("Operation Systems", 5, new DateTime(2000, 20, 20)));
        }

        public Student() : base()
        {
            degree = Education.Bachelor;

            //Random rand = new Random();
            //group_number = rand.Next(101, 121);
            group_number = 111;

            credit_list = new ArrayList();
            credit_list.Add(new Credit());
            credit_list.Add(new Credit());

            exam_list = new ArrayList();
            exam_list.Add(new Exam());
            exam_list.Add(new Exam());
            //Console.WriteLine("Created new Student with default constructor.");
        }

        /*
         * This indexator return "true" if Student.degree == education_index,
         * and "false" otherwise.
         * Both Student.degree and education_index are of type Education.
         */
        public bool this[Education education_index] 
        {
            get
            {
                Console.WriteLine("Check if student has {0} education degree:", education_index);
                return this.degree == education_index;
            }
        }

        public Person Passport_Data
        { 
            get 
            {
                Person p = new Person(base.Name, base.Last_Name, base.Birth_Date);
                return p;
            }
            set 
            { 
                base.name = value.Name;
                base.last_name = value.Last_Name;
                base.birth_date = value.Birth_Date;
            }
        }

        public Education Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        public int Group_Number
        {
            get { return group_number; }
            set 
            { 
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Assigned value", value, "Value should be in the interval [100, 599].");
                }
                else { group_number = value; }
            }
        }

        public ArrayList Exam_List
        {
            get { return exam_list; }
            set { exam_list = value; }
        }

        public ArrayList Credit_List
        {
            get { return credit_list; }
            set { credit_list = value; }
        }

        /* In case exam_list == null
         * Student.AGP returns 0.0.
         * Otherwise, AGP return the average grade
         * of Exams in exam_list.
         */
        public double AGP
        {
            get
            {
                double average = 0.0;
                if (exam_list != null)
                {
                    for (int i = 0; i < exam_list.Count; i++)
                    {
                        average = average + ((Exam)exam_list[i]).Grade;
                    }
                    average /= exam_list.Count;
                }
                return average;
            }
        }

        public void AddExams(params Exam[] input_exam_list)
        {
            if (input_exam_list != null)
            {
                if (exam_list == null)
                {
                    exam_list = new ArrayList();
                    for (int i = 0; i < input_exam_list.Length; i++)
                    {
                        exam_list.Add(input_exam_list[i]);
                        Console.WriteLine("Added {0} Exams to Student's exam_list.", input_exam_list.Length);
                    }
                }
                else if (exam_list != null)
                {
                    for (int i = 0; i < input_exam_list.Length; i++)
                    {
                        exam_list.Add(input_exam_list[i]);
                        Console.WriteLine("Added {0} Exams to Student's exam_list.", input_exam_list.Length);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "Name, Last Name, Birth Date, Degree, Group No:\n" +
                    base.ToString() + ", " + degree.ToString() + ", " +
                    group_number.ToString() + ",\n" +
                    "[Credit_Name, Passed]\n" +
                    Credit_List_ToString() +
                    "[Exam_Name, Grade, Date]\n" +
                    Exam_List_ToString();
        }

        private string Exam_List_ToString()
        {
            string s = "";
            if (exam_list != null)
            {
                for (int i = 0; i < exam_list.Count; i++)
                {
                    s = s + exam_list[i].ToString() + "\n";
                }
            }
            return s;
        }

        private string Credit_List_ToString()
        {
            string s = "";
            if (credit_list != null)
            {
                for (int i = 0; i < credit_list.Count; i++)
                {
                    s = s + credit_list[i].ToString() + "\n";
                }
            }
            return s;
        }

        /* Student.AGP property checks for exam_list == null
         * so we do not have to check for it in ToShortString().
         */
        public override string ToShortString()
        {
            return "Name, Last Name, Birth Date, Degree, Group No, AGP:\n" +
                   base.ToString() + ", " +
                   degree.ToString() + ", " +
                   group_number.ToString() + ", " +
                   AGP.ToString();
        }

        object IDateAndCopy.DeepCopy()
        {
            Student student_copy = new Student();
            return student_copy();
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                return new DateTime();
            }
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            //if (System.Object.ReferenceEquals(this, obj))
            //    return true;

            Student s = obj as Student;
            if ((object)s == null)
                return false;
            Person p = obj as Person;
            if ((object)p == null)
                return false;

            return base.Name == s.Name &&
                   base.Last_Name == s.Last_Name &&
                   base.Birth_Date == s.Birth_Date &&
                   this.Degree.ToString() == s.Degree.ToString() &&
                   this.Group_Number.ToString() == s.Group_Number.ToString() &&
                   this.Exam_List.ToString() == s.Exam_List.ToString() &&
                   this.Credit_List.ToString() == s.Credit_List.ToString();
        }

        /*
         * public bool Equals(Student s)
        {
            if (s == null)
                return false;

            return base.Equals(s as Person) &&
                   this.degree == s.degree &&
                   this.group_number == s.group_number &&
                   this.exam_list == s.exam_list &&
                   this.credit_list == s.credit_list;
        }
        */

        public static bool operator ==(Student s1, Student s2)
        {
            if (System.Object.ReferenceEquals(s1, s2))
                return true;
            if ((object)s1 == null || (object)s2 == null)
                return false;

            return s1.name == s2.name &&
                s1.last_name == s2.last_name &&
                s1.birth_date == s2.birth_date &&
                s1.degree == s2.degree &&
                s1.group_number == s2.group_number &&
                s1.credit_list == s2.credit_list &&
                s1.exam_list == s2.exam_list;
        }

        public static bool operator !=(Student s1, Student s2)
        { return !(s1 == s2); }

        public override int GetHashCode()
        {
            if (this.credit_list == null ||
                this.exam_list == null)
            {
                throw new NullReferenceException("One of the Student object's fields is null.");
            }
            else
            {
                unchecked
                {
                    int hash = 29;
                    hash = hash * 31 + base.GetHashCode();
                    hash = hash * 31 + (int)this.degree;
                    hash = hash * 31 + this.group_number;
                    hash = hash * 31 + Credit_List_GetHashCode();
                    hash = hash * 31 + Exam_List_GetHashCode();
                    return hash;
                }
            }
            /*
            try
            {
                
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("One of the Person object fields is null.");
                Console.WriteLine(nre.Message);
                return -1;
            }
             * */
        }

        private int Credit_List_GetHashCode()
        {
            unchecked
            {
                int hash = 29;
                foreach (Credit cr in credit_list)
                {
                    hash = hash * 31 + cr.GetHashCode();
                }
                return hash;
            }
        }

        private int Exam_List_GetHashCode()
        {
            unchecked
            {
                int hash = 29;
                foreach (Exam ex in exam_list)
                {
                    hash = hash * 31 + ex.GetHashCode();
                }
                return hash;
            }
        }

    }
}
