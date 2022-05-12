using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
        
    {
        private Student student;

        //How to properly manage methods where it is not guranteed that we will return the required type?
        public Student GetStudentDataByUser(User user)
        {
            if (user.FN == null)
            {
                Console.WriteLine("The pointed user doesn't have a FN");

            }

            
           foreach(User user1 in UserData._testUsers)
            {
                if (user1.FN == user.FN)
                {
                    student = user;
                }

                else
                {
                    Console.WriteLine("Student not found");
                }

            }

            return student;
            
        }
    }
}
