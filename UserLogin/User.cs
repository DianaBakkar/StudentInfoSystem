using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FN { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Valid { get; set; }

      
        public User()
        {

        }

         public User(string username,string password,string fn,int role,DateTime created,DateTime valid )
         {
             this.UserName = username;
             this.Password = password;
             this.FN = fn;
             this.Role = role;
             this.Created = created;
             this.Valid = valid;


         }
        

    }

  
  
}
