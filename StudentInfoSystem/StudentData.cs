using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        static public List<Student> _testStudents { get; set; }



        static private void SetStudent()
        {

            _testStudents = new List<Student>();
            Student student1 = new Student("Iliya", "Ivanov");
            _testStudents.Add(student1);

        }
        
        
       
    }
}
