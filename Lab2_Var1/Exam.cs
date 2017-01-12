using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    public class Exam : IDateAndCopy
    {
        public Exam(string input_Exam_Name, int input_Grade, DateTime input_Exam_Date)
        {
            this.Exam_Name = input_Exam_Name;
            this.Grade = input_Grade;
            this.Exam_Date = input_Exam_Date;
            Console.WriteLine("Created new Exam with given parameters.");
        }

        public Exam()
        {
            this.Exam_Name = "Computer Science";
            this.Grade = 5;
            this.Exam_Date = new DateTime(1998, 1, 20);
            //Console.WriteLine("Created new Exam with default constructor.");
        }

        public override string ToString()
        {
            return Exam_Name + ", " + Grade.ToString() + ", " + Exam_Date.ToString("d");
        }

        public string Exam_Name { get; set; }
        
        public int Grade { get; set; }

        public DateTime Exam_Date { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // if parameter obj can not be cast to Exam return null
            Exam e = (Exam)obj;
            if ((System.Object)e == null)
            {
                return false;
            }

            return this.Exam_Name == e.Exam_Name &&
                   this.Exam_Date == e.Exam_Date &&
                   this.Grade == e.Grade;
        }

        public bool Equals(Exam e)
        {
            if (e == null)
                return false;

            return this.Exam_Name == e.Exam_Name &&
                   this.Exam_Date == e.Exam_Date &&
                   this.Grade == e.Grade;
        }

        public static bool operator ==(Exam e1, Exam e2)
        {
            if (System.Object.ReferenceEquals(e1, e2))
                return true;

            if ((object)e1 == null || (object)e2 == null)
                return false;

            return e1.Exam_Name == e2.Exam_Name &&
                   e1.Exam_Date == e2.Exam_Date &&
                   e1.Grade.ToString() == e2.Grade.ToString();
        }

        public static bool operator !=(Exam e1, Exam e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            if (this.Exam_Name == null || this.Exam_Date == null)
            {
                throw new NullReferenceException("One of the Exam object fields is null.");
            }
            else
            {
                unchecked
                {
                    int hash = 29;
                    for (int i = 0; i < Exam_Name.Length; i++)
                    {
                        hash = hash * 31 + (int)Exam_Name[i];
                    }
                    hash = hash * 31 + Exam_Date.Year + Exam_Date.Month + Exam_Date.Day;
                    hash = hash * 31 + this.Grade;
                    return hash;
                }
            }
        }

        object IDateAndCopy.DeepCopy()
        {
            Exam exam_copy = new Exam();
            exam_copy.Exam_Name = this.Exam_Name;
            exam_copy.Grade = this.Grade;
            exam_copy.Exam_Date = this.Exam_Date;
            return exam_copy;
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                return new DateTime();
            }
            set;
        }
    }
}
