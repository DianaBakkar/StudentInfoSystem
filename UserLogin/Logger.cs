using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static private List<string> fileContents = new List<string>();
        static  int i = 0;
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserName + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("test.txt") == true)
            {
                
                string s = File.ReadAllText("test.txt");
                File.AppendAllText("test.txt", s);
                i++;

            }

        }

        static public IEnumerable<string> Files()
        {

            foreach (string line in currentSessionActivities)
            {
                fileContents.Add(line);
            }

            return fileContents;
        }
        static public IEnumerable<string>  GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }
    }
}
