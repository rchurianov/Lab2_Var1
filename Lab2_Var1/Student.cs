using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Var1
{
    public class Student
    {
        private Person passport_data;
        private Education degree;
        private int group_number;
        private Exam[] exam_list;

        public Student(Person p, Education e, int i)
        {
            passport_data = p;
            degree = e;
            group_number = i;
        }

        public Student()
        {
            passport_data = new Person();

            degree = Education.Bachelor;

            Random rand = new Random();
            group_number = rand.Next(101, 121);
            Console.WriteLine("Created new Student with default constructor.");

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
            get { return passport_data; }
            set { passport_data = value;}
        }

        public Education Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        public int Group_Number
        {
            get { return group_number; }
            set { group_number = value; }
        }

        public Exam[] Exam_List
        {
            get { return exam_list; }
            set { exam_list = value; }
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
                    for (int i = 0; i < exam_list.Length; i++)
                    {
                        average = average + exam_list[i].Grade;
                    }
                    average /= exam_list.Length;
                }
                return average;
            }
        }

        public void AddExams(params Exam[] input_exam_list)
        {
            if (exam_list != null)
            {
                Exam[] new_exam_list = new Exam[exam_list.Length + input_exam_list.Length];
                for (int i = 0; i < exam_list.Length; ++i)
                {
                    new_exam_list[i] = exam_list[i];
                }
                for (int i = exam_list.Length; i < exam_list.Length + input_exam_list.Length; ++i)
                {
                    new_exam_list[i] = input_exam_list[i - exam_list.Length];
                }
                exam_list = new_exam_list;
            }
            else
                exam_list = input_exam_list;
            Console.WriteLine("Added {0} Exams to Student's exam_list.", input_exam_list.Length);
        }

        public override string ToString()
        {
            if (exam_list != null)
                return "Name, Last Name, Birth Date, Degree, Group No:\n" +
                       passport_data.ToString() + ", " + degree.ToString() + ", " +
                       group_number.ToString() + ",\n" +
                       "[Exam_Name, Grade, Date]\n" +
                       Exam_List_ToString();
            else
                return "Name, Last Name, Birth Date, Degree, Group No:\n" +
                       passport_data.ToString() + ", " +
                       degree.ToString() + ", " + group_number.ToString();
        }

        private string Exam_List_ToString()
        {
            string s = "";
            if (exam_list != null)
            {
                for (int i = 0; i < exam_list.Length; i++)
                {
                    s = s + exam_list[i].ToString() + "\n";
                }
            }
            return s;
        }

        /* Student.AGP property checks for exam_list == null
         * so we do not have to check for it in ToShortString().
         */
        public virtual string ToShortString()
        {
            return "Name, Last Name, Birth Date, Degree, Group No, AGP:\n" +
                   passport_data.ToString() + ", " +
                   degree.ToString() + ", " +
                   group_number.ToString() + ", " +
                   AGP.ToString();
        }
    }
}
