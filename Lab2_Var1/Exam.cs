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
                   e1.Grade == e2.Grade;
        }

        public static bool operator !=(Exam e1, Exam e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            try
            {
                unchecked
                {
                    int hash = 29;
                    hash = hash * 31 + this.Exam_Name.GetHashCode();
                    hash = hash * 31 + this.Exam_Date.GetHashCode();
                    hash = hash * 31 + this.Grade.GetHashCode();
                    return hash;
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("One of the Exam object fields is null.");
                Console.WriteLine(nre.Message);
                return -1;
            }
        }

        object IDateAndCopy.DeepCopy()
        {
            throw new NotImplementedException();
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
