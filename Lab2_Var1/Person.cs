using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var1
{
    public class Person : IDateAndCopy
    {
        protected string name;
        protected string last_name;
        protected System.DateTime birth_date;

        public Person()
        {
            this.name = "John";
            this.last_name = "Johnson";
            this.birth_date = new System.DateTime(1990, 2, 2);
            Console.WriteLine("Created new Person with default constructor.");
        }

        public Person(string input_name, string input_last_name, System.DateTime input_birth_date) {
            this.name = input_name;
            this.last_name = input_last_name;
            this.birth_date = input_birth_date;
            Console.WriteLine("Created new Person with given parameters.");
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Last_Name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public System.DateTime Birth_Date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        public int Int_Birth_Date
        {
            get
            {
                return birth_date.Year * 10000 + birth_date.Month * 100 + birth_date.Day;
            }
            set
            {
                int year = (int)(value / 10000);
                int month = (int)((value - year * 10000) / 100);
                int day = (int)(value - year * 10000 - month * 100);
                this.birth_date = new System.DateTime(year, month, day);
            }
        }

        public override string ToString()
        {
            return this.name + ", " + this.last_name + ", " + this.birth_date.ToString("d");
        }

        public virtual string ToShortString()
        {
            return this.name + ", " + this.last_name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // if parameter obj can not be cast to Person return null
            Person p = obj as Person;
            if((System.Object)p == null)
            {
                return false;
            }

            return this.name == p.name &&
                   this.last_name == p.last_name &&
                   this.birth_date == p.birth_date;
        }

        public bool Equals(Person p)
        {
            if (p == null)
            {
                return false;
            }

            return this.name == p.name &&
                   this.last_name == p.last_name &&
                   this.birth_date == p.birth_date;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (System.Object.ReferenceEquals(p1, p2))
            {
                return true;
            }

            if ((object)p1 == null || (object)p2 == null)
            { return false; }

            return p1.name == p2.name &&
                   p1.last_name == p2.last_name &&
                   p1.birth_date == p2.birth_date;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            try
            {
                unchecked
                {
                    int hash = 29;
                    hash = hash * 31 + this.name.GetHashCode();
                    hash = hash * 31 + this.last_name.GetHashCode();
                    hash = hash * 31 + this.birth_date.GetHashCode();
                    return hash;
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("One of the Person object fields is null.");
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
