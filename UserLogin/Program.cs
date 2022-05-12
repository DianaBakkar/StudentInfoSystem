using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        public static void ErrorFn(string errorMsg)
        {
            Console.WriteLine(errorMsg + "!!!!");
        }

        public static void AdminMenu()
        {
            Console.WriteLine("Please press a key to choose an option:\n" +
                              " 0:Exit\n" +
                              " 1:Change User Role\n" +
                              " 2:Change User Valid State\n" +
                              " 3:List of Users\n" +
                              " 4:Show Activity Log File\n" +
                              " 5:Check current activity\n");
            string option = Console.ReadLine();
            int opt = Convert.ToInt32(option);
            switch (opt)
            {
                case 0:
                    Console.WriteLine("Exit");
                    break;
                case 1:
                    Console.WriteLine("Please enter the username of the user and his/her role");
                    string username = Console.ReadLine();
                    string role = Console.ReadLine();
                    UserData.AssignUserRole(username, Convert.ToInt32(role));
                    Console.WriteLine("Role is changed");
                    Logger.LogActivity("Role is changed");
                    break;
                case 2:
                    Console.WriteLine("Please enter the username of the user and his/her active to date");
                    string username1 = Console.ReadLine();
                    string active = Console.ReadLine();
                    UserData.SetUserActive(username1, Convert.ToDateTime(active));
                    Console.WriteLine("Valid Date is changed");
                    Logger.LogActivity("Valid Date is changed");
                    break;
                case 3:
                    Console.WriteLine("The list of users is:\n");
                    Console.WriteLine(UserData.TestUsers);
                    break;
                case 4:

                    Console.WriteLine("The activity log file is:");
                    IEnumerable<string> file = Logger.Files();
                    foreach (string line in file)
                    {
                        Console.WriteLine(line);
                    }
                    break;
                case 5:
                    Console.Write("Please enter the required filter");
                    string filter = Console.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                    foreach (string line in currentActs)
                    {
                        sb.Append(line);
                    }
                    Console.WriteLine("The current activity is:\n" + sb.ToString());
                    break;

            }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Please enter your username");
            string un = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string pw = Console.ReadLine();
            LoginValidation lv = new LoginValidation(un, pw, ErrorFn);
            User tu = new User();
            tu = null;
            lv.ValidateUserInput(ref tu);
            if (tu == null)
            {
                Console.Write("Null user");

            }

            else
            {
                if (tu.Role == 2)
                    AdminMenu();
            }
        }
    }
}
