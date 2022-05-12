using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string Rank { get; set; }
        public string Status { get; set; }
        public int FN { get; set; }
        public int Year { get; set; }
        public int Group { get; set; }
        public int Partition { get; set; }

        public Student(string firstName, string middleName,string LName,
            string faculty,string major,string rank,string status,
            int fn,int year,int group,int partition)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Lastname = LName;
            this.Faculty = faculty;
            this.Major = major;
            this.Rank = rank;
            this.Status = status;
            this.FN = fn;
            this.Year = year;
            this.Group = group;
            this.Partition = partition;
        }
        public Student(string fname,string lname)
        {
            this.FirstName = fname;
            this.Lastname = lname;

        }


    }
}
