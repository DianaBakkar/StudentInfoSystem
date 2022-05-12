using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{

    public class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);
       

        public static UserRoles currentUserRole
        {
            get;private set;
        }

        //Added to fix LogAvtivity Method in Logger
        public static string currentUserName
        {
            get; private set;
        }

        private string UserName;
        private string Password;
        private string ErrorMessage;
        private ActionOnError aoe;

        public LoginValidation(string userName,string password,ActionOnError actionOnError  )
        {
            this.UserName = userName;
            this.Password = password;
            this.aoe = actionOnError;
        }

        public Boolean ValidateUserInput(ref User user)

        {

            
            Boolean emptyUsername;
            emptyUsername = UserName.Equals(String.Empty);
            if (emptyUsername == true)
            {
                ErrorMessage = "No username is filled";
                currentUserRole = 0;
                aoe(ErrorMessage);
                Console.WriteLine(ErrorMessage);
                return false;
            }
            Boolean emptyPassword;
            emptyPassword = Password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                ErrorMessage = "No password is filled";
                currentUserRole = 0;
                aoe(ErrorMessage);
                Console.WriteLine(ErrorMessage);
                return false;
            }

            Boolean shortPassword;
            shortPassword = Password.Length < 5;
            if (shortPassword == true)
            {
                ErrorMessage = "The password is too short";
                currentUserRole = 0;
                aoe(ErrorMessage);
                Console.WriteLine(ErrorMessage);
                return false;
            }
            Boolean shortUsername;
            shortUsername = UserName.Length < 5;
            if (shortUsername == true)
            {
                ErrorMessage = "The username is too short";
                currentUserRole = 0;
                aoe(ErrorMessage);
                Console.WriteLine(ErrorMessage);
                return false;
            }
            
            User checker = UserData.IsUserPassCorrect(UserName, Password);
            if (checker == null)
            {
                ErrorMessage = "User not found";
                currentUserRole = 0;
                aoe(ErrorMessage);
                Console.WriteLine(ErrorMessage);
                return false;
            }
            else
            {
                Console.WriteLine("User found");
                currentUserRole = (UserRoles)checker.Role;
                user = checker;
                int caseSwitch = (int)currentUserRole;
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Role: Anonymous");
                        break;

                    case 2:
                        Console.WriteLine("Role:Admin");
                        break;

                    case 3:
                        Console.WriteLine("Role:Inspector");
                        break;

                    case 4:
                        Console.WriteLine("Role:Professor");
                        break;

                    case 5:
                        Console.WriteLine("Role:Student");
                        break;

                }
                Console.WriteLine("username:" + user.UserName + "  " + "password:" + user.Password);
                Logger.LogActivity("Succesful Login");

                return true;
            }
        }
    }
}
