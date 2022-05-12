using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class UserData
    {

        static private List<User> _testUsers;
        
       
        static public  List<User> TestUsers
        {
            get {
                UserData.ResetTestUserData();
                return _testUsers;
                    
            }

            set {
            }
        }

        static public User IsUserPassCorrect(string username,string password) 
        {
            /*foreach(User user in TestUsers)
      
            {
                 if (user.UserName == username && user.Password == password)
                        return user; 
            }*/

            try
            {
                User user = (from u in TestUsers where u.UserName == username && u.Password == password select u).First();

                if (user != null) return user;
            }
            catch(InvalidOperationException)
            {  }

            return null;

               

        }


        static private void ResetTestUserData()
        {
            _testUsers = new List<User>();
            
            User user0 = new User("username1", "password1", "2377618", 5,DateTime.Now,DateTime.MaxValue);
            _testUsers.Add(user0);
            User user1 = new User("username2", "password2", "2399618", 5, DateTime.Now, DateTime.MaxValue);
            _testUsers.Add(user1);
            User user2 = new User("username3", "password3", "23776999", 2, DateTime.Now, DateTime.MaxValue);
            _testUsers.Add(user2);

        }

        static public void  SetUserActive(String name,DateTime active)
        {
            foreach (User user in TestUsers)
            {

                if (user.UserName == name)
                {
                    user.Valid = active;
                    Logger.LogActivity("Change of expiry date for user:"+user.UserName);
                }
            }     
        }

        //I converted from role to int
        static public void AssignUserRole(string name,Int32 role)
        {
            foreach (User user in TestUsers)
            {

                if (user.UserName == name)
                {
                    user.Role = role;
                    Logger.LogActivity("Change of role for user:" + user.UserName);
                }

                }
        }
    }
}
